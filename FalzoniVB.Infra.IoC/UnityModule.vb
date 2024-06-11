Imports System.Data.Entity
Imports FalzoniVB.Application.ServiceApplication.Identity
Imports FalzoniVB.Application.ServiceApplication.Configuration
Imports FalzoniVB.Application.ServiceApplication.Register
Imports FalzoniVB.Domain.Interfaces.Repositories.Base
Imports FalzoniVB.Domain.Interfaces.Repositories.Register
Imports FalzoniVB.Infra.Data.Context.MySql
Imports FalzoniVB.Infra.Data.Context.SqlServer
Imports FalzoniVB.Infra.Data.Repositories.Base
Imports FalzoniVB.Infra.Data.Repositories.Register
Imports FalzoniVB.Service.Register
Imports FalzoniVB.Utils.Helpers
Imports Unity

Public Class UnityModule
    Public Shared Function LoadModules() As UnityContainer
        Dim container = New UnityContainer()

#Region "Repositories"
        container.RegisterType(GetType(IBaseRepository(Of)), GetType(BaseRepository(Of)))

        container.RegisterType(Of ICustomerRepository, CustomerRepository)()
        container.RegisterType(Of ICustomerAddressRepository, CustomerAddressRepository)()
        container.RegisterType(Of IProductRepository, ProductRepository)()
        container.RegisterType(Of IProductCategoryRepository, ProductCategoryRepository)()
#End Region

#Region "Services"
        container.RegisterType(Of CustomerService)()
        container.RegisterType(Of ProductService)()
#End Region

#Region "Application"
        container.RegisterType(Of RoleServiceApplication)()
        container.RegisterType(Of AccountServiceApplication)()
        container.RegisterType(Of IdentityUtilityServiceApplication)()
        container.RegisterType(Of UserServiceApplication)()

        container.RegisterType(Of CustomerServiceApplication)()
        container.RegisterType(Of ProductServiceApplication)()
#End Region

        'Complements
        container.RegisterType(Of IUnitOfWork, UnitOfWork)()

        'Context
        Select Case ConfigurationHelper.ProviderName
            Case "SqlServer"
                container.RegisterType(Of DbContext, FalzoniSqlServerContext)()
                Exit Select
            Case "MySql"
                container.RegisterType(Of DbContext, FalzoniMySqlContext)()
                Exit Select
        End Select

        Return container

    End Function
End Class
