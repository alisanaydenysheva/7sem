import sqlite3
import sys

from PyQt5.QtWidgets import QApplication, QMainWindow, QWidget, QTableWidgetItem
from forms_staff import Ui_MainWindow

STAFF_POSTS = ['студент', 'методист', 'директор']


class MyWidget(QMainWindow, Ui_MainWindow):
    def __init__(self):
        super().__init__()
        self.setupUi(self)
        self.cbPost.addItems(STAFF_POSTS)
        self.rbMale.setChecked(True)
        self.pbInsert.clicked.connect(self.insert_staff)
        self.pbOpen.clicked.connect(self.open_file)
        self.pbDelete.clicked.connect(self.delete_staff)
        self.pbFind.clicked.connect(self.find_for_val)
        self.conn = None

    def open_file(self):
        try:
            self.conn = sqlite3.connect('staff_db.db')
            cur = self.conn.cursor()
            data = cur.execute("select * from staff")
            col_name = [i[0] for i in data.description]
            data_rows = data.fetchall()
        except Exception as e:
            print(f"Проблемы с подключением к БД. {e}")
            return e
        self.twStaffs.setColumnCount(len(col_name))
        self.twStaffs.setHorizontalHeaderLabels(col_name)
        self.twStaffs.setRowCount(0)
        self.cbColNames.addItems(col_name)
        for i, row in enumerate(data_rows):
            self.twStaffs.setRowCount(self.twStaffs.rowCount() + 1)
            for j, elem in enumerate(row):
                self.twStaffs.setItem(i, j, QTableWidgetItem(str(elem)))
        self.twStaffs.resizeColumnsToContents()
        self.avg_age()

    def update_twStaffs(self, query="select * from staff"):
        try:
            cur = self.conn.cursor()
            data = cur.execute(query).fetchall()
        except Exception as e:
            print(f"Проблемы с подключением к БД. {e}")
            return e
        self.twStaffs.setRowCount(0)
        for i, row in enumerate(data):
            self.twStaffs.setRowCount(self.twStaffs.rowCount() + 1)
            for j, elem in enumerate(row):
                self.twStaffs.setItem(i, j, QTableWidgetItem(str(elem)))
        self.twStaffs.resizeColumnsToContents()
        self.avg_age()

    def insert_staff(self):
        row = [self.leFio.text(), 'муж' if self.rbMale.isChecked() else 'жен', self.sbAge.text(),
               self.lePhone.text(), self.leEmail.text(), self.cbPost.itemText(self.cbPost.currentIndex()),
               self.sbExp.text(), self.lePhone_2.text()]
        try:
            cur = self.conn.cursor()
            cur.execute(f"""insert into staff(fio, sex, age, phone, email, position, exp, studbilet)
            values('{row[0]}', '{row[1]}', {row[2]}, '{row[3]}', '{row[4]}', '{row[5]}', '{row[6]}', '{row[7]}')""")
            self.conn.commit()
            cur.close()
        except Exception as e:
            print(f"Исключение: {e}")
            return e
        self.update_twStaffs()

    def delete_staff(self):
        row = self.twStaffs.currentRow()
        num = self.twStaffs.item(row, 0).text()
        try:
            cur = self.conn.cursor()
            cur.execute(f"delete from staff where num = {num}")
            self.conn.commit()
            cur.close()
        except Exception as e:
            print(f"Исключение: {e}")
            return e
        self.update_twStaffs()

    def avg_age(self):
        try:
            cur = self.conn.cursor()
            avg = cur.execute("select avg(age) as avg from staff").fetchone()
        except Exception as e:
            print(f"Проблемы с подключением к БД. {e}")
            return e
        self.lblAvgAge.setText(f"Средний возраст {round(avg[0], 2)}")

    def find_for_val(self):
        val = self.leFind.text()
        col = self.cbColNames.itemText(self.cbColNames.currentIndex())
        self.update_twStaffs(f"select * from staff where {col} like '{val}%'")
        # try:
        #     cur = self.conn.cursor()
        #     avg = cur.execute(f"select * from staff where {col} like '{val}%'").fetchone()
        # except Exception as e:
        #     print(f"Проблемы с подключением к БД. {e}")
        #     return e
        # self.lblAvgAge.setText(f"Средний возрст {round(avg[0], 2)}")

    def closeEvent(self, event):
        if self.conn is not None:
            self.conn.close()
        event.accept()


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MyWidget()
    ex.show()
    sys.exit(app.exec_())
