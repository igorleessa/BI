angular.module('bi-app').controller('faturamentoCtrl', function ($scope, AppService, $window) {

    $scope.listFaturamentos = function () {
        $scope.atualizando = true;
        $scope.faturamentos = [];

        AppService.chamarEndpoint('TrazerFaturamento', [],function (retorno) {
            $scope.faturamentos = retorno.data;

            Array.prototype.carregaDados = function (dados) {
                return this.map(function (obj) {
                    return obj[dados];
                });
            }


            AmCharts.makeChart("chartdiv", {
                "type": "pie",
                "dataProvider": $scope.faturamentos = retorno.data,
                "titleField": "Operacao",
                "valueField": "ValorNF",
                "balloonText": "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>",
                "minRadius": 150,
                "legend": {
                    "align": "center",
                    "markerType": "circle"
                }

            });
            

            //var barChartData = {
            //    labels: $scope.faturamentos.carregaDados('Operacao'),
            //    datasets: [
            //        {
            //            fillColor: "rgba(220,220,220,0.5)",
            //            strokeColor: "rgba(220,220,220,0.8)",
            //            highlightFill: "rgba(220,220,220,0.75)",
            //            highlightStroke: "rgba(220,220,220,1)",
            //            data: $scope.faturamentos.carregaDados('ValorNF')
            //        },
            //    ]
            //}

     
            //var ctx1 = document.getElementById("canvas").getContext("2d");
            //window.myBar = new Chart(ctx1).Bar(barChartData, {
            //    responsive: true
            //});
            

            $scope.atualizando = false;
        }, function () {
            swal('Erro ao carregar faturamentos','error');
        });
    };

    $scope.listFaturamentos();
});