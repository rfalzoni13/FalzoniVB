﻿Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web.Http
Imports FalzoniVB.Application.ServiceApplication.Register
Imports FalzoniVB.Presentation.Api.Models.Identity
Imports FalzoniVB.Presentation.Api.Utils
Imports NLog

Namespace Controllers.Admin.Register
    <CustomAuthorize(Roles:="Administrator")>
    <RoutePrefix("Api/User")>
    Public Class UserController
        Inherits ApiController

#Region "Attributes"
        Private Shared ReadOnly _logger As Logger = LogManager.GetCurrentClassLogger()
        Private ReadOnly _userServiceApplication As UserServiceApplication
#End Region

#Region "Constructor"
        Public Sub New(userServiceApplication As UserServiceApplication)
            _userServiceApplication = userServiceApplication
        End Sub
#End Region

#Region "Getters"
        ' GET Api/User/GetAll
        ''' <summary>
        ''' Listar todos os usuarios
        ''' </summary>
        ''' <response code="401">Unauthorized</response>
        ''' <response code="404">Not Found</response>
        ''' <response code="500">Internal Server Error</response>
        ''' <remarks>Listagem de todos os usuarios</remarks>
        ''' <returns></returns>
        <HttpGet>
        <Route("GetAll")>
        Public Function GetAll() As HttpResponseMessage
            Dim action As String = Me.ActionContext.ActionDescriptor.ActionName
            Try
                Dim retorno = _userServiceApplication.GetAll()
                If retorno IsNot Nothing And retorno.Count() > 0 Then
                    _logger.Info(action + " - Sucesso!")

                    _logger.Info(action + " - Finalizado")
                    Return Request.CreateResponse(HttpStatusCode.OK, retorno)
                Else
                    Throw New HttpResponseException(HttpStatusCode.NotFound)
                End If
            Catch ex As HttpResponseException
                If ex.Response.StatusCode = HttpStatusCode.NotFound Then
                    Return ResponseManager.ReturnExceptionNotFound(ex, Request, _logger, action, "Nenhum registro encontrado!")
                End If

                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            Catch ex As Exception
                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            End Try
        End Function

        ' GET Api/User/Get?id={Id}
        ''' <summary>
        ''' Listar usuário pelo Id
        ''' </summary>
        ''' <response code="400">Bad Request</response>
        ''' <response code="401">Unauthorized</response>
        ''' <response code="404">Not Found</response>
        ''' <response code="500">Internal Server Error</response>
        ''' <remarks>Retorna o usuário através do Id do mesmo</remarks>
        ''' <param name="Id">Id do usuário</param>
        ''' <returns></returns>
        <HttpGet>
        <Route("Get")>
        Public Function [Get](Id As Guid) As HttpResponseMessage
            Dim action As String = Me.ActionContext.ActionDescriptor.ActionName
            Try
                If Id <> Nothing Then
                    Dim usuario = _userServiceApplication.Get(Id)

                    If usuario IsNot Nothing Then

                        _logger.Info(action + " - Sucesso!")

                        _logger.Info(action + " - Finalizado")
                        Return Request.CreateResponse(HttpStatusCode.OK, usuario)
                    Else
                        Throw New HttpResponseException(HttpStatusCode.NotFound)
                    End If
                Else
                    Return ResponseManager.ReturnBadRequest(Request, _logger, action, "Parâmetro incorreto!")
                End If
            Catch ex As HttpResponseException
                If ex.Response.StatusCode = HttpStatusCode.NotFound Then
                    Return ResponseManager.ReturnExceptionNotFound(ex, Request, _logger, action, "Nenhum registro encontrado!")
                End If

                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            Catch ex As Exception
                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            End Try
        End Function
#End Region

