﻿Imports System.Net.Http
Imports FalzoniVB.Presentation.Administrator.Clients.Base
Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Configuration
Imports FalzoniVB.Presentation.Administrator.Models.Common
Imports FalzoniVB.Presentation.Administrator.Models.Configuration
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Configuration
Imports FalzoniVB.Utils.Helpers

Namespace Clients.Register
    Public Class RoleClient
        Inherits BaseClient(Of RoleModel, RoleTableModel)
        Implements IRoleClient

        Public Function GetAllNames() As List(Of String) Implements IRoleClient.GetAllNames
            Dim url = UrlConfigurationHelper.RoleGetAllNames

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token)

                Dim response As HttpResponseMessage = client.GetAsync(url).Result
                If response.IsSuccessStatusCode Then
                    Dim roles = response.Content.ReadAsAsync(Of List(Of String))().Result

                    Return roles
                Else
                    Dim statusCode = response.Content.ReadAsAsync(Of StatusCodeModel)().Result

                    Throw New ApplicationException(statusCode.Message)
                End If
            End Using
        End Function
    End Class
End Namespace
