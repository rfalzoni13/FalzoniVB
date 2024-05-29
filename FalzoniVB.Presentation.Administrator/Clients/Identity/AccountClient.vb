﻿Imports System.Net.Http
Imports System.Security.Claims
Imports System.Threading.Tasks
Imports FalzoniVB.Presentation.Administrator.Models.Common
Imports FalzoniVB.Presentation.Administrator.Models.Identity
Imports FalzoniVB.Utils.Helpers
Imports Microsoft.Owin.Security
Imports Newtonsoft.Json

Namespace Clients.Identity
    Public Class AccountClient
#Region "LOGIN"
        Public Async Function Login(model As LoginModel, request As HttpRequestBase) As Task
            Dim url = UrlConfigurationHelper.AccountLogin
            Using httpClient As New HttpClient()

                'Setar Timeout de conexão
                httpClient.Timeout = TimeSpan.FromSeconds(30)

                Dim content As HttpContent = New FormUrlEncodedContent(
                {
                        New KeyValuePair(Of String, String)("grant_type", "password"),
                        New KeyValuePair(Of String, String)("username", model.Login),
                        New KeyValuePair(Of String, String)("password", model.Password)
                })

                Dim response As HttpResponseMessage = Await httpClient.PostAsync(url, content)
                If response.IsSuccessStatusCode Then
                    Dim resultContent As String = response.Content.ReadAsStringAsync().Result

                    Dim token = JsonConvert.DeserializeObject(Of TokenModel)(resultContent)

                    Dim [options] As AuthenticationProperties = New AuthenticationProperties()

                    [options].AllowRefresh = True
                    [options].IsPersistent = True
                    [options].ExpiresUtc = token.Expire

                    Dim claims As Claim() =
                    {
                            New Claim(ClaimTypes.NameIdentifier, token.UserId),
                            New Claim(ClaimTypes.Role, token.RoleId),
                            New Claim(ClaimTypes.Expiration, token.Expire.ToString()),
                            New Claim("AccessToken", token.AccessToken),
                            New Claim("RefreshToken", token.RefreshToken)
                    }

                    Dim identity = New ClaimsIdentity(claims, "ApplicationCookie")

                    request.GetOwinContext().Authentication.SignIn(options, identity)
                Else
                    Dim errorResponse = response.Content.ReadAsAsync(Of ResponseErrorLogin)().Result

                    Throw New ApplicationException(If(Not String.IsNullOrEmpty(errorResponse.error_description), errorResponse.error_description, errorResponse.[error]))
                End If
            End Using
        End Function


        Public Async Function RefreshToken() As Task
            Dim url = UrlConfigurationHelper.AccountLogin

            Dim reftoken As String = HttpContext.Current.GetOwinContext().Authentication.User.Claims.
            FirstOrDefault(Function(x) x.Type.Contains("RefreshToken")).Value
            If reftoken Is Nothing Then
                Throw New Exception("Token expirado ou inválido")
            End If

            Using httpClient As New HttpClient()
                Dim content As HttpContent = New FormUrlEncodedContent(
                {
                        New KeyValuePair(Of String, String)("grant_type", "refresh_token"),
                        New KeyValuePair(Of String, String)("refresh_token", reftoken)
                })

                Dim response As HttpResponseMessage = Await httpClient.PostAsync(url, content)
                If response.IsSuccessStatusCode Then
                    Dim resultContent As String = Await response.Content.ReadAsStringAsync()

                    HttpContext.Current.GetOwinContext().Authentication.SignOut("ApplicationCookie")

                    Dim token = JsonConvert.DeserializeObject(Of TokenModel)(resultContent)

                    Dim [options] As AuthenticationProperties = New AuthenticationProperties()

                    [options].AllowRefresh = True
                    [options].IsPersistent = True
                    [options].ExpiresUtc = token.Expire

                    Dim claims As Claim() =
                    {
                            New Claim(ClaimTypes.NameIdentifier, token.UserId),
                            New Claim(ClaimTypes.Role, token.RoleId),
                            New Claim(ClaimTypes.Expiration, token.Expire.ToString()),
                            New Claim("AccessToken", token.AccessToken),
                            New Claim("RefreshToken", token.RefreshToken)
                    }

                    Dim identity = New ClaimsIdentity(claims, "ApplicationCookie")

                    HttpContext.Current.GetOwinContext().Authentication.SignIn(options, identity)
                Else
                    Throw New ApplicationException("Login e/ou Senha incorretos!")
                End If
            End Using
        End Function

        Public Async Function Logout(request As HttpRequestBase) As Task
            Dim url = UrlConfigurationHelper.AccountLogout

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsync(url, Nothing)
                If response.IsSuccessStatusCode Then
                    HttpContext.Current.Session.Clear()
                    request.GetOwinContext().Authentication.SignOut("ApplicationCookie")
                Else
                    Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()

                    Throw New Exception(statusCode.Message)
                End If
            End Using
        End Function
