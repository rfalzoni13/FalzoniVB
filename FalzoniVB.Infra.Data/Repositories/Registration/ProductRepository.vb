Imports FalzoniVB.Domain.Entities.Registration
Imports FalzoniVB.Domain.Interfaces.Repositories.Registration
Imports FalzoniVB.Infra.Data.Repositories.Base

Namespace Repositories.Registration
    Public Class ProductRepository
        Inherits BaseRepository(Of Product)
        Implements IProductRepository
    End Class
End Namespace
