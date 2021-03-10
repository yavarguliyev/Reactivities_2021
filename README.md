# Reactivities

## server-side

> `commands that giving dotnet command information`

- dotnet --info
- dotnet -h
- dotnet new -l
- dotnet tool list --global

> `command that creates new git ignore file`

- dotnet new gitignore

> `command that creaties new solution file`

- dotnet new sln -n Reactivities

> `commands that creating new api or class lib`

- dotnet new webapi -n API
- dotnet new classlib -n Application
- dotnet new classlib -n Domain
- dotnet new classlib -n Persistance

> `commands that adding solution file to the existing projects`

- dotnet sln add API/API.csproj
- dotnet sln add Application/Application.csproj
- dotnet sln add Domain/Domain.csproj
- dotnet sln add Persistance/Persistance.csproj

> `command that shows solution list`

- dotnet sln list

> `commands that adding references between projects`

- cd API/
- dotnet add reference ../Application
- cd ..
- cd Application/
- dotnet add reference ../Persistance
- dotnet add reference ../Domain
- cd ..
- cd Persistance/
- dotnet add reference ../

> `commands that can run API`

- dotnet run
- dotnet watch run

> `command for creating database`

- dotnet ef migrations add initial -p Persistence/ -s API/

> `command for updating database`

- dotnet ef database update -p Persistence/ -s API/

> `command for resetting database`

- dotnet ef database drop -p Persistence/ -s API

> `for setting date in postman`

```javascript
var moment = require('moment')

pm.environment.set('activityDate', moment().add(14, 'days').toISOString())
```

> `setting token in postman`

```javascript
pm.environment.set('TOKEN', pm.response.json().token)
```

## client_side

> `command that creates new react-app project with typescript`

- npx create-react-app client_side --use-npm --template typescript

> `dependencies`

- npm install axios
- npm install semantic-ui-react semantic-ui-css
- npm install uuid
- npm install mobx mobx-react-lite
