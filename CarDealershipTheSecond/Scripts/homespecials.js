$(document).ready(function () {
    loadSpecials();
});

function loadSpecials() {
    $('#specialshere').empty();
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/specials",
        success: function (_specials) {
            $.each(_specials, function (index, special) {
                var result = "";
                result += '<div class="row specialsRow"><div class="col-sm-2">';
                result += '<img src="../Images/DollarSign.jpg" style="width:100%"></div><div class="col-sm-10">';
                result += "<h3>" + special.SpecialTitle + "</h3>";
                result += "<p>" + special.SpecialDescription + "</p>";
                result += "</div></div>";
                $('#specialshere').append(result);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadSpecials Failure!!");
        }
    });
}
