Imports FalzoniVB.Domain.Entities.Register
Imports FalzoniVB.Domain.Interfaces.Repositories.Register
Imports FalzoniVB.Infra.Data.Repositories.Base

Namespace Repositories.Register
    Public Class ProductRepository
        Inherits BaseRepository(Of Product)
        Implements IProductRepository
    End Class
End Namespace
