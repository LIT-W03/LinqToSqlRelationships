$(function() {
    $(".show-cars").on('click', function() {
        var button = $(this);
        var personId = button.data('person-id');
        $("#cars-" + personId).toggle();
    });
});