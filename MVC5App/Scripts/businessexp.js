var currentEditId;
var replacementId;
$(document).ready(function () {
    setDates();
    getBusinessExpData();
});
function getBusinessExpData() {
    var dateRange = getDateRange(); 
    $('#expenses-table').empty();
    currentEditId = null;
    replacementId = null;
    $.ajax({
        type: "POST",
        url: "/BusinessExp/GetBusinessExp",
        contentType: "application/json; charset=utf-8",
        data: "{beginDate:'" + dateRange.beginDate + "', endDate: '" + dateRange.endDate + "'}",
        success: function (data) {
            var dataArr = data.expDataList;
            var lastInvoiceNum = 0; 
            var table = "<thead><tr><td>Invoice Number</td><td>Vendor ID</td><td>Date</td><td>Due Date</td><td>Account Number</td><td>Amount</td>" +
                        "</tr><thead><tbody>";
            for (var i in dataArr) {
                var onDate = dateCleaner(dataArr[i].OnDate);
                var dueDate = dateCleaner(dataArr[i].DueDate);
                var amount = parseFloat(Math.round(dataArr[i].Amount * 100) / 100).toFixed(2);
                var VendorInfo = dataArr[i].VendorInfo;
                table += "<tr>" +
                    "<td id='" + dataArr[i].InvoiceNum + "-dis'>" + dataArr[i].InvoiceNum + "</td>" +

                    "<td title ='"+VendorInfo+"' id='" + dataArr[i].InvoiceNum + "-VendorId-dis'onclick='toggleUpdate(this, false)'>" + dataArr[i].VendorId +
                    "<td id='" + dataArr[i].InvoiceNum + "-VendorId-upd' style='display:none'></td>" +

                    "<td id='" + dataArr[i].InvoiceNum + "-OnDate-dis'onclick='toggleUpdate(this,true)'>" + onDate + "</td>" +
                    "<td id='" + dataArr[i].InvoiceNum + "-OnDate-upd' style='display:none'></td>" +

                    "<td id='" + dataArr[i].InvoiceNum + "-DueDate-dis' onclick='toggleUpdate(this,true)'>" + dueDate + "</td>" +
                    "<td id='" + dataArr[i].InvoiceNum + "-DueDate-upd' style='display:none'></td>" +

                    "<td id='" + dataArr[i].InvoiceNum + "-AccountNum-dis'onclick='toggleUpdate(this,false)'>" + dataArr[i].AccountNum + "</td>" +
                    "<td id='" + dataArr[i].InvoiceNum + "-AccountNum-upd' style='display:none'></td>" +

                    "<td id='" + dataArr[i].InvoiceNum + "-Amount-dis' onclick='toggleUpdate(this,false)'>" + amount + "</td>" +
                    "<td id='" + dataArr[i].InvoiceNum + "-Amount-upd' style='display:none'></td>" +
                    "</tr>";
                lastInvoiceNum = dataArr[i].InvoiceNum;
            }
            lastInvoiceNum++;
            table += "<tr id='input-row' style='visibility:hidden'><td></td><td><input id='ven-input' type='number'</td>" +
                "<td><input id='on-date-input'</td><td><input id='due-date-input'</td>" +
                "<td><input id='account-input' type='number'</td><td><input id='amount-input' type='number'</td></tr > ";
            table += "</tbody>";
            $('#expenses-table').append(table);
        }
    });

}
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
function toggleUpdate(dom, isDate) {
    domHolder = dom;
    //if new currentEditId != Id
    if (currentEditId !== dom.getAttribute('id') && currentEditId !== null) {
        document.getElementById(currentEditId).style.display = "table-cell";
        document.getElementById(replacementId).style.display = "none";
    }

    currentEditId = dom.getAttribute('id'); //grab the current Id
    replacementId = currentEditId.replace("-dis", "-upd"); //use the current Id to create a replacement Id
    document.getElementById(replacementId).style.display = 'table-cell'; //show the replacement input box
    dom.style.display = 'none'; //hide the 'old' field' 
    var input = document.getElementById(replacementId); 
    var originalVal = dom.textContent; //grab the original value 
    if (isDate) {
        input.innerHTML = "<input id='datepicker'  value='" + originalVal + "'><span id='saveBut' onclick='submitChange(true)';>Save</span>";
        //setupdate
        setDatePicker("#datepicker");
    } else {
        input.innerHTML = "<input id='numInput' type='number' value='" + originalVal + "'><span id='saveBut' onclick='submitChange(false)';>Save</span>";
    }
}


