window.onload = function () {

    //Guardamos en una variable la URL de la API de personas
    var urlApi = 'https://crudnervion.azurewebsites.net/api/personas';

    //Llamamos a la función que obtiene los datos de la API
    fetch(urlApi)
        .then(response => response.json()) //Convertimos la respuesta a JSON
        .then(data => { //Aquí ya tenemos los datos

            //Guardamos en una variable el body de la tabla
            var tbody = document.getElementById('tbodyPersonas');

            //Recorremos el array de datos
            data.forEach(persona => {
                //Creamos una fila por cada persona
                var fila = document.createElement('tr');
                //Añadimos las columnas a la fila
                fila.innerHTML = `
                    <td>${persona.nombre}</td>
                    <td>${persona.apellidos}</td>                   
                `;
                //TODO: Poner el nombre del departamento
                tbody.appendChild(fila); //Añadimos la fila al body de la tabla
            });
        })
        //Si hay algún error, lo mostramos en consola
        .catch(error => console.error('Error al obtener los datos:', error));
};