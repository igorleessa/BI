angular.module('bi-app').controller('faturamentoCtrl', function ($scope, AppService, $window) {

    $scope.listFaturamentos = function () {
        $scope.atualizando = true;
        $scope.faturamentos = [];

        AppService.chamarEndpoint('TrazerFaturamento', undefined, function (retorno) {
            $scope.faturamentos = retorno.data;
            $scope.atualizando = false;
        }, function () {
            swal('Erro ao carregar faturamentos','error');
        });
    };

    Array.prototype.carregaDados = function (dados) {
        return this.map(function (obj) {
            return obj[dados];
        });
    }

    var carregarFaturamento = document.getElementsByClassName('TrazerFaturamento');

    for (var i = 0, len = carregarFaturamento.length; i < len; i++) {
        var pieData = [
        {
            value: dados.carregaDados('Operacao'),
            color: dados.carregaDados('CodHex'),
            label: dados.carregaDados('ValorNF')
        }];

        window.onload = function () {
            var ctx = document.getElementById("chart-area").getContext("2d");
            window.myPie = new Chart(ctx).Pie(pieData);
        };
    }

    //$scope.abc = 1233333;
});