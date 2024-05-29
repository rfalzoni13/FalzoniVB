Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Base
Imports FalzoniVB.Presentation.Administrator.Models.Registration
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Registration

Namespace Clients.Interfaces.Registration
    Public Interface IProductClient
        Inherits IBaseClient(Of ProductModel, ProductTableModel)
    End Interface
End Namespace
