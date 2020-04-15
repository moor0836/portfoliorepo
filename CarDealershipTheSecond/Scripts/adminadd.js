$(document).ready(function () {
    LoadMakes();
    LoadColors();
})

function LoadMakes() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/getallmakes",
        success: function (makes) {
            var x = document.getElementById('Make');
            $.each(makes, function (index, make) {
                var option = document.createElement('option');
                option.appendChild(document.createTextNode(make.MakeName));
                option.value = make.MakeId;
                x.appendChild(option);
            });
            document.getElementById("Make").selectedIndex = 0;
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadmakes failure!");
        }
    });
}

function LoadColors() {
    var x = document.getElementById('ExColor');
    var y = document.getElementById('InColor');

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/getallcolors",
        success: function (colors) {
            $.each(colors, function (index, color) {
                var option = document.createElement('option');
                option.appendChild(document.createTextNode(color.ColorName));
                option.value = color.ColorId;
                x.appendChild(option);
                var optiony = document.createElement('option');
                optiony.appendChild(document.createTextNode(color.ColorName));
                optiony.value = color.ColorId;
                y.appendChild(optiony);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadcolors failure!");
        }
    });
    var optiondisabled = document.createElement('option');
    optiondisabled.appendChild(document.createTextNode('-- select color --'));
    optiondisabled.disabled = true;
    optiondisabled.selected = true;
    x.appendChild(optiondisabled);
    var optiondisabled2 = document.createElement('option');
    optiondisabled2.appendChild(document.createTextNode('-- select color --'));
    optiondisabled2.disabled = true;
    optiondisabled2.selected = true;
    y.appendChild(optiondisabled2);
}

function PopulateModelItems() {
    var select = document.getElementById("Model");
    var length = select.options.length;
    for (i = length - 1; i >= 0; i--) {
        select.options[i] = null;
    }

    var optiondisabled = document.createElement('option');
    optiondisabled.appendChild(document.createTextNode('-- select model --'));
    optiondisabled.disabled = true;
    optiondisabled.selected = true;
    select.appendChild(optiondisabled);

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/getallmodels?makeId=" + document.getElementById('Make').options[document.getElementById('Make').selectedIndex].value,
        success: function (models) {
            $.each(models, function (index, model) {
                var option = document.createElement('option');
                option.appendChild(document.createTextNode(model.ModelName));
                option.value = model.ModelId;
                select.appendChild(option);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadmodels failure!");
        }
    });
}

function UpdateBodyStyle() {
    var select = document.getElementById("BodyStyle");
    select.options[0] = null;

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/getbodystyle?modelId=" + document.getElementById('Model').options[document.getElementById('Model').selectedIndex].value,
        success: function (style) {
            var option = document.createElement('option');
            option.appendChild(document.createTextNode(style));
            option.value = style;
            select.appendChild(option);
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("updatebodystyle failure!");
        }
    });
}


function ValidateVIN() {
    if ((document.getElementById('VIN').value).length != 17) {
        alert("You must enter a 17-digit VIN!");
        return false;
    }
    var unique = true;

    return $.ajax({
        type: "GET",
        url: "https://localhost:44386/getactivevins",
        success: function (vins) {
            var unique = true;
            $.each(vins, function (index, vin) {
                if (document.getElementById('VIN').value == vin) {
                    alert("There is already a vehicle with that VIN in our system!");
                    unique = false;
                }
            });
            if (unique == true) {
                ActualSave();
            }
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("validatevin failure!");
        }
    }).done(function () {
        return true;
    })
}


function ValidateImage() {

    if (document.getElementById('uploadFile').value == "") {
        alert("You must upload a photo!");
        return false;
    }
    if ((document.getElementById('uploadFile').value.split('.').pop() != "jpg") && (document.getElementById('uploadFile').value.split('.').pop() != "JPG")) {
        alert("The image should be type .jpg but it was type " + document.getElementById('uploadFile').value.split('.').pop());
        return false;
    }
    return true;
}




function SaveAll() {

    if (ValidateImage() == false) {
        return false;
    }
    else if (document.getElementById('Make').value == "-- select make --") {
        alert("You must select a make!");
        return false;
    }
    else if (document.getElementById('Model').value == "-- select model --") {
        alert("You must select a model!");
        return false;
    }
    else if (document.getElementById('Year').value == "") {
        alert("You must enter a year!");
        return false;
    }
    else if (document.getElementById('Transmission').value == "-- choose transmission type --") {
        alert("You must choose the transmission type!");
        return false;
    }
    else if (document.getElementById('ExColor').value == "--select color--") {
        alert("You must choose the color!");
        return false;
    }
    else if (document.getElementById('InColor').value == "-- select color --") {
        alert("You must choose the interior color!");
        return false;
    }
    else if (document.getElementById('Mileage').value == "") {
        alert("You must enter the current mileage!");
        return false;
    }
    else if (document.getElementById("Type").value == "new" && document.getElementById('Mileage').value > 1000) {
        alert("You've indicated the vehicle is new, but the mileage is over 1000. Please review and correct.");
        return false;
    }
    else if (document.getElementById("Type").value == "used" && document.getElementById('Mileage').value <= 1000) {
        alert("You've indicated the vehicle is used, but the mileage is not over 1000. Please review and correct.");
        return false;
    }
    else if (document.getElementById('MSRP').value == "") {
        alert("You must enter the MSRP!");
        return false;
    }
    else if (document.getElementById('SalePrice').value == "" || document.getElementById('SalePrice').value < 1 ||
        document.getElementById('SalePrice').value > 990000) {
        alert("You must enter the sale price!");
        return false;
    }
    else if (document.getElementById('SalePrice').value > document.getElementById('MSRP').value) {
        alert("The sale price should never be greater than MSRP!");
        return false;
    }
    else if (document.getElementById('Description').value == "") {
        alert("You must enter a description!");
        return false;
    }
    else {
        ValidateVIN();
    }
}

function ActualSave() {
    var params = {
        vin: document.getElementById('VIN').value, //yes
        year: document.getElementById('Year').value, //yes
        modelId: document.getElementById('Model').value,
        exColorId: document.getElementById('ExColor').value,
        inColorId: document.getElementById('InColor').value,
        styleId: document.getElementById('BodyStyle').value,
        transmission: document.getElementById('Transmission').value,
        mileage: document.getElementById('Mileage').value,
        mSRP: document.getElementById('MSRP').value,
        salePrice: document.getElementById('SalePrice').value,
        description: document.getElementById('Description').value
    };
    var query = $.param(params);

    $.ajax({
        type: "POST",
        url: "https://localhost:44386/savenewvehicle?" + query,
        success: function () {
            alert("New vehicle added!");
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("Unknown error adding the vehicle!!");
        }
    });
    document.forms["frmUpload"].submit();
}

function UpdateModelVIN() {
    document.getElementById('modelVIN').value = document.getElementById('VIN').value;
}
