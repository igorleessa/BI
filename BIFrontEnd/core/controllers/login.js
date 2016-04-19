angular.module('bi-app').controller('loginCtrl', function($scope, $log, $http, $cookies, AppService, MsgService, $location) {
    
    $scope.load = function(){
        $scope.usuariologado = AppService.usuariologado();
        $scope.exibeBarraTarefas = $scope.usuariologado.Token ? true : false;
        $scope.login = {Usuario: "", Senha: ""};
        $scope.lembrar = true;  
    };
    $scope.sistema = "bi";
    $scope.load();

    $scope.logar = function(){
        $log.info($scope.login);
        $scope.info($scope.lembrar);
    
        AppService.chamarEndpoint('LoginUsuario', $scope.login, function(response) {
            AppService.setUsuarioLogado(response.data);
            $scope.load();
            MsgService.alertaSucesso('Bem-vindo, ' + response.data.NomeUsuario);
            $location.path('/main');
        },function(){
            $scope.load();
            MsgService.mensagemErro('Problema ao se conectar!', 'Verifique se o usuário e senha estão corretos.');
        });

        $scope.deslogar =function(){
            AppService.setUsuarioLogado({});
            $scope.load();
        };