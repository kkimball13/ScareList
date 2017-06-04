(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', main);

    function main() {
        var vm = this;
        vm.showSuccessAlert = false;

        vm.receiveItems = _receiveItems;
        vm.getAllHaunts = _getAllHaunts;

        //$(document).ready(function () {
        //    _receiveItems();
        //    console.log("test");

        //});


        function _receiveItems(_onGetSuccess, _onGetError) {
                vm.getAllHaunts()

        }

        function _getAllHaunts(onSuccess, onError){
        console.log("getting items");

        var url = "/api/haunts";

        var settings = {
            cache: false
            , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
            , dataType: "json"
            , success: vm.onGetSuccess
            , error: vm.onGetError
            , type: "GET"


        };

        $.ajax(url, settings);
        }

        function _onGetSuccess(data, status, xhr) {
            console.log("success");
            console.log(data.items);

        }

        function _onGetError() {
            console.log("error");
    

        }
    }
})();