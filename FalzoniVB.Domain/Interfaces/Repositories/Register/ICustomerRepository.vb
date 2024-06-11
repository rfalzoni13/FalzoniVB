Imports System
Imports FalzoniVB.Domain.Entities.Register
Imports FalzoniVB.Domain.Interfaces.Repositories.Base

Namespace Interfaces.Repositories.Register
    Public Interface ICustomerRepository
        Inherits IBaseRepository(Of Customer)

        Function GetWithInclude(Id As Guid) As Customer
    End Interface
End Namespace
