import { formatName, calculateAverage } from "./utils.js";
import { getGrade, getTopper } from "./student.service.js";
// Sample data
let students = [
    { id: 1, name: "smith", marks: 85 },
    { id: 2, name: "john", marks: 92 },
    { id: 3, name: "Allen", marks: 35 }
];
// Format Names
console.log("Formatted Names:");
for (let i = 0; i < students.length; i++) {
    console.log(formatName(students[i].name));
}
// Grades
console.log("\nGrades:");
for (let i = 0; i < students.length; i++) {
    console.log(students[i].name + " -> " + getGrade(students[i].marks));
}
// Average
let avg = calculateAverage(students);
console.log("\nAverage Marks:", avg);
// Topper
let topper = getTopper(students);
console.log("\nTopper:", topper.name, "-", topper.marks);