#Region "Add User"
        ' POST Api/User/Add
        ''' <summary>
        ''' Inserir usuário
        ''' </summary>
        ''' <response code="400">Bad Request</response>
        ''' <response code="401">Unauthorized</response>
        ''' <response code="404">Not Found</response>
        ''' <response code="500">Internal Server Error</response>
        ''' <remarks>Insere um novo usuário passando um objeto no body da requisição no método POST</remarks>
        ''' <param name="applicationUserRegisterModel">Objeto de registro usuário</param>
        ''' <returns></returns>
        <HttpPost>
        <Route("Add")>
        Public Function Add(<FromBody> applicationUserRegisterModel As ApplicationUserRegisterModel) As HttpResponseMessage
            Dim action As String = Me.ActionContext.ActionDescriptor.ActionName

            Try
                If ModelState.IsValid Then
                    _logger.Info(action + " - Iniciado")

                    Dim userDto = applicationUserRegisterModel.ConvertToDTO()

                    _userServiceApplication.Add(userDto)

                    _logger.Info(action + " - Sucesso!")

                    _logger.Info(action + " - Finalizado")

                    Return Request.CreateResponse(HttpStatusCode.Created, "Usuário incluído com sucesso!")
                Else
                    Return ResponseManager.ReturnBadRequest(Request, _logger, action, "Por favor, preencha os campos corretamente!")
                End If
            Catch ex As HttpResponseException
                If ex.Response.StatusCode = HttpStatusCode.NotFound Then
                    Return ResponseManager.ReturnExceptionNotFound(ex, Request, _logger, action, "Nenhum registro encontrado!")
                End If

                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            Catch ex As Exception
                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            End Try
        End Function

        ' POST Api/User/AddAsync
        ''' <summary>
        ''' Inserir usuário modo assíncrono
        ''' </summary>
        ''' <response code="400">Bad Request</response>
        ''' <response code="401">Unauthorized</response>
        ''' <response code="404">Not Found</response>
        ''' <response code="500">Internal Server Error</response>
        ''' <remarks>Insere um novo usuário passando um objeto no body da requisição no método POST de forma assíncrona</remarks>
        ''' <param name="applicationUserRegisterModel">Objeto de registro usuário</param>
        ''' <returns></returns>
        <HttpPost>
        <Route("AddAsync")>
        Public Async Function AddAsync(<FromBody> applicationUserRegisterModel As ApplicationUserRegisterModel) As Task(Of HttpResponseMessage)
            Dim action As String = Me.ActionContext.ActionDescriptor.ActionName

            Try
                If ModelState.IsValid Then
                    _logger.Info(action + " - Iniciado")

                    Dim userDto = applicationUserRegisterModel.ConvertToDTO()

                    Await _userServiceApplication.AddAsync(userDto)

                    _logger.Info(action + " - Sucesso!")

                    _logger.Info(action + " - Finalizado")

                    Return Request.CreateResponse(HttpStatusCode.Created, "Usuário incluído com sucesso!")
                Else
                    Return ResponseManager.ReturnBadRequest(Request, _logger, action, "Por favor, preencha os campos corretamente!")
                End If
            Catch ex As HttpResponseException
                If ex.Response.StatusCode = HttpStatusCode.NotFound Then
                    Return ResponseManager.ReturnExceptionNotFound(ex, Request, _logger, action, "Nenhum registro encontrado!")
                End If

                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            Catch ex As Exception
                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            End Try
        End Function
#End Region

