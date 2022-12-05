from csv_csv import file_open, insert, drop_by_arg, find, avg_age, save, show_csv
from builtins import print

FILENAME = "data.csv"

MENU = {
    '1': 'Открыть файл',
    '2': 'Добавить',
    '3': 'Удалить',
    '4': 'Найти по значению',
    '5': 'Вывести средний возраст',
    '6': 'Сохранить в файл',
    '7': 'Вывести записи',
    '0': '<-Меню',
    'exit': 'Выход'
}

for key, val in MENU.items():
    print(key, '-', val)

while True:
    action = input('>_ ')
    if action == '1':
        file_open()
    elif action == '2':
        print(insert(input('ФИО: '), int(input('Возраст: ')), input('Телефон: '), input('Статус: '),
                     input('Студенческий билет: ')))
    elif action == '3':
        col = input('Колонка: ')
        val = input('Значение: ')
        print(drop_by_arg(val, col_name=col))
    elif action == '4':
        col = input('Колонка: ')
        val = input('Значение: ')
        find(val, col_name=col)
    elif action == '5':
        avg_age()
    elif action == '6':
        save()
    elif action == '0':
        for key, val in MENU.items():
            print(key, '-', val)
    elif action == '7':
        show_csv()
    elif action == 'exit':
        break
