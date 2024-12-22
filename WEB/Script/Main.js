document.addEventListener('DOMContentLoaded', function () {
    // Carregar menu lateral
    document.getElementById('menu-lateral').innerHTML = '';
    fetch('../Views/MenuLateral.html')
        .then(response => response.text())
        .then(data => {
            document.getElementById('menu-lateral').innerHTML = data;
        })
        .catch(error => console.error('Erro ao carregar o menu:', error));
});
