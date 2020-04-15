$(document).ready(function () {
    LoadUsers();
    LoadResults("all", "01/01/2000", "01/01/2100");
});

function UpdateSearchResults() {
    var from = document.getElementById('dateFrom').value;
    if (from == null || from == "") {
        from = "01/01/2000";
    }
    var to = document.getElementById('dateTo').value;
    if (to == null || to == "") {
        to = "01/01/2100";
    }
    LoadResults(document.getElementById("users").value, from, to);
}

function LoadUsers() {
    var x = document.getElementById('users');
    var length = x.options.length;
    for (i = length - 1; i >= 0; i--) {
        x.options[i] = null;
    }
    var firstrow = document.createElement('option');
    firstrow.appendChild(document.createTextNode(" --All -- "));
    firstrow.value = "all";
    x.appendChild(firstrow);

    $.ajax({
        type: "GET",
        url: "https://localhost:44386/userswithsales",
        success: function (_people) {
            $.each(_people, function (index, person) {
                var option = document.createElement('option');
                option.appendChild(document.createTextNode(person));
                option.value = person;
                x.appendChild(option);
            })

        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("LoadUsers Failure!!");
        }
    });
    document.getElementById("users").selectedIndex = "1"
}


function LoadResults(user, fromdate, todate) {
    $('#resultsRows').empty();
    var query = "user=" + user + "&fromDate=" + fromdate + "&toDate=" + todate;
    $.ajax({
        type: "GET",
        url: "https://localhost:44386/salesreportitems?" + query,
        success: function (_items) {
            $.each(_items, function (index, item) {
                var result = "<tr><td>" + item.User + "</td><td>$" + item.TotalSales +
                    "</td><td>" + item.CountSales + "</td></tr>";
                $('#resultsRows').append(result);
            })

        },
        error: function (jqXHR, testStatus, errorThrown) {
            alert("LoadResults Failure!!");
        }
    });
}