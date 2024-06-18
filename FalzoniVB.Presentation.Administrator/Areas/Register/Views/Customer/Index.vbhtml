﻿@Code
    ViewData("Title") = "Módulo clientes"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Section styles
    @If FalzoniVB.Utils.Helpers.ConfigurationHelper.IsBundleled Then
        @Styles.Render("~/bundles/datatable")
    Else
        @<link href="https://cdn.datatables.net/v/bs/jszip-3.10.1/dt-2.0.8/b-3.0.2/b-html5-3.0.2/b-print-3.0.2/r-3.0.2/sc-2.4.3/datatables.min.css" rel="stylesheet">
    End If
End Section


<!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
        <h1>
            Módulo Clientes
        </h1>
        <ol class="breadcrumb">
            <li><a href="@Url.Action("Index", "Home", New With {.Area = String.Empty})"><i class="glyphicon glyphicon-home"></i> Home</a></li>
            <li class="active"><i class="glyphicon glyphicon-edit"></i> Cadastro</li>
            <li class="active"><i class="fa fa-user"></i> Cliente</li>
        </ol>
    </section><!--section -->
    <!-- Main content -->
    <section class="content container-fluid">
        @Html.Partial("_ReturnMessages")
        <div class="row">
            <div class="col-md-12">
                @Html.ActionLink("Novo cliente", "Create", "Customer", New With {.Area = "Register"}, New With {.class = "btn btn-info"})
            </div><!-- /.col-lg-6 -->
        </div><!-- /.row -->
        <br /><br />
        <div class="row">
            <div class="col-md-12 col-sm-6">
                <div class="box box-info">
                    <div class="box-header">
                        <h3 class="box-title">Lista de clientes</h3>
                    </div>
                    <div class="box-body">
                        <div class="table-responsive">
                            <table id="CustomerTable" class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>
                                            @Html.DisplayName("Nome")
                                        </th>
                                        <th>
                                            @Html.DisplayName("Gênero")
                                        </th>
                                        <th>
                                            @Html.DisplayName("Email")
                                        </th>
                                        <th>
                                            @Html.DisplayName("Documento")
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
    @If FalzoniVB.Utils.Helpers.ConfigurationHelper.IsBundleled Then
        @Scripts.Render("~/bundles/js/datatable")
        @Scripts.Render("~/bundles/js/moment")
    Else
        @<script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.2.7/pdfmake.min.js"></script>
        @<script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.2.7/vfs_fonts.js"></script>
        @<script src="https://cdn.datatables.net/v/bs/jszip-3.10.1/dt-2.0.8/b-3.0.2/b-html5-3.0.2/b-print-3.0.2/r-3.0.2/sc-2.4.3/datatables.min.js"></script>
        @<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.26.0/moment.min.js" integrity="sha512-QkuqGuFAgaPp3RTyTyJZnB1IuwbVAqpVGN58UJ93pwZel7NZ8wJOGmpO1zPxZGehX+0pc9/dpNG9QdL52aI4Cg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
        @<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.26.0/moment-with-locales.min.js" integrity="sha512-yT/SWoCe2HVxCkQHbD+kjcQCxDld8tCyij/NH8bO36Ae4HDKhd8n2xJy7E22ETNpxXPr4hfY/UACaSEdSn7mtA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>

        @Scripts.Render("~/Scripts/core/datatable-utils.js")
    End If

    @Scripts.Render("~/Scripts/register/customer/main.js")

End Section
