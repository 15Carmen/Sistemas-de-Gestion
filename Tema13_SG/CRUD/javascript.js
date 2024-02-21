window.onload = comienzo;

//Guardamos en una variable la URL de la API de personas
var urlApi = 'https://crudnervion.azurewebsites.net/api/personas';
var urlApiDept = 'https://crudnervion.azurewebsites.net/api/departamentos';

var btnInasertar = document.getElementById("btnInsertar");
var persona = document.getElementsByTagName("tr");

/**
 * Funciones que se ejecutan al cargar la página
 */
function comienzo() {
   
    //Llenar la tabla con los datos de la base de datos
    ListarPersonas();

    //Si se clickea el botón de agregar, se abre el modal
    btnInasertar.addEventListener("click", AgregarPersona);

    //Si se clickea una fila de la tabla, se selecciona

}

function ListarPersonas() {

   // Llamamos a la función que obtiene los datos de la API de personas
   fetch(urlApi)
   .then(response => response.json()) // Convertimos la respuesta a JSON
   .then(data => { // Aquí ya tenemos los datos de las personas

       // Guardamos en una variable el body de la tabla
       var tbody = document.getElementById('tablaPersonas');

       // Recorremos el array de datos de las personas
       data.forEach(persona => {

           // Creamos una fila por cada persona
           var fila = document.createElement('tr');
           fila.id = "fila";

           var fotoCell = document.createElement('img');
           fotoCell.src = persona.foto;
           fila.appendChild(fotoCell);

           // Creamos celdas para cada dato de la persona
           var nombreCell = document.createElement('td');
           nombreCell.textContent = persona.nombre
           fila.appendChild(nombreCell);

           var apellidosCell = document.createElement('td');
           apellidosCell.textContent = persona.apellidos;
           fila.appendChild(apellidosCell);

           var fechaNacCell = document.createElement('td');
           fechaNacCell.textContent = persona.fechaNac;
           fila.appendChild(fechaNacCell);

           var direccionCell = document.createElement('td');
           direccionCell.textContent = persona.direccion;
           fila.appendChild(direccionCell);
        
           var telefonoCell = document.createElement('td');
           telefonoCell.textContent = persona.telefono;
           fila.appendChild(telefonoCell);

           var idDepartamentoCell = document.createElement('td');
           idDepartamentoCell.textContent = persona.idDepartamento;
           fila.appendChild(idDepartamentoCell);

           var departamentoCell = document.createElement('td');

           // Buscamos el departamento correspondiente a la persona
           fetch(urlApiDept)
               .then(responseDept => responseDept.json()) // Convertimos la respuesta a JSON
               .then(dataDept => { // Aquí ya tenemos los datos de los departamentos

                   // Buscamos el departamento de la persona por su ID
                   var departamento = dataDept.find(departamento => departamento.id == persona.idDepartamento);
                        
                   if (departamento) {
                       departamentoCell.textContent = departamento.nombre; //Asignamos el nombre del departamento
                   }else{
                       departamentoCell.textContent = "Departamento no encontrado";
                   }
               })
               .catch(error => console.error('Error al obtener los datos del departamento:', error));

           fila.appendChild(departamentoCell);

           // Añadimos la fila al tbody de la tabla
           tbody.appendChild(fila);
       });
   })
   // Si hay algún error, lo mostramos en consola
   .catch(error => console.error('Error al obtener los datos de las personas:', error));

    

}

function AgregarPersona(){
    // Conseguimos el modal del HTML
    var modal = document.getElementById("myModal");

    // Conseguimos el elemento <span> que cierra el modal
    var span = document.getElementsByClassName("close")[0];

    //Cuando se clicka el botón, se abrirá el modal 
    modal.style.display = "block";

    //Cuando se clicka el <span> (x), se cierra el modal
    span.onclick = function() {
        modal.style.display = "none";
    }

   //Cuando se clicka fuera del modal, se cierra
    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}
