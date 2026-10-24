
const btnCerrarSesion = document.getElementById("btnCerrarSesion");

if (btnCerrarSesion) {
    btnCerrarSesion.addEventListener("click", async (evento) => {
        // Evita navegar antes de cerrar la sesión.
        evento.preventDefault();

        try {
            btnCerrarSesion.style.pointerEvents = "none";
            btnCerrarSesion.style.opacity = "0.7";

            const respuesta = await fetch("/api/auth/logout", {
                method: "POST",
                credentials: "same-origin"
            });

            if (!respuesta.ok) {
                throw new Error("No se pudo cerrar la sesión.");
            }

            // Regresa al inicio de sesión después de cerrar la cookie.
            window.location.replace("/");
        } catch (error) {
            btnCerrarSesion.style.pointerEvents = "";
            btnCerrarSesion.style.opacity = "";

            alert(error.message || "Ocurrió un error al cerrar la sesión.");
        }
    });
}
