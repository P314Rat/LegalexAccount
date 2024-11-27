let element;

document.addEventListener("DOMContentLoaded", () => {
    element = document.getElementById("dropdown-content");
});

const CallDropdownManagement = (e, baseUrl) => {
    const parent = e.parentNode;
    const dropdown = parent.querySelector(".dropdown-content");

    console.log(baseUrl);

    if (dropdown) {
        fetch();

        dropdown.classList.toggle("show-block");
    }
}
