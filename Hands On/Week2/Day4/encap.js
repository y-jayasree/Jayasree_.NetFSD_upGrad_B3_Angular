class Student {
    constructor(name, rollNumber, marks) {
        this.name = name;
        this.rollNumber = rollNumber;
        this.marks = marks;
    }

    getDetails() {
        console.log("Name:", this.name);
        console.log("Roll Number:", this.rollNumber);
        console.log("Marks:", this.marks);
    }

    getGrade() {
        if (this.marks >= 90) {
            return "A";
        } else if (this.marks >= 75) {
            return "B";
        } else if (this.marks >= 50) {
            return "C";
        } else {
            return "Fail";
        }
    }
}

let s1 = new Student("Jayasree", 101, 92);
let s2 = new Student("Deepu", 102, 68);

s1.getDetails();
console.log("Grade:", s1.getGrade());

s2.getDetails();
console.log("Grade:", s2.getGrade());