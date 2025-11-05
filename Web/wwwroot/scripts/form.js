
document.addEventListener("submit", (e) => e.target.matches("form") && sessionStorage.setItem("scrollY", window.scrollY)); 

document.addEventListener("DOMContentLoaded", () => {
    const yPosition = sessionStorage.getItem("scrollY")
    if (yPosition) {
        window.scrollTo({ top: parseInt(yPosition, 10), behavior: 'instant' })
        sessionStorage.removeItem("scrollY")
    }
});
     