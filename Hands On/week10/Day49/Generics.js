"use strict";
//Generic Function
function getFirstElement(items) {
    if (items.length == 0) {
        throw new Error("Array is empty");
    }
    return items[0];
}
// generic class
class DataManager {
    items = [];
    add(items) {
        this.items.push(items);
    }
    getAll() {
        return this.items;
    }
}
//Use Case Implementation
const userManager = new DataManager();
userManager.add({ id: 1, name: "Jaya" });
userManager.add({ id: 2, name: "Deepu" });
userManager.add({ id: 2, name: "Raji" });
const productManager = new DataManager();
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "mobile" });
productManager.add({ id: 103, title: "Tab" });
console.log("ALL USER : ");
console.log(userManager.getAll());
//all products
console.log("\nALL Products : ");
console.log(productManager.getAll());
// first element using generic func
const firstUser = getFirstElement(userManager.getAll());
const firstProduct = getFirstElement(productManager.getAll());
console.log("\nFirstUser :");
console.log(firstUser);
console.log("\nFirstProduct :");
console.log(firstProduct);
