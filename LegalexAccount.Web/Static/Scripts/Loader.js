var loader, header, main;


document.addEventListener("DOMContentLoaded", () => {
    loader = document.getElementById("loader");
    header = document.querySelector("header");
    main = document.querySelector("main");

    // Скрываем header и main до загрузки страницы
    if (header)
        header.style.opacity = "0";

    if (main)
        main.style.opacity = "0";
});

window.addEventListener("load", () => {
    // Добавляем плавное появление
    if (header) {
        header.style.transition = "opacity 0.4s ease-in-out";
        header.style.opacity = "1";
    }

    if (main) {
        main.style.transition = "opacity 0.4s ease-in-out";
        main.style.opacity = "1";
    }

    loader.style.transition = "opacity 0.6s ease-in-out, visibility 0s linear 0.6s";
    loader.style.opacity = "0";
    loader.style.visibility = "hidden";
});
