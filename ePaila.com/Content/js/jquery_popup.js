$(document).ready(function () {    
    $("#fa-comment").click(function () {
        $("#commentdiv").css("display", "block");
    });
    $("#comment #cancel").click(function () {
        $(this).parent().parent().hide();
    });
});