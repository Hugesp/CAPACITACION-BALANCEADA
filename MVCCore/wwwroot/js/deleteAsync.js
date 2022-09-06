var urlDelete;
var idDelete;

var DeleteAsync = function (event) {
    event.preventDefault();//Cancela comportamiento por default y se comporta como boton normal
    event.stopPropagation();//si hay dos acciones encimadas, esta función solo permite ejecutar una acción

    //Obtiene los datos desde el boton que se ejecute
    let target = event.target;
    let element = target.dataset.element;
    idDelete = target.dataset.id;

    document.getElementById('deleteTitle').innerHTML = `Eliminar`;
    document.getElementById('deleteMensaje').innerHTML = `¿Seguro de eliminar el registro ${element}?`;

    urlDelete = path + '/' + controller + '/delete'

    const elem = document.getElementById('deleteModal');
    const instance = M.Modal.init(elem, { dismissible: false });
    instance.open();
}

document.getElementById('btnDelete').addEventListener('click', function (e) {
    e.preventDefault();
    ConfirmDelete(ReloadTable);
});

function ConfirmDelete(callback) {//Manda a llamar una promesa 
    callDeleteAsync()
        .then(response => {//Pasa si se ejecuta correctamente
            var toastHTML =
                '<span>Registro eliminado correctamente</span><button class="btn-flat toast-action yellow-text">OK!</button>'
            M.toast({ html: toastHTML });
        })
        .catch(error => {//Pasa si se ejecuta con errores
            console.log('Error', error);
            var toastHTML = '<span>No se elimino el registro</span><button class="btn-flat toast-action red-text">Error!</button>'
            if (error.status === 409)//Errores personalizados, cuando en la base de datos el registro tiene dependencias
            {
                toastHTML = '<span>No puede eliminar el registro.</span><button class="btn-flat toast-action red-text">Error!</button>'
            }
            M.toast({ html: toastHTML });
        })
        .then(response => {//Siempre se ejecuta
            callback();//Funcion que yo puedo pasar como parametro en Js
        });
}

async function callDeleteAsync() {
    const formData = new FormData();
    formData.append('id', idDelete);
    //fetch proporciona una forma fácil y lógica de obtener recursos de forma asíncrona por la red.
    let response = await fetch(urlDelete, {
        method: 'POST',
        body: formData
    });

    if (response.ok) {
        return await response.json();
    } else {
        return Promise.reject({//Una peticcion fue rechazada
            status: response.status,
            statusText: response.statusText
        });
    }
}