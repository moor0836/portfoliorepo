$(document).ready(function () {
    var full_url = document.URL;
    var url_array = full_url.split('/');
    var last_segment = url_array[url_array.length - 1];
    if (last_segment != "ContactUs") {
        document.getElementById("Message").value = "RE VIN: " + last_segment;
    }
});

$('#submitcontactusbutton').on('click', function () {
    if (Validate()) {
        $.ajax({
            type: "POST",
            url: "https://localhost:44386/contactus",
            data: JSON.stringify({
                ContactName: $('#Name').val(),
                ContactPhone: $('#Phone').val().replace(/\D/g, ''),
                ContactEmail: $('#Email').val(),
                ContactMessage: $('#Message').val()
            }),
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            success: function () {
                alert("Thanks! We'll be in contact soon!");
                window.location.href = "https://localhost:44386/";
            },
            error: function (jqXHR, testStatus, errorThrown) {
                alert("Failure!!");
            }
        });
    }
})

function Validate() {
    var phone = $('#Phone').val().replace(/\D/g, '');
    var emailFormat = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!($('#Name').val()).includes(" ")) {
        alert("You must provide first and last names!");
        return false;
    }
    else if ($('#Phone').val() == "" && $('#Email').val() == "") {
        alert("You must provide either a phone number or an email!");
        return false;
    }
    else if ($('#Phone').val() != "" && phone.length != 10) {
        alert("You must enter a 10-digit phone number!");
        return false;
    }
    else if ($('#Email').val() != "" && !emailFormat.test($('#Email').val())) {
        alert("You must provide a properly formatted email!");
        return false;
    }
    else if ($('#Message').val() == "") {
        alert("You must provide a short message describing why you want to be contacted!");
        return false;
    }
    else {
        return true;
    }
}

function OpenNewWindowGMaps() {
    window.open("https://www.google.com/maps/place/Spencer's+Place/@43.080426,-72.4277105,15z/data=!4m5!3m4!1s0x89e1a7b1e511c69d:0xb765edcd7e865a88!8m2!3d43.0795683!4d-72.4266976", "blank");
}