$(function () {
  $("#login").submit(function (e) {
    e.preventDefault();

    let email = $("#email").val().trim();
    let pass = $("#pass").val().trim();

    $(".text-danger").text("");

    if (!email) return $("#eErr").text("Required");
    if (!pass) return $("#pErr").text("Required");

    localStorage.setItem("user", email);

    $("#msg").text("Login successful");
  });
});
