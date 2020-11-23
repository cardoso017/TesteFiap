function FnContato() {

    if (!ValidarNome())
    { return false };

    $(".overlay").show();

    capturando = document.getElementById('Contato_Nome').value;


    var vFuncionalidade = {
        "Contato": {
            "Nome": capturando
        }
    }


    $.ajax({
        type: "POST",
        url: "../Contatos/Create",
        dataType: "json",
        data: vFuncionalidade,
        success: function (data) {
            if (data.idContato > 0) {
             
                ListarItens(data.idContato);
                ListarItensTelefone(data.idContato);
            }
        },
    });


}


function ListarItensTelefone(idContato) {

    


    $.ajax({
        type: "GET",
        url: "https://localhost:44350/Telefones/Index",
        dataType: "html",
        data: { id: idContato },
        success: function (data) {
            var divItens = $("#divTelefone");
            divItens.empty();
            divItens.show();
            divItens.html(data)



        },
        error: function (response) {
            alert(vMsgErro + response.responseText);
        },
        complete: function () {
            $(".overlay").hide();
        }
    });


}

function ListarItens(idContato) {

    


    $.ajax({
        type: "GET",
        url: "https://localhost:44350/Emails/Index",
        dataType: "html",
        data: { id: idContato },
        success: function (data) {
            var divItens = $("#divEmail");
            divItens.empty();
            divItens.show();
            divItens.html(data)

        },
        error: function (response) {
            alert(vMsgErro + response.responseText);
        },
        complete: function () {
            $(".overlay").hide();
        }
    });


}










function FnEmail(idContato) {


    if (!ValidarEmail()) { return false };

    $(".overlay").show();

    capturando = document.getElementById('emails_Email').value;
   

    var vFuncionalidade =   {
            "Email": capturando, 
            IdContato: idContato
    }



    $.ajax({
        type: "POST",
        url: "https://localhost:44350/Emails/Create",
        dataType: "json",
        data: vFuncionalidade,
        success: function (data) {
            if (data.idContato > 0) {
            
                ListarItens(data.idContato);
            }
        },
    });


}




function FnTelefone(idContato) {

   

    $(".overlay").show();

    capturando = document.getElementById('Telefone_Numero').value;


    var vFuncionalidade = {
        "Numero": capturando,
        IdContato: idContato
    }


    $.ajax({
        type: "POST",
        url: "https://localhost:44350/Telefones/Create",
        dataType: "json",
        data: vFuncionalidade,
        success: function (data) {
            if (data.idContato > 0) {
              
                ListarItensTelefone(data.idContato);
            }
        },
    });


}



function FnDetailsEmail(IdContato) {



    $(".overlay").show();

    var vFuncionalidade = { id: IdContato }



    $.ajax({
        type: "GET",
        url: "https://localhost:44350/Emails/Edit",
        dataType: "HTML",

        data: vFuncionalidade,
        success: function (data) {
            $("#DivEditarEmail").html(data);
            $("#ModalEditarEmail").modal('show');
        },
        error: function (response) {
            alert(vMsgErro + response.responseText);
        },
        complete: function () {
            $(".overlay").hide();
        }
    });


}

function FnEditarEmail(idContato, idEmail) {



    $(".overlay").show();

    capturando = document.getElementById('Email').value;


    var vFuncionalidade = {
        "Email": capturando,
        IdEmail: idEmail,
        IdContato: idContato
    }


    $.ajax({
        type: "POST",
        url: "https://localhost:44350/Emails/Edit",
        dataType: "json",
        data: vFuncionalidade,
        success: function (data) {
            if (data.idContato > 0) {

                $("#ModalEditarEmail").modal('hide').on('hidden.hidden.bs.modal', function () {
                    ListarItens(idContato);
                });

            }
        },
    });


}



function fnDeletarEmail(idContato, idEmail) {



    $(".overlay").show();

    capturando = document.getElementById('Email').value;


    var vFuncionalidade = {
   
        id: idEmail
       
    }


    $.ajax({
        type: "POST",
        url: "https://localhost:44350/Emails/DeleteConfirmed",
        dataType: "json",
        data: vFuncionalidade,
        success: function (data) {
            if (data.idContato > 0) {

                $("#ModalEditarEmail").modal('hide').on('hidden.hidden.bs.modal', function () {
                    ListarItens(idContato);
                });

            }
        },
    });


}


function FnLoad(id) {
    ListarItens(id);
    ListarItensTelefone(id);
}



function FnDetailsTelefone(IdContato) {



    $(".overlay").show();

    var vFuncionalidade = { id: IdContato }



    $.ajax({
        type: "GET",
        url: "https://localhost:44350/Telefones/Edit",
        dataType: "HTML",

        data: vFuncionalidade,
        success: function (data) {
            $("#DivEditarTelefone").html(data);
            $("#ModalEditarTelefone").modal('show');
        },
        error: function (response) {
            alert(vMsgErro + response.responseText);
        },
        complete: function () {
            $(".overlay").hide();
        }
    });


}



function FnEditarTelefone(idContato, idTelefone) {


    $(".overlay").show();

    capturando = document.getElementById('Numero').value;


    var vFuncionalidade = {
        "Numero": capturando,
        IdTelefone: idTelefone,
        IdContato: idContato
    }


    $.ajax({
        type: "POST",
        url: "https://localhost:44350/Telefones/Edit",
        dataType: "json",
        data: vFuncionalidade,
        success: function (data) {
            if (data.idContato > 0) {

                $("#ModalEditarTelefone").modal('hide').on('hidden.hidden.bs.modal', function () {
                    ListarItensTelefone(idContato);
                });

            }
        },
    });


}


function fnDeletarTelefone(idContato, idTelefone) {


    $(".overlay").show();

    capturando = document.getElementById('Numero').value;


    var vFuncionalidade = {
     
        id: idTelefone
      
    }


    $.ajax({
        type: "POST",
        url: "https://localhost:44350/Telefones/Delete",
        dataType: "json",
        data: vFuncionalidade,
        success: function (data) {
            if (data.idContato > 0) {

                $("#ModalEditarTelefone").modal('hide').on('hidden.hidden.bs.modal', function () {
                    ListarItensTelefone(idContato);
                });

            }
        },
    });


}

function ValidarNome() {


    nome = document.getElementById('Contato_Nome').value;
    
    if (nome == "" ) {
        alert("Insira um nome válido.");
        return false;
    }

    if (nome.length >= 50) {
        alert("Onome deve possuir 50 caracteres");

        return false;
    }


    return true;

}


function ValidarEmail() {


    email = document.getElementById('emails_Email').value;

    if (email == "" || !validarEmail(email)) {
        alert("Insira um email válido.");
        return false;
    }

    if (email.length >= 50) {
        alert("Onome deve possuir 50 caracteres");

        return false;
    }



    return true;

}


function validarEmail(email) {
    var emailFilter = /^\S+\@(\[?)[a-zA-Z0-9_\-\.]+\.([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    if (!(emailFilter.test(email))) {
        return false;
    } else {
        return true;
    }
}

