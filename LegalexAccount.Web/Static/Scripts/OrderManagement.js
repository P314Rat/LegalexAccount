let elementsWithManagementPanel = [];

document.addEventListener("DOMContentLoaded", () => {
    elementsWithManagementPanel = document.getElementsByClassName("with-management-panel");
});

const CallManagementPanel = (currentElement) => {
    Array.from(elementsWithManagementPanel).forEach((element) => element.classList.remove("m-panel"));
    currentElement.classList.add("m-panel");
}
