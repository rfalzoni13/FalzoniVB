﻿Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports FalzoniVB.Presentation.Administrator.Models.Base
Imports FalzoniVB.Presentation.Administrator.Models.Common
Imports FalzoniVB.Utils.Helpers
Imports Newtonsoft.Json.Linq

Namespace Models.Register
    Public Class UserModel
        Inherits BaseModel

        <Required(ErrorMessage:="O nome é obrigatório")>
        Public Property Name As String

        <DisplayName("E-mail")>
        <Required(ErrorMessage:="O e-mail é obrigatório")>
        Public Property Email As String

        <DisplayName("Gênero")>
        <Required(ErrorMessage:="O gênero é obrigatório")>
        Public Property Gender As String

        <DisplayName("Data de nascimento")>
        Public Property DateBirth As Date

        Public Property UserName As String

        Public Property PhoneNumber As String

        Public Property PhotoPath As String

        Public Property Roles As String()

        Public Overridable Property File As FileModel

        Public Overridable ReadOnly Property Genders As List(Of SelectListItem)
            Get
                Return New List(Of SelectListItem) From
                {
                    New SelectListItem With
                    {
                        .Text = "Masculino",
                        .Value = "Masculino"
                    },
                    New SelectListItem With
                    {
                        .Text = "Feminino",
                        .Value = "Feminino"
                    }
                }
            End Get
        End Property

        'Methods
        Public Sub LoadProfilePhoto()
            Me.PhotoPath = If(Not String.IsNullOrEmpty(PhotoPath), $"{UrlConfigurationHelper.PathUrl}\\{PhotoPath}", Me.PhotoPath)
        End Sub
    End Class
End Namespace
