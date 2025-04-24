
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
                <link rel="stylesheet" href="bootstrap/bootstrap.min.css"/>
                <link rel="stylesheet" href="app.css"/>
                <link rel="stylesheet" href="tables.css?v=1.0.0.0"/>
                <link rel="stylesheet" href="OcenaPracowniczaLys.styles.css"/>
                <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
                <script src="print.js"></script>
                <link rel="icon" type="image/png" href="favicon.png"/>
                <style>
                  @media print {
                    * {
                      -webkit-print-color-adjust: exact !important;
                      print-color-adjust: exact !important;
                    }
                    .answer-part{
                    page-break-inside: avoid !important;
                    break-inside: avoid !important;
                    -webkit-column-break-inside: avoid !important;
                    -webkit-page-break-inside: avoid !important;
                    -moz-page-break-inside: avoid !important;
                    }
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
