$(document).ready(function () {
    var alertType = getParameterByName("alertType");

    if (alertType != "") {
        var alertMessage = getParameterByName("alertMessage");
        displayNotification(alertType, alertMessage);
    }
});


//grabs query string values by using the query string name
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function displayNotification(alertType, alertMessage)
{
    var alertIcon = "";
    var alertTitle = "";

    switch (alertType)
    {
        case "success":
            alertIcon = "glyphicon glyphicon-ok";
            alertTitle = "Success";
            break;
        case "info":
            alertIcon = "glyphicon glyphicon-exclamation-sign";
            alertTitle = "FYI";
            break;
        case "error":
            alertIcon = "glyphicon glyphicon-warning-sign";
            alertTitle = "Error";
            break;
    }

    $.pnotify({
        title: alertTitle,
        text: alertMessage,
        type: alertType,
        icon: alertIcon,
        nonblock: true,
        nonblock_opacity: .2
    });
}