﻿Imports System.Threading.Tasks
Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Configuration
Imports FalzoniVB.Presentation.Administrator.Models.Common
Imports FalzoniVB.Presentation.Administrator.Models.Configuration
Imports FalzoniVB.Utils.Helpers

Public Class ProfileActionAttribute
    Inherits ActionFilterAttribute

    Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
        If HttpContext.Current.GetOwinContext().Authentication.User.Identity.IsAuthenticated Then
            Dim userClient As IUserClient = DependencyResolver.Current.GetService(GetType(IUserClient))

            Dim userId As String = HttpContext.Current.Request.GetOwinContext().Authentication.User.Claims.FirstOrDefault(Function(x) x.Type.Contains("nameidentifier")).Value

            Dim token = RequestHelper.GetAccessToken()

            If String.IsNullOrEmpty(token) Then Throw New Exception("Não autorizado!")

            Try
                Dim user As UserModel = filterContext.HttpContext.Session("UserData")
                If user Is Nothing Then
                    user = Task.Run(Async Function() Await userClient.GetAsync(UrlConfigurationHelper.UserGet, userId)).Result
                End If

                filterContext.HttpContext.Session("UserData") = user

                filterContext.Controller.ViewData("Usuario") = StringHelper.SetDashboardName(user.Name)
                filterContext.Controller.ViewData("Perfil") = user.Roles(0)
                filterContext.Controller.ViewData("Foto") = user.PhotoPath

            Catch ex As Exception
                filterContext.HttpContext.Session.Clear()
                filterContext.HttpContext.GetOwinContext().Authentication.SignOut("ApplicationCookie")
                filterContext.Controller.TempData("Return") = New ReturnModel With
                {
                    .Type = "Error",
                    .Message = ex.Message
                }

                filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary From
                {
                    {"area", String.Empty},
                    {"controller", "Account"},
                    {"action", "Login"}
                })
            End Try
        End If
    End Sub
End Class
