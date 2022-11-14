function CargarGraficoOrdernesPago(data_ordernes) {
    var titulo = "Grafico Ordernes Pago";
    var chartsordenes = [];
    SeccionArrayOrdenesPago = data_ordernes;

    function destroyCharts() {
        chartsordenes.forEach(chartsordenes => chartsordenes.destroy());
        chartsordenes = [];
    }
    var Ordernesgrafico = function (x, y) {

        this.monto = x;
        this.moneda = y;
    };
    var datagraficoOrdenesPago = new Ordernesgrafico;
    var arrayMonto = [];
    var arrayMoneda = [];
    var arrayEstado = [];
    SeccionArrayOrdenesPago.forEach(function (OrdenesPago, indice, array) {

        arrayMonto.push(OrdenesPago.monto);
        arrayMoneda.push(OrdenesPago.moneda);
        arrayEstado.push(OrdenesPago.estado);
    });

    destroyCharts();
    armarGraficaOrdenesPago(arrayMonto, arrayMoneda, chartsordenes);
    armarGraficaOrdenesPago2(arrayMonto, arrayEstado, chartsordenes);
    function armarGraficaOrdenesPago(arrayMonto, arrayMoneda, chartsordenes) {

        var options = {
            chart: {
                width: 380,
                type: 'pie',
            },
            labels: arrayMoneda,
            series: arrayMonto,
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
        };


        var chart = new ApexCharts(
            document.querySelector("#Chart_Orden"),
            options
        );
        chart.render();
        chartsordenes.push(chart);
    }



    function armarGraficaOrdenesPago2(arrayMonto, arrayEstado, chartsordenes) {


        var options = {
            chart: {
                height: 350,
                type: 'bar',
            },
            plotOptions: {
                bar: {
                    horizontal: true,
                }
            },
            dataLabels: {
                enabled: false
            },
            series: [{
                data: arrayMonto
            }],
            xaxis: {
                categories: arrayEstado,
            }
        };

        var chart = new ApexCharts(
            document.querySelector("#chartOrden2"),
            options
        );

        chart.render();
    }
}