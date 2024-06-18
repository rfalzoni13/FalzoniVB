Imports FalzoniVB.Domain.Entities.Base
Imports FalzoniVB.Domain.Entities.Register

Namespace Entities.Stock
    Public Class Product
        Inherits BaseEntity

        Public Property ProductCategoryId As Guid

        Public Property Name As String

        Public Property Code As Single

        Public Property Description As String

        Public Property Price As Decimal


        Public Overridable Property Category As ProductCategory
    End Class
End Namespace
