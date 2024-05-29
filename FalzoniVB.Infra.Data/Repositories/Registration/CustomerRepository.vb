Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports FalzoniVB.Domain.Entities.Registration
Imports FalzoniVB.Domain.Interfaces.Registration
Imports FalzoniVB.Infra.Data.Context
Imports FalzoniVB.Infra.Data.Repositories.Base

Namespace Repositories.Registration
    Public Class CustomerRepository
        Inherits BaseRepository(Of Customer)
        Implements ICustomerRepository

        Public Function GetWithInclude(Id As Guid) As Customer Implements ICustomerRepository.GetWithInclude
            Using context = FalzoniContext.Create()
                Return context.Customer.
                Include(Function(x) x.Addresses).
                FirstOrDefault(Function(x) x.Id = Id)
            End Using
        End Function

        Public Overrides Sub Update(obj As Customer)
            Using context = FalzoniContext.Create()
                For Each endereco In obj.Addresses
                    context.CustomerAddress.AddOrUpdate(endereco)
                Next

                context.Customer.AddOrUpdate(obj)
                context.SaveChanges()
            End Using
        End Sub

        Public Overrides Sub Delete(Id As Guid)
            Using context = FalzoniContext.Create()
                Dim obj = context.Customer.Include(Function(x) x.Addresses).FirstOrDefault(Function(x) x.Id = Id)

                If obj IsNot Nothing Then
                    context.Customer.AddOrUpdate(obj)
                    context.SaveChanges()
                End If
            End Using
        End Sub
    End Class
End Namespace