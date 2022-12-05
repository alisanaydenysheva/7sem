import datetime as DT


def str_to_date(self_date, other_date):
    dt1 = self_date.split(".")
    dt2 = other_date.split(".")
    self_bdate = DT.date(int(dt1[2]), int(dt1[1]), int(dt1[0]))
    other_bdate = DT.date(int(dt2[2]), int(dt2[1]), int(dt2[0]))
    return self_bdate, other_bdate


class Student:
    def __init__(self, number, fio, bdate, stip, on_leave=False):
        if stip < 0:
            raise ValueError("Стипендия не может быть отрицательной")
        if type(number) != int:
            raise TypeError("Номер студента должен быть числовым")
        self.number = number
        self.fio = fio
        self.bdate = bdate
        self.salary = stip
        self.on_leave = on_leave

    # Изменяем стипендию
    def increase_salary(self, summa):
        self.salary += summa

    # Перехват функции print, когда она преобразует свое значение в строку
    def __str__(self):
        return f"Студент {self.number} {self.fio}, {self.bdate}," \
               f" стипендия: {self.salary}, болеет: {'да' if self.on_leave else 'нет'}"

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

    # Добавляем студента в отдел
    def append(self, emp):
        if type(emp) != Student:
            raise TypeError("Атрибут содержит тип {} вместо Employee".format(type(emp)))
        self.employees.append(emp)

    # Перехват функции print, когда она преобразует свое значение в строку
    # Возврат информации об отделе
    def __str__(self):
        return f"Группа 195: {self.title}, Куратор, он же Босс: Гришакова Татьяна Николаевна, Количество студентов: {len(self.employees)} "

    # Вывод студентов группы
    def print_employees(self):
        for emp in self.employees:
            print(emp)

    # Вывод участников группы на больничном\не больничном
    def print_employees_on_leave(self, status=True):
        for emp in self.employees:
            if emp.on_leave == status:
                print(emp.number, emp.fio)


emp_1 = Student(1, 'Калашников Михаил Романович', '02.04.2003', 1440)
emp_2 = Student(2, 'Комаров Данила Алексеевич', '12.04.2004', 530)
# Сравним по датам рождения
print(emp_1 < emp_2)
print(emp_1 > emp_2)
print(emp_1 == emp_2)
print(emp_1 <= emp_2)
print(emp_1 >= emp_2)

depart_1 = Department('195 группа', emp_1)
depart_1.append(emp_1)
depart_1.append(emp_2)
print(depart_1)
depart_1.print_employees()
emp_1.increase_salary(1333)
emp_1.on_leave = True
emp_2.on_leave = True
print(emp_1)
depart_1.print_employees_on_leave()
