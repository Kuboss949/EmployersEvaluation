
    window.printFragment = function (elementId) {
    var printContent = document.getElementById(elementId);
    if (!printContent) {
    console.error("Nie znaleziono elementu o identyfikatorze: " + elementId);
    return;
}

    // Otwarcie nowego okna lub zakładki
    var printWindow = window.open("", "", "width=800,height=600");
    // Kopiujemy zawartość elementu do nowego dokumentu
    printWindow.document.write(`
            <html>
            <head>
                <title>Podgląd wydruku</title>
                <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
                <link rel="stylesheet" href="bootstrap/bootstrap.min.css"/>
                <link rel="stylesheet" href="app.css"/>
                <link rel="stylesheet" href="OcenaPracowniczaLys.styles.css"/>
                <style>
                    /* Opcjonalne style wydruku */
                    body {
                        padding: 20px;
                        font-family: sans-serif;
                    }
                </style>
            </head>
            <body>
                ${printContent.outerHTML}
            </body>
            </html>
        `);
    printWindow.document.close();
    printWindow.focus();
    // Opcjonalnie: poczekaj chwilę aby treść się wyrenderowała, potem wywołaj print
    setTimeout(() => {
    printWindow.print();
    printWindow.close();
}, 500);
}
