$('.input-cpf').mask('000.000.000-00')
$('.input-phone').mask('(00) 0000-0000')

setTimeout(() => {
    $('.div-alert').remove();    
}, 5000)


function showCustomModal(title, bodyText, primaryButtonText, secondaryButtonText, primaryButtonAction, secondaryButtonAction) {
    $('.modal-title').text(title);
    $('.modal-body p').text(bodyText);
    $('.modal-footer .btn-primary').text(primaryButtonText);        
    $('.modal-footer .btn-primary').off('click').on('click', primaryButtonAction);

    if (!secondaryButtonText) {
        $('.modal-footer .btn-secondary').hide();   
    }
    else {
        $('.modal-footer .btn-secondary').show();
        $('.modal-footer .btn-secondary').text(secondaryButtonText);
        $('.modal-footer .btn-secondary').off('click').on('click', secondaryButtonAction);
    }
        
    $('.modal').modal('show');
}


function showGenericAlert(message, type) {    
    var $alert = $('<div class="alert alert-' + type + '" role="alert">' + message + '</div>');
    
    var $alertContainer = $('<div class="div-alert"></div>').append($alert);
    
    $alert.on('click', function () {
        $alertContainer.remove();
    });
    
    $('body').append($alertContainer);
}