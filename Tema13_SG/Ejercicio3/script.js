window.onload = inicializaEvento;

var divMensaje;
var listaDepartamentos = [];

function inicializaEvento() {
  divMensaje = document.getElementById("btnLlamada");
  peticionDepartamentos();
}


/*
function rellenarTablaPersonas(arrayPersonas, arrayDepartamentos)
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
        
        while(arrayPersonas[i].idDepartamento == arrayDepartamentos[i].idDepartamento){
            columna.innerHTML = arrayDepartamentos[i].nombreDepartamento;
            fila.appendChild(columna);
        }

        tbody.appendChild(fila);    //añadimos la fila al body
        
    }
    tablaPersonas.appendChild(tbody);   //añadimos el body a la tabla de personas
    console.log(tbody);
}
*/

function peticionDepartamentos(){
    //punto 1
    let requestDepartamentos = new XMLHttpRequest();
    let tablaDepartamentos  = document.getElementById("tablaPersonas");
    
    //punto 2
    requestDepartamentos.open("GET", "https://crudnervion.azurewebsites.net/api/departamentos");

    //punto 4
    requestDepartamentos.onreadystatechange = function(){

        alert(requestDepartamentos.readyState)
        if(requestDepartamentos.readyState < 4){
            divMensaje.innerHTML = "Cargando..."
        }else if(requestDepartamentos.readyState == 4 && requestDepartamentos.status == 200){
            divMensaje.innerHTML = "";
            listaDepartamentos = JSON.parse(requestDepartamentos.responseText);
            rellenarTablaPersonas();
        }
    };

    //punto 5
    requestDepartamentos.send();
}

function rellenarTablaPersonas(){

    //punto 1
    let requestPersonas = new XMLHttpRequest();

    //punto 2
    requestPersonas.open("GET", "https://crudnervion.azurewebsites.net/api/personas")

    //punto 4
    requestPersonas.onreadystatechange = function(){

        alert(requestPersonas.readyState)
        if(requestPersonas.readyState < 4){
            divMensaje.innerHTML = "Cargando..."
        }else if(requestPersonas.readyState == 4 && requestPersonas.status == 200){
            divMensaje.innerHTML = "";
            
            let personaConDptm = JSON.parse(requestPersonas.responseText);

            while(){
                
            }
        }
    };

    //punto 5
    requestPersonas.send();
}


