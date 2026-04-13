$(function () {
  loadProducts("homeProducts");

  $("#search").on("input", function () {
    applyFilter($("#search").val(), window.currentCategory);
  });

  // Top Deals Carousel
  const topDeals = [
    {id:1, name:"Laptop", price:50000, image:"images/laptop.jpg"},
    {id:2, name:"Smartphone", price:25000, image:"images/phone.jpg"},
    {id:3, name:"Headphones", price:2000, image:"images/headphone.jpg"}
  ];
  topDeals.forEach((p,i)=>{
    let active = i===0?'active':'';
    $("#carouselInner").append(`
      <div class="carousel-item ${active}">
        <img src="${p.image}" class="d-block w-100">
        <div class="carousel-caption d-none d-md-block">
          <h5>${p.name}</h5>
          <p>₹${p.price}</p>
        </div>
      </div>
    `);
  });

  // Registration Form
  $("#registerForm").submit(function(e){
    e.preventDefault();
    $("#regMsg").text("Registration successful!");
    this.reset();
  });
});

window.currentCategory = "";

// Filter by category
function filterCategory(category){
  window.currentCategory = category;
  applyFilter($("#search").val(), category);
}

// Load products
function loadProducts(containerId){
  $.getJSON("data/products.json", function(data){
    showProducts(data, containerId);
  });
}

// Apply search filter
function applyFilter(search="", category=""){
  $.getJSON("data/products.json", function(data){
    let filtered = data.filter(p => 
      (!category || p.category===category) &&
      (!search || p.name.toLowerCase().includes(search.toLowerCase()))
    );
    showProducts(filtered, "homeProducts");
  });
}

// Display products
function showProducts(arr, containerId){
  let html = "";
  arr.forEach(p=>{
    html += `
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
      </div>
    `;
  });
  $("#" + containerId).html(html);

  $(".add-btn").click(function(){
    let id = $(this).data("id");
    let product = arr.find(p => p.id==id);
    addToCart(product, $(this));
  });
}
// Registration
$("#registerForm").submit(function(e){
  e.preventDefault();
  const name = $("#regName").val();
  const email = $("#regEmail").val();
  const password = $("#regPassword").val();

  let users = JSON.parse(localStorage.getItem("users")) || [];
  users.push({name,email,password});
  localStorage.setItem("users", JSON.stringify(users));

  // Redirect to home page
  window.location.href = "index.html";
});
