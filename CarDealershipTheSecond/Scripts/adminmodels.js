$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/getallmodelsanymake",
        success: function (models) {
            $.each(models, function (index, model) {
                var row = "<tr><td>";
                row += model.MakeName + "</td><td>";
                row += model.ModelName + "</td><td>";
                row += model.DateAdded.slice(0, 10) + "</td><td>";
                row += model.Creator + "</td></tr>";
                $('#modelstablebody').append(row);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadmodels failure!");
        }
    });

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/getallmakes",
        success: function (makes) {
            var x = document.getElementById('MakeName');

            $.each(makes, function (index, make) {
                var option = document.createElement('option');
                option.appendChild(document.createTextNode(make.MakeName));
                option.value = make.MakeId;
                x.appendChild(option);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadmakes failure!");
        }
    });

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/getallstyles",
        success: function (styles) {
            var x = document.getElementById('BodyStyle');

            $.each(styles, function (index, style) {
                var option = document.createElement('option');
                option.appendChild(document.createTextNode(style.StyleName));
                option.value = style.StyleId;
                x.appendChild(option);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadmakes failure!");
        }
    });
})

function SaveNewModel() {
    if (Validate()) {
        $.ajax({
            type: "POST",
            url: "https://localhost:44386/savenewmodel?name=" + document.getElementById("newModelName").value
                + "&makeId=" + document.getElementById('MakeName').value + "&user=" + document.getElementById('Salesperson').value + "&styleId=" + document.getElementById('BodyStyle').value,
            success: function () {
                alert("New Model saved!");
                location.reload();
            },
            error: function (jqXHR, testStatus, errorThrown) {
                alert("savenewmodel failure!");
            }
        });
    }
}


function Validate() {
    var model = document.getElementById("newModelName").value;
    if (model != null && model != "") {
        model = model[0].toUpperCase() + model.slice(1);
        document.getElementById("newModelName").value = model;
        return true;
    }
    else {
        alert("You must enter a model name!");
    }
}