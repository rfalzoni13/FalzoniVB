@ModelType FalzoniVB.Presentation.Administrator.Models.Identity.ForgotPasswordModel

@Code
    ViewData("Title") = "Recuperar Senha"
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Projeto Falzoni - @ViewData("Title")</title>
    @Styles.Render("~/bundles/bootstrap")
    @Styles.Render("~/bundles/admin-lte")
    @Styles.Render("~/bundles/admin-lte/skins")
    @Styles.Render("~/Content/css/Login")
    @Scripts.Render("~/bundles/modernizr")
    <style>
        body {
            background-color: #ebebeb;
        }
    </style>
</head>
<body class="hold-transition login-page">
    <div class="login-box">
        <div class="login-logo">
            <p>Projeto <b>Falzoni</b></p>
        </div>
        <!-- /.login-logo -->
        <div class="login-box-body">
            @Html.Partial("_ReturnMessages")
            <h4 class="login-box-msg">@FalzoniVB.Resources.My.Resources.Domain.PasswordRecovery</h4>
            @Using (Html.BeginForm("Login", "Account", FormMethod.Post, New With {.class = "form-signin"}))
                @<div class="form-group has-feedback">
                    @Html.TextBoxFor(Function(x) x.Email, New With { .type = "email", .id = "Senha", .class = "form-control", .placeholder = "Digite seu e-mail"})
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
                @<div class="row">
                    <div class="col-md-12">
                        <button type = "submit" class="btn btn-success btn-block btn-flat">@FalzoniVB.Resources.My.Resources.Actions.Enter</button>
                    </div>
                </div>
            End Using
            <br />
            @Html.ActionLink(FalzoniVB.Resources.My.Resources.Login.BackToLogin, "Login", "Account")
        </div>
        <!-- /.login-box-body -->
    </div>

    <div class="container container-footer">
        <footer>
            <p>&copy; @DateTime.Now.Year - Renato Falzoni - @FalzoniVB.Resources.My.Resources.Login.Copyright</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/js/bootstrap")
    @Scripts.Render("~/bundles/js/admin-lte")
    @Scripts.Render("~/bundles/Scripts")
</body>
</html>
