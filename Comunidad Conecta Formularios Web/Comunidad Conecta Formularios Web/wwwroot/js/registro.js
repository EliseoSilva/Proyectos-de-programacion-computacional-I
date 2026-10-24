
const formRegistro = document.getElementById("formRegistro");
const nombres = document.getElementById("nombres");
const apellidos = document.getElementById("apellidos");
const correoRegistro = document.getElementById("correoRegistro");
const telefono = document.getElementById("telefono");
const claveRegistro = document.getElementById("claveRegistro");
const confirmarClave = document.getElementById("confirmarClave");
const mensajeRegistro = document.getElementById("mensajeRegistro");

formRegistro.addEventListener("submit", async (evento) => {
    evento.preventDefault();

    mensajeRegistro.textContent = "";
    mensajeRegistro.style.color = "#2868a5";

    if (claveRegistro.value !== confirmarClave.value) {
        mensajeRegistro.style.color = "#c0392b";
        mensajeRegistro.textContent = "Las contraseñas no coinciden.";
        confirmarClave.focus();
        return;
    }

    const datosUsuario = {
        nombres: nombres.value.trim(),
        apellidos: apellidos.value.trim(),
        correo: correoRegistro.value.trim(),
        telefono: telefono.value.trim(),
        contrasena: claveRegistro.value
    };

    try {
        const respuesta = await fetch("/api/usuarios", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(datosUsuario)
        });

        const resultado = await respuesta.json();

        if (!respuesta.ok) {
            throw new Error(
                resultado.mensaje || "No se pudo crear la cuenta."
            );
        }

        mensajeRegistro.style.color = "#218838";
        mensajeRegistro.textContent =
            "¡Cuenta creada correctamente! Redirigiendo al inicio de sesión...";

        formRegistro.reset();

        setTimeout(() => {
            window.location.href = "/";
        }, 1800);

    } catch (error) {
        mensajeRegistro.style.color = "#c0392b";
        mensajeRegistro.textContent =
            error.message || "No fue posible conectar con el servidor.";
    }
});
