window.onload = inicializaEvento;

function inicializaEvento() {
  //let button = document.getElementById("btnSaludar");
  //button.addEventListener("click", saludar, false);
  document.getElementById("btnLlamada").addEventListener("click", pedirNombre, false);
}

function pedirNombre() {

    //punto 1
    var miLlamada = new XMLHttpRequest();
    var divNombre = document.getElementById("divNombre");

    //punto 2
    miLlamada.open("GET", "https://crudnervion.azurewebsites.net/api/personas");

    //punto 4
    miLlamada.onreadystatechange = function () {

        alert(miLlamada.readyState);
        if (miLlamada.readyState < 4) {
            divNombre.innerHTML = "Cargando...";
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var pedirResultado = JSON.parse(miLlamada.responseText);
            divNombre.innerHTML = pedirResultado[4].nombre + " " + pedirResultado[4].apellidos;
        }
    };

    //punto 5
    miLlamada.send();
}