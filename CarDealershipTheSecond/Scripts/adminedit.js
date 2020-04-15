$(document).ready(function () {
    LoadMakes();
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
            LoadColors();
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
            LoadVehicle();
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


function LoadVehicle() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/geteasyeditbyvin?VIN=" + document.getElementById('VIN').value,
        success: function (vehicle) {
            document.getElementById('Make').value = vehicle.MakeId;
            PopulateModelItems(vehicle);
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadvehicle failure!");
        }
    });

}

function PopulateModelItems(vehicle) {
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

            var type = vehicle.Mileage;
            if (type < 1000) {
                document.getElementById('Type').value = "new";
            } else {
                document.getElementById('Type').value = "used";
            }
            document.getElementById('Model').value = vehicle.ModelId;
            UpdateBodyStyle();
            document.getElementById('Year').value = vehicle.Year;
            document.getElementById('Transmission').value = vehicle.Transmission;
            document.getElementById('ExColor').value = vehicle.ExColorId;
            document.getElementById('InColor').value = vehicle.InColorId;
            document.getElementById('Mileage').value = vehicle.Mileage;
            document.getElementById('MSRP').value = vehicle.MSRP;
            document.getElementById('SalePrice').value = vehicle.SalePrice;
            document.getElementById('Description').value = vehicle.Description;
            document.getElementById('Featured').checked = vehicle.Featured;

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

function validateFileType() {
    var files = m.files;
    $.each(files, function () {
        if (this.extension.toLowerCase() != ".jpg") {
            alert("Only .jpg files can be uploaded!");
        }
    });
}

function SaveAll() {
    if (Validate()) {
        var params = {
            vin: document.getElementById('VIN').value,
            year: document.getElementById('Year').value,
            modelId: document.getElementById('Model').value,
            exColorId: document.getElementById('ExColor').value,
            inColorId: document.getElementById('InColor').value,
            transmission: document.getElementById('Transmission').value,
            mileage: document.getElementById('Mileage').value,
            mSRP: document.getElementById('MSRP').value,
            salePrice: document.getElementById('SalePrice').value,
            description: document.getElementById('Description').value,
            featured: document.getElementById('Featured').checked
        };
        var query = $.param(params);

        $.ajax({
            type: "POST",
            url: "https://localhost:44386/editvehicle?" + query,
            success: function () {
                alert("Vehicle updated!");
            },
            error: function (jqXHR, testStatus, errorThrown) {
                alert("Unknown error editing the vehicle!!");
            }
        });

        document.forms["frmUpload"].submit();
    }


}

function UpdateModelVIN() {
    document.getElementById('modelVIN').value = document.getElementById('VIN').value;
}

function Delete() {
    if (confirm("Are you sure you want to delete " + document.getElementById('VIN').value + "?")) {
        $.ajax({
            type: "POST",
            url: "https://localhost:44386/deletevehicle?VIN=" + document.getElementById('VIN').value,
            success: function () {
                alert("Vehicle deleted!");
            },
            error: function (jqXHR, testStatus, errorThrown) {
                alert("Unknown error deleting the vehicle!!");
            }
        });
        window.location.href = "https://localhost:44386/admin/index";
    }
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

function Validate() {
    if (document.getElementById('uploadFile').value != "") {
        if (!ValidateImage()) {
            return false;
        }
    }
    if (document.getElementById('Year').value == "") {
        alert("You must enter a year!");
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
    return true;
}
