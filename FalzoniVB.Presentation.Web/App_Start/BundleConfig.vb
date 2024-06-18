Imports System.Web.Optimization
Imports FalzoniVB.Utils.Helpers

Public Class BundleConfig
    ' Para obter mais informações sobre o Agrupamento, visite https://go.microsoft.com/fwlink/?LinkID=303951
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
        'RegisterJQueryScriptManager()

        bundles.Add(New ScriptBundle("~/bundles/WebFormsJs").Include(
                        "~/Scripts/WebForms/WebForms.js",
                        "~/Scripts/WebForms/WebUIValidation.js",
                        "~/Scripts/WebForms/MenuStandards.js",
                        "~/Scripts/WebForms/Focus.js",
                        "~/Scripts/WebForms/GridView.js",
                        "~/Scripts/WebForms/DetailsView.js",
                        "~/Scripts/WebForms/TreeView.js",
                        "~/Scripts/WebForms/WebParts.js"))

        ' A ordem é muito importante para que esses arquivos funcionem; eles possuem dependências explícitas
        bundles.Add(New ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"))

        ' Use a versão de Desenvolvimento do Modernizr para se desenvolver e aprender com ele. Em seguida, quando estiver
        ' pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa
        ' bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
        '                "~/Scripts/Libraries/modernizr-*"))

        RegisterJQueryBundle(bundles)
    End Sub

    Public Shared Sub RegisterJQueryBundle(bundles As BundleCollection)
        bundles.UseCdn = Not ConfigurationHelper.IsBundleled

        Dim cdnPath As String = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.1.min.js"

        If Debugger.IsAttached Then
            cdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.1.js"
            BundleTable.EnableOptimizations = True
        End If

        Dim scriptBundle = New ScriptBundle("~/Scripts/jquery", cdnPath)
        If (ConfigurationHelper.IsBundleled) Then
            scriptBundle.Include("~/Scripts/Libraries/jquery/jquery-*")
        End If

        bundles.Add(scriptBundle)
    End Sub

    'Public Shared Sub RegisterJQueryScriptManager()
    '    Dim jQueryScriptResourceDefinition As New ScriptResourceDefinition
    '    With jQueryScriptResourceDefinition
    '        .Path = "~/scripts/libraries/jquery/jquery-3.7.1.min.js"
    '        .DebugPath = "~/scripts/libraries/jquery/jquery-3.7.1.js"
    '        .CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.min.js"
    '        .CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.7.0.js"
    '    End With

    '    ScriptManager.ScriptResourceMapping.AddDefinition("jquery", jQueryScriptResourceDefinition)
    'End Sub
End Class
