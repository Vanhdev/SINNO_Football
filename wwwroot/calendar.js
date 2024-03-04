window.calendar = {
    render: function () {
        const daysTag = document.querySelector(".days"),
            currentDate = document.querySelector(".current-date"),
            prevNextIcon = document.querySelectorAll(".icons span");

        // getting new date, current year and month
        let date = new Date(),
            currYear = date.getFullYear(),
            currMonth = date.getMonth();

        // storing full name of all months in array
        const months = ["January", "February", "March", "April", "May", "June", "July",
            "August", "September", "October", "November", "December"];

        const renderCalendar = () => {
            let firstDayofMonth = new Date(currYear, currMonth, 1).getDay(), // getting first day of month
                lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate(), // getting last date of month
                lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay(), // getting last day of month
                lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate(); // getting last date of previous month
            let dayTag = "";

            for (let i = firstDayofMonth; i > 0; i--) { // creating li of previous month last days
                dayTag += `<div class="day prev inactive">${lastDateofLastMonth - i + 1}</div>`;
            }

            for (let i = 1; i <= lastDateofMonth; i++) { // creating li of all days of current month
                // adding active class to li if the current day, month, and year matched
                let isToday = i === date.getDate() && currMonth === new Date().getMonth()
                    && currYear === new Date().getFullYear() ? "active" : "";
                dayTag += `<div class="day ${isToday}">${i}</div>`;
            }

            for (let i = lastDayofMonth; i < 6; i++) { // creating li of next month first days
                dayTag += `<div class="day next inactive">${i - lastDayofMonth + 1}</div>`
            }
            currentDate.innerText = `${months[currMonth]} ${currYear}`; // passing current mon and yr as currentDate text
            daysTag.innerHTML = dayTag;
        }
        renderCalendar();

        prevNextIcon.forEach(icon => { // getting prev and next icons
            icon.addEventListener("click", () => { // adding click event on both icons
                // if clicked icon is previous icon then decrement current month by 1 else increment it by 1
                currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;

                if (currMonth < 0 || currMonth > 11) { // if current month is less than 0 or greater than 11
                    // creating a new date of current year & month and pass it as date value
                    date = new Date(currYear, currMonth, new Date().getDate());
                    currYear = date.getFullYear(); // updating current year with new date year
                    currMonth = date.getMonth(); // updating current month with new date month
                } else {
                    date = new Date(); // pass the current date as date value
                }
                renderCalendar(); // calling renderCalendar function
            });
        });
    },
    click: function () {
        const months = ["January", "February", "March", "April", "May", "June", "July",
            "August", "September", "October", "November", "December"];
        var days = document.getElementsByClassName("day");
        currentDate = document.querySelector(".current-date");
        var cur = currentDate.innerHTML.split(" ");
        var month = cur[0];
        var year = cur[1];
        var currentMonth;
        for (let i = 0; i < months.length; i++) {
            if (month == months[i]) currentMonth = i + 1;
        }

        for (var day of days) {
            day.addEventListener("click", () => {
                var d = day.innerText;
                if (day.className.includes("prev")) {
                    if (currentMonth == 1) {
                        currentMonth = 12;
                        year = (year * 1) - 1;
                    }
                    else currentMonth -= 1;

                    console.log(d, currentMonth, year);
                }
                else if (day.className.includes("next")) {
                    if (currentMonth == 12) {
                        currentMonth = 1;
                        year = (year * 1) + 1;
                    }
                    else currentMonth += 1;

                    console.log(d, currentMonth, year);
                }
                else console.log(d, currentMonth, year);
            })
            
        }
    }
}