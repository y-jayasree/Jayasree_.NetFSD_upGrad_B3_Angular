function loadNavbar() {
  let cart = JSON.parse(localStorage.getItem("cart")) || [];
  let count = cart.reduce((sum, item) => sum + item.qty, 0);

  let currentUser = JSON.parse(localStorage.getItem("currentUser"));
  let userDisplay = '';
  if(currentUser){
    userDisplay = `
      <li class="nav-item"><a class="nav-link">Hello, ${currentUser.name}</a></li>
      <li class="nav-item"><a class="nav-link" href="#" id="logoutBtn">Logout</a></li>
    `;
  } else {
    userDisplay = `
      <li class="nav-item"><a class="nav-link" href="login.html">Login</a></li>
      <li class="nav-item"><a class="nav-link" href="register.html">Register</a></li>
    `;
  }

  $("#navbar").html(`
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
      <div class="container">
        <a class="navbar-brand" href="index.html">ShopEZ</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navContent">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navContent">
          <ul class="navbar-nav ms-auto">
            <li class="nav-item"><a class="nav-link" href="index.html">Home</a></li>
            <li class="nav-item"><a class="nav-link" href="products.html">Products</a></li>
            <li class="nav-item"><a class="nav-link" href="cart.html">Cart [${count}]</a></li>
            ${userDisplay}
          </ul>
        </div>
      </div>
    </nav>
  `);

  // Logout
  $("#logoutBtn").click(function(e){
    e.preventDefault();
    localStorage.removeItem("currentUser");
    window.location.href = "login.html";
  });
}

$(function(){
  loadNavbar();
});
