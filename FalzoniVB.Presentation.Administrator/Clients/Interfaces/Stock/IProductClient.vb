Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Base
Imports FalzoniVB.Presentation.Administrator.Models.Stock
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Stock

Namespace Clients.Interfaces.Stock
    Public Interface IProductClient
        Inherits IBaseClient(Of ProductModel, ProductTableModel)
    End Interface
End Namespace
