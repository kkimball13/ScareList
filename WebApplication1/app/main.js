(function () {
    'use strict';

    angular
        .module('app')
        .controller('Main', main);

    function main() {
        var vm = this;
        vm.showSuccessAlert = false;

        vm.addHaunt = _addHaunt;
        vm.hauntInfo = null;
        vm.onPostSuccess = _onPostSuccess;
        vm.onPostError = _onPostError;
        vm.resetForm = _resetForm;



        function _addHaunt(addHaunt) {

            console.log("button clicked");

            var url = "/api/haunts";
            var myData = $("#hauntInfo").serialize();

            var settings = {
                cache: false
                , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
                , data: myData
                , dataType: "json"
                , success: vm.onPostSuccess(myData)
                , error: vm.onPostError
                , type: "POST"


            };

            $.ajax(url, settings);

        }

        function _onPostSuccess(myData, status, xhr) {
            vm.showSuccessAlert = true;
            console.log("success");
            vm.resetForm();

        }

        function _onPostError(jqXhr, error) {
            console.log("error");

        }

        function _resetForm() {

            document.getElementById("hauntInfo").reset();
            alert("Haunt successfully submitted");

        };



        $.getJSON('https://data.lacity.org/resource/xyvg-dst2.json', function (data) {
            console.log(data);
            //vm.displayData(data);
        });


    }

})();