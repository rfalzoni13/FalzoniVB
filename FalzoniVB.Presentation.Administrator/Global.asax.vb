Imports System.Security.Claims
Imports System.Web.Helpers
Imports System.Web.Optimization

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        If FalzoniVB.Utils.Helpers.ConfigurationHelper.IsBundleled Then
            BundleConfig.RegisterBundles(BundleTable.Bundles)
        End If
        AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier
    End Sub
End Class
