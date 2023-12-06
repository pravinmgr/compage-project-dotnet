# Compage Project Dotnet Template

## Install

```bash
  Visual Studio 2022
  .NET 7 
  SQL Server  
```

## Technologies

```bash
    ASP.NET Core 7
    Entity Framework Core 7   
    MediatR
    AutoMapper   
    xUnit
 ```

## Database

```bash
  Use script.sql for add table in SQL Server
```

### Run Docker container

```bash
  docker run --network host -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Intelops@123" -p  0.0.0.0:1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

### Fire below commands to create database and table

```sql
CREATE
DATABASE [ProcurementDb];
CREATE TABLE [dbo].[Order]
(
    [
    id] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [Name] [nvarchar]
(
    50
) NULL,
    [Description] [nvarchar]
(
    50
) NULL,
    [Price] [decimal]
(
    18,
    0
) NULL,
    [Quantity] [int] NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED
(
[
    id] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY];

CREATE TABLE [dbo].[Invoice]
(
    [
    Id] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [Name] [nvarchar]
(
    max
) NOT NULL,
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED
(
[
    Id] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
```

### Run the code 
```bash
dotnet build
dotnet run
```
### open swagger
```html
http://localhost:5170/swagger/index.html
```