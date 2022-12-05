import csv
import sys

from PyQt5.QtWidgets import QApplication, QMainWindow, QWidget, QTableWidgetItem
from forms_staff import Ui_MainWindow

STAFF_POSTS = ['бухгалтер', 'менеджер', 'программист']


class MyWidget(QMainWindow, Ui_MainWindow):
    def __init__(self):
        super().__init__()
        self.setupUi(self)
        self.cbPost.addItems(STAFF_POSTS)
        self.rbMale.setChecked(True)
        self.pbInsert.clicked.connect(self.insert_staff)
        self.pbOpen.clicked.connect(self.open_file)
        self.data = None

    def open_file(self):
        with open('data.csv', "r", newline="", encoding='utf-8') as csv_file:
            reader = csv.reader(csv_file, delimiter=';', quotechar='"')
            title = next(reader)
            self.data = list(reader)
            self.twStaffs.setColumnCount(len(title))
            self.twStaffs.setHorizontalHeaderLabels(title)
            self.twStaffs.setRowCount(0)
            for i, row in enumerate(self.data):
                self.twStaffs.setRowCount(self.twStaffs.rowCount() + 1)
                for j, elem in enumerate(row):
                    self.twStaffs.setItem(i, j, QTableWidgetItem(elem))
            self.twStaffs.resizeColumnsToContents()

    def insert_staff(self):
        print(self.data)
        num = max(self.data, key=lambda x: int(x['ном']))
        print(num)
        row = [num, self.leFio.text(), 'муж' if self.rbMale.isChecked() else 'жен', self.sbAge.text(),
               self.lePhone.text(), self.leEmail.text(), self.cbPost.itemText(self.cbPost.currentIndex()),
               self.sbExp.text(), self.lePhone_2.text()]
        i = self.twStaffs.rowCount()
        self.twStaffs.insertRow(i)
        for j, elem in enumerate(row):
            self.twStaffs.setItem(i, j, QTableWidgetItem(elem))
        self.twStaffs.resizeColumnsToContents()


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MyWidget()
    ex.show()
    sys.exit(app.exec_())
