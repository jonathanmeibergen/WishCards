// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () { changeText(); });


function changeBackground() {
    var imagePath = '/backgrounds/' + $('#WishCard_Background option:selected').val();
    $('#render_background').attr('src', imagePath);
}

function changeText() {
    var cardP = document.createElement('p');
    var text = $('#WishCard_Text').val();
    cardP.append(text);
    $('#render_text').empty();
    $('#render_text').append(cardP);
    changeTextColor();
}

function changeTextColor() {
    var color = $('#WishCard_TextColor').val();
    $('#render_text p').css('color', color);
}

function changeTypeFace() {
    var type = $('#WishCard_TypeFace').val();
    $('#render_text').removeClass();
    $('#render_text').addClass('type_' + type);

    //alert($('render_text:[class^="type_"]'));

    /*
    var arrClasses = [];
    $("render_text[class*='type_']").removeClass(function () { // Select the element divs which has class that starts with some-class-
        var className = this.className.match(/type_\d+/); //get a match to match the pattern some-class-somenumber and extract that classname
        if (className) {
            arrClasses.push(className[0]); //if it is the one then push it to array
            return className[0]; //return it for removal
        }
    });
    */
}

/**
 * Created by Malal91 and Haziel
 * Select multiple email by jquery.email_multiple
 * **/

(function ($) {

    $.fn.email_multiple = function (options) {

        let defaults = {
            reset: false,
            fill: false,
            data: null
        };

        let settings = $.extend(defaults, options);
        let email = "";

        return this.each(function () {
            $(this).after("<span class=\"to-input\">Email :</span>\n" +
                "<div class=\"all-mail\"></div>\n" +
                "<input type=\"text\" name=\"email\" class=\"enter-mail-id\" placeholder=\"Enter Email ...\" />");
            let $orig = $(this);
            let $element = $('.enter-mail-id');
            $element.keydown(function (e) {
                $element.css('border', '');
                if (e.keyCode === 13 || e.keyCode === 32) {
                    let getValue = $element.val();
                    if (/^[a-z0-9._-]+@[a-z0-9._-]+\.[a-z]{2,6}$/.test(getValue)) {
                        $('.all-mail').append('<span class="email-ids">' + getValue + '<span class="cancel-email">x</span></span>');
                        $element.val('');

                        email += getValue + ';'
                    } else {
                        $element.css('border', '1px solid red')
                    }
                }

                $orig.val(email.slice(0, -1))
            });

            $(document).on('click', '.cancel-email', function () {
                $(this).parent().remove();
            });

            if (settings.data) {
                $.each(settings.data, function (x, y) {
                    if (/^[a-z0-9._-]+@[a-z0-9._-]+\.[a-z]{2,6}$/.test(y)) {
                        $('.all-mail').append('<span class="email-ids">' + y + '<span class="cancel-email">x</span></span>');
                        $element.val('');

                        email += y + ';'
                    } else {
                        $element.css('border', '1px solid red')
                    }
                })

                $orig.val(email.slice(0, -1))
            }

            if (settings.reset) {
                $('.email-ids').remove()
            }

            return $orig.hide()
        });
    };

})(jQuery);