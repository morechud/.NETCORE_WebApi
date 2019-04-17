The following command can be used for scaffolding when Microsoft.EntityFramworkCore.SQLServer is needed after 
database and tables are created in the DB in Nuget package manager console

Scaffold-DbContext "Server=WINDOWS-FIKNDOP\SQLEXPRESS;Database=GCSAppraisalDB;UID=sa;PWD=admin;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Scaffold-DbContext "Server=WINDOWS-FIKNDOP\SQLEXPRESS;Database=GCSAppraisalDB;Trusted_Connection=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force

And comment our the OnConfiguring method since the configuration will be done on Startup class and appsettings.json.
Make sure the following is added to appsettings.json

  "ConnectionStrings": {
    "DefaultConnection": "Server=  WINDOWS-FIKNDOP\\SQLEXPRESS;Database=GCSAppraisalDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }

For Logging: Use extension: Serilog.Extensions.Logging.File
Add loggerFactory.AddFile("Logs/SpeedWalkerApi-{Date}.txt") to Startup constructor
Use dependency injection to add readonly ILogger<GCSAppraisalController> log;


