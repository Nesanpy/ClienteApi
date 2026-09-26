Imports ClienteApi.Models

Namespace Services

    ' Lógica de negocio relacionada con clientes
    Public Interface IClienteService

        Function GetAllAsync() As Task(Of List(Of Cliente))
        Function GetByIdAsync(id As Integer) As Task(Of Cliente)
        Function CreateAsync(cliente As Cliente) As Task(Of Cliente)
        Function UpdateAsync(id As Integer, cliente As Cliente) As Task(Of Boolean)
        Function DeleteAsync(id As Integer) As Task(Of Boolean)

    End Interface

End Namespace
