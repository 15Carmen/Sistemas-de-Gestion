window.onload = comienzo;

//Creamos las clases Persona y Departamento con sus respectivos constructores
class Persona {
    constructor(id, foto, nombre, apellidos, fechaNac, direccion, telefono, idDepartamento) {
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

class Departamento {

    constructor(id, nombre) {
        this.id = id;
        this.nombre = nombre;
    }
}

//Guardamos en una variable las url de la api que vamos a usar
var urlApi = "http://localhost:5264/api/personas";
var urlApiDept = "http://localhost:5264/api/departamentos";

//Guardamos las variables globales de los elementos HTML que vamos a utilizar
var btnDetalles = document.getElementById("btnDetalles");
var tablaSimple = document.getElementById("tablaSimple");
var tablaDetalles = document.getElementById("tablaDetalles");

/**
 * Función donde estarán todos los metodos y funciones que se inicializan al cargarse
 * la página
 */
function comienzo() {
    //Método que rellena la tabla con los nombres y los apellidos de plas personas
    ListaPersonasSimple();

    //Cuando se clicke el boton se mostrarán los detalles de las personas seleccionadas
    btnDetalles.onclick = MostrarDetalles();

}

/**
 * Función que mustra el nombre y los apellidos de las personas
 * y además incluye el checkBox al final de cada una
 */
function ListaPersonasSimple() {

    var tbody = document.getElementById("tablaSimple");

    fetch(urlApi)
        .then(response => response.json()) //convertimos la respuesta en json
        .then(data => { //Aquí ya tenemos todos los datos de las personas

            data.forEach(persona => {
                // Creamos una fila por cada persona
                var fila = document.createElement('tr');
                fila.id = "fila";

                // Creamos celdas para el nombre y el apellido de la persona
                var nombreCell = document.createElement('td');
                nombreCell.textContent = persona.nombre
                fila.appendChild(nombreCell);

                var apellidosCell = document.createElement('td');
                apellidosCell.textContent = persona.apellidos;
                fila.appendChild(apellidosCell);

                //creamos un checkBox
                var checkBox = document.createElement('input');
                checkBox.type = 'checkBox';
                fila.appendChild(checkBox);

                //Añadimos la fila a la tabla
                tbody.appendChild(fila);

            });

            
        })   // Si hay aln error, lgúo mostramos en consola
        .catch(error => console.error('Error al obtener los datos de las personas:', error));

}

/**
 * Función que mostrará una lista con los detalles de las personas
 * si el checkBox de ellas ha sido seleccionado. Si ningún checkBox 
 * se selecciona, se mostrará una alerta indicándole al usuario que 
 * debe seleccionar a alguna persona primero
 */
function MostrarDetalles() {

    //Conseguimos la tabla del HTML
    var detalles = document.getElementById("divDetalles");
    var tbodyDetalles = document.getElementById("tablaDetalles");

    //Creamos una lista de personas seleccionadas
    var isCheck = [];

    //Recorremos la tablaSimple de personas y comprobamos si el checkBox está seleccionado
    tablaSimple.forEach(personaSimple => {
        //Si la persona tiene el checkBox seleccionado la añadimos al array de personas seleccionadas
        if (personaSimple.checkBox.value = true) {
            isCheck.push(personaSimple);

            //Cuando se clicke el botón aparecerá la tabla
            detalles.style.display = "block";
        }
    });


    fetch(urlApi)
        .then(responseDetalles => responseDetalles.json()) //Convertimos la respuesta en json
        .then(dataDetalles => { //Aquí ya tenemos todos los datos de las personas
            
            //Recorremos el array de datos de las personas 
            dataDetalles.forEach(personaDetalle => {

                //Recorremos el array de personas seleccionadas
                isChecked.forEach(personaCheck => {
                    //Si el id del listado de personas es igual al de seleccionadas 
                    if (personaDetalle.id == personaCheck.id) {
                        // Creamos una fila por cada persona
                        var fila = document.createElement('tr');
                        fila.id = "fila";

                        // Creamos celdas para el nombre, el apellido, la foto y el departamento de la persona
                        var nombreCell = document.createElement('td');
                        nombreCell.textContent = personaDetalle.nombre
                        fila.appendChild(nombreCell);

                        var apellidosCell = document.createElement('td');
                        apellidosCell.textContent = personaDetalle.apellidos;
                        fila.appendChild(apellidosCell);

                        var fotoCell = document.createElement('img');
                        fotoCell.src = personaDetalle.foto;
                        fila.appendChild(fotoCell);

                        var departamentoCell = document.createElement('td');

                        // Buscamos el departamento correspondiente a la persona
                        fetch(urlApiDept)
                            .then(responseDept => responseDept.json()) // Convertimos la respuesta a JSON
                            .then(dataDept => { // Aquí ya tenemos los datos de los departamentos

                                // Buscamos el departamento de la persona por su ID
                                var departamento = dataDept.find(departamento => departamento.id == personaDetalle.idDepartamento);

                                if (departamento) {
                                    departamentoCell.textContent = departamento.nombre; //Asignamos el nombre del departamento
                                } else {
                                    departamentoCell.textContent = "Departamento no encontrado";
                                }
                            })
                            .catch(error => console.error('Error al obtener los datos del departamento:', error));

                        fila.appendChild(departamentoCell);

                        // Añadimos la fila al tbody de la tabla
                        tbodyDetalles.appendChild(fila);

                    }
                });

            });

        })// Si hay algún error, lo mostramos en consola
        .catch(error => console.error('Error al obtener los datos de las personas:', error));


}