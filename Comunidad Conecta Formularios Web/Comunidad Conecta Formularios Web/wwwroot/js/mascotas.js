
const galeria = document.getElementById("galeriaMascotas");
const buscar = document.getElementById("buscarMascota");
const filtroEstado = document.getElementById("filtroEstado");
const filtroEspecie = document.getElementById("filtroEspecie");
const modal = document.getElementById("modalMascota");
const modalDetalles = document.getElementById("modalDetalles");
const formulario = document.getElementById("formMascota");

let siguienteId = 4;

let mascotas = [
    {
        id: 1,
        nombre: "Max",
        especie: "Perro",
        estado: "Perdida",
        fecha: "2026-10-21",
        ubicacion: "San Salvador, Centro",
        contacto: "Contacto de demostración 1",
        imagen: "https://images.unsplash.com/photo-1552053831-71594a27632d?w=700",
        descripcion: "Perro de color dorado. Se busca ayuda para localizarlo."
    },
    {
        id: 2,
        nombre: "Luna",
        especie: "Gato",
        estado: "En adopción",
        fecha: "2026-10-20",
        ubicacion: "San Miguel",
        contacto: "Contacto de demostración 2",
        imagen: "https://images.unsplash.com/photo-1573865526739-10659fec78a5?w=700",
        descripcion: "Gatita en busca de un hogar responsable."
    },
    {
        id: 3,
        nombre: "Rocky",
        especie: "Perro",
        estado: "Encontrada",
        fecha: "2026-10-19",
        ubicacion: "Santa Ana",
        contacto: "Contacto de demostración 3",
        imagen: "https://images.unsplash.com/photo-1543466835-00a7907e9de1?w=700",
        descripcion: "Perro encontrado. Se busca a su familia."
    }
];

const obtenerFechaLocal = () => {
    const fecha = new Date();
    return new Date(fecha.getTime() -
        fecha.getTimezoneOffset() * 60000)
        .toISOString().slice(0, 10);
};

function escapar(texto) {
    return String(texto).replace(/[&<>"']/g, c => ({
        "&": "&amp;",
        "<": "&lt;",
        ">": "&gt;",
        '"': "&quot;",
        "'": "&#39;"
    })[c]);
}

function formatoFecha(fecha) {
    if (!fecha) return "Sin fecha";
    const [a, m, d] = fecha.split("-");
    return `${d}/${m}/${a}`;
}

function claseEstado(estado) {
    if (estado === "Encontrada") return "estado-entregada";
    if (estado === "En adopción") return "estado-disponible";
    return "estado-proceso";
}

function actualizarResumen() {
    document.getElementById("totalMascotas").textContent =
        mascotas.length;

    document.getElementById("totalPerdidas").textContent =
        mascotas.filter(m => m.estado === "Perdida").length;

    document.getElementById("totalAdopcion").textContent =
        mascotas.filter(m => m.estado === "En adopción").length;
}

function renderizarMascotas() {
    const termino = buscar.value.trim().toLocaleLowerCase("es");

    const resultados = mascotas.filter(m => {
        const coincideTexto = [
            m.nombre, m.especie, m.ubicacion, m.descripcion
        ].some(valor =>
            valor.toLocaleLowerCase("es").includes(termino)
        );

        return coincideTexto &&
            (!filtroEstado.value || m.estado === filtroEstado.value) &&
            (!filtroEspecie.value || m.especie === filtroEspecie.value);
    });

    galeria.innerHTML = resultados.length
        ? resultados.map(m => `
            <article class="mascota-card">
                ${m.imagen
                ? `<img class="mascota-foto"
                        src="${escapar(m.imagen)}"
                        alt="Fotografía de ${escapar(m.nombre)}"
                        loading="lazy"
                        onerror="this.hidden=true;this.nextElementSibling.hidden=false;">`
                : ""
            }
                <div class="mascota-sin-foto"
                    ${m.imagen ? "hidden" : ""} aria-hidden="true">♡</div>

                <div class="mascota-cuerpo">
                    <div class="mascota-titulo">
                        <div>
                            <h3>${escapar(m.nombre)}</h3>
                            <p class="mascota-especie">${escapar(m.especie)}</p>
                        </div>
                        <span class="estado ${claseEstado(m.estado)}">
                            ${escapar(m.estado)}
                        </span>
                    </div>

                    <p class="mascota-ubicacion">
                        Ubicación: ${escapar(m.ubicacion)}<br>
                        Fecha: ${formatoFecha(m.fecha)}
                    </p>

                    <p class="mascota-descripcion">
                        ${escapar(m.descripcion)}
                    </p>

                    <div class="mascota-acciones">
                        <button data-accion="ver" data-id="${m.id}">
                            Ver detalles
                        </button>
                        <button data-accion="editar" data-id="${m.id}">
                            Editar
                        </button>
                        <button class="accion-eliminar"
                            data-accion="eliminar" data-id="${m.id}"
                            aria-label="Eliminar reporte">×</button>
                    </div>
                </div>
            </article>
        `).join("")
        : `<div class="mascota-vacio">
            <strong>No se encontraron reportes.</strong><br>
            Prueba con otro término o cambia los filtros.
           </div>`;

    document.getElementById("contadorMascotas").textContent =
        `${resultados.length} resultados`;

    actualizarResumen();
}

