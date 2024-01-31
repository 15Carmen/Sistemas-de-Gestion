window.onload = inicializaEvento;

function inicializaEvento() {
  document.getElementById("btnLlamada").addEventListener("click", pedirNombre, false);
}

function rellenarTablaPersonas(arrayPersonas/*, arrayDepartamentos*/)
{
    var tablaPersonas = document.getElementById("tablaPersonas"); //cogemos la tabla
    var tbody = document.createElement("tbody"); //creamos el cuerpo de la tabla

    for (i = 0; i < arrayPersonas.length; i++) {

        var fila = document.createElement("tr"); //creamos la fila

        var columna = document.createElement("td"); //creamos la columna
        columna.innerHTML = arrayPersonas[i].nombre;   //le metemos el  a la columna
        fila.appendChild(columna);  //metemos la columna en la fila

        columna = document.createElement("td");
        columna.innerHTML = arrayPersonas[i].apellidos;
        fila.appendChild(columna);

        columna = document.createElement("td");
        columna.innerHTML = arrayPersonas[i].nombreDepartamento;
        fila.appendChild(columna);

        /*
        var departamento = arrayPersonas[i].idDepartamento  //guardamos el id del departamento de la persona
        columna = document.createElement("td") //creamos la columna
        columna.innerText = arrayDepart[departamento].nombre //le metemos el nombre del departamento
        fila.appendChild(contenido)
*/
        tbody.appendChild(fila);
        
    }
    tablaPersonas.appendChild(tbody);
    console.log(tbody);
}


function pedirNombre() {

    //punto 1
    var miLlamadaPersonas = new XMLHttpRequest();
    //var miLlamadaDepartamentos = new XMLHttpRequest();
    var divState = document.getElementById("divState");

    //punto 2
    miLlamadaPersonas.open("GET", "https://crudnervion.azurewebsites.net/api/personas", false);
    //miLlamadaDepartamentos.open("GET", "https://crudnervion.azurewebsites.net/api/departamentos", true);

    //punto 4
    miLlamadaPersonas.onreadystatechange = function () {

        alert(miLlamadaPersonas.readyState);
        if (miLlamadaPersonas.readyState < 4) {

            divState.innerHTML = "Pidendo datos...";

        } else if (miLlamadaPersonas.readyState == 4 && miLlamadaPersonas.status == 200) {

            var pedirResultado = JSON.parse(miLlamadaPersonas.responseText);
            //var pedirResultadoDepartamentos = JSON.parse(miLlamadaDepartamentos.responseText);
            
            rellenarTablaPersonas(pedirResultado/*, pedirResultadoDepartamentos*/);
            divState.innerHTML = "";
        }
    };

    //punto 5
    miLlamadaPersonas.send();
   //miLlamadaDepartamentos.send();
}