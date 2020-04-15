$(document).ready(function () {
    LoadFinanceTypes();
})

function LoadFinanceTypes() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/getfinancetypes",
        success: function (types) {
            var x = document.getElementById('FinanceType');

            $.each(types, function (index, type) {
                var option = document.createElement('option');
                option.appendChild(document.createTextNode(type.FinanceTypeName));
                option.value = type.FinanceTypeId;
                x.appendChild(option);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadmakes failure!");
        }
    });
}

$('#purchaseVehicleButton').on('click', function () {
    if (Validate()) {
        $.ajax({
            type: "POST",
            url: "https://localhost:44386/purchase",
            data: JSON.stringify({
                VIN: $('#VIN').text(), //no need to validate - readonly and entered from system
                CustomerName: $('#Name').val(), //need to validate first and last
                Street1: $('#Street1').val(), //must include number, name, suffix
                Street2: $('#Street2').val(), //optional - no validation
                City: $('#City').val(), // must not be empty
                State: $('#State').val(), //supplied - defaults to AZ, no validation needed
                Zip: $('#Zip').val(), //must be 5 digits, all numbers
                Email: $('#Email').val(), //must provide, must format correctly
                Phone: $('#Phone').val().replace(/\D/g, ''), //must provide, must be 10 digit number once reformatted
                PurchasePrice: $('#PurchasePrice').val(), //must be at least 95% of msrp
                FinanceTypeId: $('#FinanceType').val(), //defaults to bank finance, cannot be non-empty
                Salesperson: $('#Salesperson').val() //hidden field, no validation needed
            }),
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            success: function () {
                alert("Nice sale!");
                window.location.href = "https://localhost:44386/sales";
            },
            error: function (jqXHR, testStatus, errorThrown) {
                alert("Unknown error posting the sale!!");
            }
        });
    } 
})

function Validate() {
    var emailFormat = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var phone = $('#Phone').val().replace(/\D/g, '');
    if (!($('#Name').val()).includes(" ")) {
        alert("You must provide first and last names!");
        return false;
    }
    else if (($('#Street1').val().split(" ")).length < 3) {
        alert("You must include a number, street name, and suffix - i.e 2222 Street St.");
        return false;
    }
    else if ($('#City').val() == "") {
        alert("You must provide the city name!");
        return false;
    }
    else if (!(/^\d+$/.test($('#Zip').val())) || $('#Zip').val().length != 5) {
        alert("You must provide a 5 digit numeric zip code!");
        return false;
    }
    else if (!(emailFormat.test($('#Email').val())) || $('#Email').val() == "") {
        alert("You must provide a properly formatted email!");
        return false;
    }
    else if (phone.length != 10) {
        alert("You must enter a 10-digit phone number!");
        return false;
    }
    else if ($('#PurchasePrice').val() < (.95 * $('#MSRPCHECK').val()) || $('#PurchasePrice').val() > $('#MSRPCHECK').val()) {
        alert("The purchase price must be at least 95% of and no more than the vehicle's MSRP!");
        return false;
    }
    else {
        return true;
    }
}