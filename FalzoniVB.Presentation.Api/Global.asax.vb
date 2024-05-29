Imports System.Web.Http

Public Class WebApiApplication
    Inherits HttpApplication

    Protected Sub Application_Start()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
    End Sub
End Class
