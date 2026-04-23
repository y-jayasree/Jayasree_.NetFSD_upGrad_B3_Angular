"use strict";
class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    //getter
    getSalary() {
        return this.salary;
    }
    //setter 
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Salary must be greater than 0");
        }
    }
    displayDetails() {
        console.log(`ID: ${this.id}`);
        console.log(`ID: ${this.name}`);
        console.log(`ID: ${this.salary}`);
    }
}
class Manager extends Employee {
    teamsize;
    constructor(id, name, salary, teamsize) {
        super(id, name, salary);
        this.teamsize = teamsize;
    }
    displayDetails() {
        super.displayDetails();
        console.log(`Team size: ${this.teamsize}`);
    }
}
const emp1 = new Employee(1, "smith", 30000);
const mgr1 = new Manager(2, "king", 70000, 10);
console.log("EMP Details:");
emp1.displayDetails();
emp1.setSalary(35000);
console.log("updated salary:", emp1.getSalary());
console.log("\nManager Details:");
mgr1.displayDetails();
