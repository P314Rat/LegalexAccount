const connection = new signalR.HubConnectionBuilder()
    .withUrl("/presence")
    .build();

connection.start().catch(err => console.error(err));

connection.on("UserOnline", function (userId) {
    console.log("Пользователь онлайн: " + userId);

    let element = document.getElementById("status-indicator-" + userId);

    if (element) { // Проверяем, что элемент существует
        element.classList.add("online");
    }
});

connection.on("UserOffline", function (userId) {
    console.log("Пользователь оффлайн: " + userId);
    document.querySelectorAll(".status-indicator").forEach(el => el.classList.remove("online"));
});
