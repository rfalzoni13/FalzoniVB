﻿
@Code
    Layout = Nothing
End Code

@Styles.Render("~/bundles/bootstrap")
@Styles.Render("~/bundles/admin-lte")
@Styles.Render("~/bundles/admin-lte/skins")
@Styles.Render("~/Content/css")
@Scripts.Render("~/bundles/modernizr")

<title>Projeto Falzoni - @Response.StatusCode.ToString() Não Encontrado</title>

<div class="container">
    <div class="row">
        <h1 class="box-title">Projeto <b>Falzoni</b></h1>
    </div>
    <div class="row">
        <h1 class="text-center">@Response.StatusCode! Página não encontrada!</h1>
    </div>
</div>

@Scripts.Render("~/bundles/jquery")
@Scripts.Render("~/bundles/js/bootstrap")
