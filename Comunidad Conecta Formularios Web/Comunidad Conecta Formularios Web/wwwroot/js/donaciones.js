
const tabla = document.getElementById("tablaDonaciones");
const buscar = document.getElementById("buscarDonacion");
const filtroEstado = document.getElementById("filtroEstado");
const modal = document.getElementById("modalDonacion");
const modalDetalles = document.getElementById("modalDetalles");
const formulario = document.getElementById("formDonacion");
const mensaje = document.getElementById("mensajeDonacion");

let siguienteId = 4;
let donaciones = [
    {
        id: 1,
        nombre: "Canasta de alimentos",
        categoria: "Alimentos",
        donante: "María López",
        fecha: "2026-10-20",
        estado: "Disponible",
        descripcion: "Productos básicos para familias."
    },
    {
        id: 2,
        nombre: "Ropa para niños",
        categoria: "Ropa",
        donante: "Carlos Martínez",
        fecha: "2026-10-19",
        estado: "En proceso",
        descripcion: "Prendas en buen estado."
    },
    {
        id: 3,
        nombre: "Cuadernos escolares",
        categoria: "Material escolar",
        donante: "Ana Rodríguez",
        fecha: "2026-10-18",
        estado: "Entregada",
        descripcion: "Material para estudiantes."
    }
];

const obtenerFechaLocal = () => {
    const fecha = new Date();
    const zona = fecha.getTimezoneOffset() * 60000;
    return new Date(fecha.getTime() - zona)
        .toISOString().slice(0, 10);
};

function escapar(texto) {
    return String(texto).replace(/[&<>"']/g, caracter => ({
        "&": "&amp;",
        "<": "&lt;",
        ">": "&gt;",
        '"': "&quot;",
        "'": "&#39;"
    })[caracter]);
}

function formatoFecha(fecha) {
    if (!fecha) return "Sin fecha";

    const [anio, mes, dia] = fecha.split("-");
    return `${dia}/${mes}/${anio}`;
}

function claseEstado(estado) {
    if (estado === "Disponible") return "estado-disponible";
    if (estado === "Entregada") return "estado-entregada";
    return "estado-proceso";
}

function actualizarResumen() {
    document.getElementById("totalDonaciones").textContent =
        donaciones.length;

    document.getElementById("totalDisponibles").textContent =
        donaciones.filter(d => d.estado === "Disponible").length;

    document.getElementById("totalEntregadas").textContent =
        donaciones.filter(d => d.estado === "Entregada").length;
}

function renderizarDonaciones() {
    const termino = buscar.value.trim().toLocaleLowerCase("es");

    const resultados = donaciones.filter(d => {
        const coincideTexto = [
            d.nombre, d.categoria, d.donante
        ].some(valor =>
            valor.toLocaleLowerCase("es").includes(termino)
        );

        const coincideEstado =
            !filtroEstado.value || d.estado === filtroEstado.value;

        return coincideTexto && coincideEstado;
    });

    tabla.innerHTML = resultados.length
        ? resultados.map(d => `
            <tr>
                <td>
                    <div class="nombre-registro">
                        <div class="registro-icono" aria-hidden="true">♡</div>
                        <div>
                            <strong>${escapar(d.nombre)}</strong>
                            <small>ID: ${d.id}</small>
                        </div>
                    </div>
                </td>
                <td>${escapar(d.categoria)}</td>
                <td>${escapar(d.donante)}</td>
                <td>${formatoFecha(d.fecha)}</td>
                <td>
                    <span class="estado ${claseEstado(d.estado)}">
                        ${escapar(d.estado)}
                    </span>
                </td>
                <td>
                    <div class="acciones">
                        <button class="btn-accion"
                            data-accion="ver" data-id="${d.id}"
                            aria-label="Ver detalles"
                            title="Ver detalles">◉</button>
                        <button class="btn-accion"
                            data-accion="editar" data-id="${d.id}"
                            aria-label="Editar"
                            title="Editar">✎</button>
                        <button class="btn-accion eliminar"
                            data-accion="eliminar" data-id="${d.id}"
                            aria-label="Eliminar"
                            title="Eliminar">×</button>
                    </div>
                </td>
            </tr>
        `).join("")
        : `<tr><td colspan="6" class="sin-resultados">
            No se encontraron donaciones.
           </td></tr>`;

    document.getElementById("textoResultados").textContent =
        `Mostrando ${resultados.length} de ${donaciones.length} registros`;

    actualizarResumen();
}

