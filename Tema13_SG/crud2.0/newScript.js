window.onload = function() {

    // Obtener referencias a los elementos del DOM
    const personasTable = document.getElementById('personasTable');
    const insertarPersonaBtn = document.getElementById('insertarPersonaBtn');
    const insertarPersonaModal = document.getElementById('insertarPersonaModal');
    const insertarPersonaForm = document.getElementById('insertarPersonaForm');
    const editarPersonaModal = document.getElementById('editarPersonaModal');
    const editarPersonaForm = document.getElementById('editarPersonaForm');

    const urlApiPersonas = 'https://crudnervion.azurewebsites.net/api/personas';
    const urlApiDepartamentos = 'https://crudnervion.azurewebsites.net/api/departamentos';


    /**
     * Función para mostrar las personas y sus departamentos en la tabla
     */
    function mostrarPersonasYDepartamentos() {
        // Limpiar la tabla antes de agregar los datos
        personasTable.querySelector('tbody').innerHTML = '';

        fetch(urlApiPersonas)
            .then(response => response.json())
            .then(personas => { //Obtenemos las personas
                fetch(urlApiDepartamentos)
                    .then(response => response.json())
                    .then(departamentos => {    //Obtenemos los departamentos

                        //Por cada persona, buscamos su departamento y lo mostramos en la tabla
                        personas.forEach(persona => {
                            //Buscamos el departamento de la persona
                            const departamentoPersona = departamentos.find(depto => depto.id === persona.idDepartamento);
                            //Guardamos el nombre del departamento o 'Sin departamento' si no tiene
                            const departamentoNombre = departamentoPersona ? departamentoPersona.nombre : 'Sin departamento';
                            //Indicamos que si la persona tiene foto, se muestre, si no, se muestre 'Sin foto'.
                            const fotoHTML = persona.foto ? `<img src="${persona.foto} " style="max-width: 100px;">` : 'Sin foto';
                            
                            //Creamos una nueva fila en la tabla con los datos de la persona
                            const newRow = personasTable.querySelector('tbody').insertRow();
                            newRow.innerHTML = `
                                <td>${persona.nombre}</td>
                                <td>${persona.apellidos}</td>
                                <td>${persona.fechaNac}</td>
                                <td>${persona.direccion}</td>
                                <td>${persona.telefono}</td>
                                <td>${fotoHTML}</td>
                                <td>${departamentoNombre}</td>
                                <td>
                                    <button class="editarBtn" data-id="${persona.id}">Editar</button>
                                    <button class="borrarBtn" data-id="${persona.id}">Borrar</button>
                                </td>
                            `;
                        });

                        //Cuando se haga clic en el botón de editar, se mostrará el modal de edición
                        document.querySelectorAll('.editarBtn').forEach(btn => {
                            btn.addEventListener('click', mostrarModalEditar);
                        });

                        //Cuando se haga clic en el botón de borrar, se borrará la persona
                        document.querySelectorAll('.borrarBtn').forEach(btn => {
                            btn.addEventListener('click', function(event) {
                                //Obtenemos el id de la persona a borrar
                                const personaId = event.target.getAttribute('data-id');
                                //Preguntamos si está seguro de borrar la persona
                                const confirmacion = confirm('¿Estás seguro de borrar esta persona?');
                                //Si acepta borrar la persona
                                if (confirmacion) {
                                    fetch(`https://crudnervion.azurewebsites.net/api/personas/${personaId}`, {
                                        method: 'DELETE'
                                    })
                                    .then(response => {
                                        if (response.ok) {  //Si todo ha ido bien se borra la persona
                                            console.log('Persona borrada correctamente');
                                            //Refrescamos la página para eliminar la persona de la tabla
                                            mostrarPersonasYDepartamentos();
                                        } else { //Si ha habido algún error se muestra por consola
                                            console.error('Error al borrar persona:', response.statusText);
                                        }
                                    })
                                    .catch(error => console.error('Error al borrar persona:', error));
                                }
                            });
                        });
                    })
                    .catch(error => console.error('Error al listar los departamentos:', error));
            })
            .catch(error => console.error('Error al listar las personas:', error));
    }

    // Función para cargar los nombres de los departamentos en los selct departamentos de los formularios
    function cargarNombresDepartamentos() {
        fetch(urlApiDepartamentos)
            .then(response => response.json())
            .then(departamentos => { //Obtenemos los departamentos
                //Obtenemos el select de departamentos
                const departamentoSelect = document.getElementById('departamento');
                //Limpiamos el select
                departamentoSelect.innerHTML = '';
                //Por cada departamento, creamos una opción en el select
                departamentos.forEach(departamento => {
                    departamentoSelect.innerHTML += `<option value="${departamento.id}">${departamento.nombre}</option>`;
                });
            })
            .catch(error => console.error('Error al listar los departamentos:', error));
    }

    //Llamamos a las funcines para mostrar datos al cargar la página
    mostrarPersonasYDepartamentos();
    cargarNombresDepartamentos();

    /**
     * Función para mostrar el modal de edición y cargar datos de la persona seleccionada
     */
    function mostrarModalEditar(event) {
        //Obtenemos el id de la persona a editar
        const personaId = event.target.getAttribute('data-id');

        fetch(`https://crudnervion.azurewebsites.net/api/personas/${personaId}`)
            .then(response => response.json())
            .then(persona => { //Obtenemos la persona
                fetch(urlApiDepartamentos)
                .then(response => response.json())
                .then(departamentos => {    //Obtenemos los departamentos

                    //Llenamos el formulario de edición con los datos de la persona
                    editarPersonaForm.innerHTML = `
                        <input type="hidden" name="id" value="${persona.id}">
                        <label for="nombre">Nombre:</label>
                        <input type="text" id="nombre" name="nombre" value="${persona.nombre}" required><br><br>
                        <label for="apellido">Apellidos:</label>
                        <input type="text" id="apellidos" name="apellidos" value="${persona.apellidos}" required><br><br>
                        <label for="fechaNac">Fecha de Nacimiento:</label>
                        <input type="text" id="fechaNac" name="fechaNac" value="${persona.fechaNac}" required><br><br>
                        <label for="direccion">Dirección:</label>
                        <input type="text" id="direccion" name="direccion" value="${persona.direccion}" required><br><br>
                        <label for="telefono">Teléfono:</label>
                        <input type="text" id="telefono" name="telefono" value="${persona.telefono}" required><br><br>
                        <label for="foto">Foto:</label>
                        <input type="text" id="foto" name="foto" value="${persona.foto}" required><br><br>
                        <label for="departamento">Departamento:</label>
                        <select id="departamento" name="departamento" required>
                            ${departamentos.map(depto => `<option value="${depto.id}" ${depto.id === persona.departamentoId ? 'selected' : ''}>${depto.nombre}</option>`).join('')}
                        </select><br><br>
                        <button type="submit">Guardar</button>
                    `;
                    editarPersonaModal.style.display = "block";
                })
                .catch(error => console.error('Error fetching departamentos:', error));
            })
            .catch(error => console.error('Error fetching persona for editing:', error));
    }

    /**
     * Evento para insertar una nueva persona
     */
    editarPersonaForm.addEventListener('submit', function() {
    
        /**
         * Guardamos en una variable los nuevos datos del formulario de la persona.
         * --------------------------------------------------------------
         * FormData es una interfaz en JavaScript recorre todos los elementos del formulario 
         * (editarPersonaForm) y recopila los valores de los campos del formulario en un 
         * objeto clave/valor. 
         * Cada campo del formulario se representa como un par clave/valor en el objeto FormData,
         * donde la clave es el atributo name del campo y el valor es el valor del campo.
         */
        const datosFormulario = new FormData(editarPersonaForm);
        //Obtenemos el id de la persona a editar
        const personaId = datosFormulario.get('id');
        //Creamos un objeto con los datos de la persona
        const personaEditada = {};

        //Recorremos los datos del formulario y los guardamos en el objeto personaEditada
        datosFormulario.forEach((value, key) => {
            personaEditada[key] = value;
        });

        fetch(`https://crudnervion.azurewebsites.net/api/personas/${personaId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(personaEditada) //Enviamos los datos de la persona editada
        })
        .then(response => {
            if (response.ok) {
                //Si todo ha ido bien se muestra por consola
                console.log('Persona editada correctamente');
                editarPersonaModal.style.display = "none"; //Se cierra el modal de edición
                // Refrescamos la página para mostrar a la persona editada
                mostrarPersonasYDepartamentos();
            } else {
                console.error('Error al editar persona:', response.statusText);
            }
        })
        .catch(error => console.error('Error al editar persona:', error));
    });

    /**
     * Función para mostrar el modal para insertar una nueva persona
     */
     insertarPersonaBtn.addEventListener('click', function() {
        insertarPersonaModal.style.display = "block";
    });

    /**
     * Evento para insertar una nueva persona en la api
     * --------------------------------------------------------------
     * 
     * Da un error 400 que no consigo solucionar, por lo que no se puede insertar una nueva persona.
     * Agradecería que me dijeras que es lo que falla.
     */
    insertarPersonaForm.addEventListener('submit', function(event) {

        event.preventDefault(); // Evitar que el formulario se envíe automáticamente

        // Capturar los datos del formulario utilizando FormData
        const datosFormulario = new FormData(insertarPersonaForm);

        // Convertir los datos del formulario en un objeto JSON
        const nuevaPersona = {};
        datosFormulario.forEach((value, key) => {
            nuevaPersona[key] = value;
        });

        // Enviar una solicitud HTTP POST a la API para insertar la nueva persona
        fetch(urlApiPersonas, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(nuevaPersona)
        })
        .then(response => {
            if (response.ok) {
                // Si la inserción fue exitosa, cerrar el modal y actualizar la tabla
                insertarPersonaModal.style.display = "none";
                mostrarPersonasYDepartamentos();
            } else {
                alert('Error al insertar persona');
            }
        })
        .catch(error => console.error('Error al insertar persona:', error));
    });

    // Cerrar el modal cuando se haga clic en la 'X'
    document.querySelector('.close').addEventListener('click', function() {
        editarPersonaModal.style.display = "none";
        insertarPersonaModal.style.display = "none";
    });
}
