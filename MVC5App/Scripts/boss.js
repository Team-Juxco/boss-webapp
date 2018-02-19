 // remember the last item we altered in order to hide it if we alter a different one
var lastAlter = null;
function alter(key, value, id) {
    if (typeof id === "undefined") {
        id = ""
    } else {
        id = "-" + id
    }

    if (lastAlter !== null) {
        // hide the last altered value
        document.getElementById(lastAlter + "-display").style.display = "block";
        document.getElementById(lastAlter + "-alter").style.display = "none";
    }
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

function toggleSidebar() {
    var sidebar = document.getElementsByClassName("sidebar")[0];
    if (sidebar.style.display === "none") {
        sidebar.style.display = "block";
    } else {
        sidebar.style.display = "none";
    }
}