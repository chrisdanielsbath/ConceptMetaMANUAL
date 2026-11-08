Entity Framework Guide for ConceptMetaDbModels
==============================================

Initial setup
-------------

Open the Package Manager Console (View | Other Windows | Package Manager Console in Visual Studio).

Issue the following command to install dotnet-ef tool on your machine.

> dotnet tool install dotnet-ef --global

The above command installs the latest stable version of dotnet-ef tool globally on your machine.
You can also use --version option to specify a particular version of the tool.
You can check if the tool is installed or not by issuing the following command:

> dotnet tool list --global

Creating and applying a migration
---------------------------------

Next, you need to create a migration issuing the following command:

> dotnet ef migrations add v0.1 --context ConceptMetaDbModelsContext

Now, issue the following command to apply the migration you just created.

> dotnet ef database update --context ConceptMetaDbModelsContext

This command will create the database (if it doesn't exist already) and create the table as per the EF Core model definition.
If the database already exists, it will be updated (if needed) to reflect the EF Core model definition.
