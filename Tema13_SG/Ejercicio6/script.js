/**
 * Vamos a realizar un ejercicio en el que debemos crear una BBDD, una API y una página que mediante AJAX se conecta a esa API.

Crear dos tablas en vuestro servidor SQL en Azure:
marcas (id (PK), nombre) 
modelos(id (pk), idMarca, nombre, precio)

Crear la API que con los Controllers y Actions que consideréis necesarios para realizar la página

Crear una página que permita modificar los precios de los modelos que pertenezcan a una marca seleccionada.
Lo primero que debe hacer el usuario es seleccionar una marca de coches.
Cuando seleccione una marca, aparecerá un listado de todos los modelos de esa marca con un texbox al lado de cada registro.
En ese textbox aparecerá el precio del coche, y el usuario podrá modificarlo.
El botón “Guardar” guardará las modificaciones hechas en los precios de los modelos. Si un modelo no ha sufrido cambios en su precio, no debe mandarse a guardar.
 */

//Para crear la página que permita modificar los precios de los modelos que pertenezcan a una marca seleccionada, necesitamos realizar los siguientes pasos:
//Lo primero que debe hacer el usuario es seleccionar una marca de coches.
//Cuando seleccione una marca, aparecerá un listado de todos los modelos de esa marca con un texbox al lado de cada registro.
//En ese textbox aparecerá el precio del coche, y el usuario podrá modificarlo.
//El botón “Guardar” guardará las modificaciones hechas en los precios de los modelos. Si un modelo no ha sufrido cambios en su precio, no debe mandarse a guardar.

// Función que se ejecuta al cargar la página
window.onload = inicializaEvento;

var listaMarcas = []; //array donde se guardará la lista de marcas
var divMarca;      //div donde se mostrará la lista de modelos

function inicializaEvento() {
    divMarca = document.getElementById("btnGuardar");

}

function pedirMarcas() {

    //punto 1
    let requestMarcas = new XMLHttpRequest();

    //punto 2
    requestMarcas.open("GET", "https://apiajax.azurewebsites.net/api/marcas");

    //punto 4
    requestMarcas.onreadystatechange = function () {

        if (requestMarcas.readyState < 4) {
            divMarca.innerHTML = "Cargando..."
        } else if (requestMarcas.readyState == 4 && requestMarcas.status == 200) {
            divMarca.innerHTML = "";

            //Guardamos la lista de marcas en un array
            listaMarcas = JSON.parse(requestMarcas.responseText);
            
            //Generamos el select con las marcas
            let select = document.createElement('selectMarca');
            select.value = null;
            select.text = "Selecciona una marca";
            listaMarcas.appendChild(select);

            //Recorremos el array de marcas
            for (let i = 0; i < listaMarcas.length; i++) {
                
                marcaSelect = listaMarcas[i];
                let option = document.createElement("option");
                option.value = marcaSelect.id;
                option.text = marcaSelect.nombre;
                listaMarcas.appendChild(option);
            }

            //Creamos el botón de mostrar modelos
            let button = document.createElement("button");
            button.innerHTML = "Mostrar modelos";
            button.id = "btnModelos";
            divListas.appendChild(button);
            button.addEventListener("click", muestraModelos, false);

        }
    };

    //punto 5
    requestMarcas.send();
}

function muestraModelos() {
    //punto 1
    let requestModelos = new XMLHttpRequest();

    //punto 2
    requestModelos.open("GET", "https://apiajax.azurewebsites.net/api/modelos");

    //punto 4
    requestModelos.onreadystatechange = function () {

        if (requestModelos.readyState < 4) {
            divMarca.innerHTML = "Cargando..."
        } else if (requestModelos.readyState == 4 && requestModelos.status == 200) {
            divMarca.innerHTML = "";
            //Guardamos la lista de modelos en un array
            listaModelos = JSON.parse(requestModelos.responseText);
            
        }
    };

    //punto 5
    requestModelos.send();
}




