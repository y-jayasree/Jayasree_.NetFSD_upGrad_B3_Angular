class Employee{
    public id:number;
    protected name:string;
    private salary:number;

    constructor(id:number,name:string,salary:number){
        this.id=id;
        this.name=name;
        this.salary=salary;
    }
    //getter
    public getSalary():number{
        return this.salary;
    }
    //setter 
    public setSalary(value:number):void{
        if(value>0){
            this.salary=value;
        }
        else{
            console.log("Salary must be greater than 0");
        }
    }

    public displayDetails():void{
        console.log(`ID: ${this.id}`);
        console.log(`ID: ${this.name}`);
        console.log(`ID: ${this.salary}`);
    }
}

class Manager extends Employee{
    public teamsize:number;
    constructor(id:number,name:string,salary:number,teamsize:number){
        super(id,name,salary);
        this.teamsize=teamsize;
    }
    public displayDetails(): void {
        super.displayDetails();
        console.log(`Team size: ${this.teamsize}`);
    }
}

const emp1=new Employee(1,"smith",30000);
const mgr1=new Manager(2,"king",70000,10);

console.log("EMP Details:");
emp1.displayDetails();

emp1.setSalary(35000);
console.log("updated salary:",emp1.getSalary());

console.log("\nManager Details:");
mgr1.displayDetails();