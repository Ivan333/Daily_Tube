$(function () {
    $("#MenuPocetna ul li:last-child").css({ "margin-left": "155px" });
    $('.videa').css('cursor', 'pointer');
    $('.videa').click(function () {
        $('html').css('overflow-y', 'hidden');
        var v = ($(this).find('.url')).text();
        if (v.indexOf("youtube") >= 0) {
            v = v.replace("watch?v=", "embed/");
        } else if (v.indexOf("dailymotion") >= 0) {
            v = v.replace("video", "embed/video");
        } else if (v.indexOf("vimeo") >= 0) {
            var tmp = v.split('/');
            v = "//player.vimeo.com/video/" + tmp[3];
        }
        $('.dispNone').val(v);
        $('.pozicija').css("display", "block");
        $('.labelPregledi').text(($(this).find('.brPreg')).text() + " прегледи");
        $('.labelVkRejting').text("Рејтинг: " + ($(this).find('.vkRejting')).text());
        $('.labelVData').text("Објавено на: " + ($(this).find('.vData')).text());
        $('.labelInfo').text("Канал: " + ($(this).find('.vKanal')).text() + " (" + ($(this).find('.vSajt')).text() + ")");
        $('.tbIdVideo').val($(this).find('.vId').text());
        $('.tbIdVideo').val($(this).find('.vId').text());
        $('.incrimentViews').click();
        $('.loadIframe').click();
    });
    $('.btnRemovePretplata').click(function () {
        var v = ($(this).parent().find('.kanalId')).val();
        $('.kanalId').val(v);
        $('.hiddeRemove').click();
    });
    $('.exitFloat').click(function () {
        $('.pozicija').css("display", "none");
        $('#ContentPlaceHolder1_GledanjeNaVidea_Label2').text("");
        $('#ContentPlaceHolder1_GledanjeNaVidea_rejtEror').text("");
        $('#ContentPlaceHolder1_GledanjeNaVidea_UpdatePanel1').html("");
        $('.removeIframe').click();
        $('html').css('overflow-y', 'scroll');
    });
    $('.buttonLeft').click(function () {
        ($(this).parent().find('.jqClass')).animate({
            scrollLeft: '-=400px'
        }, "fast")
    });
    $('.buttonRight').click(function () {
        ($(this).parent().find('.jqClass')).animate({
            scrollLeft: '+=400px'
        }, "fast")
    });
});