$(() => {

    $("#confirmed").on('click', function () {

        const id = $(this).data('button-id');
        $.post('/home/UpdateConfirmed', { id: id }, function () {
            $.get('/home/getconfirmedCount', function (count) {
                $("#confirmedcounter").text(`(${count})`);
              $.get('/home/getpendingCount', function (count) {
                  $("#pendingcounter").text(`(${count})`);
                    });

            });
            $("#confirmed").hide();
            $("#refused").hide();
        });
    });
    $("#refused").on('click', function () {

        const id = $(this).data('refuse-id');
        $.post('/home/UpdateRefused', { id: id }, function () {
            $.get('/home/getCount', function (count) {
                $("#refusedcounter").html(`(${count})`);
                $.get('/home/getpendingCount', function (count) {
                    $("#pendingcounter").text(`(${count})`);
                });


            });
            $("#confirmed").hide();
            $("#refused").hide();
        });
    });
    $("#toggle").on('click', function () {
        $(".notes").toggle();
    });

});