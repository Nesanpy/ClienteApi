Imports Microsoft.AspNetCore.Builder
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.EntityFrameworkCore
Imports ClienteApi.Data
Imports ClienteApi.Repositories
Imports ClienteApi.Services

Module Program

    Sub Main(args As String())

        Dim builder = WebApplication.CreateBuilder(args)

        ' Servicios MVC - Swagger
        builder.Services.AddControllers()
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()

        ' Entity Framework Core y SQL Server
        Dim connectionString As String = builder.Configuration.GetConnectionString("EmpresaDBConnection")
        builder.Services.AddDbContext(Of EmpresaDBContext)(
            Sub(options) options.UseSqlServer(connectionString)
        )

        ' Inyección de Dependencias
        builder.Services.AddScoped(Of IClienteRepository, ClienteRepository)()
        builder.Services.AddScoped(Of IClienteService, ClienteService)()

        Dim app = builder.Build()

        ' Pipeline HTTP
        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If

        app.UseHttpsRedirection()
        app.UseAuthorization()
        app.MapControllers()

        app.Run()

    End Sub

End Module
