dotnet add package Microsoft.EntityFrameworkCore --version 7.0.3
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.3
dotnet add package Swashbuckle.AspNetCore --version 6.5.0
dotnet add package Swashbuckle.AspNetCore.SwaggerGen --version 6.5.0

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255),
    Price DECIMAL(10,2) NOT NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
);