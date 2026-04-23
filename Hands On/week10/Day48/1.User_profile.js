"use strict";
//1.Variable Declaration: 
const userName = "Jaya";
let Age = 22;
const Email = "Jaya@gmail.com";
const isSubscribed = true;
// inference
let country = "India";
let logincount = 5;
let usermessage = `Hello ${userName},you are ${Age} years old and your email is ${Email}`;
//inc age by 1
Age += 1;
let isPremiumEligible = Age > 18 && isSubscribed;
console.log("User Profile:");
console.log(usermessage);
console.log("Updated Age:", Age);
console.log("Country:", country);
console.log("Login Count:", logincount);
console.log("Is Subscribed:", isSubscribed);
console.log("Eligible for Premium:", isPremiumEligible);
