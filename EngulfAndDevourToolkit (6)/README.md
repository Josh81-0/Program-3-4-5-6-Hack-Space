# Engulf & Devour Accounting Toolkit

This is an internal Blazor Server web app developed for Engulf & Devour (E&D) accountants. It helps manage HOA reserve studies and build balance sheets in a clean and user-friendly way.

## README Requirements

1. Description of the persistence refactor:  
In this assignment, I replaced the old JSON file-based persistence system with a proper relational database using EF Core and SQLite. I created a new `AppDbContext` that handles both Balance Sheet items and Reserve Study components. The services were updated to use `IDbContextFactory<AppDbContext>` for all data operations. All JSON-related code and files have been removed. The user interface, components, and features remain exactly the same — only the data storage layer was changed to meet the database requirement.

2. How to run the application:  
Make sure you have the .NET 10 SDK installed. Clone or download the repository, open a terminal in the project folder, and run these commands:  
`dotnet restore`  
`dotnet ef database update`  
`dotnet run`  

Once the app starts, open your browser and go to the address shown in the console (usually https://localhost:5001 or https://localhost:7234).

3. Location of the SQLite database file:  
The SQLite database is saved as `ed-toolkit.db`. During development, you’ll find it in the `bin/Debug/net10.0/` folder. When the app is published, the file will appear next to the executable.

4. Migration commands used:  
I used the following EF Core commands to set up the database:  
`dotnet ef migrations add InitialCreate --context AppDbContext`  
`dotnet ef database update --context AppDbContext`

5. AI usage disclosure:  
No AI tools were used in the development of this project. All code was written manually.





