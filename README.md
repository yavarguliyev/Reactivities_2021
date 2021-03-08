# Reactivities

## server-side

> commands that giving dotnet command information

- dotnet --info
- dotnet -h
- dotnet new -l
- dotnet tool list --global

> commands that creating new git ignore file

- dotnet new gitignore

> commands that creating new solution file

- dotnet new sln -n Reactivities

> commands that creating new api or class lib

- dotnet new webapi -n API
- dotnet new classlib -n Application
- dotnet new classlib -n Domain
- dotnet new classlib -n Persistance

> commands that adding solution file to the existing projects

- dotnet sln add API/API.csproj
- dotnet sln add Application/Application.csproj
- dotnet sln add Domain/Domain.csproj
- dotnet sln add Persistance/Persistance.csproj

> commands that showing solution list

- dotnet sln list

> commands that adding references between projects

- cd API/
- dotnet add reference ../Application
- cd ..
- cd Application/
- dotnet add reference ../Persistance
- dotnet add reference ../Domain
- cd ..
- cd Persistance/
- dotnet add reference ../

> commands that can run API

- dotnet run
- dotnet watch run

> commands for creating database

- dotnet ef migrations add initial -p Persistence/ -s API/

> commands for updating database

- dotnet ef database update -p Persistence/ -s API/

> commands for resetting database

- dotnet ef database drop -p Persistence/ -s API
