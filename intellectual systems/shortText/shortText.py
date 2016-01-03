import codecs
import time

langModels = []

# model params
penalty_for_absence_feature_in_lang_model = 1
koefs_for_feature_len = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
min_feature_size = 1
max_feature_size = 12
maxWordsInFile = 50000
infinity = 10000000000

# learning params
tg = 'tg', r'training/tg_train_full.txt'
uz = 'uz', r'training/uz_train_full.txt'
ru = 'ru', r'training/ru_train_full.txt'
kk = 'kk', r'training/kk_train_full.txt'
uk = 'uk', r'training/uk_train_full.txt'
languages = [tg, uz, ru, kk, uk]

# checking params
tg_check = 'tg', r'test/test_tg.txt'
uz_check = 'uz', r'test/test_uz.txt'
ru_check = 'ru', r'test/test_ru.txt'
kk_check = 'kk', r'test/test_kk.txt'
uk_check = 'uk', r'test/test_uk.txt'

check_list = [tg_check, uz_check, ru_check, kk_check, uk_check]


def create_model(lang_name, words):
    print('learning {0}'.format(lang_name))
    dict_model = {}
    words_len = len(words)

    # limit for count words
    toplimit = maxWordsInFile
    if words_len < maxWordsInFile:
        toplimit = words_len

    for i in range(1, toplimit):
        word = words[i]
        word_len = len(word)
        for featureSize in range(min_feature_size, word_len + 1):
            for featureNum in range(0, word_len - featureSize + 1):
                feature = word[featureNum:featureNum + featureSize]
                if feature in dict_model:
                    dict_model[feature] += 1
                else:
                    dict_model[feature] = 1
    dict_len = len(dict_model)

    # normalize
    for key in dict_model.keys():
        dict_model[key] /= dict_len

    return lang_name, dict_model


def learning(langs):
    for lang_name, file_path in langs:
        with codecs.open(file_path, 'r', encoding='utf-8') as myfile:
            text = myfile.read()
        words = text.split()
        model = create_model(lang_name, words)
        langModels.append(model)


def get_best_lang(text_model):
    min_dist, best_lang = infinity, ''
    for lang_name, lang_model in langModels:
        dist = get_distanse(lang_model, text_model)
        print('dist to {0} = {1}'.format(str(lang_name), str(dist)))
        if min_dist > dist:
            min_dist, best_lang = dist, lang_name
    return best_lang


def get_distanse(sorted_lang_model, sorted_text_model):
    result = 0
    for text_model_key in sorted_text_model.keys():
        key_len = len(text_model_key)
        if key_len > max_feature_size:
            continue
        if text_model_key in sorted_lang_model:
            result += abs(sorted_text_model[text_model_key] - sorted_lang_model[text_model_key]) \
                      * koefs_for_feature_len[key_len-1]
        else:
            result += penalty_for_absence_feature_in_lang_model
    return result


def check_algo():
    correct = 0
    total = 0
    for lang_name, file_path in check_list:
        print(file_path)
        print(lang_name)
        with codecs.open(file_path, 'r', encoding='utf-8') as myfile:
            phrases = myfile.readlines()

        for phrase in phrases:
            total += 1
            lang, phrase_text_model = create_model('text model', phrase.split())

            if lang_name == get_best_lang(phrase_text_model):
                correct += 1
        print("check {0} is ready".format(lang_name))

    return (correct / total) * 100


print("================= learning start ==================")
start_time = time.time()
learning(languages)
print("================= learning: {0} seconds ============".format(time.time() - start_time))


print("================= detect lang for one phrase ============")
start_time = time.time()
text = 'ella leica va shunga oxshash koʻp yirik firmalarning markazi manbalar'
nane_text_model, text_model = create_model('uz text', text.split())
print(get_best_lang(text_model))
print("================= detect for one phrase: {0} seconds ============".format(time.time() - start_time))


print("================= detect lang for one phrase ============")
start_time = time.time()
text = 'Это текст на русском, этот текст классный, он мне очень нравится'
nane_text_model, text_model = create_model('ru text', text.split())
print(get_best_lang(text_model))
print("================= detect for one phrase: {0} seconds ============".format(time.time() - start_time))


print("================= detect lang for checking set ============")
start_time = time.time()
correct_res = check_algo()
print("correct percent {0}".format(correct_res))
print("================= detect for one phrase: {0} seconds ============".format(time.time() - start_time))







