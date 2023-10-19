$('.input-cpf').mask('000.000.000-00')
$('.input-phone').mask('(00) 0000-0000')

setTimeout(() => {
    $('.div-alert').remove();    
}, 5000)


function showCustomModal(title, body, primaryButtonText, secondaryButtonText, primaryButtonAction, secondaryButtonAction) {
    $('#modal-custom .modal-title').text(title);
    $('#modal-custom .modal-body p').empty();
    $('#modal-custom .modal-body p').append(body);
    $('#modal-custom .modal-footer .btn-primary').text(primaryButtonText);        
    $('#modal-custom .modal-footer .btn-primary').off('click').on('click', primaryButtonAction);

    if (!secondaryButtonText) {
        $('#modal-custom .modal-footer .btn-secondary').hide();   
    }
    else {
        $('#modal-custom .modal-footer .btn-secondary').show();
        $('#modal-custom .modal-footer .btn-secondary').text(secondaryButtonText);
        $('#modal-custom .modal-footer .btn-secondary').off('click').on('click', secondaryButtonAction);
    }
        
    $('#modal-custom').modal('show');
}


function showGenericAlert(message, type) {    
    var $alert = $('<div class="alert alert-' + type + '" role="alert">' + message + '</div>');
    
    var $alertContainer = $('<div class="div-alert"></div>').append($alert);
    
    $alert.on('click', function () {
        $alertContainer.remove();
    });
    
    $('body').append($alertContainer);
}


    $('.Popover').hover(function () {
        var content = $(this).data('content');
        var buttonPosition = $(this).offset();
        var buttonWidth = $(this).width();

        var popoverContainer = $('<div class="custom-popover"></div>');
        popoverContainer.html(content);
        popoverContainer.css({
            'z-index': 100000000000000,
            position: 'absolute',
            top: buttonPosition.top - 20,
            left: buttonPosition.left + buttonWidth + 20            
        });

        $('body').append(popoverContainer);

        $('.Popover, .custom-popover').on('mouseleave', function () {
            $('.custom-popover').remove();
        });

        popoverContainer.show();
    });
