Imports Microsoft.AspNetCore.Mvc
Imports ClienteApi.Models
Imports ClienteApi.Services

Namespace Controllers

    ' REST Controller para la administración de clientes
    <ApiController>
    <Route("api/[controller]")>
    Public Class ClientesController
        Inherits ControllerBase

        Private ReadOnly _service As IClienteService

        Public Sub New(service As IClienteService)
            _service = service
        End Sub

        ' GET api/clientes — Consulta todos los clientes
        <HttpGet>
        Public Async Function GetAll() As Task(Of ActionResult(Of List(Of Cliente)))
            Dim clientes = Await _service.GetAllAsync()
            Return Ok(clientes)
        End Function

        ' GET api/clientes/{id} — Consulta un cliente por Id
        <HttpGet("{id}")>
        Public Async Function GetById(id As Integer) As Task(Of ActionResult(Of Cliente))
            Dim cliente = Await _service.GetByIdAsync(id)

            If cliente Is Nothing Then
                Return NotFound(New With {.mensaje = $"No se encontró el cliente con Id {id}."})
            End If

            Return Ok(cliente)
        End Function

        ' POST api/clientes — Registra un nuevo cliente
        <HttpPost>
        Public Async Function Create(<FromBody> cliente As Cliente) As Task(Of ActionResult(Of Cliente))
            Try
                Dim nuevoCliente = Await _service.CreateAsync(cliente)
                Return CreatedAtAction(NameOf(GetById), New With {.id = nuevoCliente.Id}, nuevoCliente)
            Catch ex As ArgumentException
                Return BadRequest(New With {.mensaje = ex.Message})
            End Try
        End Function

        ' PUT api/clientes/{id} — Modifica un cliente existente
        <HttpPut("{id}")>
        Public Async Function Update(id As Integer, <FromBody> cliente As Cliente) As Task(Of IActionResult)
            Try
                Dim actualizado = Await _service.UpdateAsync(id, cliente)

                If Not actualizado Then
                    Return NotFound(New With {.mensaje = $"No se encontró el cliente con Id {id}."})
                End If

                Return NoContent()
            Catch ex As ArgumentException
                Return BadRequest(New With {.mensaje = ex.Message})
            End Try
        End Function

        ' DELETE api/clientes/{id} — Elimina un cliente
        <HttpDelete("{id}")>
        Public Async Function Delete(id As Integer) As Task(Of IActionResult)
            Dim eliminado = Await _service.DeleteAsync(id)

            If Not eliminado Then
                Return NotFound(New With {.mensaje = $"No se encontró el cliente con Id {id}."})
            End If

            Return NoContent()
        End Function

    End Class

End Namespace
