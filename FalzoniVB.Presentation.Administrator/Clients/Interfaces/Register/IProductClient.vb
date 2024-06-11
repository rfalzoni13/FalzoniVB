Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Base
Imports FalzoniVB.Presentation.Administrator.Models.Register
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Register

Namespace Clients.Interfaces.Register
    Public Interface IProductClient
        Inherits IBaseClient(Of ProductModel, ProductTableModel)
    End Interface
End Namespace
