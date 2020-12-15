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