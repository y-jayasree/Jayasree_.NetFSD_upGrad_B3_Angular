const products = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 500, quantity: 2 },
    { name: "Keyboard", price: 1500, quantity: 1 }
];

export const calculateTotal = (items) => {
    return items.reduce((total, item) => {
        return total + item.price * item.quantity;
    }, 0);
};

export const generateInvoice = (items) => {

    const lines = items.map(item =>
        `${item.name} - ₹${item.price} x ${item.quantity} = ₹${item.price * item.quantity}`
    );

    const total = calculateTotal(items);

    return `
${lines.join("\n")}

Total Cart Value: ₹${total}
`;
};

export default products;
