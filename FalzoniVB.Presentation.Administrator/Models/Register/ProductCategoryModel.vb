﻿Imports FalzoniVB.Presentation.Administrator.Models.Base
Imports FalzoniVB.Presentation.Administrator.Models.Stock

Namespace Models.Register
    Public Class ProductCategoryModel
        Inherits BaseModel

        Public Property Name As String

        Public Overridable Property Product As ProductModel
    End Class
End Namespace