#Region "Update User"
        ' PUT Api/User/Update
        ''' <summary>
        ''' Atualizar usuário
        ''' </summary>
        ''' <response code="400">Bad Request</response>
        ''' <response code="401">Unauthorized</response>
        ''' <response code="404">Not Found</response>
        ''' <response code="500">Internal Server Error</response>
        ''' <remarks>Atualiza o usuário passando o objeto no body da requisição pelo método PUT</remarks>
        ''' <param name="applicationUserRegisterModel">Objeto de registro do usuário</param>
        ''' <returns></returns>
        <HttpPut>
        <Route("Update")>
        Public Function Update(<FromBody> applicationUserRegisterModel As ApplicationUserRegisterModel) As HttpResponseMessage
            Dim action As String = Me.ActionContext.ActionDescriptor.ActionName

            Try
                If ModelState.IsValid Then
                    _logger.Info(action + " - Iniciado")

                    Dim userDto = applicationUserRegisterModel.ConvertToDTO()

                    _userServiceApplication.Update(userDto)

                    _logger.Info(action + " - Sucesso!")

                    _logger.Info(action + " - Finalizado")

                    Return Request.CreateResponse(HttpStatusCode.OK, "Usuário atualizado com sucesso!")
                Else
                    Return ResponseManager.ReturnBadRequest(Request, _logger, action, "Por favor, preencha os campos corretamente!")
                End If
            Catch ex As HttpResponseException
                If ex.Response.StatusCode = HttpStatusCode.NotFound Then
                    Return ResponseManager.ReturnExceptionNotFound(ex, Request, _logger, action, "Nenhum registro encontrado!")
                End If

                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            Catch ex As Exception
                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            End Try
        End Function

        ' PUT Api/User/UpdateAsync
        ''' <summary>
        ''' Atualizar usuário modo assíncrono
        ''' </summary>
        ''' <response code="400">Bad Request</response>
        ''' <response code="401">Unauthorized</response>
        ''' <response code="404">Not Found</response>
        ''' <response code="500">Internal Server Error</response>
        ''' <remarks>Atualiza o usuário passando o objeto no body da requisição pelo método PUT de forma assíncrona</remarks>
        ''' <param name="applicationUserRegisterModel">Objeto de registro do usuário</param>
        <HttpPut>
        <Route("UpdateAsync")>
        Public Async Function UpdateAsync(<FromBody> applicationUserRegisterModel As ApplicationUserRegisterModel) As Task(Of HttpResponseMessage)
            Dim action As String = Me.ActionContext.ActionDescriptor.ActionName

            Try
                If ModelState.IsValid Then
                    _logger.Info(action + " - Iniciado")

                    Dim userDto = applicationUserRegisterModel.ConvertToDTO()

                    Await _userServiceApplication.UpdateAsync(userDto)

                    _logger.Info(action + " - Sucesso!")

                    _logger.Info(action + " - Finalizado")

                    Return Request.CreateResponse(HttpStatusCode.OK, "Usuário atualizado com sucesso!")
                Else
                    Return ResponseManager.ReturnBadRequest(Request, _logger, action, "Por favor, preencha os campos corretamente!")
                End If
            Catch ex As HttpResponseException
                If ex.Response.StatusCode = HttpStatusCode.NotFound Then
                    Return ResponseManager.ReturnExceptionNotFound(ex, Request, _logger, action, "Nenhum registro encontrado!")
                End If

                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            Catch ex As Exception
                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            End Try
        End Function

#End Region

#Region "Delete User"
        ' DELETE Api/User/Delete
        ''' <summary>
        ''' Excluir usuario
        ''' </summary>
        ''' <response code="400">Bad Request</response>
        ''' <response code="401">Unauthorized</response>
        ''' <response code="500">Internal Server Error</response>
        ''' <remarks>Exclui o usuario passando o objeto no body da requisição pelo método DELETE</remarks>
        ''' <param name="applicationUserRegisterModel">Objeto de registro do usuario</param>
        ''' <returns></returns>
        <HttpDelete>
        <Route("Delete")>
        Public Function Delete(<FromBody> applicationUserRegisterModel As ApplicationUserRegisterModel) As HttpResponseMessage
            Dim action As String = Me.ActionContext.ActionDescriptor.ActionName
            Try
                If ModelState.IsValid Then
                    _logger.Info(action + " - Iniciado")

                    Dim userDto = applicationUserRegisterModel.ConvertToDTO()

                    _userServiceApplication.Delete(userDto)

                    _logger.Info(action + " - Sucesso!")

                    _logger.Info(action + " - Finalizado")

                    Return Request.CreateResponse(HttpStatusCode.OK, "Usuário excluído com sucesso!")
                Else
                    Return ResponseManager.ReturnBadRequest(Request, _logger, action, "Por favor, preencha os campos corretamente!")
                End If
            Catch ex As Exception
                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            End Try
        End Function

        ' DELETE Api/User/DeleteAsync
        ''' <summary>
        ''' Excluir usuario assíncrono
        ''' </summary>
        ''' <response code="400">Bad Request</response>
        ''' <response code="401">Unauthorized</response>
        ''' <response code="500">Internal Server Error</response>
        ''' <remarks>Exclui o usuario passando o objeto no body da requisição pelo método DELETE de forma assíncrona</remarks>
        ''' <param name="applicationUserRegisterModel">Objeto de registro do usuario</param>
        ''' <returns></returns>
        <HttpDelete>
        <Route("DeleteAsync")>
        Public Async Function DeleteAsync(<FromBody> applicationUserRegisterModel As ApplicationUserRegisterModel) As Task(Of HttpResponseMessage)
            Dim action As String = Me.ActionContext.ActionDescriptor.ActionName
            Try
                If ModelState.IsValid Then
                    _logger.Info(action + " - Iniciado")

                    Dim userDto = applicationUserRegisterModel.ConvertToDTO()

                    Await _userServiceApplication.DeleteAsync(userDto)

                    _logger.Info(action + " - Sucesso!")

                    _logger.Info(action + " - Finalizado")

                    Return Request.CreateResponse(HttpStatusCode.OK, "Usuário excluído com sucesso!")
                Else
                    Return ResponseManager.ReturnBadRequest(Request, _logger, action, "Por favor, preencha os campos corretamente!")
                End If
            Catch ex As Exception
                Return ResponseManager.ReturnExceptionInternalServerError(ex, Request, _logger, action)
            End Try

        End Function

#End Region
    End Class
End Namespace