//func to call backend update method to save changes
function submitChange(isDate) {
    var newValue; 
    if (isDate) {
        newValue = document.getElementById('datepicker').value;
        newValue = new Date(newValue);
        newValue = newValue.getFullYear() + "-" + ("0" + (newValue.getMonth() + 1)).slice(-2) + "-" + ("0" + newValue.getDate()).slice(-2);
    } else {
        newValue = document.getElementById('numInput').value; //get the new value of the input box
    }
    var submitData = currentEditId.split("-");  
    var InvoiceNum = parseInt(submitData[0]); //grab the invoice num
    var colName = submitData[1]; //get the column name
    
    $.ajax({
        type: "POST",
        url: "/BusinessExp/Update",
        contentType: "application/json; charset=utf-8",
        data: "{ InvoiceNum: '" + InvoiceNum + "', newValue: '" + newValue + "', colName: '" + colName + "' }",
        success: function () {
            getBusinessExpData();
        }
    });
}

//set the current month and year for load view
function setDates() {
    var curDate = new Date();
    document.getElementById("month-select").value = curDate.getMonth() + 1;
    document.getElementById("year-select").value = curDate.getFullYear();
}

//func tog et date ranges for the selected month and year
function getDateRange() {
    var dateRange = { "beginDate": "", "endDate": "" };
    var month = document.getElementById("month-select").value;
    if (month < 10) {
        month = "0" + month;
    }
    var year = document.getElementById("year-select").value;
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
function dateCleaner(str) {
    //var string = parseInt(str.substring(str.lastIndexOf("(") + 1, str.lastIndexOf(")")));
    var date = new Date(str);
    var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
        "July", "Aug", "Sept", "Oct", "Nov", "Dec"
    ];
    return monthNames[date.getMonth()] + " " + date.getDate() + ", " + date.getFullYear();
}

function setDatePicker(pickerId) {
    var $j = jQuery.noConflict();
    $(pickerId).datepicker({
        dateFormat: "M d, yy"
    });
    var previousDate;

    $(pickerId).focus(function () {
        previousDate = $(this).val();
    });
    $(pickerId).blur(function () {
        var newDate = $(this).val();
        if (!moment(newDate, 'DD/MM/YYYY', true).isValid()) {
            $(this).val(previousDate);
        }
    });
}
function showInsert() {
    $('#input-row').css("visibility", "visible");
    setDatePicker("#on-date-input");
    setDatePicker("#due-date-input");
    $('#insert-but').hide();
    $('#save-but').show();
    $('#ven-input').change(function () {
        $(this).val($(this).val().match(/\d*\.?\d+/));
    });
    $('#account-input').change(function () {
        $(this).val($(this).val().match(/\d*\.?\d+/));
    });
    $('#amount-input').change(function () {
        $(this).val($(this).val().match(/\d*\.?\d+/));
    });
}

function saveInsert() {
    if (!$('#ven-input').val() || !$('#on-date-input').val() || !$('#due-date-input').val() || !$('#account-input').val() || !$('#amount-input').val()) {
        alert("All fields must be filled!");
        return;
    }
    var dueDate = new Date($('#due-date-input').val());
    dueDate = dueDate.getFullYear() + "-" + ("0" + (dueDate.getMonth() + 1)).slice(-2) + "-" + ("0" + dueDate.getDate()).slice(-2);
    var onDate = new Date($('#on-date-input').val());
    onDate = onDate.getFullYear() + "-" + ("0" + (onDate.getMonth() + 1)).slice(-2) + "-" + ("0" + onDate.getDate()).slice(-2);

    var jObj = {
        "VendorId": $('#ven-input').val(),
        "OnDate": onDate,
        "DueDate": dueDate,
        "AccountNum": $('#account-input').val(),
        "Amount": $('#amount-input').val()
    };
    $.ajax({
        type: "POST",
        url: "/BusinessExp/Insert",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(jObj),
        success: function () {
            getBusinessExpData();
            $('#insert-but').show();
            $('#save-but').hide();
        }
    });
}
