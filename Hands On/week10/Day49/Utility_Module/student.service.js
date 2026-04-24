import { PASS_MARKS } from "./constants.js";
export function getGrade(marks) {
    if (marks >= 90)
        return "A";
    else if (marks >= 75)
        return "B";
    else if (marks >= PASS_MARKS)
        return "c";
    else
        return "Fail";
}
export function getTopper(students) {
    let topper = students[0];
    for (let i = 1; i < students.length; i++) {
        if (students[i].marks > topper.marks) {
            topper = students[i];
        }
    }
    return topper;
}
