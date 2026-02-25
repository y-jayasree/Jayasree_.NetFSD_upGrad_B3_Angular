import products from "./p3ind.js";
import { generateInvoice } from "./p3ind.js";

const invoice = generateInvoice(products);

console.log(invoice);
