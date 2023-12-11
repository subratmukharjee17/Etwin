function login() {
    //I check if the fields are empty
    var token = $('input[name="__RequestVerificationToken"]').val();

    var Uname = $("#uname").val();
    var Pwd = $("#pwd").val();

    if (Uname == "") {
        $("#username_notif").show();
        $("#uname").css({ 'border-bottom': '4px solid red' });
        return false;
    } else {
        $("#username_notif").hide();
    }
    if (Pwd == "") {
        $("#paswword_notif").show();
        $("#pwd").css({ 'border-bottom': '4px solid red' });
        return false;
    } else {
        $("#paswword_notif").hide();
    }

    //Set the URL and check if the entered values ​​are present in the database
    $("#loading-overlay").show();
    $.ajax({
        url: "/Operators/Authentication",
        type: 'POST',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: {
            UserName: $("#uname").val(),
            Password: $("#pwd").val(),
            RememberUser: $('#remember_me').is(":checked"),
        }
    }).done(function (response) {
        $("#loading-overlay").hide();
        if (response == "Invalid Credential") {
            $("#loading-overlay").hide();
            $("#error_notif").show();
            $("#uname").css({ 'border-bottom': '4px solid red' });
            $("#pwd").css({ 'border-bottom': '4px solid red' });
        } else {
            window.location.href = "/Department/Index";
        }
    });
}

$(function () {
    $("#toggle_pwd").click(function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var type = $(this).hasClass("fa-eye-slash") ? "text" : "password";
        $("#pwd").attr("type", type);
    });
});

function preventBack() {
    window.history.forward();
}
setTimeout("preventBack()", 0);
window.onbeforeunload = function () { return; };
