let elementsWithManagementPanel = [];

document.addEventListener("DOMContentLoaded", () => {
    elementsWithManagementPanel = document.getElementsByClassName("with-management-panel");
});

const CallManagementPanel = (currentEement) => {
    Array.from(elementsWithManagementPanel).forEach((element) => element.classList.remove("m-panel"));
    currentEement.classList.add("m-panel");
}
