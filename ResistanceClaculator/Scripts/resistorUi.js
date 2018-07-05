
function DisplayValidationErrors(errors) {
    if (!errors) {

        $('#errors').hide();
        return;
    }

    $('#errors').show();
    var $ul = $('div.validation-summary-valid > ul');
    $ul.empty();
    $.each(errors, function (idx, errorMessage) {
        $ul.append('<li>' + errorMessage + '</li>');
    });
}
function Calculate() {
    $("#result").html("");
    $('#errors').hide();
    var calcObj = {
        SelectedColorA: $('#A').val(),
        SelectedColorB: $('#B').val(),
        SelectedColorC: $('#C').val(),
        SelectedColorD: $('#D').val()
    };
    $.ajax({
        url: "/Home/Calculate",
        data: JSON.stringify(calcObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (output) {
            if (output.Success) {
                $("#result").html(output.Result);
            }
            else {
                DisplayValidationErrors(output.Errors);
            }
        },
        error: function (errormessage) {
            DisplayValidationErrors(errormessage);
        }
    })
};

 function SetResistorStripColor(selectBandId, selectedColor) {
    var defaultCss = { "background-color": '' };
    if (selectBandId == "A") {

        if (selectedColor) {
            $('#BandA').css({ "background-color": selectedColor });
        }
        else {
            $('#BandA').css(defaultCss);
        }
    }
    if (selectBandId == "B") {

        if (selectedColor) {
            $('#BandB').css({ "background-color": selectedColor });
        }
        else {
            $('#BandB').css(defaultCss);
        }
    }
    if (selectBandId == "C") {

        if (selectedColor) {
            $('#BandC').css({ "background-color": selectedColor });
        }
        else {
            $('#BandC').css(defaultCss);
        }
    }
    if (selectBandId == "D") {

        if (selectedColor) {
            $('#BandD').css({ "background-color": selectedColor });
        }
        else {
            $('#BandD').css(defaultCss);
        }
    }
}
$('.band-select').change(function () {
        $("#result").html("");
        var selectedBand = $(this).attr("id");
        var selectedColor = $(this).val();
          SetResistorStripColor(selectedBand, selectedColor);      
    });

$(document).ready(function () {
    $('#errors').hide();
});
