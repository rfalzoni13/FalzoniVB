﻿Imports System.Net.Http
Imports System.Threading.Tasks
Imports FalzoniVB.Presentation.Administrator.Clients.Base
Imports FalzoniVB.Presentation.Administrator.Models.Common
Imports FalzoniVB.Presentation.Administrator.Models.Identity
Imports FalzoniVB.Presentation.Administrator.Models.Configuration
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Configuration
Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Configuration
Imports FalzoniVB.Utils.Helpers

Namespace Clients.Register
    Public Class UserClient
        Inherits BaseClient(Of UserModel, UserTableModel)
        Implements IUserClient

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Async Function GetAsync(url As String, id As String) As Task(Of UserModel)
            Using client As New HttpClient()
                client.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token)

                Dim response As HttpResponseMessage = Await client.GetAsync($"{url}?id={id}")
                If response.IsSuccessStatusCode Then
                    Dim model = Await response.Content.ReadAsAsync(Of UserModel)()

                    'Carregar foto do perfil
                    model.LoadProfilePhoto()

                    Return model
                Else
                    Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()
                    Throw New ApplicationException(statusCode.Message)
                End If
            End Using
        End Function

        Public Overrides Async Function GetTableAsync(url As String) As Task(Of UserTableModel)
            Dim table = New UserTableModel()

            Try
                Using client As New HttpClient()
                    client.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token)

                    Dim response As HttpResponseMessage = Await client.GetAsync(url)
                    If response.IsSuccessStatusCode Then
                        Dim users = Await response.Content.ReadAsAsync(Of ICollection(Of UserModel))()

                        For Each user In users
                            table.data.Add(New UserListTableModel With
                            {
                                .Id = user.Id,
                                .Name = user.Name,
                                .Email = user.Email,
                                .UserName = user.UserName,
                                .Gender = user.Gender,
                                .Created = user.Created,
                                .Modified = user.Modified
                            })
                        Next

                        table.recordsFiltered = table.data.Count
                        table.recordsTotal = table.data.Count
                    Else
                        Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()
                        Throw New ApplicationException(statusCode.Message)
                    End If
                End Using
            Catch ex As Exception
                table.error = ExceptionHelper.CatchMessageFromException(ex)
            End Try

            Return Await Task.FromResult(table)
        End Function

        Public Overrides Function Add(url As String, obj As UserModel) As String
            Dim model = New ApplicationUserModel(obj)

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token)

                Dim response As HttpResponseMessage = client.PostAsJsonAsync(url, model).Result
                If response.IsSuccessStatusCode Then
                    Return response.Content.ReadAsAsync(Of String)().Result
                Else
                    Dim statusCode As StatusCodeModel = response.Content.ReadAsAsync(Of StatusCodeModel)().Result

                    Throw New ApplicationException(statusCode.Message)
                End If
            End Using
        End Function

        Public Overrides Function Update(url As String, obj As UserModel) As String
            Dim model = New ApplicationUserModel(obj)

            Using client As New HttpClient()
                client.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token)

                Dim response As HttpResponseMessage = client.PutAsJsonAsync(url, model).Result
                If response.IsSuccessStatusCode Then
                    Dim retorno As String = response.Content.ReadAsAsync(Of String)().Result
                    Return retorno
                Else
                    Dim statusCode As StatusCodeModel = response.Content.ReadAsAsync(Of StatusCodeModel)().Result

                    Throw New ApplicationException(statusCode.Message)
                End If
            End Using
        End Function
    End Class
End Namespace
