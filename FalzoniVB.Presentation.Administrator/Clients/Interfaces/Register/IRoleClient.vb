Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Base
Imports FalzoniVB.Presentation.Administrator.Models.Register
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Register

Namespace Clients.Interfaces.Register
    Public Interface IRoleClient
        Inherits IBaseClient(Of RoleModel, RoleTableModel)

        Function GetAllNames() As List(Of String)
    End Interface
End Namespace
