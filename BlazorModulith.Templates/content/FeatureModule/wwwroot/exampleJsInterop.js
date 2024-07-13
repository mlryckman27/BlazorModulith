// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function copyToClipBoard(text) {
    navigator.clipboard.writeText(text)
        .then(() => {
            console.log("Text copied to clipboard");
        })
        .catch((error) => {
            console.error("Failed to copy text to clipboard:", error);
        });
}
