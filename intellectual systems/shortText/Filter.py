import codecs
import re
import string


def is_uz_char(ch):
    return ch in 'abdefghijklmnopqrstuvxyzoʻgʻshchngʼyeyoyuyats '

def is_tg_char(ch):
   return ch in 'абвгғдеёжзиӣйкқлмнопрстуӯфхҳчҷшъэюя '

def is_ru_char(ch):
   return ch in 'абвгдеёжзийклмнопрстуфхцчшщъыьэюя '

def is_kk_char(ch):
   return ch in 'аәбвгғдеёжзийкқлмнңоөпрстуұүфхһцчшщъыіьэюя '

def is_uk_char(ch):
   return ch in 'абвгдежзийклмнопрстуфхцчшщьюяґєїі '

#read file
file = codecs.open('uk_train.txt', 'r', encoding='utf-8');
data = file.read()
file.close()

#remove tabs
data = data.replace('\t',' ')

#remove new lines
data = data.replace('\n',' ')

#replace punctuation to spaces. for fix 'word.anotherword' -> 'wordanotherword'
#data = data.translate(str.maketrans('!"#$%&()*+,-./:;<=>?@[]^_{|}~','                             '))
data = data.translate(str.maketrans(string.punctuation,'                                '))

#to lower case
data = data.lower()

#remove all chars except tgs chars
data = ''.join(filter(lambda x: is_uk_char(x), data))

#remove multi spaces
data = re.sub(' +',' ',data)

#print(data)

file = open('uk_train_full.txt', 'wt', encoding='utf-8')
file.write(data)
file.close()
