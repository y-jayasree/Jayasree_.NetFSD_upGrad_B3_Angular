import { Student } from "./student.model.js";
export function formatName(name:string):string{
    return name.charAt(0).toUpperCase()+name.slice(1).toLowerCase();
}
export function calculateAverage(students:Student[]):number{
    let total=0;
    for(let i=0;i<students.length;i++){
        total+=students[i].marks;
    }
    return total/students.length;
}