Imports FalzoniVB.Domain.Entities.Registration
Imports FalzoniVB.Domain.Interfaces.Repositories.Base

Namespace Interfaces.Repositories.Registration
    Public Interface ICustomerRepository
        Inherits IBaseRepository(Of Customer)

        Function GetWithInclude(Id As Guid) As Customer
    End Interface
End Namespace
