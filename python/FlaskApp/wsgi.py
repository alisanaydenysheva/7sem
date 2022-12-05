import json
from flask import Flask, request, url_for, render_template

app = Flask(__name__)

@app.route('/')
@app.route('/index')
def start():
    return render_template('index.html', css_path=url_for('static', filename='css/index_style.css'))


# Вывод таблицы с  сотрудниками
@app.route('/employees')
def employees():
    with open(url_for('static', filename='data/organization.json')[1:], 'rt', encoding='utf-8') as f:
        org_list = json.loads(f.read())
    return render_template('employees.html', org=org_list, css_path=url_for('static', filename='css/emp_style.css'))


# Вывод сотрудника по id
@app.route('/employee/<int:id>')
def employee(id=None):
    with open(url_for('static', filename='data/organization.json')[1:], 'rt', encoding='utf-8') as f:
        org_list = json.loads(f.read())
    return render_template('employee.html', org=org_list,
                           css_path=url_for('static', filename='css/emp_style.css'),
                           id=id)


# Вывод кто в отпуске/ не в отпуске
@app.route('/employees_on_leave/<on_leave>')
def employees_on_leave(on_leave=True):
    with open(url_for('static', filename='data/organization.json')[1:], 'rt', encoding='utf-8') as f:
        org_list = json.loads(f.read())
    return render_template('employees_on_leave.html', org=org_list,
                           css_path=url_for('static', filename='css/emp_style.css'),
                           on_leave=on_leave.capitalize())


# Добавление сотрудника
@app.route('/add_employee', methods=['POST', 'GET'])
def add_emploee():
    if request.method == 'GET':
        return render_template('add_employee.html', css_path=url_for('static', filename='css/form_style.css'))
    elif request.method == 'POST':
        with open(url_for('static', filename='data/organization.json')[1:], 'rt', encoding='utf-8') as f:
            org_list = json.loads(f.read())
            org_list['Employees'].append({'id': int(request.form['id']), 'FIO': request.form['fio'],
                                          'bdate': request.form['bdate'], 'salary': int(request.form['salary']),
                                          'on_leave': request.form['onleave']})
        with open(url_for('static', filename='data/organization.json')[1:], 'wt', encoding='utf-8') as f_out:
            json.dump(org_list, f_out)
        return "Новый студент добавлен!"

if __name__ == '__main__':
    app.run(port=8000, host='127.0.0.1')