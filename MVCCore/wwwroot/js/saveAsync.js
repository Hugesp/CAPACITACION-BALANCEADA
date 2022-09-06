function SaveAsync(url, form, callback) {
    callAsync(url, form)
        .then(response => {
            var toastHTML = '<span>Información almacenada correctamente</span><button class="btn-flat toast-action red-text">Error!</button>'
            M.toast({ html: toastHTML });
        })
        .catch(error => {
            console.log('Error', error);
            var toastHTML = '<span>No se guardo el registro</span><button class="btn-flat toast-action red-text">Error!</button>'
            M.toast({ html: toastHTML });
        })
        .then(response => {
            callback();
            //$('#addEditModal').modal('close');
        });
}

async function callAsync(url, form) {
    //fetch proporciona una forma fácil y lógica de obtener recursos de forma asíncrona por la red.
    let response = await fetch(url, {
        method: 'POST',
        body: form
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