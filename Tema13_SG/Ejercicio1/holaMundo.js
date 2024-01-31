window.onload = inicializaEvento

function inicializaEvento(){
    let button = document.getElementById("btnSaludar");
    button.addEventListener("click", saludar, false);
}

function saludar(){
    //punto 1
    let miLlamada = new XMLHttpRequest();
    let divMensaje = document.getElementById("divMensaje")

    //punto 2
    miLlamada.open("GET", "http://127.0.0.1:5500/Ejercicio1/Hola.html")

    //punto 4
    miLlamada.onreadystatechange = function(){

        alert(miLlamada.readyState);
        if(miLlamada.readyState < 4){
            divMensaje.innerHTML = "Cargando..."
        }else if (miLlamada.readyState==4 && miLlamada.status == 200){
            
            divMensaje.innerHTML = this.responseText;
        }
    };

    //punto 5
    miLlamada.send();
}