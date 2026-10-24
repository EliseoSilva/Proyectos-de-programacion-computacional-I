
const formulario = document.getElementById("formLogin");
const campoContrasena = document.getElementById("contrasena");
const btnMostrar = document.getElementById("btnMostrar");
const mensaje = document.getElementById("mensaje");
const campoCorreo = document.getElementById("correo");

// Mostrar u ocultar la contraseña.
btnMostrar.addEventListener("click", () => {
    const mostrar = campoContrasena.type === "password";

    campoContrasena.type = mostrar ? "text" : "password";
    btnMostrar.textContent = mostrar ? "Ocultar" : "Ver";
    btnMostrar.setAttribute("aria-pressed", String(mostrar));
    btnMostrar.setAttribute(
        "aria-label",
        mostrar ? "Ocultar contraseña" : "Mostrar contraseña"
    );
});

// Iniciar sesión mediante la API.
formulario.addEventListener("submit", async (evento) => {
    evento.preventDefault();

    mensaje.style.color = "#2868a5";
    mensaje.textContent = "Verificando tus credenciales...";

    try {
        const respuesta = await fetch("/api/auth/login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                correo: campoCorreo.value.trim(),
                contrasena: campoContrasena.value
            })
        });

        const resultado = await respuesta.json();

        if (!respuesta.ok) {
            throw new Error(
                resultado.mensaje || "No se pudo iniciar sesión."
            );
        }

        mensaje.style.color = "#218838";
        mensaje.textContent = "¡Inicio de sesión correcto!";

        window.location.href = "/paginas/inicio.html";

    } catch (error) {
        mensaje.style.color = "#c0392b";
        mensaje.textContent =
            error.message || "No se pudo conectar con el servidor.";
    }
});
