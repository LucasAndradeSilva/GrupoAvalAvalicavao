$('.input-cpf').mask('000.000.000-00')

setTimeout(() => {
    $('.div-alert').remove();    
}, 5000)


    // Função para exibir a modal personalizada
    function showCustomModal(title, bodyText, primaryButtonText, secondaryButtonText, primaryButtonAction, secondaryButtonAction) {
        $('.modal-title').text(title);
        $('.modal-body p').text(bodyText);
        $('.modal-footer .btn-primary').text(primaryButtonText);
        $('.modal-footer .btn-secondary').text(secondaryButtonText);
        $('.modal-footer .btn-primary').off('click').on('click', primaryButtonAction);
        $('.modal-footer .btn-secondary').off('click').on('click', secondaryButtonAction);
        $('.modal').modal('show');
    }
