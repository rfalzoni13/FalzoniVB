Imports NLog

<Authorize>
Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Private Shared ReadOnly _logger As Logger = LogManager.GetCurrentClassLogger()

    Function Index() As ActionResult
        Try
            Return View()
        Catch ex As Exception
            _logger.Fatal("Ocorreu um erro: " + ex.ToString())
            Throw
        End Try
        Return View()
    End Function
End Class
