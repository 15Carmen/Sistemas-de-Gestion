window.onload = inicializaEvento;

//Variables globales
var divMensaje;                 //div donde se mostrará la tabla de personas
var listaDepartamentos = [];    //array donde se guardará la lista de departamentos

function inicializaEvento() {
    // hacemos que para que se muestre la tabla de personas con el nombre de departamento al 
    // clicar al botón de "Llamada"
  divMensaje = document.getElementById("btnLlamada").onclick = peticionDepartamentos;
}

function peticionDepartamentos(){
    //punto 1
    let requestDepartamentos = new XMLHttpRequest();
    
    //punto 2
    requestDepartamentos.open("GET", "https://crudnervion.azurewebsites.net/api/departamentos");

    //punto 4
    requestDepartamentos.onreadystatechange = function(){

        //alert(requestDepartamentos.readyState)
        if(requestDepartamentos.readyState < 4){
            divMensaje.innerHTML = "Cargando..."
        }else if(requestDepartamentos.readyState == 4 && requestDepartamentos.status == 200){
            divMensaje.innerHTML = "";
            //Guardamos la lista de departamentos en un array
            listaDepartamentos = JSON.parse(requestDepartamentos.responseText);
            //Llamamos a la función que rellena la tabla de personas
            rellenarTablaPersonas();
        }
    };

    //punto 5
    requestDepartamentos.send();
}

function rellenarTablaPersonas(){

    //punto 1
    let requestPersonas = new XMLHttpRequest();

    //punto 2
    requestPersonas.open("GET", "https://crudnervion.azurewebsites.net/api/personas")

    //punto 4
    requestPersonas.onreadystatechange = function(){

        //alert(requestPersonas.readyState)
        if(requestPersonas.readyState < 4){
            divMensaje.innerHTML = "Cargando..."
        }else if(requestPersonas.readyState == 4 && requestPersonas.status == 200){
            divMensaje.innerHTML = "";
            
            //Creamos la tabla de personas con nombre de departamentos
            let personaConDptm = JSON.parse(requestPersonas.responseText); 

            //Mientras haya personas en la lista
            while(personaConDptm.length > 0){

                let persona = personaConDptm.pop();         //sacamos la ultima persona de la lista y la guardamos en persona 
                let fila = document.createElement("tr");    //creamos la fila
                let columna = document.createElement("td"); //creamos la columna
                columna.innerHTML = persona.nombre;         //le metemos el nombre a la columna
                fila.appendChild(columna);                  //metemos la columna en la fila

                columna = document.createElement("td");     //creamos una nueva columna
                columna.innerHTML = persona.apellidos;      //le metemos los apellidos a la columna
                fila.appendChild(columna);                  //metemos la columna en la fila

                columna = document.createElement("td");     //creamos una nueva columna
               
                //Buscamos el nombre de departamento que le corresponde a la persona
                for(i = 0; i < listaDepartamentos.length; i++){
                    if(persona.idDepartamento == listaDepartamentos[i].id){
                        columna.innerHTML = listaDepartamentos[i].nombre;   //le metemos el nombre del departamento a la columna
                    }
                }

                fila.appendChild(columna);                 //metemos la columna en la fila

                tabla.appendChild(fila);                    //añadimos la fila a la tabla de personas
            }
        }
    };

    //punto 5
    requestPersonas.send();
}


