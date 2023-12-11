function recoverPassword() {
    var Uname = $("#txtUserName").val();
    //debugger

    if (Uname == "") {
        $("#username_notif").show();
        $("#txtUserName").css({ 'border-bottom': '4px solid red' });
        return false;
    }

    $.ajax({
        //debugger
        url: "/Operators/PasswordRecoveryEmail",
        type: 'POST',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: {
            Username: $("#txtUserName").val()
        }
    }).done(function (response) {
        if (response) {
            window.location.href = '@Url.Action("PasswordRecovery", "Operators")';

        }
        else {
            alert("Invalid Email Id!");
        }
    });
}