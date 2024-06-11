﻿Imports System.Threading.Tasks
Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Configuration
Imports FalzoniVB.Utils.Helpers

Public Class UserRegisterAttribute
    Inherits ActionFilterAttribute

    Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
        Dim roleClient As IRoleClient = DependencyResolver.Current.GetService(GetType(IRoleClient))

        If HttpContext.Current.GetOwinContext().Authentication.User.Identity.IsAuthenticated Then
            If filterContext.Controller.ViewBag.Perfis Is Nothing Then
                filterContext.Controller.ViewBag.Perfis = Task.Run(Async Function() Await roleClient.GetAllAsync(UrlConfigurationHelper.RoleGetAll)).Result
            End If
        End If

        MyBase.OnActionExecuting(filterContext)
    End Sub
End Class
