window.onload=inicializaEventos; //para que en el momento en que se inicie la página salte esa función

function inicializaEventos(){
    document.getElementById("btnCambiar").addEventListener("click", cambiarTitulo, false)
}

function cambiarTitulo() {

    misH2=document.getElementsByTagName("h2");   
    misH2[0].innerHTML="Anacleto nunca falla";

    miBoton= document.getElementById("btnCambiar");

    miBoton.value= "Titulo cambiado";
    miBoton.disabled=true;

}