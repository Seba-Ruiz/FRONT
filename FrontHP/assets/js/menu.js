$(document).ready(function () {

    //var url = "/FrontHP/Home/Menu"; //para iis
    var url = "../Home/Menu"; //para local test
    var conc = '';

    $.getJSON(url, function (data) {
        $("#menurender").html("");

        //var menurender = [];
        //for (var i = 0; i < data.length; i++) {
        //    menurender[i] = data[i].app
        //}

        //function eliminateDuplicates(arr) {
        //    var i,
        //        len = arr.length,
        //        out = [],
        //        obj = {};

        //    for (i = 0; i < len; i++) {
        //        obj[arr[i]] = 0;
        //    }
        //    for (i in obj) {
        //        out.push(i);
        //    }
        //    return out;
        //}

        //var menurender = eliminateDuplicates(menurender);
        if (data == "Error") {
            $("#menurender").append('<li class="has_sub">' + "UD. NO POSEE PERMISOS" + '</li>');
        } else {
            for (var i = 0; i < data.length; i++) {
                
                        var txt =
                            '<li><a href=' + '"' + data[i].ruta + '"' +' class="waves-effect">' + data[i].app + '<span class="menu-arrow"></span></a></li>'

                $("#menurender").append(txt);
            }
        }
    });
});