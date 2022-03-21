# zoomoAssessment

This project has been created for the technical assessment test at Zoomo Sydney.

The project has been created using .NET 5.

It is a Console Application. 

The tests have been written using xUnit tests.

## Dependencies 

1. Download .NET 5
   SDK 5.0.406: https://dotnet.microsoft.com/en-us/download/dotnet/5.0
   ASP.NET Core Runtime 5.0.15: https://dotnet.microsoft.com/en-us/download/dotnet/5.0
   
## Instructions to RUN

1. Download the project files and extract them in a folder.
2. Navigate(cd into) to the Zoomo Folder inside the project via Terminal.
3. Now, use the command "dotnet build"
4. Once the build is finished, use command, "dotnet run bin/Debug/net5.0/Zoomo.dll"
5. The application will now run.

## Instructions to Run Tests
1. Navigate into the ZoomoTests folder.
2. In your terminal, while you're in the ZoomoTests directory, run the command "dotnet test"

Please note: The test for URL checker might fail, that is due to the fact that one of the files being used has a lot of links in it and some of the links occasionally does not work.
