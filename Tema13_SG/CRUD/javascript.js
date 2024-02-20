window.onload = comienzo;

var tablaPersonas = document.getElementById("tablaPersonas");
var btnAgregar = document.getElementById("btnAgregar");
var btnActualizar = document.getElementById("btnActualizar");
var btnBorrar = document.getElementById("btnBorrar");
var filasTabla = document.getElementsById("filasTabla");
var nuevaPersona = document.getElementsByTagName("tr");

/**
 * Funciones que se ejecutan al cargar la página
 */
function comienzo() {
   
    //Llenar la tabla con los datos de la base de datos
    listarPersonas();
    //Si se clickea una fila de la tabla, se selecciona
    filasTabla.addEventListener("click", seleccionar, false);
}

function listarPersonas() {

    //Guardamos la URL de la API
    var url = "https://crudnervion.azurewebsites.net/api/personas";

    

}


