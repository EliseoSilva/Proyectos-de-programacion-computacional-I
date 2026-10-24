document.addEventListener("DOMContentLoaded", () => {
    let usuarios = [];

async function cargarUsuarios() {
    try {
        const respuesta = await fetch("/api/usuarios");

        if (!respuesta.ok) {
            throw new Error("No se pudieron cargar los usuarios.");
        }

        usuarios = await respuesta.json();

        // Adaptamos los datos de SQL Server al formato de la interfaz.
        usuarios = usuarios.map(usuario => ({
            ...usuario,
            id: usuario.id_usuario,
            nombre: `${usuario.nombres ?? ""} ${usuario.apellidos ?? ""}`.trim(),
            estado: null
        }));

        renderizarUsuarios();
    } catch (error) {
        console.error("Error al cargar usuarios:", error);
        alert("No fue posible cargar los usuarios desde SQL Server.");
    }
}

    const tablaUsuarios = document.getElementById("tablaUsuarios");
    const buscarUsuario = document.getElementById("buscarUsuario");
    const filtroRol = document.getElementById("filtroRol");
    const filtroEstado = document.getElementById("filtroEstado");

    const totalUsuarios = document.getElementById("totalUsuarios");
    const usuariosActivos = document.getElementById("usuariosActivos");
    const totalAdministradores = document.getElementById("totalAdministradores");
    const usuariosInactivos = document.getElementById("usuariosInactivos");
    const contadorUsuarios = document.getElementById("contadorUsuarios");
    const mensajeVacio = document.getElementById("mensajeVacio");

    const modalUsuario = document.getElementById("modalUsuario");
    const modalDetalleUsuario = document.getElementById("modalDetalleUsuario");
    const formularioUsuario = document.getElementById("formularioUsuario");

    const btnNuevoUsuario = document.getElementById("btnNuevoUsuario");
    const cerrarModalUsuario = document.getElementById("cerrarModalUsuario");
    const cancelarUsuario = document.getElementById("cancelarUsuario");
    const cerrarDetalleUsuario = document.getElementById("cerrarDetalleUsuario");
    const cerrarDetalleBoton = document.getElementById("cerrarDetalleBoton");

    const tituloModalUsuario = document.getElementById("tituloModalUsuario");
    const contenidoDetalleUsuario = document.getElementById("contenidoDetalleUsuario");

    const idUsuario = document.getElementById("idUsuario");
    const nombreUsuario = document.getElementById("nombreUsuario");
    const correoUsuario = document.getElementById("correoUsuario");
    const telefonoUsuario = document.getElementById("telefonoUsuario");
    const rolUsuario = document.getElementById("rolUsuario");
    const estadoUsuario = document.getElementById("estadoUsuario");

    const apellidoUsuario = document.getElementById("apellidoUsuario");
    const departamentoUsuario = document.getElementById("departamentoUsuario");
    const direccionUsuario = document.getElementById("direccionUsuario");
    const biografiaUsuario = document.getElementById("biografiaUsuario");
    const fotoUsuario = document.getElementById("fotoUsuario");

    function escaparHTML(valor) {
        return String(valor ?? "").replace(/[&<>"']/g, caracter => ({
            "&": "&amp;",
            "<": "&lt;",
            ">": "&gt;",
            '"': "&quot;",
            "'": "&#39;"
        })[caracter]);
    }

    function actualizarResumen() {
        totalUsuarios.textContent = usuarios.length;

        usuariosActivos.textContent = usuarios.filter(
            usuario => usuario.estado === "Activo"
        ).length;

        totalAdministradores.textContent = usuarios.filter(
            usuario => usuario.rol === "Administrador"
        ).length;

        usuariosInactivos.textContent = usuarios.filter(
            usuario => usuario.estado === "Inactivo"
        ).length;
    }

    function obtenerUsuariosFiltrados() {
        const busqueda = buscarUsuario.value.trim().toLowerCase();
        const rolSeleccionado = filtroRol.value;
        const estadoSeleccionado = filtroEstado.value;

        return usuarios.filter(usuario => {
            const coincideBusqueda =
                usuario.nombre.toLowerCase().includes(busqueda) ||
                usuario.correo.toLowerCase().includes(busqueda) ||
                usuario.telefono.toLowerCase().includes(busqueda);

            const coincideRol =
                rolSeleccionado === "" || usuario.rol === rolSeleccionado;

            const coincideEstado =
                estadoSeleccionado === "" || usuario.estado === estadoSeleccionado;

            return coincideBusqueda && coincideRol && coincideEstado;
        });
    }

    function renderizarUsuarios() {
        const filtrados = obtenerUsuariosFiltrados();

        tablaUsuarios.innerHTML = filtrados.map(usuario => `
            <tr>
                <td>
                    <div class="usuario-tabla">
                        <div class="avatar avatar-pequeno">
                            ${escaparHTML(usuario.nombre.charAt(0).toUpperCase())}
                        </div>
                        <strong>${escaparHTML(usuario.nombre)}</strong>
                    </div>
                </td>

                <td>${escaparHTML(usuario.correo)}</td>
                <td>${escaparHTML(usuario.telefono || "No registrado")}</td>
                <td>
                    <span class="etiqueta-rol">
                        ${escaparHTML(usuario.rol)}
                    </span>
                </td>
                <td>
                    <span class="estado ${usuario.estado === "Activo" ? "estado-activo" : "estado-inactivo"}">
                        ${escaparHTML(usuario.estado)}
                    </span>
                </td>
                <td>
                    <div class="acciones-tabla">
                        <button type="button" class="accion-btn"
                            data-accion="detalle" data-id="${usuario.id}">
                            Ver
                        </button>

                        <button type="button" class="accion-btn"
                            data-accion="editar" data-id="${usuario.id}">
                            Editar
                        </button>

                        <button type="button" class="accion-btn accion-eliminar"
                            data-accion="eliminar" data-id="${usuario.id}">
                            Eliminar
                        </button>
                    </div>
                </td>
            </tr>
        `).join("");

        mensajeVacio.hidden = filtrados.length !== 0;

        contadorUsuarios.textContent =
            `Mostrando ${filtrados.length} de ${usuarios.length} usuarios`;

        actualizarResumen();
    }

    function abrirModal(modal) {
        modal.classList.add("mostrar");
        modal.setAttribute("aria-hidden", "false");
    }

    function cerrarModal(modal) {
        modal.classList.remove("mostrar");
        modal.setAttribute("aria-hidden", "true");
    }


    function limpiarFormulario() {
        formularioUsuario.reset();
        idUsuario.value = "";
        rolUsuario.value = "Ciudadano";
    }


    function abrirNuevoUsuario() {
        limpiarFormulario();
        tituloModalUsuario.textContent = "Nuevo usuario";
        abrirModal(modalUsuario);
    }


    function editarUsuario(id) {
        const usuario = usuarios.find(item => item.id === id);

        if (!usuario) return;

        limpiarFormulario();

        tituloModalUsuario.textContent = "Editar usuario";

        idUsuario.value = usuario.id;
        nombreUsuario.value = usuario.nombres ?? "";
        apellidoUsuario.value = usuario.apellidos ?? "";
        correoUsuario.value = usuario.correo ?? "";
        telefonoUsuario.value = usuario.telefono ?? "";
        departamentoUsuario.value = usuario.departamento ?? "";
        direccionUsuario.value = usuario.direccion ?? "";
        rolUsuario.value = usuario.rol ?? "Ciudadano";
        fotoUsuario.value = usuario.foto ?? "";
        biografiaUsuario.value = usuario.biografia ?? "";

        abrirModal(modalUsuario);
    }


    function verDetalleUsuario(id) {
        const usuario = usuarios.find(item => item.id === id);

        if (!usuario) return;

        contenidoDetalleUsuario.innerHTML = `
            <div class="detalle-usuario">
                <div class="avatar avatar-detalle">
                    ${escaparHTML(usuario.nombre.charAt(0).toUpperCase())}
                </div>

                <h3>${escaparHTML(usuario.nombre)}</h3>

                <div class="detalle-fila">
                    <strong>ID:</strong>
                    <span>${usuario.id}</span>
                </div>

                <div class="detalle-fila">
                    <strong>Correo:</strong>
                    <span>${escaparHTML(usuario.correo)}</span>
                </div>

                <div class="detalle-fila">
                    <strong>Teléfono:</strong>
                    <span>${escaparHTML(usuario.telefono || "No registrado")}</span>
                </div>

                <div class="detalle-fila">
                    <strong>Rol:</strong>
                    <span>${escaparHTML(usuario.rol)}</span>
                </div>

                <div class="detalle-fila">
                    <strong>Estado:</strong>
                    <span>${escaparHTML(usuario.estado)}</span>
                </div>
            </div>
        `;

        abrirModal(modalDetalleUsuario);
    }


    async function eliminarUsuario(id) {
        const usuario = usuarios.find(item => item.id === id);

        if (!usuario) return;

        const confirmar = confirm(
            `¿Seguro que deseas eliminar a ${usuario.nombre}?`
        );

        if (!confirmar) return;

        try {
            const respuesta = await fetch(`/api/usuarios/${id}`, {
                method: "DELETE",
                credentials: "same-origin"
            });

            const resultado = await respuesta.json().catch(() => ({}));

            if (!respuesta.ok) {
                throw new Error(
                    resultado.mensaje || "No se pudo eliminar el usuario."
                );
            }

            alert("Usuario eliminado correctamente.");

            // Volvemos a consultar los datos reales de SQL Server.
            await cargarUsuarios();
        } catch (error) {
            console.error("Error al eliminar usuario:", error);
            alert(error.message || "Ocurrió un error al eliminar el usuario.");
        }
    }

    formularioUsuario.addEventListener("submit", async evento => {
        evento.preventDefault();

        const nombres = nombreUsuario.value.trim();
        const apellidos = apellidoUsuario.value.trim();
        const correo = correoUsuario.value.trim();

        if (!nombres || !apellidos || !correo) {
            alert("Completa los nombres, apellidos y el correo electrónico.");
            return;
        }

        const idActual = idUsuario.value
            ? Number(idUsuario.value)
            : null;

        const datosUsuario = {
            nombres,
            apellidos,
            correo,
            telefono: telefonoUsuario.value.trim() || null,
            departamento: departamentoUsuario.value.trim() || null,
            direccion: direccionUsuario.value.trim() || null,
            biografia: biografiaUsuario.value.trim() || null,
            foto: fotoUsuario.value.trim() || null,
            rol: rolUsuario.value
        };

        try {
            if (idActual !== null) {
                const respuesta = await fetch(`/api/usuarios/${idActual}`, {
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(datosUsuario)
                });

                const resultado = await respuesta.json();

                if (!respuesta.ok) {
                    throw new Error(
                        resultado.mensaje || "No se pudo actualizar el usuario."
                    );
                }

                alert("Usuario actualizado correctamente.");
            } else {
                alert(
                    "La edición ya está conectada con SQL Server. " +
                    "El registro de usuarios nuevos todavía necesita su endpoint."
                );
                return;
            }

            cerrarModal(modalUsuario);
            limpiarFormulario();
            await cargarUsuarios();

        } catch (error) {
            console.error("Error al guardar usuario:", error);
            alert(error.message || "Ocurrió un error al guardar los cambios.");
        }
    });


    btnNuevoUsuario.addEventListener("click", abrirNuevoUsuario);

    cerrarModalUsuario.addEventListener("click", () => {
        cerrarModal(modalUsuario);
    });

    cancelarUsuario.addEventListener("click", () => {
        cerrarModal(modalUsuario);
    });

    cerrarDetalleUsuario.addEventListener("click", () => {
        cerrarModal(modalDetalleUsuario);
    });

    cerrarDetalleBoton.addEventListener("click", () => {
        cerrarModal(modalDetalleUsuario);
    });

    buscarUsuario.addEventListener("input", renderizarUsuarios);
    filtroRol.addEventListener("change", renderizarUsuarios);
    filtroEstado.addEventListener("change", renderizarUsuarios);

    tablaUsuarios.addEventListener("click", evento => {
        const boton = evento.target.closest("button[data-accion]");

        if (!boton) return;

        const id = Number(boton.dataset.id);
        const accion = boton.dataset.accion;

        if (accion === "detalle") {
            verDetalleUsuario(id);
        } else if (accion === "editar") {
            editarUsuario(id);
        } else if (accion === "eliminar") {
            eliminarUsuario(id);
        }
    });

    [modalUsuario, modalDetalleUsuario].forEach(modal => {
        modal.addEventListener("click", evento => {
            if (evento.target === modal) {
                cerrarModal(modal);
            }
        });
    });

    document.addEventListener("keydown", evento => {
        if (evento.key === "Escape") {
            cerrarModal(modalUsuario);
            cerrarModal(modalDetalleUsuario);
        }
    });

    cargarUsuarios();
});
