Imports ClienteApi.Models
Imports ClienteApi.Repositories

Namespace Services

    ' Implementación del Service de Clientes
    Public Class ClienteService
        Implements IClienteService

        Private ReadOnly _repository As IClienteRepository

        Public Sub New(repository As IClienteRepository)
            _repository = repository
        End Sub

        Public Async Function GetAllAsync() As Task(Of List(Of Cliente)) Implements IClienteService.GetAllAsync
            Return Await _repository.GetAllAsync()
        End Function

        Public Async Function GetByIdAsync(id As Integer) As Task(Of Cliente) Implements IClienteService.GetByIdAsync
            Return Await _repository.GetByIdAsync(id)
        End Function

        Public Async Function CreateAsync(cliente As Cliente) As Task(Of Cliente) Implements IClienteService.CreateAsync
            If String.IsNullOrWhiteSpace(cliente.Nombre) Then
                Throw New ArgumentException("El nombre del cliente es obligatorio.")
            End If

            If String.IsNullOrWhiteSpace(cliente.Apellido) Then
                Throw New ArgumentException("El apellido del cliente es obligatorio.")
            End If

            Return Await _repository.AddAsync(cliente)
        End Function

        Public Async Function UpdateAsync(id As Integer, cliente As Cliente) As Task(Of Boolean) Implements IClienteService.UpdateAsync
            If String.IsNullOrWhiteSpace(cliente.Nombre) Then
                Throw New ArgumentException("El nombre del cliente es obligatorio.")
            End If

            cliente.Id = id
            Return Await _repository.UpdateAsync(cliente)
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task(Of Boolean) Implements IClienteService.DeleteAsync
            Return Await _repository.DeleteAsync(id)
        End Function

    End Class

End Namespace
