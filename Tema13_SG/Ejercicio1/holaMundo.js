window.onload = inicializaEvento

function inicializaEvento(){
    let button = document.getElementById("btnSaludar");
    button.addEventListener("click", saludar, false);
}

function saludar(){
    let miLlamada = new XMLHttpRequest();
    let divMensaje = document.getElementById("divMensaje")

    miLlamada.open("GET", "Hola.html")

    miLlamada.onreadystatechange = function(){
        if(miLlamada.readyState < 4){
            divMensaje.innerHTML = "Cargando..."
        }else if (miLlamada.readyState==4 && miLlamada.status == 200){
            let response = JSON.parse(miLlamada.responseText);
            divMensaje.innerHTML = response[1].nombre + " " + response[1].apellidos;
        }
    };

    miLlamada.send();
}