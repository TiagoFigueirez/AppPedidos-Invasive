document.addEventListener('DOMContentLoaded', function () {
    const checkbox = document.getElementById('checkbox_emergencial');
    const conteiner_dataProcedimento = document.getElementById('conteiner_dataProcedimento');
    const conteiner_horaProcedimento = document.getElementById('conteiner_horaProcedimento');
    const dataProcedimento = document.getElementById('DataProcedimento');
    const horaProcedimento = document.getElementById('HoraProcedimento');

    function esconderComandoHora() {
        if (checkbox.checked) {
            conteiner_dataProcedimento.style.display = 'none';
            conteiner_horaProcedimento.style.display = 'none';

            dataProcedimento.value = '';
            horaProcedimento.value = '';
        } else {
            conteiner_dataProcedimento.style.display = '';
            conteiner_horaProcedimento.style.display = '';
        }
    }
    esconderComandoHora();

    checkbox.addEventListener('change', function () {
        esconderComandoHora();
    });
});

document.addEventListener('DOMContentLoaded', function () {
    const alertBox = document.getElementById('alertId');

    if (alertBox) {
        setTimeout(function () {
            alertBox.classList.add('hidden');
        }, 3000);//na função setTimeout adicionamos uma function como parametro que terorna a classe para esconder e isso ocorre em 3 seg
    }
})