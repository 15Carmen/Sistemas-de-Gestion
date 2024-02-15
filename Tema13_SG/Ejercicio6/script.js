// Función que se ejecuta al cargar la página
window.onload = inicializaEvento;

var listaMarcas = document.getElementById("marcaSelect"); //array donde se guardará la lista de marcas
var listaModelosMarca = [];                               //array donde se guardará la lista de modelos
var btnGuardar = document.getElementById("btnGuardar");   //botón de guardar
var divMarca = document.getElementById("divMarca");       //div donde se mostrará la lista de marcas
var divModelo = document.getElementById("divModelo");     //div donde se mostrará la lista de modelos

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

    //punto 2. Conseguimos los modelos de la marca seleccionada
    requestModelos.open("GET", "https://apiajax.azurewebsites.net/api/modelos/byMarca/" + idMarca);

    //punto 4
    requestModelos.onreadystatechange = function () {

        if (requestModelos.readyState < 4) {
            divModelo.innerHTML = "Cargando..."
        } else if (requestModelos.readyState == 4 && requestModelos.status == 200) {
            divModelo.innerHTML = "";

            //Guardamos la lista de modelos en un array
            let listaModelosPorMarca = JSON.parse(requestModelos.responseText);

            var titulo = document.createElement("h3");
            titulo.textContent = "Modelos de la marca seleccionada:";
            divModelo.appendChild(titulo);

            //Recorremos los modelos
            for (let i = 0; i < listaModelosPorMarca.length; i++) {

                //Guardamos el modelo en una variable auxiliar
                let modelo = listaModelosPorMarca[i];

                //Si el id de la marca seleccionada coincide con el id de la marca del modelo
                if (modelo.idMarca == idMarca) {
                    
                    //Creamos las etiquetas que necesitaremos para mostrar los modelos
                    var nombreModelo = document.createElement("label");
                    var precioModelo = document.createElement("input");
                    var br = document.createElement("br");
                    
                    //añadimos las etiquetas al div
                    divModelo.appendChild(nombreModelo );
                    divModelo.appendChild(precioModelo);
                    divModelo.appendChild(br);

                    //Añadimos los valores a las etiquetas
                    nombreModelo.textContent = modelo.nombre;
                    precioModelo.value = modelo.precio;
                
                    //Añadimos el modelo al array de modelos
                    listaModelosMarca.push(modelo);
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

   //Recorremos la lista de modelos
   for(let i = 0; i < listaModelosMarca.length; i++){

       //Guardamos el modelo en una variable auxiliar
       let modeloActualizado = listaModelosMarca[i];

       //Guardamos el precio que ha introducido el usuario
       let precioActualizado = document.getElementsByTagName("input")[i].value

       //Si el precio introducido es diferente al precio actual
        if(modeloActualizado.precio != precioActualizado){
            //Guardamos el precio actualizado
            modeloActualizado.precio = precioActualizado;
        }
       

       //punto 1
       let requestPrecio = new XMLHttpRequest();

       //punto 2
       requestPrecio.open("PUT", "https://apiajax.azurewebsites.net/api/modelos/" + modeloActualizado.idModelo);

       //punto 3
       requestPrecio.setRequestHeader("Content-Type", "application/json");

       //punto 4
       requestPrecio.onreadystatechange = function () {

           if (requestPrecio.readyState < 4) {
               divModelo.innerHTML = "Cargando..."
           } else if (requestPrecio.readyState == 4 && requestPrecio.status == 200) {
               divModelo.innerHTML = "Precio actualizado";
           }
       };

       //punto 5
       requestPrecio.send(JSON.stringify(modeloActualizado));
   }

}




