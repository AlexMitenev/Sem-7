using System;
using System.Collections.Generic;
using System.Resources;

namespace God
{
    internal class God : IGod
    {
        private readonly CreateHelper _helper = new CreateHelper();
        public List<Human> Humans { get; set; }       

        public God()
        {
            Humans = new List<Human>();
        }
        public int this[int i]
        {
            get
            {
                if (i < 0 && i > Humans.Count - 1)
                {
                    return 0;
                }
                var coolParent = Humans[i] as CoolParent;
                return coolParent == null ? 0 : coolParent.MoneyCount;
            }
        }

        public int GetAllMoney()
        {
            int summ = 0;
            for (int i = 0; i < Humans.Count; i++)
            {
                summ += this[i];
            }
            return summ;
        }

        public Human CreateHuman()
        {
            Sex sex = _helper.GetRandomSex();
            return CreateHuman(sex);
        }

        public Human CreateHuman(Sex sex)
        {
            Human human;
            var name = _helper.GetRandomName(sex);
            HumanType humanType = _helper.GetRandomHumanType();
            switch (humanType)
            {
                case HumanType.Student:
                    human = CreateStudent(name, sex);
                    break;

                case HumanType.Botan:
                    human = CreateBotan(name, sex);
                    break;

                case HumanType.Parent:
                    human = CreateParent(name, sex);
                    break;

                case HumanType.CoolParent:
                    human = CreateCoolParent(name, sex);
                    break;

                default:
                    throw new NotSupportedException();
            }
            Humans.Add(human);
            return human;
        }

        public Human CreatePair(Human human)
        {
            if (human == null)
            {
                return null;
            }

            Human pair = null;

            var student = human as Student;
            if (student != null)
            {
                var name = _helper.GetNameByPatronymic(student.Patronymic);

                var botan = student as Botan;
                if (botan != null)
                {
                    var rating = botan.AverageRating;
                    pair = CreateCoolParent(name, Sex.Man, rating);
                }
                else
                {
                    pair = CreateParent(name, Sex.Man);
                }
            }

            var parent = human as Parent;
            if (parent != null)
            {
                Sex sex = _helper.GetRandomSex();
                var name = _helper.GetRandomName(sex);

                var coolParent = human as CoolParent;
                if (coolParent != null)
                {
                    var money = coolParent.MoneyCount;
                    pair = CreateBotan(name, sex, money);
                }
                else
                {
                    pair = CreateStudent(name, sex);
                }
            }
            Humans.Add(pair);
            return pair;
        }

        private Student CreateStudent(string name, Sex sex)
        {
            int age = _helper.GetStudentRandomAge();
            string patronymic = _helper.GetRandomPatronymic(sex);

            return new Student(patronymic, name, age, sex);
        }

        private Botan CreateBotan(string name, Sex sex, int? money = null)
        {
            int age = _helper.GetStudentRandomAge();
            string patronymic = _helper.GetRandomPatronymic(sex);
            double averageRating = money == null ? _helper.GetRandomAverageRating() : _helper.GetAvgRatingByMoney(money.Value);

            return new Botan(averageRating, patronymic, name, age, sex);
        }

        private Parent CreateParent(string name, Sex sex)
        {
            int age = _helper.GetParentRandomAge();
            int childrenCount = _helper.GetRandomChildrenCount();

            return new Parent(childrenCount, name, age, sex);
        }

        private CoolParent CreateCoolParent(string name, Sex sex, double? avgRating = null)
        {
            int age = _helper.GetParentRandomAge();
            int childrenCount = _helper.GetRandomChildrenCount();
            int money = avgRating == null ? _helper.GetRandomMoney() : _helper.GetMomeyByRating(avgRating.Value);

            return new CoolParent(money, childrenCount, name, age, sex);
        }
    }
}
