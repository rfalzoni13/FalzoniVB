Imports System.Web.Http
Imports Unity.WebApi

Namespace FalzoniVB.Infra.IoC
    Public Class UnityConfig
        Public Shared Sub Register(config As HttpConfiguration)
            Dim container = UnityModule.LoadModules()
            config.DependencyResolver = New UnityDependencyResolver(container)
        End Sub
    End Class
End Namespace
