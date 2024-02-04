# SSIS Package and Scheduler

This project consists of an SSIS package and an API built with C# ASP.NET Core. The SSIS package is designed to execute a campaign targeting clients with saving accounts to encourage them to open a credit card account. The API provides the scheduling functionality to trigger the SSIS package according to the specified campaign execution requirements.

## SSIS Package

### Description

The SSIS package is responsible for executing the campaign targeting clients with saving accounts. It retrieves client data from the database and performs necessary data transformations and campaign logic as per the business requirements.

### Prerequisites

- SQL Server
- SQL Server Data Tools (SSDT) for Visual Studio (to open and modify the SSIS package)

### How to Use


1.Clone the repository:

   ```bash
   git clone https://github.com/yourusername/ssis-package-scheduler.git
```
2.  Open the solution in Visual Studio.

3. Navigate to the SSIS project in the solution explorer.

4. Open the SSIS package `CampaignPackage.dtsx` using SQL Server Data Tools (SSDT).

5. Modify the package as needed to match the specific campaign logic and data sources.

6. Build the SSIS project.

7. Deploy and configure the SSIS package to your SQL Server Integration Services environment.

## API

### Description

The API provides the scheduling functionality to trigger the SSIS package execution according to the campaign execution requirements. It dynamically calculates the schedule to run the SSIS package from the first Monday to the Sunday after the first Monday of each month using Hangfire for job scheduling.

### Prerequisites

- .NET Core SDK
- Hangfire

### How to Use

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/ssis-package-scheduler.git
   ```
2. Open the solution in your preferred IDE (Visual Studio, Visual Studio Code, etc.).
3. Restore the NuGet packages.
4. Configure Hangfire Database connection in appsettings.json
5. Run the api
### Endpoints
  - Hangfire endpoint  -  api/hangfire eg (https://localhost:7014/hangfire)
  - api endpoint  -  api/swagger/index.html eg (https://localhost:7014/swagger/index.html) 
   
