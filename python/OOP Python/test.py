import datetime as DT


def str_to_date(self_date, other_date):
    dt1 = self_date.split(".")
    dt2 = other_date.split(".")
    self_bdate = DT.date(int(dt1[2]), int(dt1[1]), int(dt1[0]))
    other_bdate = DT.date(int(dt2[2]), int(dt2[1]), int(dt2[0]))
    return self_bdate, other_bdate


class Students:
    def __init__(self, number, fio, bdate, oklad, on_leave=False):
        self.number = number
        self.fio = fio
        self.bdate = bdate
        self.salary = oklad
        self.on_leave = on_leave

    # Изменяем стипендию
    def increase_salary(self, summa):
        self.salary += summa

    # Перехват функции print, когда она преобразует свое значение в строку
    def __str__(self):
        return f"Студент {self.number} {self.fio}, {self.bdate}," \
               f" стипендия: {self.salary}, на больничном: {'да' if self.on_leave else 'нет'}"

    # Здесь и ниже операции сравнения >, >=, <, <=, ==, !=
    def __lt__(self, other):  # <
        self_bdate, other_bdate = str_to_date(self.bdate, other.bdate)
        return self_bdate < other_bdate

    def __eq__(self, other):  # ==
        self_bdate, other_bdate = str_to_date(self.bdate, other.bdate)
        return self_bdate == other_bdate

    def __le__(self, other):  # <=
        if self.__eq__(other):
            return True

        if self.__lt__(other):
            return True
        else:
            return False


class Department:
    def __init__(self, title, chief=None, employees=None):
        self.title = title
        if employees is None:
            employees = list()
        self.employees = employees
        self.chief = chief

    # Добавляем студента в группу
    def append(self, emp):
        self.employees.append(emp)

    # Перехват функции print, когда она преобразует свое значение в строку
    # Возврат информации о группе
    def __str__(self):
        return f"Группа 205: {self.title}, Куратор: Иванов Артём Дмитриевич, Количество студентов: 10 "

    # Вывод участников группы
    def print_employees(self):
        for emp in self.employees:
            print(emp)

    # Вывод студентов группы на больничном\не больничном
    def print_employees_on_leave(self, status=True):
        for emp in self.employees:
            if emp.on_leave == status:
                print(emp.number, emp.fio)


emp_1 = Students(1, 'Литвинов Фёдор Юрьевич', '10.02.2003', 530)
emp_2 = Students(2, 'Котова Эмма Павловна', '16.02.2005', 530)
emp_3 = Students(3, 'Кудрявцева Елизавета Ивановна', '02.04.2002', 0)
emp_4 = Students(4, 'Павлова Злата Никитична', '01.01.2001', 230)
emp_5 = Students(5, 'Карпова Анна Тихоновна', '21.11.2002', 267)
emp_6 = Students(6, 'Карпова Анна Тихоновна', '11.08.2000', 530)
emp_7 = Students(7, 'Смирнова Екатерина Ярославовна', '12.02.2001', 530)
emp_8 = Students(8, 'Ершов Владислав Владимирович', '22.05.2002', 530)
emp_9 = Students(9, 'Иванов Артём Дмитриевич', '19.03.2004', 230)
emp_10 = Students(10, 'Ермолаев Артём Владиславович', '16.08.2004', 530)

# Сравним по датам рождения
print(emp_1 < emp_2)
print(emp_1 > emp_2)
print(emp_1 == emp_2)
print(emp_1 <= emp_2)
print(emp_1 >= emp_2)

depart_1 = Department('Группа', emp_1)
depart_1.append(emp_1)
depart_1.append(emp_2)
print(depart_1)
depart_1.print_employees()
emp_1.increase_salary(267)

print(emp_3)
print(emp_4)
print(emp_5)
print(emp_6)
print(emp_7)
print(emp_8)
print(emp_9)
print(emp_10)


depart_1.print_employees_on_leave()
