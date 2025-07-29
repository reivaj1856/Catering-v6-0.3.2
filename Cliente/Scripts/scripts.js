/*!
    * Start Bootstrap - SB Admin v7.0.7 (https://startbootstrap.com/template/sb-admin)
    * Copyright 2013-2023 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    // 
// Scripts
// 

function mostrarInvitados(tipoEvento) {
    document.getElementById("invitados").style.display = "flex";
    document.getElementById("galeria").style.display = "none";
    console.log("Evento seleccionado:", tipoEvento);
}

function mostrarMenu(cantidad) {
    document.getElementById("galeria").style.display = "block";
    console.log("Cantidad de invitados:", cantidad);
}
function selectCard(element) {
    // Quitar la clase "selected" de todos
    document.querySelectorAll('.d-flex.align-items-center').forEach(el => {
        el.classList.remove('selected');
    });

    // Agregar la clase "selected" al clicado
    element.classList.add('selected');
}

window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});

    
