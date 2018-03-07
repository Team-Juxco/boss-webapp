var catName = "";
var catNum = 1;
var viewYear = "";
var chartLoaded = false;
var currentEditId;
var replacementId;

$(document).ready(function () {
    setDates();
    setCategory("Fountain", 1);
});

//func to highlight selected category
function highlightCat() {
    for (var i = 1; i <= 12; i++) {
        if (i === catNum) {
            document.getElementById('select-' + catNum).style.backgroundColor = "#3e444c";
            continue;
        }
        document.getElementById('select-' + i).style.backgroundColor = "transparent";
    }
}

//set category and call display funcs
function setCategory(categoryName, val) {
    catName = categoryName;
    displayDaily();
    displayCategoryYearly();
    catNum = val;
    highlightCat();

}

//display the daily sales table and graph
function displayDaily() {
    //clear sales table
    $('#sales-table').empty();
    //create thead
    var thead = "<thead><tr><th> Date</th>" + "<th>" + catName + " Gross</th>" + "<th>" + catName + " Net</th></tr></thead>";
    //append thead to table
    $('#sales-table').append(thead);

    //get dateRange
    var dateRange = getDateRange();
    currentEditId = null;
    //get data from backend
    $.ajax({
        type: "POST",
        url: "/Sales/GetSalesData",
        contentType: "application/json; charset=utf-8",
        data: "{categoryName:'" + catName + "',beginDate:'" + dateRange.beginDate + "', endDate: '" + dateRange.endDate + "'}",
        success: function (data) {
            var dataArr = data.salesDataList;
            var tbody = "<tbody>";
            for (var i in dataArr) {
                var onDate = strToDate(dataArr[i].dateString);
                //populate tbody
                tbody += "<tr class='row-data'><td>" + dataArr[i].dateString + "</td>" +
                    "<td class='clickable' id='" + onDate + "-" + catName + "Gross-dis' onclick='toggleUpdate(this)'>" + dataArr[i].gross + "</td>"
                    + "<td id='" + onDate + "-" + catName + "Gross-upd' style='display:none'></td>" +
                    "<td class='clickable' id='" + onDate + "-" + catName + "Net-dis' onclick='toggleUpdate(this)'>" + dataArr[i].net + "</td>"
                    + "<td id='" + onDate + "-" + catName + "Net-upd' style='display:none'></td></tr> ";
            }
            tbody += "</tbody>";
            //append tbody to table
            $('#sales-table').append(tbody);

            //$('#sales-table').sortable();
            fillChart(dataArr, "recent");
        }
    });

}


//display the monthly sales table and graph
function displayCategoryMonthly(year) {
    viewYear = year;

    //clear sales table and hide/show tables
    $('#sales-table-monthly').empty();
    $('#monthly-container').show();
    $('#yearly-container').hide();
    $('#sales-year-select').val(viewYear);

    //create thead
    var thead = "<thead><tr><th> Month</th>" + "<th>" + catName + " Gross</th>" + "<th>" + catName + " Net</th></tr></thead>";
    //append thead to table
    $('#sales-table-monthly').append(thead);
    //var year = $('#sales-year-select').val();
    $.ajax({
        type: "POST",
        url: "/Sales/GetMonthlySalesData",
        contentType: "application/json; charset=utf-8",
        data: "{categoryName:'" + catName + "',year: '" + viewYear + "'}",
        success: function (data) {
            var dataArr = data.monthlySalesList;
            var tbody = "<tbody>";

            for (var i in dataArr) {

                //populate tbody
                tbody += "<tr class='row-data'><td >" + dataArr[i].month + "</td>" +
                    "<td>" + dataArr[i].monthlyGross + "</td>" +
                    "<td>" + dataArr[i].monthlyNet + "</td></tr>";
            }
            tbody += "</tbody>";
            //append tbody to table
            $('#sales-table-monthly').append(tbody);
            fillChart(dataArr, "monthly");
        }
    });
}

function getYear(obj) {
    var year = obj.value;
    return year;
}

//dsiplay the yearly sales table and graph
function displayCategoryYearly() {
    //clear sales table
    $('#monthly-container').hide();
    $('#yearly-container').show();
    $('#sales-table-yearly').empty();
    //create thead
    var thead = "<thead><tr><th> Year</th>" + "<th>" + catName + " Gross</th>" + "<th>" + catName + " Net</th></tr></thead>";
    //append thead to table
    $('#sales-table-yearly').append(thead);
    $('#sales-year-select').val();
    $.ajax({
        type: "POST",
        url: "/Sales/GetYearlySalesData",
        contentType: "application/json; charset=utf-8",
        data: "{categoryName:'" + catName + "'}",
        success: function (data) {
            var dataArr = data.yearlySalesList;
            var tbody = "<tbody>";

            for (var i in dataArr) {

                //populate tbody
                tbody += "<tr class='row-data'><td class='clickable' onclick='displayCategoryMonthly(" + dataArr[i].year + ")'>" + dataArr[i].year + "</td>" +
                    "<td>" + dataArr[i].yearlyGross + "</td>" +
                    "<td>" + dataArr[i].yearlyNet + "</td></tr>";
            }
            tbody += "</tbody>";
            //append tbody to table
            $('#sales-table-yearly').append(tbody);
            fillChart(dataArr, "yearly");
        }
    });
}


