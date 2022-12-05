function allEmployees()
{
window.location = '/employees';
}

function oneEmployee(){
var search = prompt("Введите номер студента:");
window.location = '/employee/' + search;
}

function employeesOnLeave(){
var search = prompt("Введите true или false:");
window.location = '/employees_on_leave/' + search;
}

function newEmployee(){
window.location = '/add_employee';
}