var passwordSection;
var passwordFields;


document.addEventListener("DOMContentLoaded", () => {
    passwordSection = document.getElementsByClassName("password-section")[0];
    passwordFields = document.getElementsByClassName("password-field");
    validationFields = document.getElementsByClassName("text-validation");
    const checkbox = document.getElementById("checkPass");

    if (checkbox.checked) {
        passwordSection.classList.remove("text-disabled");

        for (let item of passwordFields) {
            item.removeAttribute("disabled");
        }

        for (let item of validationFields) {
            item.removeAttribute("display", "none");
        }
    }
    else {
        passwordSection.classList.add("text-disabled");

        for (let item of passwordFields) {
            item.setAttribute("disabled", "");
        }

        for (let item of validationFields) {
            item.setAttribute("display", "none");
        }
    }
});

function checkPasswordSection(checkbox) {
    if (checkbox.checked) {
        passwordSection.classList.remove("text-disabled");

        for (let item of passwordFields) {
            item.removeAttribute("disabled");
        }

        for (let item of validationFields) {
            item.style.display = 'block';
        }
    }
    else {
        passwordSection.classList.add("text-disabled");

        for (let item of passwordFields) {
            item.setAttribute("disabled", "");
        }

        for (let item of validationFields) {
            item.style.display = 'none';
        }
    }
}
