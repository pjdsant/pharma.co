/**
 * Service.js
 * Data: 25/08/2020
 * Descrição: Esse arquivo é responsavel por carregar os dados via &http.get do MVC Controller (Onde transformara os dados em Json)
 * Autor: Paulo Santos.
 */

clienteApp.service('clienteService', function ($http) {

    this.listarClientes = function () {
        return $http.get("/Cliente/ListarCliente");
    }

    this.adicionarCliente = function (cliente) {
        var request = $http({
            method: 'post',
            url: '/Cliente/AdicionarCliente',
            data: cliente
        });

        return request;
    }

    this.adicionarClienteProc = function (cliente) {
        var request = $http({
            method: 'post',
            url: '/Cliente/AdicionarClienteProc',
            data: cliente
        });

        return request;
    }

});