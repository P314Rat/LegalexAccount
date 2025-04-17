document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById('creation-form');
    const submitButton = document.getElementsByClassName('next-step')[0];

    if (form) {
        form.addEventListener('input', () => {
            submitButton.disabled = !form.checkValidity();
        });
    }
});