//create graphs
function fillChart(dataArr, chartType) {
    var ctx;
    var dateLabel = [];
    var grossData = [];
    var netData = [];

    if (chartType === "recent") {
        ctx = document.getElementById("recentSalesChart").getContext("2d");
        for (var i in dataArr) {
            dateLabel[i] = dataArr[i].dateString;
            grossData[i] = dataArr[i].gross;
            netData[i] = dataArr[i].net;
        }
    } else if (chartType === "monthly") {
        ctx = document.getElementById("monthlySalesChart").getContext("2d");
        for (var k in dataArr) {
            dateLabel[k] = dataArr[k].month;
            grossData[k] = dataArr[k].monthlyGross;
            netData[k] = dataArr[k].monthlyNet;
        }
    } else {
        ctx = document.getElementById("yearlySalesChart").getContext("2d");
        for (var j in dataArr) {
            dateLabel[j] = dataArr[j].year;
            grossData[j] = dataArr[j].yearlyGross;
            netData[j] = dataArr[j].yearlyNet;
        }
    }
    var myChart = new Chart(ctx, { type: 'line', data: [], options: [] });
    myChart.destroy(true);
    myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: dateLabel,
            datasets: [{
                label: "Gross",
                data: grossData,
                lineTension: 0,
                backgroundColor: 'transparent',
                borderColor: '#007bff',
                borderWidth: 4,
                pointBackgroundColor: '#007bff'
            },
            {
                label: "Net",
                data: netData,
                lineTension: 0,
                backgroundColor: 'transparent',
                borderColor: '#ff0033',
                borderWidth: 4,
                pointBackgroundColor: '#ff0033'
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: false
                    }
                }]
            },
            legend: {
                display: true
            }
        }
    });
}

//set the current month and year for load view
function setDates() {
    var curDate = new Date();
    document.getElementById("sales-daily-month-select").value = curDate.getMonth() + 1;
    document.getElementById("sales-daily-year-select").value = curDate.getFullYear();
}

//func tog et date ranges for the selected month and year
function getDateRange() {
    var dateRange = { "beginDate": "", "endDate": "" };
    var month = document.getElementById("sales-daily-month-select").value;
    if (month < 10) {
        month = "0" + month;
    }
    var year = document.getElementById("sales-daily-year-select").value;
    switch (month) {
        case "01":
        case "03":
        case "05":
        case "07":
        case "08":
        case 10:
        case 12:
            dateRange.endDate = year + "-" + month + "-31";
            dateRange.beginDate = year + "-" + month + "-01";
            break;
        case "02":
        case "04":
        case "06":
        case "09":
        case 11:
            dateRange.endDate = year + "-" + month + "-30";
            dateRange.beginDate = year + "-" + month + "-01";
            break;
        default:
            break;
    }
    return dateRange;
}

//func to convert the date string to a Date
function strToDate(dateString) {
    var dateFormatted = new Date(dateString);
    var day = dateFormatted.getDate();
    var month = dateFormatted.getMonth() + 1;
    if (day < 10) {
        day = "0" + day;
    }
    if (month < 10) {
        month = "0" + month;
    }
    dateFormatted = dateFormatted.getFullYear() + "-" + month + "-" + day;
    return dateFormatted;
}

//func to toggle which value is being editted
function toggleUpdate(dom) {
    domHolder = dom;
    //if new currentEditId != Id
    if (currentEditId !== dom.getAttribute('id') && currentEditId !== null) {
        document.getElementById(currentEditId).style.display = "table-cell";
        document.getElementById(replacementId).style.display = "none";
    }

    currentEditId = dom.getAttribute('id');
    replacementId = currentEditId.replace("-dis", "-upd");
    document.getElementById(replacementId).style.display = 'table-cell';
    dom.style.display = 'none';
    var input = document.getElementById(replacementId);
    var originalVal = dom.textContent;
    input.innerHTML = "<input id='numInput' type='number' value='" + originalVal + "'><span id='saveBut' onclick='submitChange()';>Save</span>";

}

//func to call backend update method to save changes
function submitChange() {
    var newValue = document.getElementById('numInput').value;
    var submitData = currentEditId.split("-");

    var onDate = submitData[0] + "-" + submitData[1] + "-" + submitData[2];
    $.ajax({
        type: "POST",
        url: "/Sales/Update",
        contentType: "application/json; charset=utf-8",
        data: "{onDate:'" + onDate + "', columnName:'" + submitData[3] + "', newValue:'" + newValue + "'}",
        success: function () {
            displayDaily();
        }
    });
}