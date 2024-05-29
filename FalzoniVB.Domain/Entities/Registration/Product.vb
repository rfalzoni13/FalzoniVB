Imports FalzoniVB.Domain.Entities.Base

Namespace Entities.Registration
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
