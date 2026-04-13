function getCart() {
  return JSON.parse(localStorage.getItem("cart")) || [];
}

function addToCart(p) {
  let cart = getCart();
  let item = cart.find(x => x.id === p.id);

  if (item) item.qty++;
  else {
    p.qty = 1;
    cart.push(p);
  }

  localStorage.setItem("cart", JSON.stringify(cart));

  // show message
  if ($("#msg").length) {
    $("#msg").text("Product added to cart").addClass("text-success");
  }

  // update navbar cart count
  loadNavbar();

  // navigate after 0.8 second
  setTimeout(() => {
    window.location.href = "cart.html";
  }, 800);
}

function loadCart() {
  let cart = getCart();
  let html = "";
  let total = 0;

  if (cart.length === 0) {
    $("#cartBody").html('<tr><td colspan="4" class="text-danger text-center">Cart is empty</td></tr>');
    $("#total").text("₹0");
    return;
  }

  cart.forEach((p, i) => {
    total += p.price * p.qty;

    html += `
      <tr>
        <td>${p.name}</td>
        <td>
          <button class="btn btn-sm btn-secondary" onclick="decreaseQty(${i})">-</button>
          <span class="mx-2">${p.qty}</span>
          <button class="btn btn-sm btn-secondary" onclick="increaseQty(${i})">+</button>
        </td>
        <td>₹${p.price}</td>
        <td>
          <button onclick="removeItem(${i})" class="btn btn-danger btn-sm">X</button>
        </td>
      </tr>
    `;
  });

  $("#cartBody").html(html);
  $("#total").text("₹" + total);
}

function increaseQty(i) {
  let cart = getCart();
  cart[i].qty++;
  localStorage.setItem("cart", JSON.stringify(cart));
  loadCart();
  loadNavbar();
}

function decreaseQty(i) {
  let cart = getCart();
  if (cart[i].qty > 1) {
    cart[i].qty--;
  } else {
    cart.splice(i, 1);
  }
  localStorage.setItem("cart", JSON.stringify(cart));
  loadCart();
  loadNavbar();
}

function removeItem(i) {
  let cart = getCart();
  cart.splice(i, 1);
  localStorage.setItem("cart", JSON.stringify(cart));
  loadCart();
  loadNavbar();
}

$(function () {
  if ($("#cartBody").length) loadCart();
});
