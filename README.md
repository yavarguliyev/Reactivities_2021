# Reactivities

## server-side

[nuget packages](https://www.nuget.org/packages)

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
- dotnet new classlib -n Infrastructure

> `commands that adding solution file to the existing projects`

- dotnet sln add API/API.csproj
- dotnet sln add Application/Application.csproj
- dotnet sln add Domain/Domain.csproj
- dotnet sln add Persistance/Persistance.csproj
- dotnet sln add Infrastructure/Infrastructure.csproj

> `command that shows solution list`

- dotnet sln list

> `commands that adding references between projects`

- cd API/
- dotnet add reference ../Application
- dotnet add reference ../Infrastructure
- cd ..
- cd Application/
- dotnet add reference ../Persistance
- dotnet add reference ../Domain
- cd ..
- cd Persistance/
- dotnet add reference ../Domain
- cd Infrastructure
- dotnet add reference ../Application
- (dotnet restore --- to make all of our projects be aware of dependencies)

> `commands that update dotnet ef tool`

- dotnet tool update --global dotnet-ef

> `commands that can run API`

- dotnet run
- dotnet watch run

> `command for creating database`

- dotnet restore --- in order if the c# extension does not work

> `command for creating database`

- dotnet ef migrations add initial -p Persistence/ -s API/

> `command for updating database`

- dotnet ef database update -p Persistence/ -s API/

> `command for deleting last migration`

- dotnet ef migrations remove -p Persistence/ -s API/

```javascript
The meaning of '-p' is project where is data context, and '-s' where you forward the flag.

```

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

```javascript
const user = pm.response.json()

pm.test('Has properties', function () {
  pm.expect(user).to.have.property('token')
})

if (pm.test('Has properties')) {
  pm.globals.set('TOKEN', user.token)
}

pm.test('Global token has been set', function () {
  var token = pm.globals.get('TOKEN')
  pm.expect(token).to.eql(user.token)
})
```

> `setting pagination header in postman`

```javascript
var data = pm.response.json()

pm.test('response is 200', function () {
  pm.response.to.have.status(200)
})

pm.test('has all properties', function () {
  pm.expect(data[0]).to.have.property('id')
  pm.expect(data[0]).to.have.property('title')
  pm.expect(data[0]).to.have.property('description')
  pm.expect(data[0]).to.have.property('date')
  pm.expect(data[0]).to.have.property('city')
  pm.expect(data[0]).to.have.property('venue')
  pm.expect(data[0]).to.have.property('attendees')
})

pm.test('has pagination header', function () {
  pm.response.to.have.header('pagination')
})
```

## client_side

> `command that creates new react-app project with typescript`

- npx create-react-app client_side --use-npm --template typescript

> `dependencies`

- npm install axios
- npm install semantic-ui-react semantic-ui-css
- npm install uuid
- npm install mobx mobx-react-lite
- npm install react-router-dom
- npm install @types/react-router-dom --save-dev
- npm install react-calendar @types/react-calendar
- npm install react-toastify
- npm install formik
- npm install yup
- npm install @types/yup --save-dev
- npm install react-datepicker
- npm install react-datepicker --legacy-peer-deps --- in case if you get error
- npm install @types/react-datepicker --save-dev
- npm ls date-fns
- npm install date-fns@(version that is showing there)
- [date-fns documentation](https://date-fns.org)
- npm install react-dropzone
- npm install react-cropper
- npm install @microsoft/signalr
- npm install --save react-infinite-scroll --- or --- npm install react-infinite-scroller --legacy-peer-deps
- npm install @types/react-infinite-scroller
- npm install @types/facebook-js-sdk --save-dev
- npm install rimraf --save-dev

# Publish

- docker run --name dev -e POSTGRES_USER=admin -e POSTGRE_PASSWORD=secret -p 5432:5432 -d postgres:latest

- [heroku](https://dashboard.heroku.com)

```javascript
  heroku login
  heroku git:remote -a yavar-activities
```

- [dotnet buildpack](https://github.com/jincod/dotnetcore-buildpack)

```javascript
- git push heroku main
```

```javascript
https://yavar-activities.herokuapp.com/
```

- [http security checker](https://securityheaders.com) - to make sure that the application that you created is safe

- [documentation](https://documenter.getpostman.com/view/11043766/Tz5tYbfC)

- [facebook-developers](https://developers.facebook.com)

```javascript
facebook test accounts
```

```
- will_ixgiaos_will@tfbnw.net
- james_vkoeixf_james@tfbnw.net
- keiran_lussigx_keiran@tfbnw.net
- Pa$$w0rd
```

> # GitHub new branch

```javascript
git checkout -b fbLogin
git checkout main
```
