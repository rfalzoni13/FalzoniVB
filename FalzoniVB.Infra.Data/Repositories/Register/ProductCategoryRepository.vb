Imports FalzoniVB.Domain.Entities.Register
Imports FalzoniVB.Domain.Interfaces.Repositories.Register
Imports FalzoniVB.Infra.Data.Repositories.Base

Namespace Repositories.Register
    Public Class ProductCategoryRepository
        Inherits BaseRepository(Of ProductCategory)
        Implements IProductCategoryRepository
    End Class
End Namespace
