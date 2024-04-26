# Inventory-Management-System

Build Inventory Management System using .Net 6.0, and Microsoft SQL Server as it's Database

# Project Tools

> To run the project, you need to install these following tools:

| Software Name | Version | Download Link |
|---------------|---------|---------------|
| .Net 6| version 6 | https://dotnet.microsoft.com/en-us/download/dotnet/6.0|
| Visual Studio | 2022 |https://visualstudio.microsoft.com/vs/|
| SQL Server | Latest | https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16|

# Configuration

> This project needs configuration, belows are the configuration that you need to setup:

|Configuration | Notes|
|-----------|-------|
|Connection String| This is for database connection|
|Logging| This is for logging configuration|
|MiniO| Object storage for saving file (pdf, jpg, docx, xlsx, etc.)

# Installation For Front End Project

> To run the front end project, you need to run `npm install` command and then run the `npm run start`

> This is an example for long command:

```
1. open CMD
2. run the command npm install
3. run the command npm run start
```

# Scaffolding
> This project run the scaffolding by using DB first. Before run the `scaffold.ps1`, you need to adjust your connection string and your database first! After adjust your connection string, run the `scaffold.ps1` file on the entities directory
and open the windows powersheel

# Publishing
> To publish the project, you need to run this command
```
dotnet publish -c Release
```
> After the Release folder is created, don't forget to remove `appsettings.json` and `web.config`

# Deployment
> To deploy the project, you need to follow these steps:
```
1. compress the `release file` to `release.zip` file
2. Copy the `release.zip` file
3. Open the server that we want to deploy
4. paste on the desktop on the server
5. Extract the file
6. Make sure to stop your application pool
7. Copy and paste your extract file result to the project server directory
8. Check your appsettings.json file
9. Start the server
10. Check on your PC or Laptop to make sure that your server is running
```

# Documentation

[Github Documentation](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax)