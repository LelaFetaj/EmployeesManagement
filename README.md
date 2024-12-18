REST API

Project Description:

You have a Rest API for the administration of employee records consisting of:
- Simple Login (preferable JWT authentication) (no registration endpoint is needed, administrator will create new
users)
- Two User Roles: Employee, Administrator
- User Profile
- Projects and Tasks
- Employee can update his profile data and profile picture, create tasks that belong to the projects he is part of
(also can assign these tasks to other employees that are part of the project), mark his tasks as completed etc.
Employee can view all tasks that are related to the projects he is part of (in read-only mode). Employee can not
modify tasks which are not assigned to him.
- Administrator can create/update/remove users, projects and tasks. Administrator can add employees to
projects (also remove employees from them), create new tasks and assign them to other employees, mark tasks
as completed or remove them. Administrator cannot remove projects that have even open tasks.

Technologies to be used:
- .NET SDK 8.0
- Entity Framework (LINQ for querying data) (EFCore & EFCore Tools)
- Dapper (for query writing) optional
- Microsoft SQL Server 2019/2022
- Microsoft SQL Server Management Studio 19 (Database Management)
- Microsoft Visual Studio 2022


Setting Up the Project

1. Clone the repository
To get started, clone the repository to your local machine:

bash
Copy code
git clone https://github.com/LelaFetaj/EmployeesManagement.git
cd EmployeesManagement

2. Configure the Database
Ensure that you have a running database instance. If you are using SQL Server locally, update the connection string in the appsettings.json file.

3. Build and Run the Project
After setting up your database and updating the configuration, build and run the project.

With Visual Studio or VS Code:
Open the project in Visual Studio or VS Code.

Restore the required dependencies:

bash
Copy code
dotnet restore

Apply migrations to create the database schema:

bash
Copy code
dotnet ef database update

Run the application:

bash
Copy code
dotnet run


Models of the project can be separated into a different project of type Class Library and then be added as reference to
the WEB API solution. Model’s properties must be enriched with Annotations for validation and documentation
purposes. Ensure the database is implemented using the Code-First approach with Entity Framework Core.
Documentation of methods must be separated into respective Controllers not all in one yaml file. (Hint using
GroupName annotation).
Web Api project structure must consist of Controllers, Services and ViewModels. Each of the Service classes must have
their own Interface which will be used with Dependency Injection in the Controller classes.
ASP.NET Core Identity for user authentication and role-based authorization.

To handle exceptions effectively in your REST API project, you should include a middleware for exception handling. You
can use Logger service when the exception is thrown.
Implementation of event handling using RabbitMQ.

Include unit tests to validate critical functionality.
Additionally, containerize the application using Docker to streamline deployment and scalability.
Note:
- Candidates should use AI-assisted coding tools (e.g., Cursor.ai, Windsurf from Codeium) to improve productivity
and be able to explain the generated code in detail and share the prompts used during development.
- Every day that you work on the project you should send an email to the mentor and info@kreatx.com with a
brief description on your progress. Include the GitHub repository link in your daily progress email so we can
review the progress directly. Also, provide a README file in the repository with clear instructions on how to set
up and run the project.
