let element;

document.addEventListener("DOMContentLoaded", () => {
    element = document.getElementById("dropdown-content");
});

const CallDropdownManagement = async (e, baseUrl, prop) => {
    const dropdown = e.parentNode.querySelector(".dropdown-content");

    if (dropdown) {
        if (!dropdown.classList.contains("show-block")) {
            const response = await fetch(baseUrl);
            const data = await response.json();

            data.forEach(x => {
                const element = document.createElement("div");
                element.innerHTML = x[prop];
                dropdown.appendChild(element);
            });
        } else {
            dropdown.innerHTML = '';
        }
    }

    dropdown.classList.toggle("show-block");
}
