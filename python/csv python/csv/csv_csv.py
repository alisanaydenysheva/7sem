import csv

csv_file = []


# Открываю csv файл
def file_open():
    global csv_file
    with open('data.csv', "r", newline="", encoding="utf-8") as file:
        reader = csv.DictReader(file, delimiter=';')
        for row in reader:
            csv_file.append(row)
    print('Файл открыт. Записей:', len(csv_file))


# Добавление данных
def insert(fio, age, tel, otd, sb):
    global csv_file
    try:
        mx = max(csv_file, key=lambda x: int(x['ном']))
        csv_file.append({'ном': int(mx['ном']) + 1, 'фио': fio, 'возраст': age, 'телефон': tel, 'статус': otd, 'с': sb})
    except Exception as e:
        return f'Ошибка при добавленнии новой записи {e}'
    return "Данные добавлены."


# Удалить по аргументу
def drop_by_arg(val, col_name='фио'):
    global csv_file
    try:
        csv_file = list(filter(lambda x: x[col_name] != val, csv_file))
    except Exception as e:
        return f'Строка со значением {val} поля {col_name} не найдена'
    return (f'Строка со значением "{val}" столбца "{col_name}" удалена.')


# Поиск
def find(val, col_name='фио'):
    print(*list(filter(lambda x: x[col_name] == val, csv_file)))


# Средний возраст
def avg_age():
    print("Средний возраст:",
          sum([int(row['возраст']) for row in csv_file]) // len(csv_file))


# Сохранение
def save():
    with open('data.csv', "w", encoding="utf-8", newline="") as file:
        columns = ['ном', 'фио', 'возраст', 'телефон', 'статус', 'студенческий билет']
        writer = csv.DictWriter(file, delimiter=";", fieldnames=columns)
        writer.writeheader()
        writer.writerows(csv_file)
        print("Данные добавлены!")


# Открыт ли файл или нет
def show_csv():
    if len(csv_file) == 0:
        print(type(csv_file))
    else:
        print('{:<5}{:<25}{:<8}{:<12}{:<15}{:<30}'.format(
            'ном', 'фио', 'возраст', 'телефон', 'статус', 'студенческий билет'
        ))
        for el in csv_file:
            print('{:<5}{:<25}{:<8}{:<12}{:<15}{:<30}'.format
                                                       (el["ном"],
                                                        el["фио"],
                                                        el["возраст"],
                                                        el["телефон"],
                                                        el["статус"],
                                                        el["студенческий билет"]))
