$(function () {
    drawCard = function () {
        console.log('test');
        $.ajax({
            href: "/Play",
            data: {
                model
            }
        })
    };
});