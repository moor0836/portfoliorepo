// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    restoreDefault();
});

function restoreDefault() {
    document.getElementById('currentMoneyIn').value = 0;
    document.getElementById('currentMessage').value = "";
    document.getElementById('itemIdNumber').value = "";
    document.getElementById('changeMessage').value = "";
    populateTable();
}
function populateTable() {
    $('#theReallyImportantSpot').empty();
    $.ajax({

        type: "GET",
        url: "http://localhost:63167/vending/all",
        success: function (itemArray) {

            $.each(itemArray, function (index, item) {
                var result = '<div class = "item" id="' + item.id +
                    '" onclick="clickOnItem(+' + item.id + ')"><p class="idDisplay">' + item.id +
                    '</p><p class="nameDisplay">' + item.Name +
                    '<br></p><p class="priceDisplay">$' + item.Price +
                    '</p><br><p class="quantityDisplay">Quantity: ' + item.Quantity +
                    '</p></div>';
                $('#theReallyImportantSpot').append(result);
            })

        },

        error: function (jqXHR, testStatus, errorThrown) {
            alert("populateTable failure!!");
        }
    });
}

$('#addDollarButton').on('click', function () {
    var money = Number($('#currentMoneyIn').val());
    money += 1.00;
    $('#currentMoneyIn').val(money.toFixed(2));
    clearUp();
})

$('#addQuarterButton').on('click', function () {
    var money = Number($('#currentMoneyIn').val());
    money += .25;
    $('#currentMoneyIn').val(money.toFixed(2));
    clearUp();
})

$('#addDimeButton').on('click', function () {
    var money = Number($('#currentMoneyIn').val());
    money += .10;
    $('#currentMoneyIn').val(money.toFixed(2));
    clearUp();
})

$('#addNickelButton').on('click', function () {
    var money = Number($('#currentMoneyIn').val());
    money += .05;
    $('#currentMoneyIn').val(money.toFixed(2));
    clearUp();
})

function clickOnItem(x) {
    clearUp();
    $('#itemIdNumber').val(x);
}

function purchaseItem() {
    var path = 'http://localhost:63167/vending/purchase/'+ $('#itemIdNumber').val() + "/" + Number($('#currentMoneyIn').val());

    if ($('#itemIdNumber').val() == "") {
        $('#currentMessage').val('Please make a selection');
        return;
    }

    else {
        $.ajax({

            type: "POST",
            url: path,
            success: function (item) {
              if(item.success){
                $('#currentMessage').val("Thank you!!!");
                $('#changeMessage').val(returnChangeMessage(item.change));
                document.getElementById('currentMoneyIn').value = 0;
                populateTable();
              }
              else{
                if (item.failureMessage != null) {
                    $('#currentMessage').val(item.failureMessage);
                }
              }
            },

            error: function (jqXHR, testStatus, errorThrown) {
                $('#currentMessage').val(jqXHR.responseJSON.message);
            }
        });
    }
}

$('#changeReturnButton').on('click', function () {
    if ($('#currentMoneyIn').val() == 0) {
        document.getElementById('changeMessage').value = "";
    }
    else {
        document.getElementById('changeMessage').value = returnChangeMessage($('#currentMoneyIn').val());
        document.getElementById('currentMoneyIn').value = "";
    }
})

function returnChangeMessage(x) {
    var quarters = 1, dimes = 1, nickels = 1, pennies = 1;
    var result = "";
    while (true) {
        if ((quarters * .25) > x) {
            quarters--;
            if (quarters == 1) {
                result += '1 quarter, '
            }
            else if (quarters > 1) {
                result += quarters + ' quarters, '
            }
            break;
        }
        quarters++;
    }
    x -= (quarters * .25);
    while (true) {
        if ((dimes * .1) > x) {
            dimes--;
            if (dimes == 1) {
                result += '1 dime, '
            }
            else if (dimes > 1) {
                result += dimes + ' dimes, '
            }
            break;
        }
        dimes++;
    }
    x -= (dimes * .1);
    while (true) {
        if ((nickels * .05) > x) {
            nickels--;
            if (nickels == 1) {
                result += '1 nickel, '
            }
            else if (nickels > 1) {
                result += nickels + ' nickels, '
            }
            break;
        }
        nickels++;
    }
    x -= (nickels * .05);
    while (true) {
        if ((pennies * .01) > x) {
            pennies--;
            if (pennies == 1) {
                result += '1 penny'
            }
            if (pennies >= 1) {
                result += pennies + ' pennies'
            }
            break;
        }
        pennies++;
    }
    if (result.charAt(result.length - 2) == ',') {
        result = result.substring(0, result.length - 2);
    }
    return result;
}

function clearUp() {
    if ($('#currentMessage').val() == "Thank you!!!") {
        $('#currentMessage').val("");
        $('#itemIdNumber').val("");
        $('#changeMessage').val("");
    }
}
