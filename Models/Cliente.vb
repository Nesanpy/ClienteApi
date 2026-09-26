Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models

    ' Representa un cliente de la empresa, mapeado a la tabla Clientes
    <Table("Clientes")>
    Public Class Cliente

        <Key>
        Public Property Id As Integer

        <Required>
        <MaxLength(100)>
        Public Property Nombre As String

        <Required>
        <MaxLength(100)>
        Public Property Apellido As String

        <MaxLength(150)>
        Public Property Email As String

        <MaxLength(30)>
        Public Property Telefono As String

    End Class

End Namespace
