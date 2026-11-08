// JavaScript source code
function setupSearch(hiddenValControlId, hiddenTextControlId, textControlId, selectorControlId, entityName, getQueryString) {

    // get the value from the text control
    var text = $("#" + textControlId).val();

    // set content of the hidden text control to match it
    $("#" + hiddenTextControlId).val(text);

    // if shown, hide the selector
    if (!$("#" + selectorControlId).is(":hidden")) {
        $("#" + selectorControlId).hide();
    }

    // setup "onblur" handler for the text control
    $("#" + textControlId).on("blur", function () {

        // get the value from the hidden text control
        var text = $("#" + hiddenTextControlId).val();

        // set content of the text control to match it
        $("#" + textControlId).val(text);
    });

    // setup "oninput" handler for the text control
    $("#" + textControlId).on("input", function () {

        // get the value from the text control
        var text = $("#" + textControlId).val();

        if (text.length == 0) {

            // value is blank - show just the default option
            $("#" + selectorControlId).empty();
            $("#" + selectorControlId).append('<option value="">None</option>');

            // if shown, hide the selector
            if (!$("#" + selectorControlId).is(":hidden")) {
                $("#" + selectorControlId).hide();
            }
        }
        else {

            var queryString = getQueryString();

            // get a list of suggestions
            $.ajax({
                url: "/api/" + entityName + "Search/" + text + queryString,
                type: "GET",
                success: function (data) {

                    // repopulate the selector
                    $("#" + selectorControlId).empty();
                    $("#" + selectorControlId).append('<option value="">None</option>');

                    for (i = 0; i < data.length; i++) {
                        $("#" + selectorControlId).append('<option value="' + data[i].pkString + '">' + data[i].valueString + '</option>');
                    }

                    // if hidden, show the selector
                    if ($("#" + selectorControlId).is(":hidden")) {
                        $("#" + selectorControlId).show();
                    }
                },
                error: function (error) {

                    // report the error
                    alert(error.message);
                }
            })
        }
    });

    // setup "onchange" handler for the selector
    $("#" + selectorControlId).on("change", function () {

        // clear values from the main controls
        $("#" + hiddenValControlId).val("");
        $("#" + hiddenTextControlId).val("");
        $("#" + textControlId).val("");
        $("option:selected", $(this)).each(function () {

            var text = $(this).text();
            if (text == "None") {
                text = "";
            }

            // populate the main controls
            $("#" + hiddenValControlId).val($(this).val());
            $("#" + hiddenTextControlId).val(text);
            $("#" + textControlId).val(text);

            // if shown, hide the selector
            if (!$("#" + selectorControlId).is(":hidden")) {
                $("#" + selectorControlId).hide();
            }
        });
    });
}
