
    $('#park-yes').click(function () {
        $('#Room_IsParking').prop('checked', true);
    $('#park-yes').toggleClass('btn-outline-primary btn-primary');
    $('#park-no').toggleClass('btn-primary btn-outline-primary');
});
    $('#park-no').click(function () {
        $('#Room_IsParking').prop('checked', false);
    $('#park-yes').toggleClass('btn-primary btn-outline-primary');
    $('#park-no').toggleClass('btn-outline-primary btn-primary');
});
        $('#pet-yes').click(function () {
        $('#Room_IsPetFriendly').prop('checked', true);
    $('#pet-yes').toggleClass('btn-outline-primary btn-primary');
    $('#pet-no').toggleClass('btn-primary btn-outline-primary');
});
    $('#pet-no').click(function () {
        $('#Room_IsPetFriendly').prop('checked', false);
    $('#pet-yes').toggleClass('btn-primary btn-outline-primary');
    $('#pet-no').toggleClass('btn-outline-primary btn-primary');
});
        $('#smoking-yes').click(function () {
        $('#Room_IsSmoking').prop('checked', true);
    $('#smoking-yes').toggleClass('btn-outline-primary btn-primary');
    $('#smoking-no').toggleClass('btn-primary btn-outline-primary');
});
    $('#smoking-no').click(function () {
        $('#Room_IsSmoking').prop('checked', false);
    $('#smoking-yes').toggleClass('btn-primary btn-outline-primary');
    $('#smoking-no').toggleClass('btn-outline-primary btn-primary');
});

    $('#Hydro').click(function () {
        if ($('#Utilities_HasHydro').prop("checked") == true) {
        $('#Utilities_HasHydro').prop('checked', false);
    $('#Hydro').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Utilities_HasHydro').prop('checked', true);
    $('#Hydro').toggleClass('btn-outline-primary btn-primary');
}
});
    $('#Airconditioning').click(function () {
        if ($('#Utilities_HasAirconditioning').prop("checked") == true) {
        $('#Utilities_HasAirconditioning').prop('checked', false);
    $('#Airconditioning').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Utilities_HasAirconditioning').prop('checked', true);
    $('#Airconditioning').toggleClass('btn-outline-primary btn-primary');
}
});
    $('#Water').click(function () {
        if ($('#Utilities_HasWater').prop("checked") == true) {
        $('#Utilities_HasWater').prop('checked', false);
    $('#Water').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Utilities_HasWater').prop('checked', true);
    $('#Water').toggleClass('btn-outline-primary btn-primary');
}
});
    $('#Heat').click(function () {
        if ($('#Utilities_HasHeat').prop("checked") == true) {
        $('#Utilities_HasHeat').prop('checked', false);
    $('#Heat').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Utilities_HasHeat').prop('checked', true);
    $('#Heat').toggleClass('btn-outline-primary btn-primary');
}
});
    $('#Wifi').click(function () {
        if ($('#Utilities_HasWifi').prop("checked") == true) {
        $('#Utilities_HasWifi').prop('checked', false);
    $('#Wifi').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Utilities_HasWifi').prop('checked', true);
    $('#Wifi').toggleClass('btn-outline-primary btn-primary');
}
});
    $('#TV').click(function () {
        if ($('#Utilities_HasTv').prop("checked") == true) {
        $('#Utilities_HasTv').prop('checked', false);
    $('#TV').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Utilities_HasTv').prop('checked', true);
    $('#TV').toggleClass('btn-outline-primary btn-primary');
}
});

    $('#Landuary').click(function () {
        if ($('#Appliances_HasLanduary').prop("checked") == true) {
        $('#Appliances_HasLanduary').prop('checked', false);
    $('#Landuary').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Appliances_HasLanduary').prop('checked', true);
    $('#Landuary').toggleClass('btn-outline-primary btn-primary');
}
});
    $('#Dryer').click(function () {
        if ($('#Appliances_HasDryer').prop("checked") == true) {
        $('#Appliances_HasDryer').prop('checked', false);
    $('#Dryer').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Appliances_HasDryer').prop('checked', true);
    $('#Dryer').toggleClass('btn-outline-primary btn-primary');
}
});
    $('#Dishwasher').click(function () {
        if ($('#Appliances_HasDishwasher').prop("checked") == true) {
        $('#Appliances_HasDishwasher').prop('checked', false);
    $('#Dishwasher').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Appliances_HasDishwasher').prop('checked', true);
    $('#Dishwasher').toggleClass('btn-outline-primary btn-primary');
}
});
    $('#Fridge').click(function () {
        if ($('#Appliances_HasFridge').prop("checked") == true) {
        $('#Appliances_HasFridge').prop('checked', false);
    $('#Fridge').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Appliances_HasFridge').prop('checked', true);
    $('#Fridge').toggleClass('btn-outline-primary btn-primary');
}
});
    $('#Microwave').click(function () {
        if ($('#Appliances_HasMicrowave').prop("checked") == true) {
        $('#Appliances_HasMicrowave').prop('checked', false);
    $('#Microwave').toggleClass('btn-primary btn-outline-primary');
        } else {
        $('#Appliances_HasMicrowave').prop('checked', true);
    $('#Microwave').toggleClass('btn-outline-primary btn-primary');
}
});
