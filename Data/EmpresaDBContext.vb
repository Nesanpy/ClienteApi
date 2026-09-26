Imports Microsoft.EntityFrameworkCore
Imports ClienteApi.Models

Namespace Data

    ' Entity Framework Core para EmpresaDB
    Public Class EmpresaDBContext
        Inherits DbContext

        Public Sub New(options As DbContextOptions(Of EmpresaDBContext))
            MyBase.New(options)
        End Sub

        Public Property Clientes As DbSet(Of Cliente)

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            modelBuilder.Entity(Of Cliente)(Sub(entity)
                                                 entity.ToTable("Clientes")
                                                 entity.HasKey(Function(c) c.Id)
                                                 entity.Property(Function(c) c.Nombre).HasMaxLength(100).IsRequired()
                                                 entity.Property(Function(c) c.Apellido).HasMaxLength(100).IsRequired()
                                                 entity.Property(Function(c) c.Email).HasMaxLength(150)
                                                 entity.Property(Function(c) c.Telefono).HasMaxLength(30)
                                             End Sub)

            MyBase.OnModelCreating(modelBuilder)
        End Sub

    End Class

End Namespace
