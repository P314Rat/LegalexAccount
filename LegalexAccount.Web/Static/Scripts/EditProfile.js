var passwordSection;
var passwordFields;

document.addEventListener("DOMContentLoaded", () => {
    passwordSection = document.getElementsByClassName("password-section")[0];
    passwordFields = document.getElementsByClassName("password-field");
    const checkbox = document.getElementById("checkPas");

    if (checkbox.checked) {
        passwordSection.classList.remove("text-disabled");

        for (let item of passwordFields) {
            item.removeAttribute("disabled");
        }
    }
    else {
        passwordSection.classList.add("text-disabled");

        for (let item of passwordFields) {
            item.setAttribute("disabled", "");
        }
    }
});

function checkPasswordSection(checkbox) {
    if (checkbox.checked) {
        passwordSection.classList.remove("text-disabled");

        for (let item of passwordFields) {
            item.removeAttribute("disabled");
        }
    }
    else {
        passwordSection.classList.add("text-disabled");

        for (let item of passwordFields) {
            item.setAttribute("disabled", "");
        }
    }
}
