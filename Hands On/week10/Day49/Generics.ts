//Generic Function
function getFirstElement<T>(items:T[]):T{
    if(items.length==0){
        throw new Error("Array is empty");
    }
    return items[0];
}
// Generic interface
interface Repository<T>{
    add(items:T):void;
    getAll():T[];
}
// generic class
class DataManager<T> implements Repository<T>{
    private items:T[]=[];
    add(items:T):void{
        this.items.push(items);
    }
    getAll(): T[] {
        return this.items;
    }
}
//models
interface User{
    id:number;
    name:string;
}
interface Product{
    id:number;
    title:string;
}
//Use Case Implementation
const userManager=new DataManager<User>();
userManager.add({id:1,name:"Jaya"});
userManager.add({id:2,name:"Deepu"});
userManager.add({id:2,name:"Raji"});

const productManager=new DataManager<Product>();
productManager.add({id:101,title:"Laptop"});
productManager.add({id:102,title:"mobile"});
productManager.add({id:103,title:"Tab"});

console.log("ALL USER : ");
console.log(userManager.getAll());

//all products
console.log("\nALL Products : ");
console.log(productManager.getAll());

// first element using generic func
const firstUser=getFirstElement(userManager.getAll());
const firstProduct=getFirstElement(productManager.getAll());

console.log("\nFirstUser :");
console.log(firstUser);
console.log("\nFirstProduct :");
console.log(firstProduct);
