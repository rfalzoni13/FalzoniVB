Imports FalzoniVB.Presentation.Administrator.Models.Base
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Base

Namespace Models.Tables.Register
    Public Class RoleTableModel
        Inherits TableBase
        Public Sub New()
            data = New List(Of RoleListTableModel)()
        End Sub

        Public Overridable Property data As List(Of RoleListTableModel)
    End Class

    Public Class RoleListTableModel
        Inherits BaseModel

        Public Property Name As String
    End Class
End Namespace
