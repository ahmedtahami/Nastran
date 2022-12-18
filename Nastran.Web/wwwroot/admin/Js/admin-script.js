$(function () {
    $('button[data-toggle="ajax-modal"]').click(function (e) {
        let modalElement = $('#modalElement');
        let url = $(this).data('url');
        $.get(url).done(function (data) {
            modalElement.html(data);
            modalElement.find('.modal').modal('show');
        });
    });
});
$(function () {
    $('button[data-toggle="modal-form"]').click(function (e) {
        debugger;
        var form = $(this).data('form-id');
        let url = $(this).data('url');
        var data = $(form).serialize();
        $.ajax({
            type: 'POST',
            url: url,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8', // when we use .serialize() this generates the data in query string format. this needs the default contentType (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') so it is optional, you can remove it
            data: data,
            success: function (result) {
                alert('Successfully received Data ');
                console.log(result);
            },
            error: function (result) {
                var errorObj = JSON.parse(result?.responseText);
                if (errorObj) {
                    displayValidationErrors(errorObj);
                }
            }
        })
    });
});
function displayValidationErrors(errors) {
    $.each(errors, function (idx, validationError) {
        $("span[data-valmsg-for='" + validationError.PropertyName + "']").text(validationError.ErrorList[0]);
    });
}
$('#CategoryId').on("change", function () {
    var categoryId = $('#CategoryId').val();
    if (categoryId != null && categoryId != "") {
        $.get("/Products/GetSubCategoriesByCategory", { CategoryId: categoryId }, function (data) {
            $('#SubcategoryId').empty();
            $('#SubcategoryId').append("<option value=''>" + "Select sub category" + "</option>");
            $.each(data, function (index, row) {
                $("#SubcategoryId").append("<option value='" + row.Id + "'>" + row.Name + "</option>")
            });
        })
    }
});
$('#ImagesList').on('change', function () {

    var previewimages = $("#display-images");
    previewimages.html("");
    $($(this)[0].files).each(function () {
        var file = $(this);
        var reader = new FileReader();
        reader.onload = function (e) {
            var img = $("<img />");
            img.attr("class", "file-upload-image");
            img.attr("src", e.target.result);
            previewimages.append(img);
        }
        reader.readAsDataURL(file[0]);
    });
});
$('#CoverImage').on('change', function () {

    var previewimages = $("#display-cover-images");
    previewimages.html("");
    $($(this)[0].files).each(function () {
        var file = $(this);
        var reader = new FileReader();
        reader.onload = function (e) {
            var img = $("<img />");
            img.attr("class", "file-upload-image");
            img.attr("src", e.target.result);
            previewimages.append(img);
        }
        reader.readAsDataURL(file[0]);
    });
});
$('#ImagePath').on('change', function () {

    var previewimages = $("#display-images");
    previewimages.html("");
    $($(this)[0].files).each(function () {
        var file = $(this);
        var reader = new FileReader();
        reader.onload = function (e) {
            var img = $("<img />");
            img.attr("class", "file-upload-image");
            img.attr("src", e.target.result);
            previewimages.append(img);
        }
        reader.readAsDataURL(file[0]);
    });
});
$('#SalePercentage').blur(function () {
    var price = $('#UnitPrice').val();
    var percentage = $('#SalePercentage').val();
    var discountedPrice = (parseFloat(percentage) * parseFloat(price)) / 100;
    var finalPrice = parseFloat(price) - parseFloat(discountedPrice);
    $('#DiscountedPrice').val(finalPrice);
});
$('#ProductSizes').chosen({
    placeholder_text_multiple: "Select sizes"
});
$('#ProductColors').chosen({
    placeholder_text_multiple: "Select colors"
});





//Custom scripts end
(function ($) {
    "use strict";
    $(".mobile-toggle").click(function () {
        $(".nav-menus").toggleClass("open");
    });
    $(".mobile-search").click(function () {
        $(".form-control-plaintext").toggleClass("open");
    });
    $(".form-control-plaintext").keyup(function (e) {
        if (e.target.value) {
            $("body").addClass("offcanvas");
        } else {
            $("body").removeClass("offcanvas");
        }
    });
})(jQuery);

$('.loader-wrapper').fadeOut('slow', function () {
    $(this).remove();
});

$(window).on('scroll', function () {
    if ($(this).scrollTop() > 600) {
        $('.tap-top').fadeIn();
    } else {
        $('.tap-top').fadeOut();
    }
});
$('.tap-top').click(function () {
    $("html, body").animate({
        scrollTop: 0
    }, 600);
    return false;
});

function toggleFullScreen() {
    if ((document.fullScreenElement && document.fullScreenElement !== null) ||
        (!document.mozFullScreen && !document.webkitIsFullScreen)) {
        if (document.documentElement.requestFullScreen) {
            document.documentElement.requestFullScreen();
        } else if (document.documentElement.mozRequestFullScreen) {
            document.documentElement.mozRequestFullScreen();
        } else if (document.documentElement.webkitRequestFullScreen) {
            document.documentElement.webkitRequestFullScreen(Element.ALLOW_KEYBOARD_INPUT);
        }
    } else {
        if (document.cancelFullScreen) {
            document.cancelFullScreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.webkitCancelFullScreen) {
            document.webkitCancelFullScreen();
        }
    }
}
(function ($, window, document, undefined) {
    "use strict";
    var $ripple = $(".js-ripple");
    $ripple.on("click.ui.ripple", function (e) {
        var $this = $(this);
        var $offset = $this.parent().offset();
        var $circle = $this.find(".c-ripple__circle");
        var x = e.pageX - $offset.left;
        var y = e.pageY - $offset.top;
        $circle.css({
            top: y + "px",
            left: x + "px"
        });
        $this.addClass("is-active");
    });
    $ripple.on(
        "animationend webkitAnimationEnd oanimationend MSAnimationEnd",
        function (e) {
            $(this).removeClass("is-active");
        });
})(jQuery, window, document);

$(".chat-menu-icons .toogle-bar").click(function () {
    $(".chat-menu").toggleClass("show");
});


/*=====================
 05. Image to background js
 ==========================*/
$(".bg-img").parent().addClass('bg-size');

jQuery('.bg-img').each(function () {

    var el = $(this),
        src = el.attr('src'),
        parent = el.parent();

    parent.css({
        'background-image': 'url(' + src + ')',
        'background-size': 'cover',
        'background-position': 'center',
        'display': 'block'
    });

    el.hide();
});
