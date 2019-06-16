//functions 

function validaCPF(obj) {
    strCPF = obj.val();
    strCPF = strCPF.replace(/[^\d]+/g, '');
    var Soma;
    var Resto;
    var cboll = true;
    Soma = 0;

    if (strCPF.length != 11 ||
    strCPF == "00000000000" ||
    strCPF == "11111111111" ||
    strCPF == "22222222222" ||
    strCPF == "33333333333" ||
    strCPF == "44444444444" ||
    strCPF == "55555555555" ||
    strCPF == "66666666666" ||
    strCPF == "77777777777" ||
    strCPF == "88888888888" ||
    strCPF == "99999999999")
        cboll = false;


    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) cboll = false;

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) cboll = false;

    if (!cboll) {
        obj.css('border', '1px solid rgba(255,0,0,0.5)');
        $('.cpfErroMsg').show();
        obj.focus();
    } else {
        obj.css('border', '1px solid #CCC');
        $('.cpfErroMsg').hide();
        return cboll;
    }

}



$(document).ready(function () {

    $("option").each(function () {
        if ($(this).attr('title') == "" || $(this).attr('title') == undefined) {
            $(this).attr('title', $(this).text());
            $('.chosen').each(function () {
                $(this).trigger("chosen:updated");
            });
        }
    });
    $('.search-choice span').each(function () {
        if ($(this).attr('title') == "" || $(this).attr('title') == undefined) {
            $(this).attr('title', $(this).text());
        }
    });
    /*<![CDATA[*/
    jQuery(function ($) {
        jQuery('body').tooltip({ 'selector': 'a[rel=tooltip]' });
        jQuery('body').popover({ 'selector': 'a[rel=popover]' });
        $('.dropdown').hover(
                    function () {
                        $(this).addClass('open');
                        $('.navbar-collapse').collapse().height('auto');
                        $('#accordion').collapse().height('auto');
                        $('.nav-collapse').css('style', 'height: auto;');
                    },
                        function () { $(this).removeClass('open') }
                        );
        jQuery('.navbar-collapse').collapse({ 'parent': false, 'toggle': false });
    });

    $(function () {
        $("div[data-navigation='true']").find("li").children("a").each(function () {
            if ($(this).attr("href") === window.location.pathname) {
                $(this).parent().addClass("active");
            }
        });
    });

    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });
    $(function () {
        $('[data-toggle="popover"]').popover()
    });

    //Navbar Mobile
    $('.button-collapse').sideNav({
        menuWidth: 270, // Default is 240
        edge: 'left', // Choose the horizontal origin
        closeOnClick: false // Closes side-nav on <a> clicks, useful for Angular/Meteor
    });

    //Alertas
    $('#MsgSystem').find('.alert').each(function () { $(this).show('slow'); });
    $('#MsgSystemBag').find('.alert').each(function () { $(this).show('slow'); });

    //DatePicker MASK
    $(".DatePickerAttr").datepicker({
        format: "dd/mm/yyyy",
        language: "pt-BR"
    }).inputmask("99/99/9999");


    $(".grid-filter-datepicker").datepicker({
        language: "pt-BR"
    });


    //CPF MASK
    $(".cpf").inputmask("999.999.999-99").focusout(function () {
        validaCPF($(this));
    });

    //TELEFONE MASK
    $('.telefone').inputmask({ mask: ['(99) 9999-9999', '(99) 99999-9999'] });

    //CEP MASK
    $('.cep').inputmask("99999-999");


    //Cracha MASK
    //$('#Cracha').inputmask({ mask: ['9'] , repeat:12});

   


    //CHECKBOX AJUST
    $('.checkbox').each(function () {
        //se dentro da div checkbox ja tiver um label ( estilo view login/index)
        if ($(this).has('label').length && $(this).has('input[type="checkbox"]').length) {
            $(this).children('label').insertAfter($(this).children('input[type="checkbox"]'));
        } else {
            //se nao pegar o que o scafolding gera
            $(this).parents(".form-group").find('label').clone().removeAttr('class').html("").appendTo($(this));
            $(this).children('input[type="hidden"]').appendTo($(this));
            if ($(this).has('span').length) {
                $(this).children('span').appendTo($(this));
            }
        }
        //cor para todos
        if (!$(this).hasClass('checkbox-success')) { $(this).addClass("checkbox-success"); }
    });

    //SETUP HOME
    if ($('#homeObj').length > 0) {
        setupHome();
    }
});
//BTN upload
$(document).on('change', '.btn-file :file', function () {
    var input = $(this),
        numFiles = input.get(0).files ? input.get(0).files.length : 1,
        label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
    input.trigger('fileselect', [numFiles, label]);
});

//Setup HOME FUNCTIONS

function is_touch_device() {
    try {
        document.createEvent("TouchEvent");
        return true;
    } catch (e) {
        return false;
    }
}
function setupHome(){
    $("div[class^='btn']").height($('.col-md-2').height() - 10);
    if (is_touch_device()) {
        $('.col-md-2').on('click', function () {
            if ($(this).find('.vertical-align .itens').length) {
                $(this).find('.vertical-align .cen').toggle('fast');
                $(this).find('.vertical-align .itens').toggle('fast').css('display', 'flex');
            }
        });
    } else {
        $('.col-md-2').on('mouseenter', function () {
            if ($(this).find('.vertical-align .itens').length) {
                $(this).find('.vertical-align .cen').hide('fast');
                $(this).find('.vertical-align .itens').show('fast').css('display', 'flex');
            } else {
                if (!$(this).hasClass('click')) {
                    $(this).click(function () {
                        window.location = $(this).find('a').attr('href');
                    });
                }
            }
        });
        $('.col-md-2').on('mouseleave', function () {
            if ($(this).find('.vertical-align .itens').length) {
                $(this).find('.vertical-align .itens').hide('fast');
                $(this).find('.vertical-align .cen').show('fast').css('display', 'flex');
            }
        });
    }
}


/*##########################################################################################*
*  Funções não layout
* 
*/

$(function () {

    $('.list-group-item > .show-menu').on('click', function (event) {
        event.stopPropagation();
        event.preventDefault();
        var r = 0;
        $(this).closest('li').toggleClass('open');
        if ($(this).children('.glyphicon').hasClass('glyphicon-chevron-left')) {
            $(this).children('.glyphicon').removeClass('glyphicon-chevron-left');
            $(this).children('.glyphicon').addClass('glyphicon-chevron-right');
            var t = 0;
            $(this).parent().find('.list-group-submenu-item').each(function () {
                t++;
            });
            r = t * 41;
        } else {
            $(this).children('.glyphicon').addClass('glyphicon-chevron-left');
            $(this).children('.glyphicon').removeClass('glyphicon-chevron-right');

        }
        $(this).css('right', r);
    });
});
