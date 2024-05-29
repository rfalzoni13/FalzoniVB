Imports FalzoniVB.Domain.Entities.Registration
Imports FalzoniVB.Domain.Interfaces.Base

Namespace Interfaces.Registration
    Public Interface ICustomerRepository
        Inherits IBaseRepository(Of Customer)

        Function GetWithInclude(Id As Guid) As Customer
    End Interface
End Namespace
