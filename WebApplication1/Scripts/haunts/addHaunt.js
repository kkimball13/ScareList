vm.addHaunt = _addHaunt;

function _addHaunt() {

  
    var url = "/api/haunts";
    var myData = $("#hauntInfo").serialize();

    var settings = {
        cache: false
        , contentType: "application/x-www.form-urlencoded; charset=UTF-8"
        , data: myData
        , dataType: "json"
        , success: vm.onPostSuccess
        , error: vm.onPostError
        , type: "POST"


    };

    $.ajax(url, settings);

}

function _onPostSuccess() {
    console.log("success");

    $location.path = '/directory/addhaunt';
    var frm = document.getElementsByName('hauntInfo')[0];
    frm.submit();
    frm.reset();
    return false;
    
}

function _onPostError(jqXhr, error) {
    console.log("error");

}
