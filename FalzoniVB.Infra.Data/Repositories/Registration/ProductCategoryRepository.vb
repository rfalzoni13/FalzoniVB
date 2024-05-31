Imports FalzoniVB.Domain.Entities.Registration
Imports FalzoniVB.Domain.Interfaces.Repositories.Registration
Imports FalzoniVB.Infra.Data.Repositories.Base

Namespace Repositories.Registration
    Public Class ProductCategoryRepository
        Inherits BaseRepository(Of ProductCategory)
        Implements IProductCategoryRepository
    End Class
End Namespace
