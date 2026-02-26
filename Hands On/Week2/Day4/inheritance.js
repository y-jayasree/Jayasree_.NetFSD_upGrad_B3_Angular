class Vehicle {
    constructor(brand, speed) {
        this.brand = brand;
        this.speed = speed;
    }
    displayInfo() {
        console.log("Brand:", this.brand);
        console.log("Speed:", this.speed, "km/h");
    }
}
class Car extends Vehicle {
    constructor(brand, speed, fuelType) {
        super(brand, speed);
        this.fuelType = fuelType;
    }

    showCarDetails() {
        console.log("Fuel Type:", this.fuelType);
    }
}
let car1 = new Car("BMW", 120, "Petrol");
car1.displayInfo();     
car1.showCarDetails();   
