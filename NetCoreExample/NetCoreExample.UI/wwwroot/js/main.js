var myJS = {};

myJS.showLoading = function (title, message) {
    $("#loader").hide();
    if (!!title)
        $("#loadertitle").text(title);

    if (!!message)
        $("#loadermsg").text(message);

    $("#loader").show();
};

myJS.hideLoading = function () {
    $("#loader").hide();
};


(function ($) {
    "use strict";

    $(".event-map").on('mouseleave', function (event) {
        $('.event-map iframe').css("pointer-events", "none");
    });

    // Textbox Clear
    $(".hasclear").on('keyup', function (event) {
        var t = $(this);
        t.next('span').toggle(Boolean(t.val()));
    });

    $(".clearer").hide($(this).prev('input').val());

    // Price Range Slider
    $("#price-range").slider({
        tooltip: 'always',
        tooltip_split: true,
        formatter: function (value) {
            return '$ ' + value;
        }
    });

    $(activate);
    function activate() {
        $('.event-tabs')
            .scrollingTabs({
                scrollToTabEdge: true
            })
            .on('ready.scrtabs', function () {
                $('.tab-content').show();
            });
    }

    $('.hero-2 .count-down').countdown('2017/04/26').on('update.countdown', function (event) {
        var $this = $(this).html(event.strftime('<li>%D <span>day%!d</span></li>'
            + '<li>%H <span>hours</span></li>'
            + '<li>%M <span>minutes</span></li>'
            + '<li>%S <span>seconds</span></li>'));
    });

    // The slider being synced must be initialized first
    $('#carousel').flexslider({
        animation: "slide",
        controlNav: false,
        animationLoop: false,
        slideshow: false,
        itemWidth: 160,
        itemMargin: 5,
        asNavFor: '#slider'
    });

    $('#slider').flexslider({
        animation: "slide",
        controlNav: false,
        directionNav: false,
        animationLoop: false,
        slideshow: false,
        sync: "#carousel"
    });

    $('.evet-ticket').flexslider({
        animation: "slide"
    });

    $("a,section,div,span,li,input[type='text'],input[type='button'],tr,button").on("click", function () {

        if ($(this).hasClass("event-map")) {
            $('.event-map iframe').css("pointer-events", "auto");
        }

        if ($(this).hasClass("select-seat")) {
            $(this).siblings().removeClass("selected");
            $(this).addClass('selected');
        }

        if ($(this).hasClass("clearer")) {
            $(this).prev('input').val('').focus();
            $(this).hide();
        }

        if ($(this).hasClass("qty-btn")) {
            var $button = $(this);
            var oldValue = $button.closest('.qty-select').find("input.quantity-input").val();

            if ($button.text() === "+") {
                var newVal = parseFloat(oldValue) + 1;
            } else {
                // Don't allow decrementing below zero
                if (oldValue > 1) {
                    var newVal = parseFloat(oldValue) - 1;
                } else {
                    newVal = 1;
                }
            }
            $button.closest('.qty-select').find("input.quantity-input").val(newVal);
            return false;
        }

        if ($(this).hasClass("closecanvas")) {
            $("body").removeClass("offcanvas-stop-scrolling");
        }
    });


    $('#showcate-list').click(function () {
        $('.menu-open').slideToggle("fast");
    });


    /* ------------------------------------------------------------------------ 
       Adn idification
    ------------------------------------------------------------------------ */
    $('#select-all-payment').click(function (event) {
        if (this.checked) {
            // Iterate each checkbox
            $(':checkbox').each(function () {
                this.checked = true;
            });
        } else {
            $(':checkbox').each(function () {
                this.checked = false;
            });
        }
    });


    /* ------------------------------------------------------------------------ 
       SEARCH OVERLAP
    ------------------------------------------------------------------------ */
    jQuery('.adopen-open').on('click', function () {
        jQuery('.adopen-inside').fadeIn();
    });
    jQuery('.adopen-close').on('click', function () {
        jQuery('.adopen-inside').fadeOut();
    });

    // Load menu
    var loadMenu = function () {
        myJS.showLoading();
        $.ajax({
            url: "/api/v1/menu",
            method: "GET",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            cache: true,
            success: function (result) {
                myJS.hideLoading();
                if (!!result && result.length > 0) {
                    var parentText = "";
                    $.each(result, function (idx, item) {
                        if (!item.ParentId) {
                            parentText += '<li id="menu_' + item.Id + '" menutype="menulevel1">' + item.Descriptions + '</li>';
                        }
                    });
                    $("#main-menu").html("<ul>" + parentText + "</ul>");

                    $.each(result, function (idx, item) {
                        if (!!item.ParentId) {
                            var parentItem = $("#main-menu ul").find("#menu_" + item.ParentId);

                            // replace parent menu (root menu)
                            if (parentItem.length > 0) {
                                if ($(parentItem).attr("menutype") === "menulevel1") {
                                    var tmpHtml = "";
                                    if ($(parentItem).find(".containermenulvl1").children().length < 1) {
                                        var parentTitle = $(parentItem).text();
                                        tmpHtml = '<div class="dropdown">';
                                        tmpHtml += '<a class="dropdown-toggle" href="#." id="all-cat-btn" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">' + parentTitle + ' <i class="fa fa-angle-down"></i></a>';
                                        tmpHtml += '<div class="dropdown-menu" aria-labelledby="all-cat-btn"><div class="inside-menu"><div class="row containermenulvl1">';
                                        tmpHtml += '<div class="col-md-3 menulevel2" menutype="menulevel2" id="menu_' + item.Id + '"><h4>' + item.Descriptions + '</h4><div class="containermenulvl2">';
                                        tmpHtml += '</div></div>';
                                        tmpHtml += '</div></div></div>';
                                        tmpHtml += '</div>';               
                                        $(parentItem).html(tmpHtml);
                                    } else {
                                        tmpHtml += '<div class="col-md-3 menulevel2" menutype="menulevel2" id="menu_' + item.Id + '"><h4>' + item.Descriptions + '</h4><div class="containermenulvl2">';
                                        tmpHtml += '</div></div>';
                                        $(parentItem).find(".containermenulvl1").append(tmpHtml);
                                    }                                    
                                }

                                if ($(parentItem).attr("menutype") === "menulevel2") {
                                    if ($(parentItem).find(".containermenulvl2").children().length < 1) {
                                        $(parentItem).find(".containermenulvl2").html('<a href="#" menutype="menulevel3">' + item.Descriptions + '</a>');
                                    } else {
                                        $(parentItem).find(".containermenulvl2").append('<a href="#" menutype="menulevel3">' + item.Descriptions + '</a>');
                                    }
                                }
                            }                        
                        }
                    });
                } else {
                    alert("Sorry! menu data is not found...");
                }
            },
            error: function (result) {
                myJS.hideLoading();
                console.error(result);
                alert("Ups! something went wrong...");
            }
        });
    };
    loadMenu();
})(jQuery);