function limpiarFormulario() {
    formulario.reset();
    document.getElementById("mascotaId").value = "";
    document.getElementById("fechaMascota").value = obtenerFechaLocal();
    document.getElementById("tituloModal").textContent = "Nuevo reporte";
    document.getElementById("mensajeMascota").textContent = "";
}

function editarMascota(id) {
    const m = mascotas.find(item => item.id === id);
    if (!m) return;

    limpiarFormulario();

    document.getElementById("tituloModal").textContent = "Editar reporte";
    document.getElementById("mascotaId").value = m.id;
    document.getElementById("nombreMascota").value = m.nombre;
    document.getElementById("especieMascota").value = m.especie;
    document.getElementById("estadoMascota").value = m.estado;
    document.getElementById("fechaMascota").value = m.fecha;
    document.getElementById("ubicacionMascota").value = m.ubicacion;
    document.getElementById("contactoMascota").value = m.contacto;
    document.getElementById("imagenMascota").value = m.imagen;
    document.getElementById("descripcionMascota").value = m.descripcion;

    modal.showModal();
}

function verDetalles(id) {
    const m = mascotas.find(item => item.id === id);
    if (!m) return;

    document.getElementById("detalleTitulo").textContent = m.nombre;

    const campos = [
        ["Especie", m.especie],
        ["Estado", m.estado],
        ["Fecha del reporte", formatoFecha(m.fecha)],
        ["Ubicación", m.ubicacion],
        ["Contacto", m.contacto],
        ["Descripción", m.descripcion]
    ];

    document.getElementById("contenidoDetalles").innerHTML =
        campos.map(([titulo, valor]) => `
            <div class="detalle-item">
                <span>${escapar(titulo)}</span>
                <p>${escapar(valor)}</p>
            </div>
        `).join("");

    modalDetalles.showModal();
}

function eliminarMascota(id) {
    const m = mascotas.find(item => item.id === id);
    if (!m) return;

    if (!confirm(`¿Eliminar el reporte de "${m.nombre}"?`)) return;

    mascotas = mascotas.filter(item => item.id !== id);
    renderizarMascotas();
}

document.getElementById("btnNuevaMascota")
    .addEventListener("click", () => {
        limpiarFormulario();
        modal.showModal();
    });

document.getElementById("btnCerrar")
    .addEventListener("click", () => modal.close());

document.getElementById("btnCancelar")
    .addEventListener("click", () => modal.close());

document.getElementById("btnCerrarDetalle")
    .addEventListener("click", () => modalDetalles.close());

buscar.addEventListener("input", renderizarMascotas);
filtroEstado.addEventListener("change", renderizarMascotas);
filtroEspecie.addEventListener("change", renderizarMascotas);

galeria.addEventListener("click", evento => {
    const boton = evento.target.closest("button[data-accion]");
    if (!boton) return;

    const id = Number(boton.dataset.id);

    if (boton.dataset.accion === "ver") verDetalles(id);
    if (boton.dataset.accion === "editar") editarMascota(id);
    if (boton.dataset.accion === "eliminar") eliminarMascota(id);
});

formulario.addEventListener("submit", evento => {
    evento.preventDefault();

    if (!formulario.reportValidity()) return;

    const id = document.getElementById("mascotaId").value;

    const registro = {
        nombre: document.getElementById("nombreMascota").value.trim(),
        especie: document.getElementById("especieMascota").value,
        estado: document.getElementById("estadoMascota").value,
        fecha: document.getElementById("fechaMascota").value,
        ubicacion: document.getElementById("ubicacionMascota").value.trim(),
        contacto: document.getElementById("contactoMascota").value.trim(),
        imagen: document.getElementById("imagenMascota").value.trim(),
        descripcion:
            document.getElementById("descripcionMascota").value.trim()
    };

    if (Object.values(registro).some(valor => !valor)) {
        // La fotografía es opcional.
        if (!registro.imagen) {
            // No se exige una imagen para registrar una mascota.
        } else {
            document.getElementById("mensajeMascota").textContent =
                "Revisa los campos del formulario.";
            return;
        }
    }

    if (id) {
        const indice = mascotas.findIndex(m => m.id === Number(id));
        if (indice < 0) return;

        mascotas[indice] = {
            ...mascotas[indice],
            ...registro
        };
    } else {
        mascotas.push({
            id: siguienteId++,
            ...registro
        });
    }

    modal.close();
    renderizarMascotas();
});

renderizarMascotas();
