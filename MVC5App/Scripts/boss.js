 // remember the last item we altered in order to hide it if we alter a different one
var lastAlter = null;
function alter(key, value) {
    if (lastAlter !== null) {
        // hide the last altered value
        document.getElementById(lastAlter + "-display").style.display = "block";
        document.getElementById(lastAlter + "-alter").style.display = "none";
    }
    // hide the current displayed value and show the alterable textbox
    document.getElementById(key + "-display").style.display = "none";
    document.getElementById(key + "-alter").style.display = "block";

    var valueInput = document.getElementById(key + "-alter").getElementsByTagName("input")[0];
    // make sure the alterable textbox's value stays accurate
    valueInput.value = value;

    // focus on and select the text of the alterable textbox
    valueInput.select();
    lastAlter = key;
}