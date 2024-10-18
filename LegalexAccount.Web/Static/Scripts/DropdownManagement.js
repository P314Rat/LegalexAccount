let element;

document.addEventListener("DOMContentLoaded", () => {
    element = document.getElementById("dropdown-content");
});

const CallDropdownManagement = () => {
    element.classList.toggle("show-block");
}
