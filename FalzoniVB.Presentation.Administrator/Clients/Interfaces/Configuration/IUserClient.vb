Imports FalzoniVB.Presentation.Administrator.Clients.Interfaces.Base
Imports FalzoniVB.Presentation.Administrator.Models.Configuration
Imports FalzoniVB.Presentation.Administrator.Models.Tables.Configuration

Namespace Clients.Interfaces.Configuration
    Public Interface IUserClient
        Inherits IBaseClient(Of UserModel, UserTableModel)
    End Interface
End Namespace
