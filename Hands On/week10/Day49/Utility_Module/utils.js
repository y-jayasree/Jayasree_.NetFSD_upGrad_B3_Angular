export function formatName(name) {
    return name.charAt(0).toUpperCase() + name.slice(1).toLowerCase();
}
export function calculateAverage(students) {
    let total = 0;
    for (let i = 0; i < students.length; i++) {
        total += students[i].marks;
    }
    return total / students.length;
}
