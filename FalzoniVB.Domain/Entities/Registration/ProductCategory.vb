﻿Imports FalzoniVB.Domain.Entities.Base

Namespace Entities.Registration
    Public Class ProductCategory
        Inherits BaseEntity

        Public Property Name As String

        Public Overridable Property Product As Product
    End Class
End Namespace

