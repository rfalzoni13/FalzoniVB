Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Base
Imports FalzoniVB.Presentation.Administrator.Models.Registration
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Registration

Namespace Clients.Interfaces.Registration
    Public Interface ICustomerClient
        Inherits IBaseClient(Of CustomerModel, CustomerTableModel)
    End Interface
End Namespace
