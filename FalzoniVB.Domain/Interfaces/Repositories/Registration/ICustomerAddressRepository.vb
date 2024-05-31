Imports FalzoniVB.Domain.Entities.Registration
Imports FalzoniVB.Domain.Interfaces.Repositories.Base

Namespace Interfaces.Repositories.Registration
    Public Interface ICustomerAddressRepository
        Inherits IBaseRepository(Of CustomerAddress)

        Sub RemoveRange(ids As ICollection(Of Guid))
    End Interface
End Namespace
