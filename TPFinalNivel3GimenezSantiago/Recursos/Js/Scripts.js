document.addEventListener("DOMContentLoaded", function () {
    const path = window.location.pathname.toLowerCase();
    const links = document.querySelectorAll(".navbar-nav .nav-link");

    links.forEach(link => {
        const href = link.getAttribute("href").toLowerCase();
        if (path.includes(href.replace(".aspx", ""))) {
            link.classList.add("active");
        }
    });
});