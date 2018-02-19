 // remember the last item we altered in order to hide it if we alter a different one
var lastAlter = null;
function hideLastAlter() {
    if (lastAlter !== null) {
        // hide the last altered value
        document.getElementById(lastAlter + "-display").style.display = "block";
        document.getElementById(lastAlter + "-alter").style.display = "none";
        lastAlter = null;
    }
    var inserts = document.getElementsByClassName("insert-alter");
    for (i = 0; i < inserts.length; i++) {
        inserts[i].style.display = "none";
    }
    var insertButton = document.getElementById("insert-button");
    if (insertButton !== null) {
        insertButton.style.display = "block";
    }
}

function alter(key, value, id) {
    if (typeof id === "undefined") {
        id = ""
    } else {
        id = "-" + id
    }

    hideLastAlter();
    lastAlter = key + id;

    // hide the current displayed value and show the alterable textbox
    document.getElementById(key + id + "-display").style.display = "none";
    document.getElementById(key + id + "-alter").style.display = "block";

    var valueInput = document.getElementById(key + id + "-alter").getElementsByClassName("forminput")[0];
    // make sure the alterable textbox's value stays accurate
    valueInput.value = value;

    // focus on and select the text of the alterable textbox
    valueInput.select();
}

function alterInsert() {
    hideLastAlter();
    var inserts = document.getElementsByClassName("insert-alter");
    for (i = 0; i < inserts.length; i++) {
        inserts[i].style.display = "table-row";
    }
    document.getElementById("insert-button").style.display = "none";
}

function toggleSidebar() {
    var sidebar = document.getElementsByClassName("sidebar")[0];
    if (sidebar.style.display === "none") {
        sidebar.style.display = "block";
    } else {
        sidebar.style.display = "none";
    }
}