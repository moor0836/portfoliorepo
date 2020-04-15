$(document).ready(function () {
    $('#specialscontainer').empty();
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/specials",
        success: function (_specials) {
            $.each(_specials, function (index, special) {
                var result = '<div class="row specialrow"><div class="col-sm-2">' +
                    '<img src="../Images/Sale.jpg" style="width:90%;margin:auto">' +
                    '</div><div class="col-sm-10"><div class="row"><div class="col-sm-10">' +
                    special.SpecialTitle + '</div><div class="col-sm-2">' +
                    '<button type="button" onclick="DeleteSpecial(`' + special.SpecialTitle + '`)" class="deletebutton">Delete</button></div></div><div class="row">' +
                    '<p>' + special.SpecialDescription + '</p></div></div></div>';
                $('#specialscontainer').append(result);
            });

        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("load specials Failure!!");
        }
    });
})

function DeleteSpecial(specialTitle) {
    if (confirm("Are you sure you want to delete " + specialTitle + "?")) {
        $.ajax({
            type: "POST",
            url: "https://localhost:44386/deletespecial?specialTitle=" + specialTitle,
            success: function () {
                alert("Special deleted!");
                location.reload();
            },
            error: function (jqXHR, testStatus, errorThrown) {
                alert("load specials Failure!!");
            }
        });
    }
}


function SaveNewSpecial() {
    if (document.getElementById('newDescription').value == "") {
        alert("You must enter a description!");
        return false;
    }
    if (document.getElementById('newSpecialTitle').value == "") {
        alert("You must enter a title!");
        return false;
    }
    if (!CheckUniqueTitle()) {
        return false;
    }
}

function CheckUniqueTitle() {
    var title = document.getElementById('newSpecialTitle').value;

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/specials",
        success: function (_specials) {
            var unique = true;
            $.each(_specials, function (index, special) {
                if (special.SpecialTitle == title) {
                    alert("That title already exists. Choose a unique title!");
                    unique = false;
                }


            });
            if (unique == true) {
                $.ajax({
                    type: "POST",
                    url: "https://localhost:44386/savenewspecial?specialTitle=" + document.getElementById('newSpecialTitle').value +
                        "&description=" + document.getElementById('newDescription').value,
                    success: function () {
                        alert("Special saved!");
                        location.reload();
                    },
                    error: function (jqXHR, testStatus, errorThrown) {
                        alert("save special Failure!!");
                    }
                });
            }
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("load specials Failure!!");
        }
    });
}