function limpiarFormulario() {
    formulario.reset();
    document.getElementById("donacionId").value = "";
    document.getElementById("fechaDonacion").value = obtenerFechaLocal();
    document.getElementById("tituloModal").textContent = "Nueva donación";
    mensaje.textContent = "";
}

function abrirNueva() {
    limpiarFormulario();
    modal.showModal();
}

function editarDonacion(id) {
    const d = donaciones.find(item => item.id === id);
    if (!d) return;

    limpiarFormulario();

    document.getElementById("tituloModal").textContent = "Editar donación";
    document.getElementById("donacionId").value = d.id;
    document.getElementById("nombreDonacion").value = d.nombre;
    document.getElementById("categoriaDonacion").value = d.categoria;
    document.getElementById("donante").value = d.donante;
    document.getElementById("fechaDonacion").value = d.fecha;
    document.getElementById("descripcionDonacion").value = d.descripcion;
    document.getElementById("estadoDonacion").value = d.estado;

    modal.showModal();
}

function verDetalles(id) {
    const d = donaciones.find(item => item.id === id);
    if (!d) return;

    document.getElementById("detalleNombre").textContent = d.nombre;

    const campos = [
        ["Categoría", d.categoria],
        ["Donante", d.donante],
        ["Fecha", formatoFecha(d.fecha)],
        ["Estado", d.estado],
        ["Descripción", d.descripcion || "Sin descripción"]
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

function eliminarDonacion(id) {
    const donacion = donaciones.find(d => d.id === id);
    if (!donacion) return;

    if (!confirm(`¿Deseas eliminar "${donacion.nombre}"?`)) return;

    donaciones = donaciones.filter(d => d.id !== id);
    renderizarDonaciones();
}

document.getElementById("btnNueva")
    .addEventListener("click", abrirNueva);

document.getElementById("btnCerrar")
    .addEventListener("click", () => modal.close());

document.getElementById("btnCancelar")
    .addEventListener("click", () => modal.close());

document.getElementById("btnCerrarDetalle")
    .addEventListener("click", () => modalDetalles.close());

buscar.addEventListener("input", renderizarDonaciones);
filtroEstado.addEventListener("change", renderizarDonaciones);

document.getElementById("btnLimpiarFiltros")
    .addEventListener("click", () => {
        buscar.value = "";
        filtroEstado.value = "";
        renderizarDonaciones();
    });

tabla.addEventListener("click", evento => {
    const boton = evento.target.closest("button[data-accion]");
    if (!boton) return;

    const id = Number(boton.dataset.id);
    const accion = boton.dataset.accion;

    if (accion === "ver") verDetalles(id);
    if (accion === "editar") editarDonacion(id);
    if (accion === "eliminar") eliminarDonacion(id);
});

formulario.addEventListener("submit", evento => {
    evento.preventDefault();

    if (!formulario.reportValidity()) return;

    const id = document.getElementById("donacionId").value;
    const registro = {
        nombre: document.getElementById("nombreDonacion").value.trim(),
        categoria: document.getElementById("categoriaDonacion").value,
        donante: document.getElementById("donante").value.trim(),
        fecha: document.getElementById("fechaDonacion").value,
        descripcion:
            document.getElementById("descripcionDonacion").value.trim(),
        estado: document.getElementById("estadoDonacion").value
    };

    if (!registro.nombre || !registro.donante) {
        mensaje.style.color = "#c0392b";
        mensaje.textContent = "Completa los campos obligatorios.";
        return;
    }

    if (id) {
        const indice = donaciones.findIndex(d => d.id === Number(id));
        if (indice < 0) return;

        donaciones[indice] = {
            ...donaciones[indice],
            ...registro
        };
    } else {
        donaciones.push({
            id: siguienteId++,
            ...registro
        });
    }

    modal.close();
    renderizarDonaciones();
});

renderizarDonaciones();
