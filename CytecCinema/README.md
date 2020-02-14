# Cytec Cinemas

This project is built using Entity Framework Code First so the database will need to be created before it can be run.

## Instructions

To Create the database:

1. Install EF Tools CLI from the MS website - navigate to the project folder, open a command line and enter:

~~
dotnet tool install --global dotnet-ef
~~

And check it has been installed using the following command:

~~
dotnet ef
~~

2. Point to the correct MS SQL Server

Entity Framework will create the database for you but it needs a valid instance. 

In the CytecCinema/Migrations/CinemaContext.cs file, find the following line of code:

~~
optionsBuilder.UseSqlServer("Server=localhost,1433; Database=CinemaContext;User=sa; Password=reallyStrongPwd123");
~~

And replace it with:

~~
optionsBuilder.UseSqlServer("Server=<MSSQL HOST>; Database=CinemaContext;User=<USERNAME>; Password=<PASSWORD>");
~~

Replacing MSSQL Host, Username and password with the approriate values.

NB the user account must have db create priviledges.

3. Update the migration

The initial migration ahs already been created so you should be able to create the database using:

~~
dotnet ef database update
~~

If this fails you may need to delete the Migrations folder from the project folder then run:

~~
dotnet ef migrations add initial
dotnet ef database update
~~

The application should now be ready to run.