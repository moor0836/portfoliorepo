$("#submitquicksearchbutton").on('click', function () {
    $('#searchResults').empty();
    var params = {
        searchText: $('#newSearchText').val(),
        minPrice: $('#minPrice').val(),
        maxPrice: $('#maxPrice').val(),
        minYear: $('#minYear').val(),
        maxYear: $('#maxYear').val()
    };
    var query = $.param(params);

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/searchsales?" + query,
        success: function (vehicles) {
            $.each(vehicles, function (index, vehicle) {
                var result = "<div class='row resultsRow'><div class='col-sm-12'><div class='row'><div class='col-sm-3'><div class='row'>";
                result += "<b>" + vehicle.Year + ' ' + vehicle.Make + ' ' + vehicle.Model + "</b>";
                result += "</div><div class='row'><img src = '../Images/Vehicles/";
                result += vehicle.VIN + ".jpg' class='vehiclepicture' style='width:90%'>";
                result += "</div></div><div class='col-sm-3'>";
                result += "<br /><b>Body Style:</b> " + vehicle.Style + '<br />';
                result += "<b>Trans:</b> " + vehicle.Transmission + '<br />';
                result += "<b>Color:</b> " + vehicle.ExColor + '<br />';
                result += "</div><div class='col-sm-3'>";
                result += "<br /><b>Interior:</b> " + vehicle.InColor + '<br />';
                result += "<b>Mileage:</b> " + vehicle.Mileage + '<br />';
                result += "</div><div class='col-sm-3'>";
                result += "<br /><b>Sale Price:</b> $" + vehicle.SalePrice;
                result += "<br /><b>MSRP:</b> $" + vehicle.MSRP;
                result += "</div></div><div class='row'><div class='col-sm-12>";
                result += "<div class='row'><div class='col-sm-9'><b>VIN:</b> " + vehicle.VIN + "</div><div class='col-sm-3'>";
                result += "<button type='button' onclick='Purchase(\"" + vehicle.VIN + "\")'>Purchase</button></div ></div></div>";
                result += "</div></div></div>";

                $('#searchResults').append(result);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("search Failure!!");
        }
    });
})
function Purchase(VIN) {
    window.location.href = "https://localhost:44386/sales/purchase?VIN=" + VIN;
}