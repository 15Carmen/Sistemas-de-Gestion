window.onload = inicializaEvento;

function inicializaEvento() {
    document.getElementById("btnBorrar").onclick = borrarPersona;
}

function borrarPersona(){

    //punto 1
    var miLlamada = new XMLHttpRequest();
    
    var divState = document.getElementById("divState");
    var idBorrar = document.getElementById("idBorrar").value;
    var divAlert = document.getElementById("divAlert");

    //punto 2
    miLlamada.open("DELETE", "https://crudnervion.azurewebsites.net/api/personas/"+idBorrar);

    //punto 4
    miLlamada.onreadystatechange = function () {
        
        alert(miLlamada.readyState);
        if(miLlamada.readyState < 4){
            divState.innerHTML = "Buscando persona...";
        }else if(miLlamada.readyState == 4 && miLlamada.status == 200){
            divState.innerHTML = "";
            divAlert.innerHTML = "Persona borrada con éxito";
        }else if(miLlamada.readyState == 4 && miLlamada.status == 405){
            divAlert.innerHTML = "Error al borrar la persona, Method Not Allowed";
        }else{
            divAlert.innerHTML = "Error al borrar la persona, Persona no encontrada";
        }
    };
    //Punto 5
    miLlamada.send();
}