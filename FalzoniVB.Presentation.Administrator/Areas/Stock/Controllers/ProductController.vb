Imports System.Net
Imports System.Threading.Tasks
Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Stock
Imports FalzoniVB.Presentation.Administrator.Models.Common
Imports FalzoniVB.Presentation.Administrator.Models.Stock
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Stock
Imports FalzoniVB.Utils.Helpers
Imports NLog

Namespace Areas.Stock.Controllers
    Public Class ProductController
        Inherits Controller

        Private ReadOnly _productClient As IProductClient
        Private Shared ReadOnly _logger As Logger = LogManager.GetCurrentClassLogger()

        Public Sub New(productClient As IProductClient)
            _productClient = productClient
        End Sub

        ' GET Stock/Product
        Public Function Index() As ActionResult
            Return View()
        End Function

        'GET Stock/Product/LoadTable
        <HttpGet>
        Public Async Function LoadTable() As Task(Of JsonResult)

            Dim table = New ProductTableModel()

            Try

                table = Await _productClient.GetTableAsync(UrlConfigurationHelper.ProductGetAll)

            Catch ex As Exception
                _logger.Fatal("Ocorreu um erro: " + ex.ToString())
            End Try

            Return Json(table, JsonRequestBehavior.AllowGet)
        End Function

        'GET Stock/Product/Create
        <HttpGet>
        Public Function Create() As ActionResult

            Dim model = New ProductModel()

            Try

                Return View(model)

            Catch ex As ApplicationException
                _logger.Error("Ocorreu um erro: " + ex.ToString())

                TempData("Return") = New ReturnModel With
                {
                    .Type = "Error",
                    .Message = ex.Message
                }

                Return View("Index")

            Catch ex As Exception
                _logger.Fatal("Ocorreu um erro: " + ex.ToString())
                Throw
            End Try
        End Function

        ' POST Stock/Product/Create
        <HttpPost>
        Public Function Create(model As ProductModel) As ActionResult

            If Not ModelState.IsValid Then
                Return View(model)
            End If

            Try

                Dim result As String = _productClient.Add(UrlConfigurationHelper.ProductCreate, model)

                TempData("Return") = New ReturnModel With
                {
                    .Type = "Success",
                    .Message = result
                }

                Return View("Index")

            Catch ex As ApplicationException

                _logger.Error("Ocorreu um erro: " + ex.ToString())

                ModelState.AddModelError(String.Empty, ex.Message)

                Return View(model)

            Catch ex As Exception

                _logger.Error("Ocorreu um erro: " + ex.ToString())
                Throw
            End Try
        End Function

        ' GET Stock/Product/Edit
        <HttpGet>
        Public Async Function Edit(id As String) As Task(Of ActionResult)
            Try

                Dim model = Await _productClient.GetAsync(UrlConfigurationHelper.ProductGet, id)

                Return View(model)

            Catch ex As ApplicationException
                _logger.Error("Ocorreu um erro: " + ex.ToString())

                TempData("Return") = New ReturnModel With
                {
                    .Type = "Error",
                    .Message = ex.Message
                }

                Return View("Index")
            Catch ex As Exception

                _logger.Error("Ocorreu um erro: " + ex.ToString())
                Throw
            End Try
        End Function

        ' POST Stock/Product/Edit
        <HttpPost>
        Public Function Edit(model As ProductModel) As ActionResult

            If Not ModelState.IsValid Then
                Return View(model)
            End If

            Try

                Dim result As String = _productClient.Update(UrlConfigurationHelper.ProductEdit, model)

                TempData("Return") = New ReturnModel With
                {
                    .Type = "Success",
                    .Message = result
                }

                Return View("Index")

            Catch ex As ApplicationException

                _logger.Error("Ocorreu um erro: " + ex.ToString())

                ModelState.AddModelError(String.Empty, ex.Message)

                Return View(model)

            Catch ex As Exception

                _logger.Error("Ocorreu um erro: " + ex.ToString())
                Throw
            End Try
        End Function

        'POST Stock/Product/Delete
        <HttpPost>
        Public Async Function Delete(model As ProductModel) As Task(Of ActionResult)

            'List<string> errorsList = New List<string>()

            Try

                Dim result As String = Await _productClient.DeleteAsync(UrlConfigurationHelper.ProductDelete, model)

                Return Json(New With {.success = True, .message = result})
            Catch ex As ApplicationException

                _logger.Error("Ocorreu um erro: " + ex.ToString())
                Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest)

                'errorsList.Add(ex.Message)

                'Return Json(New With {.success = False, .errors = errorsList})
                Return Json(New With {.success = False, .error = ex.Message})
            Catch ex As Exception
                _logger.Error("Ocorreu um erro: " + ex.ToString())

                'errorsList.Add(ex.Message)

                If Debugger.IsAttached Then
                    'errorsList.Add("Ocorreu um erro, verifique o arquivo de log e tente novamente!")
                    Return Json(New With {.success = False, .error = "Ocorreu um erro, verifique o arquivo de log e tente novamente!"})
                End If

                'return Json(New With{ .success = False, .errors = errorsList })
                Return Json(New With {.success = False, .error = ex.Message})
            End Try
        End Function
    End Class
End Namespace