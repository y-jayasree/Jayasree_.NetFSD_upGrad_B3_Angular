const marks = [75, 80, 65, 90, 50];
const calculateTotal = (arr) => {
    return arr.reduce((sum, mark) => sum + mark, 0);
};
const calculateAverage = (arr) => {
    const total = calculateTotal(arr);
    return total / arr.length;
};
const formattedMarks = (arr) => {
    return arr.map(mark => `${mark}`);
};
const displayResult = () => {

    const total = calculateTotal(marks);
    const average = calculateAverage(marks);
    const result = average >= 50 ? "Pass" : "Fail";

    const outputDiv = document.getElementById("output");

    outputDiv.innerHTML = `
        <p><strong>Marks:</strong> ${formattedMarks(marks).join(", ")}</p>
        <p><strong>Total:</strong> ${total}</p>
        <p><strong>Average:</strong> ${average.toFixed(2)}</p>
        <p><strong>Result:</strong> ${result}</p>
    `;
};
displayResult();
