var loader, header, main;


document.addEventListener("DOMContentLoaded", () => {
    loader = document.getElementById("loader");
    header = document.querySelector("header");
    main = document.querySelector("main");

    // Скрываем header и main до загрузки страницы
    header.style.opacity = "0";
    main.style.opacity = "0";
});

window.addEventListener("load", () => {
    // Добавляем плавное появление
    header.style.transition = "opacity 0.4s ease-in-out";
    main.style.transition = "opacity 0.4s ease-in-out";
    loader.style.transition = "opacity 0.6s ease-in-out, visibility 0s linear 0.6s";

    // Показываем контент
    header.style.opacity = "1";
    main.style.opacity = "1";
    loader.style.opacity = "0";
    loader.style.visibility = "hidden";
});
