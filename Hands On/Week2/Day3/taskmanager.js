let tasks = [];
const addTaskCallback = (task, callback) => {
    setTimeout(() => {
        tasks.push(task);
        callback("Task Added");
    }, 500);
};
const addTaskPromise = (task) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks.push(task);
            resolve("Task Added");
        }, 500);
    });
};
const run = async () => {
    try {
        await addTaskPromise("Learn JS");
        await addTaskPromise("Practice Async");

        console.log(`Tasks: ${tasks.join(", ")}`);

        tasks.splice(0, 1);

        console.log(`Updated: ${tasks.join(", ")}`);

    } catch (err) {
        console.log(err);
    }
};

run();
