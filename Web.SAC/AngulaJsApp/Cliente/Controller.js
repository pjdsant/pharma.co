/**
 * Controller.js
 * Data: 25/08/2020
 * Descrição: Esse arquivo vai conter o código do 'clienteController' a qual o usaremos para poder realizar o modulo de 'clientes'
 * Autor: Paulo Santos.
 */

//Controller - Cliente:
clienteApp.controller('clienteController', function ($scope, clienteService) {

    //Aqui carregamos os dados dos clientes cadastrados quando a pagina for recarregada.
    carregarClientes();

    function carregarClientes() {
        var listarClientes = clienteService.listarClientes();

        listarClientes.then(function (d) {
            // Ret ok
            $scope.Clientes = d.data;
        },

            function () {
                alert("Ocorreu um erro ao tentar listar todos os Clientes!");
            });
    }

    //Metodo responsavel por adicionar um cliente
    $scope.adicionarCliente = function () {

        var cliente = {
            clienteId: $scope.clienteId,
            nome: $scope.nome,
            usuario: $scope.usuario,
            email: $scope.email,
            senha: $scope.senha
        };

        var adicionarInfos = clienteService.adicionarClienteProc(cliente); //clienteService.adicionarCliente(cliente);

        adicionarInfos.then(function (d) {
            if (d.data.success === true) {
                carregarClientes();
                alert("Cliente cadastrado com Sucesso!");

                $scope.limparDados();

            } else { alert("Cliente não Cadastrado!"); }
        },
            function () {
                alert("Erro ao tentar cadastrar um Novo Cliente!");
            });
    }

    $scope.limparDados = function () {
        $scope.clienteId = "";
        $scope.nome = "";
        $scope.usuario = "";
        $scope.email = "";
        $scope.senha = "";
    }


    $scope.validarCampos = function (formValid) {
        if (formValid) {
            alert('Seu formulário está corretamente preenchido.');
        } else {
            alert('Erro ao preencher o formulário');
        }
    }

});