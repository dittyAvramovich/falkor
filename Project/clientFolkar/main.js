const api_url = "https://localhost:7212/WeatherForecast";
var floor;
var dep;
var tablrData;
window.onload = function () {
    $('#myFloorsSelect').append($('<option>', {
        value: -1,
        text: "בחר קומה"
    }));
    fetch(api_url)
        .then(response => response.json())
        .then(data => {
            $.each(data, function (index, value) {
                $('#myFloorsSelect').append($('<option>', {
                    value: index + 1,
                    text: value.name
                }));
            });
            $('#myFloorsSelect').on('change', function () {
                var floorId = $(this).val();
                getDep(floorId);
                floor = floorId;
                $('#myDepSelect').removeData();
            });
            if (data != null) {
            }
            console.log(data);
        })
        .catch(error => {
            console.error(error);
        });
};

function getDep(floorId) {
    $('#myDepSelect').empty();
    $('#myDepSelect').append($('<option>', {
        value: -1,
        text: "בחר מחלקה",
    }));
    $('#myDepSelect').append($('<option>', {
        value: 0,
        text: "בחר הכל",
    }));
    fetch(`${api_url}/${floorId}`)
        .then(response => response.json())
        .then(data => {
            $.each(data, function (index, value) {
                $('#myDepSelect').append($('<option>', {
                    value: value.id,
                    text: value.department_desc
                }));
            });

            $('#myDepSelect').on('change', function () {
                dep = this.value;
                var selectedOption = $(this).find(':selected');
                var departmentDesc = selectedOption.text();
                depName = departmentDesc;
            });
        })
        .catch(error => {
            console.error(error);
        });
}
function showData() {
    fetch(`${api_url}/${floor}/${dep}`)
        .then(response => response.json())
        .then(data => {
            console.log(data)
            tablrData = data;
            if (data != null) {
                createTable(data);
            }
            console.log(data);
        })
        .catch(error => {
            console.error(error);
        });

}

function groupBy(list, keyGetter) {
    const map = new Map();
    list.forEach((item) => {
        const key = keyGetter(item);
        const collection = map.get(key);
        if (!collection) {
            map.set(key, [item]);
        } else {
            collection.push(item);
        }
    });
    return Array.from(map.entries());
}

function getCutName(fullName) {
    const parts = fullName.split(" ");
    const firstName = parts[0];
    const lastName = parts[1];
    const abbreviatedName = `${firstName.charAt(0)}. ${lastName}`;
    return abbreviatedName;
}

function createTable(data) {
    $('#message').empty();
    $('#tabtbody').empty();
    $('#message').append(`לוח תורים לתאריך 18.02.2022 קומה ${floor}`)

    const grouped = groupBy(data, d => d.scheduled_time_interval);
    var columns = Object.keys(data[0]);

    var colString = "";
    colString += `<tr><th>שעה</th>`;
    for (let index = 9; index < columns.length; index++) {
        colString += `<th>${columns[index]}</th>`;
    }
    colString += "</tr>"
    $('#tabtbody').append(colString);

    var rowString = "";
    grouped.forEach(g => {
        rowString += `<tr> <td> ${g[0]} </td>`;
        for (let index = 9; index < columns.length; index++) {
            rowString += "<td>"
            g[1].forEach(el => {
                if (el[columns[index]] == null)
                    rowString += ``
                else rowString += `<span class="clickable" id="${el.patient_id}"data-value="${el[columns[index]]}">${getCutName(el[columns[index]])} </span><br/>`
            });
            rowString += "</td>"
        }
        rowString += '</tr>'
    });

    $('#tabtbody').append(rowString);
};

document.addEventListener("click", function (e) {
    const name = e.target.dataset.value;
    const id = e.target.id;
    const person = tablrData?.find((i) => i.patient_id == id);
    var payer = "";
    if (person?.payer == "" || person?.payer == null)
        payer = "פרטי";
    if (person) {
        alert(`שם מלא:${name},
  שעת זימון:${person?.schedule_time},שם רופא:${person?.doctor_Name},גורם משלם:${payer != "" ? payer : person?.payer}`)
    }
});