$(function () {
  let cart = JSON.parse(localStorage.getItem("cart")) || [];

  if (cart.length === 0) {
    $("#msg")
      .removeClass("text-success")
      .addClass("text-danger")
      .text("Please add products to cart");

    $("#checkoutForm button").prop("disabled", true);
  }

  // Display total
  let total = 0;
  cart.forEach(p => { total += p.price * p.qty; });
  $("#total").text(total);

  // Add error spans to HTML if they don't exist
  if (!$("#nameError").length) $("#name").after('<small id="nameError" class="text-danger"></small>');
  if (!$("#emailError").length) $("#email").after('<small id="emailError" class="text-danger"></small>');
  if (!$("#addressError").length) $("#address").after('<small id="addressError" class="text-danger"></small>');

  $("#checkoutForm").submit(function (e) {
    e.preventDefault();

    let name = $("#name").val().trim();
    let email = $("#email").val().trim();
    let address = $("#address").val().trim();

    $("#nameError, #emailError, #addressError").text("");
    $("#msg").text("");

    let ok = true;

    // Name validation
    if (name.length < 3) {
      $("#nameError").text("Name must be at least 3 characters.");
      ok = false;
    }

    // Email validation
    if (!email.includes("@") || email.length < 5) {
      $("#emailError").text("Enter a valid email.");
      ok = false;
    }

    // Address validation
    if (address.length < 10) {
      $("#addressError").text("Address must be at least 10 characters.");
      ok = false;
    }

    if (!ok) return;

    localStorage.removeItem("cart");

    $("#msg")
      .removeClass("text-danger")
      .addClass("text-success")
      .html("<b>Order placed successfully</b>");

    // Reset form
    $("#checkoutForm")[0].reset();

    // Update navbar cart count if function exists
    if (typeof loadNavbar === "function") loadNavbar();

    // Disable button after order
    $("#checkoutForm button").prop("disabled", true);

    // Reset total
    $("#total").text("0");
  });
});
