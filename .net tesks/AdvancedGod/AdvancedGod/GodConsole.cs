using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AdvancedGod
{
    class GodConsole
    {
        private string assemblyPrefix = "AdvancedGod.";
        private Random rand = new Random();
        private NameHelper nameHelper = new NameHelper();
        private PrinterHelper printerHelper = new PrinterHelper();

        public void Start()
        {
            var currentDay = DateTime.Now.DayOfWeek;
            if (currentDay == DayOfWeek.Sunday)
            {
                Console.WriteLine("Приносим извенения, лавочка закрыта");
                return;
            }

            Console.WriteLine("Вас приветствует консоль бога. Нажмите enter,"
                               + "чтобы сгенерировать новую пару. Нажмите Q или F10 для выхода");
            bool flag = true;
            while (flag)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Q:
                    case ConsoleKey.F10:
                        flag = false;
                        break;
                    case ConsoleKey.Enter:
                        GeneratePairAndCheck();
                        break;
                    default:
                        Console.WriteLine("Некорректный символ!");
                        break;
                }
            }
        }

        private void GeneratePairAndCheck()
        {
            Human first =  GenerateRandomHuman();
            Human second =  GenerateRandomHuman();
            try
            {
                var couple = Couple(first, second);
                if (couple != null)
                {
                    printerHelper.PrintChild(couple);
                }          
            }
            catch (HomosexualityException ex)
            {
                printerHelper.PrintExeption("Эти люди не подходят друг другу по полу");
            }
        }

        private IHasName Couple(Human first, Human second)
        {
            if (first == null || second == null) return null;

            printerHelper.PrintHuman(first);
            printerHelper.PrintHuman(second);

            if (first.Sex == second.Sex)
            {
                throw new HomosexualityException();
            }

            var father = first.Sex == Sex.Man ? first : second;

            var firstType = first.GetType();
            var secondType = second.GetType();

            MemberInfo firstInfo = firstType;
            MemberInfo secondInfo = secondType;

            var firstAttributeForSecond = GetNeededAttibute(firstInfo, secondInfo);
            var secondAttrbuteForFirst = GetNeededAttibute(secondInfo, firstInfo);

            if (firstAttributeForSecond == null || secondAttrbuteForFirst == null)
            {
                return null;
            }

            var isFirstLikeSecond = IsLiked(firstAttributeForSecond.Probability);
            var isSecondLikeFirst = IsLiked(secondAttrbuteForFirst.Probability);

            printerHelper.PrintLikes(isFirstLikeSecond, isSecondLikeFirst);


            if (isFirstLikeSecond && isSecondLikeFirst)
            {
                Type childType = Type.GetType(assemblyPrefix + firstAttributeForSecond.ChildType, false, true);
                var name = GetChildName(father);
                return GetChild(childType, name);
            }

            Console.WriteLine(string.Empty);
            return null;
        }

        private Human GenerateRandomHuman()
        {
            var humanTypesCount = Enum.GetNames(typeof(HumanType)).Length;
            var humanIndex = rand.Next(0, humanTypesCount);

            switch(humanIndex)
            {
                case (int)HumanType.Student:
                    return new Student(nameHelper.GetHumanName(Sex.Man));
                case (int)HumanType.Botan:
                    return new Botan(nameHelper.GetHumanName(Sex.Man));
                case (int)HumanType.Girl:
                    return new Girl(nameHelper.GetHumanName(Sex.Woman));
                case (int)HumanType.PrettyGirl:
                    return new PrettyGirl(nameHelper.GetHumanName(Sex.Woman));
                case (int)HumanType.SmartGirl:
                    return new SmartGirl(nameHelper.GetHumanName(Sex.Woman));
                default:
                    throw new NotImplementedException();
            }
        }

        private Couple GetNeededAttibute(MemberInfo firstInfo, MemberInfo secondInfo)
        {
            object[] firstAttributes = firstInfo.GetCustomAttributes(false);
            foreach (object firstAtr in firstAttributes)
            {
                var coupleAtr = firstAtr as Couple;

                if (coupleAtr != null && coupleAtr.Pair == secondInfo.Name)
                {
                    return coupleAtr;
                }
            }
            return null;
        }

        private bool IsLiked(double probability)
        {
            var val = rand.NextDouble();
            return val <= probability;
        }

        private string GetChildName(Human parentType)
        {
            if (parentType == null)
            {
                return string.Empty;
            }

            var defaultName = "Unknown";
            var name = string.Empty;
            var type = parentType.GetType();
            var methods = type.GetMethods();
            var firstStringMethod = methods.FirstOrDefault(m => m.ReturnType == typeof(String));
            try
            {
                var methodRes = firstStringMethod.Invoke(parentType, new object[] {}) as string;
                if (methodRes != null)
                {
                    name = methodRes;
                }
            }
            catch
            {
                name = defaultName;
            }
            return name;
        }

        private IHasName GetChild(Type childType, string name)
        {            
            if (childType != null && name != null)
            {
                System.Reflection.ConstructorInfo ci = childType.GetConstructor(new Type[] { typeof(string) });
                IHasName child = ci.Invoke(new object[] { name }) as IHasName;
                return child;
            }
            return null;
        }
    }
}
