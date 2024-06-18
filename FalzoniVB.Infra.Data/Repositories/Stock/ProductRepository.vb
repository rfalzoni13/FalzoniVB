Imports FalzoniVB.Domain.Entities.Stock
Imports FalzoniVB.Domain.Interfaces.Repositories.Stock
Imports FalzoniVB.Infra.Data.Repositories.Base

Namespace Repositories.Stock
    Public Class ProductRepository
        Inherits BaseRepository(Of Product)
        Implements IProductRepository
    End Class
End Namespace
