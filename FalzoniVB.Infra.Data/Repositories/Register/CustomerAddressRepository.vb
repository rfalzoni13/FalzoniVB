﻿Imports FalzoniVB.Domain.Entities.Register
Imports FalzoniVB.Domain.Interfaces.Repositories.Register
Imports FalzoniVB.Infra.Data.Context
Imports FalzoniVB.Infra.Data.Repositories.Base

Namespace Repositories.Register
    Public Class CustomerAddressRepository
        Inherits BaseRepository(Of CustomerAddress)
        Implements ICustomerAddressRepository

        Public Sub RemoveRange(ids As ICollection(Of Guid)) Implements ICustomerAddressRepository.RemoveRange
            Using context = FalzoniContext.Create()
                Dim enderecos As ICollection(Of CustomerAddress) = context.CustomerAddress.Where(Function(x) Not ids.Contains(x.Id)).ToList()
                If enderecos.Any() Then
                    context.CustomerAddress.RemoveRange(enderecos)
                    context.SaveChanges()
                End If
            End Using
        End Sub
    End Class
End Namespace