#End Region

#Region "EXTERNAL LOGIN"
        Public Async Function ExternalLogin(provider As String) As Task
            Dim url = $"{UrlConfigurationHelper.AccountExternalLogin}?provider={provider}"

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                If Not response.IsSuccessStatusCode Then
                    Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()

                    Throw New ApplicationException(statusCode.Message)
                End If
            End Using
        End Function

        Public Async Function GetExternalLogins() As Task(Of IList(Of ExternalLoginModel))
            Dim url As String = UrlConfigurationHelper.AccountGetExternalLogins

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                If response.IsSuccessStatusCode Then

                    Return Await response.Content.ReadAsAsync(Of IList(Of ExternalLoginModel))()

                Else

                    Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()

                    Throw New Exception(statusCode.Message)
                End If
            End Using
        End Function


        Public Async Function AddExternalLogin(model As AddExternalLoginBindingModel) As Task(Of IList(Of IdentityResultCodeModel))
            Dim url = UrlConfigurationHelper.AccountAddExternalLogin

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsJsonAsync(url, model)
                If response.IsSuccessStatusCode Then

                    Return Await response.Content.ReadAsAsync(Of IList(Of IdentityResultCodeModel))()

                Else

                    Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()

                    Throw New Exception(statusCode.Message)
                End If
            End Using
        End Function

        Public Async Function AddUserExternalLogin(model As RegisterExternalBindingModel) As Task(Of IList(Of IdentityResultCodeModel))
            Dim url = UrlConfigurationHelper.AccountAddUserExternalLogin

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsJsonAsync(url, model)
                If response.IsSuccessStatusCode Then

                    Return Await response.Content.ReadAsAsync(Of IList(Of IdentityResultCodeModel))()

                Else

                    Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()

                    Throw New Exception(statusCode.Message)
                End If
            End Using
        End Function

        Public Async Function RemoveExternalLogin(model As RegisterExternalBindingModel) As Task(Of IList(Of IdentityResultCodeModel))
            Dim url = UrlConfigurationHelper.AccountRemoveExternalLogin

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsJsonAsync(url, model)
                If response.IsSuccessStatusCode Then

                    Return Await response.Content.ReadAsAsync(Of IList(Of IdentityResultCodeModel))()

                Else

                    Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()

                    Throw New Exception(statusCode.Message)
                End If
            End Using
        End Function
#End Region

#Region "PASSWORD"
        Public Async Function ChangePassword(model As ChangePasswordModel) As Task(Of IdentityResultCodeModel)
            Dim url = UrlConfigurationHelper.AccountChangePassword

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsJsonAsync(url, model)
                If response.IsSuccessStatusCode Then

                    Return Await response.Content.ReadAsAsync(Of IdentityResultCodeModel)()

                Else

                    Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()

                    Throw New Exception(statusCode.Message)
                End If
            End Using
        End Function

        Public Async Function ForgotPassword(model As ForgotPasswordModel) As Task(Of String)
            Dim url = UrlConfigurationHelper.AccountForgotPassword

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsJsonAsync(url, model)
                If response.IsSuccessStatusCode Then

                    Return Await response.Content.ReadAsStringAsync()

                Else

                    Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()

                    Throw New Exception(statusCode.Message)
                End If
            End Using
        End Function


        Public Async Function ResetPassword(model As ResetPasswordModel) As Task(Of IdentityResultCodeModel)
            Dim url = UrlConfigurationHelper.AccountResetPassword

            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.PostAsJsonAsync(url, model)
                If response.IsSuccessStatusCode Then

                    Return Await response.Content.ReadAsAsync(Of IdentityResultCodeModel)()

                Else

                    Dim statusCode As StatusCodeModel = Await response.Content.ReadAsAsync(Of StatusCodeModel)()

                    Throw New Exception(statusCode.Message)
                End If
            End Using
        End Function
#End Region
    End Class
End Namespace
