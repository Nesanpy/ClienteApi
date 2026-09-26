Imports ClienteApi.Models

Namespace Repositories

    ' Acceso a datos de la entidad Cliente
    Public Interface IClienteRepository

        Function GetAllAsync() As Task(Of List(Of Cliente))
        Function GetByIdAsync(id As Integer) As Task(Of Cliente)
        Function AddAsync(cliente As Cliente) As Task(Of Cliente)
        Function UpdateAsync(cliente As Cliente) As Task(Of Boolean)
        Function DeleteAsync(id As Integer) As Task(Of Boolean)

    End Interface

End Namespace
