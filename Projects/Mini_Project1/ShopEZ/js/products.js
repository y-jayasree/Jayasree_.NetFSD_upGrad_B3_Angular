$(function(){
  loadProducts("productList");
});

// Load products
function loadProducts(containerId){
  $.getJSON("data/products.json", function(data){
    showProducts(data, containerId);
  });
}

// Display products
function showProducts(arr, containerId){
  let html="";
  arr.forEach(p=>{
    html+=`
      <div class="col-md-3 mb-3">
        <div class="card">
          <img src="${p.image}">
          <div class="card-body">
            <h6>${p.name}</h6>
            <p>₹${p.price}</p>
            <a href="product-details.html?id=${p.id}" class="btn btn-sm btn-dark">View</a>
            <button class="btn btn-sm btn-outline-dark add-btn" data-id="${p.id}">Add</button>
            <div class="text-success mt-1 msg" style="display:none;"></div>
          </div>
        </div>
      </div>`;
  });
  $("#" + containerId).html(html);

  $(".add-btn").click(function(){
    let id = $(this).data("id");
    let product = arr.find(p=>p.id==id);
    addToCart(product, $(this));
  });
}

// Add to cart
function addToCart(product, btn){
  let cart = JSON.parse(localStorage.getItem("cart")) || [];
  let existing = cart.find(p=>p.id===product.id);
  if(existing) existing.qty+=1;
  else { product.qty=1; cart.push(product); }
  localStorage.setItem("cart", JSON.stringify(cart));
  if(typeof loadNavbar==="function") loadNavbar();
  btn.siblings(".msg").text(`${product.name} added`).fadeIn().delay(1500).fadeOut();
}
