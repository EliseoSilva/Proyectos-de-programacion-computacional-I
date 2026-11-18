/*
 * Funciones generales de la WebApp academica.
 * Mantiene el esquema utilizado en clase: jQuery, fetch y vistas HTML separadas.
 */

let zIndexVentana = 1000;

// Registra los eventos una sola vez, aunque el archivo se vuelva a cargar.
function inicializarEventosWebApp() {
    if (window.eventosWebAppInicializados) {
        return;
    }

    window.eventosWebAppInicializados = true;

    // Abrir las vistas desde el menu principal.
    const menuAcademico = document.getElementById("mnxAcademica");

    if (menuAcademico) {
        menuAcademico.addEventListener("click", event => {
            const opcion = event.target.closest("a[data-form]");

            if (!opcion || !menuAcademico.contains(opcion)) {
                return;
            }

            event.preventDefault();
            abrirVentana(opcion.dataset.form);
        });
    }

    // Cerrar cualquier ventana que tenga el atributo data-ng-form.
    // Se usa delegacion porque los botones se insertan dinamicamente.
    document.addEventListener("click", event => {
        const botonCerrar = event.target.closest(".btn-close[data-ng-form]");

        if (!botonCerrar) {
            return;
        }

        event.preventDefault();
        cerrarVentana(botonCerrar.dataset.ngForm);
    });
}

// DOMContentLoaded puede haber ocurrido si este archivo se carga de forma tardia.
if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", inicializarEventosWebApp);
} else {
    inicializarEventosWebApp();
}

/**
 * Muestra una ventana y la coloca por encima de las que ya estan abiertas.
 */
function mostrarVentana($ventana) {
    zIndexVentana += 1;

    $ventana
        .css("z-index", zIndexVentana)
        .show();
}

/**
 * Carga una vista HTML dentro del contenedor que tiene el mismo ID.
 * Ejemplo: abrirVentana("busqueda_alumno") carga /views/busqueda_alumno.html.
 */
async function abrirVentana(form) {
    if (!form) {
        console.error("No se indico el nombre de la vista que se desea abrir.");
        return;
    }

    const contenedor = document.getElementById(form);

    if (!contenedor) {
        console.error(`No existe un contenedor con el ID #${form}.`);
        return;
    }

    if (typeof window.jQuery === "undefined") {
        console.error("jQuery no esta cargado. No se puede abrir la vista.");
        return;
    }

    const $ventana = $(contenedor);

    // Si la vista ya fue cargada, solamente se vuelve a mostrar.
    if ($ventana.find("form").length > 0) {
        mostrarVentana($ventana);
        return;
    }

    try {
        // La ruta comienza con / para que no se convierta en /views/views/...
        const urlVista = new URL(
            `/views/${encodeURIComponent(form)}.html`,
            window.location.origin
        );

        const respuesta = await fetch(urlVista, {
            method: "GET",
            cache: "no-cache"
        });

        if (!respuesta.ok) {
            throw new Error(
                `No se pudo cargar la vista ${form}. HTTP ${respuesta.status} ${respuesta.statusText}.`
            );
        }

        const vista = await respuesta.text();

        if (!vista.trim()) {
            throw new Error(`La vista ${form}.html esta vacia.`);
        }

        // jQuery inserta la vista, incluidos los scripts que forman parte de ella.
        $ventana.html(vista);
        mostrarVentana($ventana);

        // Conserva la ventana arrastrable como en el codigo utilizado en clase.
        if (typeof $ventana.draggable === "function") {
            if ($ventana.hasClass("ui-draggable")) {
                $ventana.draggable("destroy");
            }

            $ventana.draggable();
        }
    } catch (error) {
        console.error(`Error al abrir la vista "${form}":`, error);
    }
}

/**
 * Oculta la ventana indicada por data-ng-form.
 */
function cerrarVentana(form) {
    if (!form) {
        console.error("El boton de cierre no contiene data-ng-form.");
        return;
    }

    const contenedor = document.getElementById(form);

    if (!contenedor) {
        console.error(`No existe un contenedor para cerrar: #${form}.`);
        return;
    }

    $(contenedor).hide();
}

/**
 * Consulta los alumnos en el endpoint definido por AlumnosController.
 * El controlador usa [Route("api/[controller]")], [HttpGet("buscar")]
 * y recibe el parametro de consulta "buscar".
 */
async function obtenerAlumnos(buscar = "") {
    const urlApi = new URL("/api/Alumnos/buscar", window.location.origin);
    urlApi.searchParams.set("buscar", buscar ?? "");

    const respuesta = await fetch(urlApi, {
        method: "GET",
        headers: {
            Accept: "application/json"
        }
    });

    if (!respuesta.ok) {
        const detalle = await respuesta.text();
        const mensajeDetalle = detalle ? ` Respuesta del servidor: ${detalle}` : "";

        throw new Error(
            `Error al consultar alumnos. HTTP ${respuesta.status} ${respuesta.statusText}.${mensajeDetalle}`
        );
    }

    let alumnos;

    try {
        alumnos = await respuesta.json();
    } catch (error) {
        throw new Error(
            "La API de alumnos no devolvio un JSON valido. Revisa la respuesta del endpoint /api/Alumnos/buscar.",
            { cause: error }
        );
    }

    if (!Array.isArray(alumnos)) {
        throw new Error("La API de alumnos respondio, pero el resultado no es una lista.");
    }

    return alumnos;
}
