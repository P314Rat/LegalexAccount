document.addEventListener("DOMContentLoaded", () => {
    const steps = document.getElementsByClassName("step");
    Array.from(steps).forEach((element, index) => ConfigureStep(element, index));
});

const ConfigureStep = (currentElement, index) => {
    const stepNumber = currentElement.getAttribute("data-step");

    if (index === stepNumber - 1) {
        currentElement.classList.add("current");
        currentElement.getElementsByClassName("step-button")[0].innerHTML = '<span class="current-dot"></span>';
    }
    else if (index > stepNumber - 1) {
        currentElement.classList.add("upcoming");
        currentElement.getElementsByClassName("step-button")[0].innerHTML = '<span class="upcoming-dot"></span>';
    }
    else if (index < stepNumber - 1) {
        currentElement.classList.add("complete");
        currentElement.getElementsByClassName("step-button")[0].innerHTML = '<span class="check-icon">&#x2713</span>';
    }
}
