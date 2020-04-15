$(document).ready(function () {
    ReloadMakes()
})

function ReloadMakes() {
    $('#makestablebody').empty;

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/getallmakes",
        success: function (makes) {
            $.each(makes, function (index, make) {
                var row = "<tr><td>";
                row += make.MakeName + "</td><td>";
                row += make.DateAdded.slice(0, 10) + "</td><td>";
                row += make.Creator + "</td></tr>";
                $('#makestablebody').append(row);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadmakes failure!");
        }
    });
}
function SaveNewMake() {
    if (Validate()) {
        $.ajax({
            type: "POST",
            url: "https://localhost:44386/savenewmake?Name=" + document.getElementById("newMakeName").value + "&User=" + document.getElementById('Salesperson').value,
            success: function () {
                alert("New Make saved!");
                location.reload();
            },
            error: function (jqXHR, testStatus, errorThrown) {
                alert("loadmakes failure!");
            }
        });
    }
}

function Validate() {
    var make = document.getElementById("newMakeName").value;
    if (make != null && make != "") {
        make = make[0].toUpperCase() + make.slice(1);
        document.getElementById("newMakeName").value = make;
        return true;
    }
    else {
        alert("You must enter a make name!");
    }
}