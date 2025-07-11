addEventListener('load', inicio, false);

function inicio() {
	Id('btn-abrir-modal').addEventListener('click', activarModal, false);
	Id('btn-cerrar-modal').addEventListener('click', quitarModal, false);
	Id('aceptar-modal').addEventListener('click', quitarModal, false);
	alert('Js en funcionamiento');
	/*
	let padre;
	let abuelo;
	for (let x = 0; x < Class('simbolo-desplegar').length; x++) {
		Class('simbolo-desplegar')[x].addEventListener('click', function () {
			padre = this.parentElement;
			abuelo = padre.parentElement;
			despliegue(this, abuelo);
		}, false);
	}
	*/
}

//-------------------------------------------------------------------

function Id(elem) { return document.getElementById(elem); }
function Class(elem) { return document.getElementsByClassName(elem); }

function AlternarEstadoModal() {
	Id('ventana-modal').style == 'display:none;'? Id('ventana-modal').style = 'display:flex;': Id('ventana-modal').style = 'display:none;';
	return false;
}

function quitarModal(e) {
	e.preventDefault();
	Id('ventana-modal').style = 'display:none;'
}
function activarModal(e) {
	e.preventDefault();
	Id('ventana-modal').style = 'display:flex;'
}
function despliegue(simbolo, abu) {
	if (simbolo.innerHTML == '[+] ') {
		simbolo.innerHTML = '[-] ';
		abu.style = 'height:25em;';
	}
	else {
		simbolo.innerHTML = '[+] ';
		abu.style = 'height:2.5em;';
	}
}