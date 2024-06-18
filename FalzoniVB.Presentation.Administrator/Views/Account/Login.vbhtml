﻿@ModelType FalzoniVB.Presentation.Administrator.Models.Identity.LoginModel

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

    @If FalzoniVB.Utils.Helpers.ConfigurationHelper.IsBundleled Then
        @Styles.Render("~/bundles/bootstrap")
        @Styles.Render("~/bundles/admin-lte")
        @Scripts.Render("~/bundles/modernizr")
    Else
        @<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/css/bootstrap.min.css" integrity="sha384-HSMxcRTRxnN+Bdg0JdbxYKrThecOKuH5zCYotlSAcp1+c8xmyTe9GYg1l9a69psu" crossorigin="anonymous">
        @<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/admin-lte/2.4.0/css/AdminLTE.min.css" integrity="sha512-WwxBYWUrN/LPCceidkNpgYFBiIjrickdz+Ts+55PAzTJ9sSP8EVfId6lq0cl3/kSnGECF/7v3p3BnCLkvVhs/w==" crossorigin="anonymous" referrerpolicy="no-referrer" />
        @<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/admin-lte/2.4.0/css/skins/_all-skins.min.css" integrity="sha512-D231SkmJ+61oWzyBS0Htmce/w1NLwUVtMSA05ceaprOG4ZAszxnScjexIQwdAr4bZ4NRNdSHH1qXwu1GwEVnvA==" crossorigin="anonymous" referrerpolicy="no-referrer" />
        @<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/iCheck/1.0.3/skins/square/_all.min.css" integrity="sha512-Si0tdN9RhAc4k9mvo3AqFVLXyCMxM0+Tx1W1upLlnTSnQGakisa7IYapyEWbwMba0lu3USKjLO82VB/j1K6F9A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
        @<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha512-SfTiTlX6kk+qitfevl/7LibUOeJWlt9rbyDn92a1DqWOw9vWG2MFoays0sgObmWazO5BQPiFucnnEAjpAB+/Sw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
        @<script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js" integrity="sha512-3n19xznO0ubPpSwYCRRBgHh63DrV+bdZfHK52b1esvId4GsfwStQNPJFjeQos2h3JwCmZl0/LgLxSKMAI55hgw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    End If

    @Styles.Render("~/Content/Login.css")

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
            @Html.ActionLink(FalzoniVB.Resources.My.Resources.Login.ForgotMyPassword, "ForgotPassword", "Account")
        </div>
    </div>

    <div class="container container-footer">
        <footer>
            <p>&copy; @Date.Now.Year - Renato Falzoni - @FalzoniVB.Resources.My.Resources.Login.Copyright</p>
        </footer>
    </div>

    @If FalzoniVB.Utils.Helpers.ConfigurationHelper.IsBundleled Then
        @Scripts.Render("~/bundles/jquery")
        @Scripts.Render("~/bundles/js/bootstrap")
        @Scripts.Render("~/bundles/js/admin-lte")
        @Scripts.Render("~/bundles/js/core")
    Else
        @<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.min.js" integrity="sha512-v2CJ7UaYy4JwqLDIrZUI/4hqeoQieOmAZNXBeQyjo21dadnwR+8ZaIJVT8EE2iyI61OV8e6M8PP2/4hpQINQ/g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
        @<script src="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/js/bootstrap.min.js" integrity="sha384-aJ21OjlMXNL5UyIl/XNwTMqvzeRMZH2w8c5cRVpzpU8Y5bApTppSuUkhZXN0VxHd" crossorigin="anonymous"></script>
        @<script src="https://cdnjs.cloudflare.com/ajax/libs/admin-lte/2.4.0/js/adminlte.min.js" integrity="sha512-4LW2vmg8t+drPiNqhkUrtVZ3M/UCyhEhVasHYx7d+mXKjcw/G0BSuQ78FnkzPyWU23QBXtTUrKoPmX95KTLE4A==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
        @<script src="https://cdnjs.cloudflare.com/ajax/libs/iCheck/1.0.3/icheck.min.js" integrity="sha512-RGDpUuNPNGV62jwbX1n/jNVUuK/z/GRbasvukyOim4R8gUEXSAjB4o0gBplhpO8Mv9rr7HNtGzV508Q1LBGsfA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>

        @Scripts.Render("~/Scripts/core/root.js")
        @Scripts.Render("~/Scripts/core/routes.js")
    End If

    @Scripts.Render("~/Scripts/account/login/login.js")

</body>
</html>
