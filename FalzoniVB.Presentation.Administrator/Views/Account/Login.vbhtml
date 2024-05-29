@ModelType FalzoniVB.Presentation.Administrator.Models.Identity.LoginModel

@Code
    ViewData("Title") = "Login"
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
    <link rel="stylesheet" href="@Url.Content("~/Content/login.css")" />
    @Scripts.Render("~/bundles/modernizr")
</head>
<body class="hold-transition login-page">
    <div class="loading">
        <div class="loader"></div>
    </div>
    <div class="login-box">
        <div class="login-logo">
            <p>Projeto <b>Falzoni</b></p>
        </div>
        <!-- /.login-logo -->
        <div class="login-box-body">
            @Html.Partial("_ReturnMessages")

            <h4 class="login-box-msg">@FalzoniVB.Resources.My.Resources.Domain.AdministrationPanel</h4>

            @Using (Html.BeginForm("Login", "Account", FormMethod.Post, New With {.class = "form-signin"}))
                @Html.AntiForgeryToken()

                @<div class="form-group has-feedback">
                    @Html.TextBoxFor(Function(x) x.Login, New With {.id = "Email", .class = "form-control", .autofocus = "autofocus", .placeholder = FalzoniVB.Resources.My.Resources.Login.Email})
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
                @<div class="form-group has-feedback">
                    @Html.TextBoxFor(Function(x) x.Password, New With {.type = "password", .id = "Senha", .class = "form-control", .placeholder = FalzoniVB.Resources.My.Resources.Login.Password})
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                @<div class="row">
                    <div class="col-xs-8">
                        <div class="checkbox icheck">
                            <label for="RememberMe">
                                @Html.CheckBoxFor(Function(x) x.RememberMe) @FalzoniVB.Resources.My.Resources.Login.RememberMe
                            </label>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <button type="submit" class="btn btn-success btn-block btn-flat">@FalzoniVB.Resources.My.Resources.Actions.Enter</button>
                    </div>
                </div>
            End Using
            <br />
            @Html.ActionLink(FalzoniVB.Resources.My.Resources.Login.ForgotMyPassword, "EsqueciMinhaSenha", "Account")
        </div>
     </div>

    <div class="container container-footer">
        <footer>
            <p>&copy; @Date.Now.Year - Renato Falzoni - @FalzoniVB.Resources.My.Resources.Login.Copyright</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/js/bootstrap")
    @Scripts.Render("~/bundles/js/admin-lte")
    @Scripts.Render("~/bundles/js/core")
    <script src="@(Url.Content("~/Scripts/login/login.js"))"></script>

    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' /* optional */
            });
        });
    </script>
</body>
</html>
