
class Payment {
    pay(amount) {
        console.log("Processing payment");
    }
}
class Creditcard extends Payment {
    pay(amount) {
        console.log("Paid " + amount + " using Credit Card");
    }
}
class UPIPayment extends Payment {
    pay(amount) {
        console.log("Paid " + amount + " using UPI");
    }
}
class CashPayment extends Payment {
    pay(amount) {
        console.log("Paid " + amount + " using Cash");
    }
}
let p1 = new Creditcard();
let p2 = new UPIPayment();
let p3 = new CashPayment();

p1.pay(500);
p2.pay(500);
p3.pay(500);
