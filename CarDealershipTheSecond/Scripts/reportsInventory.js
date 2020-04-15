$(document).ready(function () {
    loadUsed();
    loadNew();
});

function loadUsed() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/usedinventoryitems",
        success: function (items) {
            $.each(items, function (index, item) {
                var row = "<tr><td>";
                row += item.Year + "</td><td>";
                row += item.Make + "</td><td>";
                row += item.Model + "</td><td>";
                row += item.Count + "</td><td>$";
                row += item.StockValue + "</td></tr>";
                $('#usedVehicles').append(row);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadused failure!");
        }
    });
}

function loadNew() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/newinventoryitems",
        success: function (items) {
            $.each(items, function (index, item) {
                var row = "<tr><td>";
                row += item.Year + "</td><td>";
                row += item.Make + "</td><td>";
                row += item.Model + "</td><td>";
                row += item.Count + "</td><td>$";
                row += item.StockValue + "</td></tr>";
                $('#newVehicles').append(row);
            });
        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("loadnew failure!");
        }
    });
}