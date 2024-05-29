Imports FalzoniVB.Domain.Entities.Registration
Imports FalzoniVB.Domain.Interfaces.Base

Namespace Interfaces.Registration
    Public Interface ICustomerAddressRepository
        Inherits IBaseRepository(Of CustomerAddress)

        Sub RemoveRange(ids As ICollection(Of Guid))
    End Interface
End Namespace
