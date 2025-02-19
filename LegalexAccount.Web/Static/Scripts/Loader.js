var loader, skeletons;


document.addEventListener("DOMContentLoaded", () => {
    loader = document.getElementById("loader");
    skeletons = Array.from(document.getElementsByClassName("skeleton"));

    skeletons.forEach(element => {
        var children = Array.from(element.children);

        children.forEach(c => c.style.opacity = "0");
    });
});

window.addEventListener("load", () => {
    skeletons.forEach(element => {
        var children = Array.from(element.children);

        children.forEach(c => {
            c.style.transition = "opacity 0 .6s ease-in-out";
            c.style.opacity = "1";
        });
    });

    loader.style.transition = "opacity .8s ease-in-out, visibility 0s linear .8s";
    loader.style.opacity = "0";
    loader.style.visibility = "hidden";
});
