// 1. Function with Required Parameter
function getWelcomeMessage(name:string):string{
    return `Welcome ${name}`;
};
// 2. Optional Parameter
function getUserInfo(name:string,age?:number):string{
    if (age !==undefined){
        return `User:${name},Age:${age}`;
    }
    return `User:${name}`;
};
// 3. Default Parameter
function getSubscriptionStatus(name:string,isSubscribed:boolean=false):string{
    if(isSubscribed){
        return `${name} is Subscribed`;
    }
    return `${name} is not Subscribed`;
};
function isEligibleForPremium(age:number):boolean{
    return age>=18;
};
// arrow func
const getAccountUpdate=(name:string):string =>{
    return ` Account updated successfully for ${name}`;
};

const NotificationService={
    appname:"Myapp",
    sendNotification:(user:string):string =>{
        return `Hello ${user}, Welcome to ${NotificationService.appname}`;
    }
}

console.log(getWelcomeMessage("Dhoni"));

console.log(getUserInfo("Dhoni"));
console.log(getUserInfo("Dhoni", 44));

console.log(getSubscriptionStatus("Dhoni"));
console.log(getSubscriptionStatus("Dhoni", true));

console.log(isEligibleForPremium(20));

console.log(getAccountUpdate("Dhoni"));

console.log(NotificationService.sendNotification("Dhoni"));