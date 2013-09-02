$(document).ready(function () {
    var alertType = getParameterByName("alertType");

    if (alertType != "") {
        var alertMessage = getParameterByName("alertMessage")

        var defaultNotyfy = notyfy({
            text: alertMessage,
            type: alertType,
            timeout: 5000
        });
    }
});


//grabs query string values by using the query string name
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}