function fazerPergunta() {

    
    var data = $("#Data").val();
    var nome = $("#Nome").val();
    var email = $("#Email").val();

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenfor = $('form[action="/Informacao/Create"] input[name="RequestVerificationToken"]').val();

    var headers = {};
    var headersfor = {};

    headers['__RequestVerificationToken'] = token;
    headersfor['__RequestVerificationToken'] = tokenfor;

    var url = "/Informacao/Create";
    $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        headers: headersfor,
        data: { Id: 0, Data: data, Nome: nome, Email: email, __RequestVerificationToken: token },
        succes: function (data) {
            if (data.Resultado > 0) {
                
                ListarComentarios(data.Resultado);
            }
        }
    });
}

function ListarComentarios(idInformacao) {
    var url = "/Comentarios/ListarComentarios";

    $.ajax({
        url: url,
        type: "GET",
        data: { id: idInformacao },
        datatype: "json",
        success: function (data) {
            var rcom = $("#rcom");
            rcom.empty();
            rcom.show();
            rcom.html(data);
        }
    });
}

function salvarComentario() {

    var assunto = $("#Assunto").val();
    var idInformacao = $('#idInformacao').val();

    var url = "/Comentario/salvarComentario";

    $.ajax({
        url: url,
        data: { assunto: assunto, idInformacao: idInformacao },
        type: "GET",
        datatype: "json",
        succes: function (data) {
            if (data.Resultado > 0) {
                ListarComentarios(idInformacao);
            }
        }
        });

}
