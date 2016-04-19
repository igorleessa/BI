var app = angular.module("bi-app");

app.factory("AppService", function ($location, $window, $templateCache, $http) {

    var usuarioLogado = {};

    var tratarErro = function (mensagem) {
        MsgService.mensagemErro('Encontramos um problema...', mensagem);
    }

    var link = "http://localhost:51149/BIWebService.asmx";

    var ultimaVersao = "19.02.2016 - 001";

    var chamarEndpoint = function (endpoint, params, sucess, error) {
        var url = link + "/" + endpoint + (params ? "?JsonChamada=" + JSON.stringify(params) : "");
        $http.get(url)
        .then(function (response) {
            if (response.data.MensagemErro) {
                tratarErro(response.data.MensagemErro);
            } else {
                sucess(response);
            }
        }, function () {
            error();
        });
    };

    return {

        usuarioLogado: function () {

            if ($cookies.versaoUI) {
                if ($cookies.versaoUI != ultimaVersao) {
                    $templateCache.removeAll();
                    $cookies.versaoUI = ultimaVersao;
                    $window.location.reload();
                }
            } else {
                $templateCache.removeAll();
                $cookies.versaoUI = ultimaVersao;
                $window.location.reload();
            }

            if ($cookies.usuarioLogado) {
                usuarioLogado = JSON.parse($cookies.usuarioLogado);
            }
            if (!usuarioLogado.Token) {
                $location.path('/login');
            }
            return usuarioLogado;
        },
        setUsuarioLogado: function (value) {
            usuarioLogado = value;
            $cookies.usuarioLogado = JSON.stringify(value);
        },
        chamarEndpoint: chamarEndpoint,
        getWsLink: function () {
            return link;
        },
        listarPermissoes: function (token, form, sucess, error) {
            var params = {
                TokenAcesso: token,
                FormID: form
            };

            chamarEndpoint('ListPermissoesUsuario', params, function (response) {
                sucess(JSON.parse(response.data));
            }, function () {
                error();
            });
        },
        mostrarErroPermissao: function () {
            swal('Permiss\u00e3o insuficiente.', 'Voc\u00ea n\u00e3o tem permiss\u00e3o para acessar este formul\u00e1rio. Caso voc\u00ea acredite que isto \u00e9 um erro, contate o administrador de seu sistema.', 'error');
            $window.document.title = "ORGM ERP WEB";
            $location.path('/home');
        }
    };
});