angular.module("bi-app", ["chart.js"]).controller("PieCtrl", function ($scope, AppService, $window) {

    $scope.listFaturamentos = function () {
        $scope.atualizando = true;
        $scope.faturamentos = [];

        AppService.chamarEndpoint('TrazerFaturamento', [], function (retorno) {
            $scope.faturamentos = retorno.data;
            //$scope.listFaturamentos = retorno.data;

            Array.prototype.carregaDados = function (dados) {
                return this.map(function (obj) {
                    return obj[dados];
                });
            }

            //$scope.labels = $scope.faturamentos.carregaDados('Operacao');
            //$scope.data = $scope.faturamentos.carregaDados('ValorNF');

            $scope.labels = $scope.faturamentos.carregaDados('Operacao');
            $scope.data = $scope.faturamentos.carregaDados('ValorNF');


            $scope.atualizando = false;
        }, function () {
            swal('Erro ao carregar faturamentos', 'error');
        });
    };

    $scope.listFaturamentos();

});