$(document).ready(function () {
    loadCarousel();
    loadFeatured();
});

$('.carousel').carousel({
    interval: 5000
})

function loadCarousel() {
    $('#specialscontainer').empty();
    var count = 1;
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/specials",
        success: function (_specials) {
            $.each(_specials, function (index, special) {
                if (count == 1) {
                    var result = '<div class="item active">' +
                        '<img src="Images/Sale.jpg" style="width:100%;margin:auto">' +
                        '<div class="carousel-caption d-none d-md-block">' +
                        '<h2>' + special.SpecialTitle + '</h2>' +
                        '<p>' + special.SpecialDescription + '</p>' +
                        '</div></div>';
                    $('#specialscontainer').append(result);
                    count++;
                }
                else {
                    var result = '<div class="item">' +
                        '<img src="Images/Sale.jpg" style="width:100%;margin:auto">' +
                        '<div class="carousel-caption d-none d-md-block">' +
                        '<h2>' + special.SpecialTitle + '</h2>' +
                        '<p>' + special.SpecialDescription + '</p>' +
                        '</div></div>';
                    $('#specialscontainer').append(result);
                }
            });

        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadCarousel Failure!!");
        }
    });
}

function loadFeatured() {
    $('#featuredvehicles').empty();
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/featuredvehicles",
        success: function (_featuredVehicles) {
            var result = "<div class='row'>";
            $.each(_featuredVehicles, function (index, vehicle) {
                result += '<a href="https://localhost:44386/Inventory/Details?VIN=' + vehicle.VIN + '"><div class="col-sm-4 featuredBox">';
                result += "<div class='row'><img src='Images/Vehicles/" + vehicle.VIN + ".jpg' class='featuredpicture'></div>";
                result += "<div class='row featuredYMM'><p>" + vehicle.Year + ' ' + vehicle.Make + ' ' + vehicle.Model + '</p></div>';
                result += "<div class='row featuredPrice'>$" + vehicle.SalePrice + '</div>';
                result += '</div></a>';
                if ((index + 1) % 3 == 0) {
                    result += "</div><div class='row'>"
                }
            });
            result += '</div>';
            $('#featuredvehicles').append(result);
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadFeatured Failure!!");
        }
    });
}