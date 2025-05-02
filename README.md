
 ASP.NET Web Forms Project Setup Guide

## 🔧 Installation Steps

### 1. Configure Connection String
1. Open `Web.config`
2. Replace the existing connection string with yours:
```xml
<connectionStrings>
    <add name="YourConnection" 
         connectionString="Server=.;Database=YourDB;Integrated Security=True;" 
         providerName="System.Data.SqlClient"/>
</connectionStrings>

```
##  2.  Database Setup (Execute in Order)

1. **Run Database Creation Script**  
   Execute this file first to create your database and tables:  
   `DB/DataBase.sql`

2. **Run Stored Procedures Script**  
   After database creation, execute this file:  
   `DB/PROCEDURE.sql`


## 3. How to Run the Project

### Using Visual Studio:
1. Open `TaskManagementSystem.sln`
2. Build solution (`Ctrl+Shift+B`)
3. Run with `F5` (Debug) or `Ctrl+F5` (Without Debug)

### Using Command Line:
```cmd
dotnet build
dotnet run



   
