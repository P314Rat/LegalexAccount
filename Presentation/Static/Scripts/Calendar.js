document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        locale: 'ru', // Устанавливаем локализацию на русский
        initialView: 'dayGridMonth', // Устанавливаем начальный вид календаря (месяц)
        headerToolbar: {
            left: 'prev,next today', // Кнопки для навигации (предыдущий, следующий месяц и сегодня)
            center: 'title', // Название текущего месяца
            right: 'dayGridMonth,dayGridWeek,dayGridDay' // Виды календаря (месяц, неделя, день)
        },
        events: [
            {
                title: 'Мероприятие 1',
                start: '2025-04-10',
                end: '2025-04-12',
                description: 'Описание события',
                color: '#1767b3', // Цвет события
            },
            {
                title: 'Мероприятие 2',
                start: '2025-04-15',
                description: 'Описание события',
                color: '#f39c12', // Другой цвет события
            }
        ],
        eventClick: function (info) {
            alert('Событие: ' + info.event.title);
        }
    });

    calendar.render(); // Рендерим календарь
});
