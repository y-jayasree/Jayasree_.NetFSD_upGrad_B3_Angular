//1.Variable Declaration: 
const userName:string="Jaya";
let Age:number=22;
const Email:string="Jaya@gmail.com";
const isSubscribed:boolean=true;

// inference
let country="India";
let logincount=5;

let usermessage:string=`Hello ${userName},you are ${Age} years old and your email is ${Email}`;
//inc age by 1
Age+=1;
let isPremiumEligible:boolean=Age>18 && isSubscribed;

console.log("User Profile:");
console.log(usermessage);

console.log("Updated Age:", Age);
console.log("Country:", country);
console.log("Login Count:", logincount);


console.log("Is Subscribed:", isSubscribed);
console.log("Eligible for Premium:", isPremiumEligible);