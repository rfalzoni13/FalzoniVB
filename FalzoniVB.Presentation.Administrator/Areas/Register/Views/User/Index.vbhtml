﻿@Code
    ViewData("Title") = "Módulo usuários"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section styles
    @Styles.Render("~/bundles/datatable")
End Section

<!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Módulo Usuários
        </h1>
        <ol class="breadcrumb">
            <li><a href="@Url.Action("Index", "Home", New With {.Area = String.Empty})"><i class="glyphicon glyphicon-home"></i> Home</a></li>
            <li class="active"><i class="glyphicon glyphicon-edit"></i> Cadastro</li>
            <li class="active"><i class="fa fa-user"></i> Usuário</li>
        </ol>
    </section><!--section -->
    <!-- Main content -->
    <section class="content container-fluid">
        @Html.Partial("_ReturnMessages")
        <div class="row">
            <div class="col-md-12">
                @Html.ActionLink("Novo usuário", "Create", "User", New With {.Area = "Register"}, New With {.class = "btn btn-info"})
            </div><!-- /.col-lg-6 -->
        </div><!-- /.row -->
        <br /><br />
        <div class="row">
            <div class="col-md-12 col-sm-6">
                <div class="box box-info">
                    <div class="box-header">
                        <h3 class="box-title">Lista de usuários</h3>
                    </div>
                    <div class="box-body">
                        <div class="table-responsive">
                            <table id="UserTable" class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>
                                            @Html.DisplayName("Nome")
                                        </th>
                                        <th>
                                            @Html.DisplayName("Email")
                                        </th>
                                        <th>
                                            @Html.DisplayName("Login")
                                        </th>
                                        <th>
                                            @Html.DisplayName("Gênero")
                                        </th>
                                        <th>
                                            @Html.DisplayName("Inserido em:")
                                        </th>
                                        <th>
                                            @Html.DisplayName("Modificado em:")
                                        </th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div><!-- /.row -->
    </section><!--section-->
</div><!--div-->

@Section modals
    @Html.Partial("_ModalSuccess")
    @Html.Partial("_ModalError")
    @Html.Partial("_ModalWarning")
End Section

@section scripts
    @Scripts.Render("~/bundles/js/datatable")
    @Scripts.Render("~/bundles/js/moment")
    <script type="text/javascript" src="@Url.Content("~/Scripts/register/user/main.js")"></script>
End Section