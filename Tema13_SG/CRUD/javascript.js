window.onload = comienzo;

class Persona{
    constructor(id, foto, nombre, apellidos, fechaNac, direccion, telefono, idDepartamento){
        this.id = id;
        this.foto = foto;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNac = fechaNac;
        this.direccion = direccion;
        this.telefono = telefono;
        this.idDepartamento = idDepartamento;
    }
}

class Departamento{

    constructor(id, nombre){
        this.id = id;
        this.nombre = nombre;
    }
}

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

    //Si se clickea una fila de la tabla se selecciona
}

/**
 * Metodo que selecciona una persona de la tabla y al dejarla seleccionada
 * cambia el color de la fila y muestra el modal de editar
 */
function SeleccionarPersona(){

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

    //conseguimos la url de la API para insertar personas
    var urlApiInsert = 'https://crudnervion.azurewebsites.net/api/personas/';

    // Conseguimos el modal del HTML
    var modal = document.getElementById("myModal");

    // Conseguimos el elemento <span> que cierra el modal
    var spanInsert = document.getElementsByClassName("closeInsert")[0];

    //Conseguimos el botón de guardar
    var btnGuardarInsert = document.getElementById("btnGuardarInsert");

    //Cuando se clicka el botón, se abrirá el modal 
    modal.style.display = "block";

    //Creamos los input para cada campo de la persona 
    var inputFoto = document.getElementById("inputFotoInsert");
    var inputNombre = document.getElementById("inputNombreInsert");
    var inputApellidos = document.getElementById("inputApellidosInsert");
    var inputFechaNac = document.getElementById("inputFechaNacInsert");
    var inputDireccion = document.getElementById("inputDireccionInsert");
    var inputTelefono = document.getElementById("inputTelefonoInsert");
    var selectDepartamento = document.getElementById("selectDepartamentoInsert");

    //Llenamos el select con los departamentos
    fetch(urlApiDept)
        .then(responseDept => responseDept.json()) // Convertimos la respuesta a JSON
        .then(dataDept => { // Aquí ya tenemos los datos de los departamentos
    
                // Recorremos el array de datos de los departamentos
                dataDept.forEach(departamento => {
    
                    // Creamos una opción por cada departamento
                    var option = document.createElement('option');
                    option.value = departamento.id;
                    option.textContent = departamento.nombre;
    
                    // Añadimos la opción al select
                    selectDepartamento.appendChild(option);
                });
        })
        .catch(error => console.error('Error al obtener los datos del departamento:', error));


    //Cuando se clicka el botón de guardar, se guardará la persona, 
    // se subirán los datos a la base de datos y se cerrará el modal

    btnGuardarInsert.onclick = function() {

        //Creamos un objeto con los datos de la persona y lo rellenamos con los datos de los input
        var persona = new Persona(
            0,
            inputFoto.value,
            inputNombre.value,
            inputApellidos.value,
            inputFechaNac.value,
            inputDireccion.value,
            inputTelefono.value,
            selectDepartamento.value
        );

        //Llamamos a la función que sube los datos a la base de datos
        fetch(urlApiInsert, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(persona)
        })
        .then(response => {
           if(response.ok){
            
                // Cerramos el modal
                modal.style.display = "none";
                // Recargamos la página para que se actualice la tabla
                location.reload();
           }else{
               alert("Error al insertar la persona");
           }
        })        
        // Si hay algún error, lo mostramos en consola
        .catch(error => console.error('Error al insertar la persona:', error));

    }

    //Cuando se clicka el <span> (x), se cierra el modal
    spanInsert.onclick = function() {
        modal.style.display = "none";
    }

   //Cuando se clicka fuera del modal, se cierra
    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}
