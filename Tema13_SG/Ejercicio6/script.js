// Función que se ejecuta al cargar la página
window.onload = inicializaEvento;

var listaMarcas = document.getElementById("marcaSelect"); //array donde se guardará la lista de marcas
var btnGuardar = document.getElementById("btnGuardar");   //botón de guardar
var divMarca = document.getElementById("divMarca");      //div donde se mostrará la lista de marcas

function inicializaEvento() {
    pedirMarcas();
    listaMarcas.addEventListener("change", muestraModelos, false);
    btnGuardar.addEventListener("click", cambiarPrecio, false);
}

/**
 * Función que muestra las diferentes marcas de coches que hay en la api
 * en un select
 */
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

            //Guardamos el json en una variable auxiliar
            let datos = JSON.parse(requestMarcas.responseText);
            
            let select = document.createElement('option');
            select.value = null;
            select.text = "Selecciona una marca";
            listaMarcas.appendChild(select);    
            
            //Recorremos los dotos
            for (let i = 0; i < datos.length; i++) {
                
                let marca = datos[i];
                let newOption = document.createElement("option");
                newOption.value = marca.idMarca;
                newOption.text = marca.nombre;
                listaMarcas.appendChild(newOption);
            }

        }
    };

    //punto 5
    requestMarcas.send();
}

/**
 * Función que mustra los modelos de la marca seleccionada anteriormente
 */
function muestraModelos() {

    //Guardamos el id de la marca seleccionada
    let idMarca = listaMarcas.options[listaMarcas.selectedIndex].value;

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
            let listaModelos = JSON.parse(requestModelos.responseText);

            var titulo = document.createElement("h3");
            titulo.textContent = "Modelos de la marca seleccionada:";
            document.body.appendChild(titulo);

            //Recorremos los modelos
            for (let i = 0; i < listaModelos.length; i++) {

                //Guardamos el modelo en una variable auxiliar
                let modelo = listaModelos[i];

                //Si el id de la marca seleccionada coincide con el id de la marca del modelo
                if (modelo.idMarca == idMarca) {
                    
                    var nombreModelo = document.createElement("label");
                    var precioModelo = document.createElement("input");

                    var br = document.createElement("br");
                    
                    document.body.appendChild(nombreModelo );
                    document.body.appendChild(precioModelo);
                    document.body.appendChild(br);

                    nombreModelo.textContent = modelo.nombre;
                    precioModelo.value = modelo.precio;
                }

            }
        }
    };

    //punto 5
    requestModelos.send();
}

/**
 * Función que guarda el nuevo precio del modelo en la api
 */
function cambiarPrecio(){

}




