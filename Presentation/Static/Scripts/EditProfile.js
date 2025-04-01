var passwordSection;
var passwordFields;
var validationFields;


document.addEventListener("DOMContentLoaded", () => {
    const checkbox = document.getElementById("checkbox");
    passwordSection = document.getElementsByClassName("password-section")[0];
    passwordFields = document.getElementsByClassName("password-field");
    validationFields = document.getElementsByClassName("text-validation");

    togglePasswordFields(checkbox);
});

function togglePasswordFields(checkbox) {
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
