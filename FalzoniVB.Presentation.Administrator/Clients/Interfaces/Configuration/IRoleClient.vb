Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Base
Imports FalzoniVB.Presentation.Administrator.Models.Configuration
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Configuration

Namespace Clients.Interfaces.Configuration
    Public Interface IRoleClient
        Inherits IBaseClient(Of RoleModel, RoleTableModel)

        Function GetAllNames() As List(Of String)
    End Interface
End Namespace
