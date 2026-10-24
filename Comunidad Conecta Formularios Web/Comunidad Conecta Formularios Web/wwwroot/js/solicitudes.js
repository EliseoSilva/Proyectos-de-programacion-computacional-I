
const tabla = document.getElementById("tablaSolicitudes");
const buscar = document.getElementById("buscarSolicitud");
const filtroEstado = document.getElementById("filtroEstado");
const filtroPrioridad = document.getElementById("filtroPrioridad");
const modal = document.getElementById("modalSolicitud");
const modalDetalles = document.getElementById("modalDetalles");
const formulario = document.getElementById("formSolicitud");

let siguienteId = 4;

let solicitudes = [
    {
        id: 1,
        titulo: "Apoyo con alimentos",
        solicitante: "Laura Hernández",
        categoria: "Alimentos",
        prioridad: "Alta",
        fecha: "2026-10-21",
        estado: "Pendiente",
        descripcion: "Apoyo con productos básicos para su familia."
    },
    {
        id: 2,
        titulo: "Material escolar",
        solicitante: "José Martínez",
        categoria: "Educación",
        prioridad: "Media",
        fecha: "2026-10-20",
        estado: "En revisión",
        descripcion: "Solicitud de cuadernos y útiles escolares."
    },
    {
        id: 3,
        titulo: "Apoyo con ropa",
        solicitante: "Ana López",
        categoria: "Ropa",
        prioridad: "Baja",
        fecha: "2026-10-18",
        estado: "Atendida",
        descripcion: "Solicitud de ropa en buen estado."
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
    if (estado === "Atendida") return "estado-disponible";
    if (estado === "Rechazada") return "estado-entregada";
    if (estado === "En revisión") return "estado-proceso";
    return "estado-proceso";
}

function clasePrioridad(prioridad) {
    return {
        Alta: "prioridad-alta",
        Media: "prioridad-media",
        Baja: "prioridad-baja"
    }[prioridad] || "prioridad-media";
}

function actualizarResumen() {
    document.getElementById("totalSolicitudes").textContent =
        solicitudes.length;

    document.getElementById("totalPendientes").textContent =
        solicitudes.filter(s => s.estado === "Pendiente").length;

    document.getElementById("totalAtendidas").textContent =
        solicitudes.filter(s => s.estado === "Atendida").length;
}

function renderizarSolicitudes() {
    const termino = buscar.value.trim().toLocaleLowerCase("es");

    const resultados = solicitudes.filter(s => {
        const coincideTexto = [
            s.titulo, s.solicitante, s.categoria
        ].some(valor =>
            valor.toLocaleLowerCase("es").includes(termino)
        );

        const coincideEstado =
            !filtroEstado.value || s.estado === filtroEstado.value;

        const coincidePrioridad =
            !filtroPrioridad.value ||
            s.prioridad === filtroPrioridad.value;

        return coincideTexto && coincideEstado && coincidePrioridad;
    });

    tabla.innerHTML = resultados.length
        ? resultados.map(s => `
            <tr>
                <td>
                    <div class="nombre-registro">
                        <div class="registro-icono">▤</div>
                        <div>
                            <strong>${escapar(s.titulo)}</strong>
                            <small>ID: ${s.id}</small>
                        </div>
                    </div>
                </td>
                <td>${escapar(s.solicitante)}</td>
                <td>${escapar(s.categoria)}</td>
                <td>
                    <span class="prioridad ${clasePrioridad(s.prioridad)}">
                        ${escapar(s.prioridad)}
                    </span>
                </td>
                <td>${formatoFecha(s.fecha)}</td>
                <td>
                    <span class="estado ${claseEstado(s.estado)}">
                        ${escapar(s.estado)}
                    </span>
                </td>
                <td>
                    <div class="acciones">
                        <button class="btn-accion" data-accion="ver"
                            data-id="${s.id}" title="Ver detalles"
                            aria-label="Ver detalles">◉</button>
                        <button class="btn-accion" data-accion="editar"
                            data-id="${s.id}" title="Editar"
                            aria-label="Editar">✎</button>
                        <button class="btn-accion eliminar"
                            data-accion="eliminar" data-id="${s.id}"
                            title="Eliminar" aria-label="Eliminar">×</button>
                    </div>
                </td>
            </tr>
        `).join("")
        : `<tr><td colspan="7" class="sin-resultados">
            No se encontraron solicitudes.
           </td></tr>`;

    document.getElementById("textoResultados").textContent =
        `Mostrando ${resultados.length} de ${solicitudes.length} registros`;

    actualizarResumen();
}

function limpiarFormulario() {
    formulario.reset();
    document.getElementById("solicitudId").value = "";
    document.getElementById("fechaSolicitud").value = obtenerFechaLocal();
    document.getElementById("tituloModal").textContent = "Nueva solicitud";
    document.getElementById("mensajeSolicitud").textContent = "";
}

function editarSolicitud(id) {
    const s = solicitudes.find(item => item.id === id);
    if (!s) return;

    limpiarFormulario();

    document.getElementById("tituloModal").textContent = "Editar solicitud";
    document.getElementById("solicitudId").value = s.id;
    document.getElementById("tituloSolicitud").value = s.titulo;
    document.getElementById("solicitante").value = s.solicitante;
    document.getElementById("categoriaSolicitud").value = s.categoria;
    document.getElementById("prioridadSolicitud").value = s.prioridad;
    document.getElementById("fechaSolicitud").value = s.fecha;
    document.getElementById("estadoSolicitud").value = s.estado;
    document.getElementById("descripcionSolicitud").value = s.descripcion;

    modal.showModal();
}

function verDetalles(id) {
    const s = solicitudes.find(item => item.id === id);
    if (!s) return;

    document.getElementById("detalleTitulo").textContent = s.titulo;

    const campos = [
        ["Solicitante", s.solicitante],
        ["Categoría", s.categoria],
        ["Prioridad", s.prioridad],
        ["Fecha", formatoFecha(s.fecha)],
        ["Estado", s.estado],
        ["Descripción", s.descripcion]
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

function eliminarSolicitud(id) {
    const s = solicitudes.find(item => item.id === id);
    if (!s) return;

    if (!confirm(`¿Eliminar la solicitud "${s.titulo}"?`)) return;

    solicitudes = solicitudes.filter(item => item.id !== id);
    renderizarSolicitudes();
}

document.getElementById("btnNuevaSolicitud")
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

buscar.addEventListener("input", renderizarSolicitudes);
filtroEstado.addEventListener("change", renderizarSolicitudes);
filtroPrioridad.addEventListener("change", renderizarSolicitudes);

document.getElementById("btnLimpiarFiltros")
    .addEventListener("click", () => {
        buscar.value = "";
        filtroEstado.value = "";
        filtroPrioridad.value = "";
        renderizarSolicitudes();
    });

tabla.addEventListener("click", evento => {
    const boton = evento.target.closest("button[data-accion]");
    if (!boton) return;

    const id = Number(boton.dataset.id);

    if (boton.dataset.accion === "ver") verDetalles(id);
    if (boton.dataset.accion === "editar") editarSolicitud(id);
    if (boton.dataset.accion === "eliminar") eliminarSolicitud(id);
});

formulario.addEventListener("submit", evento => {
    evento.preventDefault();

    if (!formulario.reportValidity()) return;

    const id = document.getElementById("solicitudId").value;

    const registro = {
        titulo: document.getElementById("tituloSolicitud").value.trim(),
        solicitante: document.getElementById("solicitante").value.trim(),
        categoria: document.getElementById("categoriaSolicitud").value,
        prioridad: document.getElementById("prioridadSolicitud").value,
        fecha: document.getElementById("fechaSolicitud").value,
        estado: document.getElementById("estadoSolicitud").value,
        descripcion:
            document.getElementById("descripcionSolicitud").value.trim()
    };

    if (Object.values(registro).some(valor => !valor)) {
        const mensaje = document.getElementById("mensajeSolicitud");
        mensaje.style.color = "#c0392b";
        mensaje.textContent = "Completa todos los campos obligatorios.";
        return;
    }

    if (id) {
        const indice = solicitudes.findIndex(s => s.id === Number(id));
        if (indice < 0) return;

        solicitudes[indice] = {
            ...solicitudes[indice],
            ...registro
        };
    } else {
        solicitudes.push({
            id: siguienteId++,
            ...registro
        });
    }

    modal.close();
    renderizarSolicitudes();
});

renderizarSolicitudes();
