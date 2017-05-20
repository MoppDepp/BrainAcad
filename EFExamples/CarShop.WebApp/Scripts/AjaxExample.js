$(document).ready(function() {
    $("#loadTextBtn").on("click", loadText);

    function loadText(e, args) {
        toggleLoader(true);
        e.preventDefault();

        $.ajax({
            method: "GET",
            url: "/Ajax/LoadText",
            success: function(response) {
                $("#text").append(response);
                toggleLoader(false);
            },
            error: function(error) {
                alert("Error occured");
                $("#text").append(error.responseText);
            }
        });
    }

    function toggleLoader(showLoader) {
        if (showLoader) {
            $("#loader").removeClass("hidden");
        } else {
            $("#loader").addClass("hidden");
        }
    }
});