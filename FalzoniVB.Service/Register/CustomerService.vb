﻿Imports FalzoniVB.Domain.DTO.Register
Imports FalzoniVB.Domain.Interfaces.Repositories.Base
Imports FalzoniVB.Domain.Interfaces.Repositories.Register

Namespace Register
    Public Class CustomerService
        Private ReadOnly _customerRepository As ICustomerRepository
        Private ReadOnly _customerAddressRepository As ICustomerAddressRepository
        Private ReadOnly _unitOfWork As IUnitOfWork

        Public Sub New(customerRepository As ICustomerRepository,
        customerAddressRepository As ICustomerAddressRepository,
        unitOfWork As IUnitOfWork)

            _customerRepository = customerRepository
            _customerAddressRepository = customerAddressRepository
            _unitOfWork = unitOfWork
        End Sub

        Public Function [Get](Id As Guid) As CustomerDTO
            Dim customer = _customerRepository.GetWithInclude(Id)
            Return New CustomerDTO(customer)
        End Function

        Public Function GetAll() As List(Of CustomerDTO)
            Dim customers = _customerRepository.GetAll()
            Return customers.ToList().ConvertAll(Function(c) New CustomerDTO(c))
        End Function

        Public Sub Add(customerDTO As CustomerDTO)
            Using transaction = _unitOfWork.BeginTransaction()
                Try
                    customerDTO.ConfigureNewEntity()

                    Dim customer = customerDTO.ConvertToEntity()

                    _customerRepository.Add(customer)

                    transaction.Commit()
                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Sub Update(customerDTO As CustomerDTO)
            Using transaction = _unitOfWork.BeginTransaction()
                Try
                    Dim customer = _customerRepository.Get(customerDTO.Id)

                    'Update principal data
                    customer.Name = customerDTO.Name
                    customer.Document = customerDTO.Document
                    customer.DateBirth = customerDTO.DateBirth
                    customer.CellPhoneNumber = customerDTO.CellPhoneNumber
                    customer.PhoneNumber = customerDTO.PhoneNumber
                    customer.Email = customerDTO.Email
                    customer.Gender = customerDTO.Gender

                    'Remove exclude addresses
                    RemoveAddresses(customerDTO)

                    'Update addresses
                    customerDTO.Addresses.ForEach(
                    Function(e)
                        Return e.Id = If(e.Id = Guid.Empty, Guid.NewGuid(), e.Id)
                        e.CustomerId = customer.Id
                        e.Created = If(e.Created = Date.MinValue, Date.Now, e.Created)
                        e.Modified = Date.Now
                    End Function)

                    customer.Addresses = customerDTO.Addresses.ToList().ConvertAll(Function(e) e.ConvertToEntity())

                    'Update modified entity data
                    customer.Modified = Date.Now

                    _customerRepository.Update(customer)

                    transaction.Commit()
                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

        Public Sub Delete(customerDTO As CustomerDTO)
            Using transaction = _unitOfWork.BeginTransaction()
                Try

                    _customerRepository.Delete(customerDTO.Id)

                    transaction.Commit()
                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        End Sub

#Region "private Methods"
        Private Sub RemoveAddresses(customerDTO As CustomerDTO)
            Dim ids = customerDTO.Addresses.Where(Function(x) x.Removed).Select(Function(x) x.Id).ToList()

            If ids.Any() Then
                _customerAddressRepository.RemoveRange(ids)
            End If
        End Sub
#End Region
    End Class
End Namespace
