window.onload = function () {

    //Guardamos en una variable la URL de la API de personas
    var urlApi = 'https://crudnervion.azurewebsites.net/api/personas';
    var urlApiDept = 'https://crudnervion.azurewebsites.net/api/departamentos';

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

                //Creamos celdas para cada dato de la persona
                var nombreCell = document.createElement('td');
                var apellidosCell = document.createElement('td');

                nombreCell.textContent = persona.nombre;
                apellidosCell.textContent = persona.apellidos;

                fila.appendChild(nombreCell);
                fila.appendChild(apellidosCell);

                var departamentoCell = document.createElement('td');
                
                //Buscamos el departamento de la persona
                fetch(urlApiDept)
                    .then(responseDept => responseDept.json()) // Convertimos la respuesta a JSON
                    .then(dataDept => { // Aquí ya tenemos los datos de los departamentos
                        
                        var departamento = dataDept.find(departamento => departamento.id == persona.idDepartamento);
                        
                        if (departamento) {
                            departamentoCell.textContent = departamento.nombre; //Asignamos el nombre del departamento
                        }else{
                            departamentoCell.textContent = "Departamento no encontrado";
                        }
                        
                    })
                    .catch(error => console.error('Error al obtener los datos del departamento:', error));
                
                    fila.appendChild
                
                tbody.appendChild(fila); //Añadimos la fila al body de la tabla
            });
        })
        //Si hay algún error, lo mostramos en consola
        .catch(error => console.error('Error al obtener los datos:', error));
};