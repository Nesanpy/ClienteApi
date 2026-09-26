Imports Microsoft.EntityFrameworkCore
Imports ClienteApi.Data
Imports ClienteApi.Models

Namespace Repositories

    ' Implementación del Repository de Clientes
    Public Class ClienteRepository
        Implements IClienteRepository

        Private ReadOnly _context As EmpresaDBContext

        Public Sub New(context As EmpresaDBContext)
            _context = context
        End Sub

        Public Async Function GetAllAsync() As Task(Of List(Of Cliente)) Implements IClienteRepository.GetAllAsync
            Return Await _context.Clientes.AsNoTracking().ToListAsync()
        End Function

        Public Async Function GetByIdAsync(id As Integer) As Task(Of Cliente) Implements IClienteRepository.GetByIdAsync
            Return Await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(Function(c) c.Id = id)
        End Function

        Public Async Function AddAsync(cliente As Cliente) As Task(Of Cliente) Implements IClienteRepository.AddAsync
            _context.Clientes.Add(cliente)
            Await _context.SaveChangesAsync()
            Return cliente
        End Function

        Public Async Function UpdateAsync(cliente As Cliente) As Task(Of Boolean) Implements IClienteRepository.UpdateAsync
            Dim existente = Await _context.Clientes.FirstOrDefaultAsync(Function(c) c.Id = cliente.Id)

            If existente Is Nothing Then
                Return False
            End If

            existente.Nombre = cliente.Nombre
            existente.Apellido = cliente.Apellido
            existente.Email = cliente.Email
            existente.Telefono = cliente.Telefono

            Await _context.SaveChangesAsync()
            Return True
        End Function

        Public Async Function DeleteAsync(id As Integer) As Task(Of Boolean) Implements IClienteRepository.DeleteAsync
            Dim existente = Await _context.Clientes.FirstOrDefaultAsync(Function(c) c.Id = id)

            If existente Is Nothing Then
                Return False
            End If

            _context.Clientes.Remove(existente)
            Await _context.SaveChangesAsync()
            Return True
        End Function

    End Class

End Namespace
