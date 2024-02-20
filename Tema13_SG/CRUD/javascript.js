window.onload = comienzo;

//Guardamos en una variable la URL de la API de personas
var urlApi = 'https://crudnervion.azurewebsites.net/api/personas';
var urlApiDept = 'https://crudnervion.azurewebsites.net/api/departamentos';

var tablaPersonas = document.getElementById("tablaPersonas");
var btnAgregar = document.getElementById("btnAgregar");
var btnActualizar = document.getElementById("btnActualizar");
var btnBorrar = document.getElementById("btnBorrar");
var filasTabla = document.getElementById("filasTabla");
var persona = document.getElementsByTagName("tr");

/**
 * Funciones que se ejecutan al cargar la página
 */
function comienzo() {
   
    //Llenar la tabla con los datos de la base de datos
    listarPersonas();
    //Si se clickea una fila de la tabla, se selecciona
    //filasTabla.addEventListener("click", seleccionar, false);
}

function listarPersonas() {

    //Llamamos a la función que obtiene los datos de la API
    fetch(urlApi)
        .then(response => response.json()) //Convertimos la respuesta a JSON
        .then(data => { //Aquí ya tenemos los datos

            //Recorremos el array de datos
            data.forEach(persona => {
                //Creamos una fila por cada persona
                var fila = document.createElement('tr');
                fila.name = "fila";

                //Creamos celdas para cada dato de la persona
                var fotoCell = document.createElement('img');
                fotoCell.id = "fotoCell";

                var nombreCell = document.createElement('td');
                nombreCell.id = "nombreCell";

                var apellidosCell = document.createElement('td');
                apellidosCell.id = "apellidosCell";

                var fechaNacCell = document.createElement('td');
                fechaNacCell.id = "fechaNacCell";

                var direccionCell = document.createElement('td');
                direccionCell.id = "direccionCell";

                var telefonoCell = document.createElement('td');
                telefonoCell.id = "telefonoCell";

                var idDepartamentoCell = document.createElement('td');
                idDepartamentoCell.id = "idDepartamentoCell";

                fotoCell.src = persona.foto;
                nombreCell.innerHTML = persona.nombre;
                apellidosCell.innerHTML = persona.apellidos;
                fechaNacCell.innerHTM = persona.fechaNac;
                direccionCell.innerHTM = persona.direccion;
                telefonoCell.innerHTM = persona.telefono;
                idDepartamentoCell.innerHTM = persona.idDepartamento;

                fila.appendChild(fotoCell);
                fila.appendChild(nombreCell);
                fila.appendChild(apellidosCell);
                fila.appendChild(fechaNacCell);
                fila.appendChild(direccionCell);
                fila.appendChild(telefonoCell);
                fila.appendChild(idDepartamentoCell);

                var departamentoCell = document.createElement('td');
                
                //Buscamos el departamento de la persona
                fetch(urlApiDept)
                    .then(responseDept => responseDept.json()) // Convertimos la respuesta a JSON
                    .then(dataDept => { // Aquí ya tenemos los datos de los departamentos
                        
                        var departamento = dataDept.find(departamento => departamento.id == persona.idDepartamento);
                        
                        if (departamento) {
                            departamentoCell.innerHTM = departamento.nombre; //Asignamos el nombre del departamento
                        }else{
                            departamentoCell.innerHTM = "Departamento no encontrado";
                        }
                        
                    })
                    .catch(error => console.error('Error al obtener los datos del departamento:', error));
                
                    fila.appendChild(departamentoCell)
                
                filasTabla.appendChild(fila); //Añadimos la fila al body de la tabla
            });
        })
        //Si hay algún error, lo mostramos en consola
        .catch(error => console.error('Error al obtener los datos:', error));

    

}


