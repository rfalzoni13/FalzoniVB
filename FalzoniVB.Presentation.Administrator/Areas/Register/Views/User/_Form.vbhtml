﻿@ModelType FalzoniVB.Presentation.Administrator.Models.Register.UserModel
@Code
    Dim action = ViewContext.RouteData.GetRequiredString("action")
    Dim roles = New List(Of String)()

    If ViewData("Perfis") IsNot Nothing Then
        Dim list = CType(ViewData("Perfis"), List(Of FalzoniVB.Presentation.Administrator.Models.Register.RoleModel))
        roles = list.Select(Function(x) x.Name).Distinct().ToList()
    End If
End Code

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        @(If(action = "Create", "Novo Usuário", "Editar Usuário"))
    </h1>
    <ol class="breadcrumb">
        <li><a href="@Url.Action("Index", "Home", New With {.Area = String.Empty})"><i class="glyphicon glyphicon-home"></i> Home</a></li>
        <li><a href="@Url.Action("Index", "Usuario", New With {.Area = "Cadastro"})"><i class="glyphicon glyphicon-edit"></i> Cadastro</a></li>
        <li><a href="@Url.Action("Index", "Usuario", New With {.Area = "Cadastro"})"><i class="fa fa-user"></i> Usuário</a></li>
        <li class="active"><i class="fa fa-plus-square"></i> @(If(action = "Create", "Novo", "Editar"))</li>
    </ol>
</section><!--section -->

<section class="content container-fluid">
    <div class="col-12">
        <div class="box box-primary">
            <div class="box-header with-border">
                <h3 class="box-title">Dados cadastrais</h3>
            </div>
            @Using (Html.BeginForm(action, "Usuario", New With {.Area = "Cadastro"}, FormMethod.Post, New With {.class = "form-user", .enctype = "multipart/form-data"}))
                @<div Class="box-body">
                    @Html.Partial("_ReturnMessages")
                    @Html.HiddenFor(Function(x) x.Id)
                    <div class="row mb-15">
                        <div class="col-md-2">
                            <img class="img-responsive img-bordered user-box" id="PhotoImg" src="@(If(Not String.IsNullOrEmpty(Model.PhotoPath), Model.PhotoPath, "/Content/Images/Profile/user.png"))" />
                        </div>
                    </div>
                    <div class="row mb-15">
                        <div class="col-md-2">
                            <input type="file" id="FileProfile" name="FileProfile" style="display:none" />
                            <button type="button" id="BtnPhoto" class="btn btn-block btn-primary">Inserir foto</button>
                        </div>
                    </div>
                    <div class="row mb-15">
                        <div class="col-md-5">
                            @Html.LabelFor(Function(x) x.Name)
                            @Html.TextBoxFor(Function(x) x.Name, New With {.class = "form-control", .autofocus = "autofocus"})
                        </div>
                        <div class="col-md-4">
                            @Html.LabelFor(Function(x) x.Email)
                            @Html.TextBoxFor(Function(x) x.Email, New With {.class = "form-control"})
                        </div>
                        @If Model.Gender IsNot Nothing Then
                            @<div class="col-md-3">
                                @Html.Label("Sexo")
                                @Html.DropDownListFor(Function(x) x.Gender, Model.Genders, "Selecione...", New With {.class = "form-control"})
                            </div>
                        End If
                    </div>
                    <div class="row mb-15">
                        @If roles.Count() > 0 Then
                            @<div class="col-md-3">
                                @Html.Label("Acessos")
                                @Html.ListBoxFor(Function(x) x.Roles, New MultiSelectList(roles), New With {.multiple = "multiple", .class = "form-control"})
                            </div>
                        End If
                        <div class="col-md-3">
                            @Html.LabelFor(Function(x) x.DateBirth)
                            <div class="input-group date" data-provide="datepicker">
                                <div class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </div>
                                @Html.TextBoxFor(Function(x) x.DateBirth, New With {.Value = If(Model.DateBirth > Date.MinValue, Model.DateBirth.ToString("dd/MM/yyyy"), String.Empty), .class = "form-control pull-right"})
                            </div>
                        </div>
                        <div class="col-md-3">
                            @Html.LabelFor(Function(x) x.PhoneNumber)
                            @Html.TextBoxFor(Function(x) x.PhoneNumber, New With {.class = "form-control phone"})
                        </div>
                        <div class="col-md-3">
                            @Html.LabelFor(Function(x) x.UserName)
                            @Html.TextBoxFor(Function(x) x.UserName, New With {.class = "form-control"})
                        </div>
                    </div>
                </div>
                @<div class="box-footer">
                    <div class="row">
                        <div class="col-md-2">
                            <button id="Send" class="btn btn-success btn-block" type="submit">@(If(action = "Create", "Cadastrar", "Salvar"))</button>
                        </div>
                        <div class="col-md-2">
                            @Html.ActionLink("Voltar", "Index", Nothing, New With {.class = "btn btn-default btn-block"})
                        </div>
                    </div>
                </div>
            End Using
        </div>
    </div> <!-- /container -->
</section>
