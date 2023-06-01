# React Todo App Consuming an ASP.NET CORE Minimal API

### Guidelines on how to run the application

First run the Minimal API application
- Goto the folder containing the TodoApi Project File and open it's path in command prompt. Ex. `cmd D:\dev\vp_task\VPTodoAPP\TodoApi`
- Then type `dotnet run` to start the API application.

There is a swagger interface for the API `https://localhost:4000/swagger/index.html`

## NB
Since this is a demo application, upon startup of the `TodoApi project(Minimal API)`, database migrations are run that delete and recreate the database incase it's existing but that process can be changed. 

Second run the React Client Application(Todo App)
- Goto the folder containing the package.json file and open it's path in command prompt. Ex `cmd D:\dev\vp_task\react_client`
- Then type `npm install` to install all the npm packages.
- Then type `npm start` to start the React Todo Application.

Then after the React Client application display below are some images. `http://localhost:3000/`

![image](https://github.com/johnny-camby/react_todo_minimal_api/assets/129853285/d5f09aea-6b06-4687-b0d2-13b9345c41b6)
![image](https://github.com/johnny-camby/react_todo_minimal_api/assets/129853285/41c14a5b-f2ab-4ae3-b600-2c672cb2d3b4)
![image](https://github.com/johnny-camby/react_todo_minimal_api/assets/129853285/2f62a50a-f9a1-4280-90b8-be524380dd07)
![image](https://github.com/johnny-camby/react_todo_minimal_api/assets/129853285/ecbd12ef-1dea-43c2-913e-4a668c94dbef)
![image](https://github.com/johnny-camby/react_todo_minimal_api/assets/129853285/d0390918-9546-41cc-9823-72f9ed885fc0)
![image](https://github.com/johnny-camby/react_todo_minimal_api/assets/129853285/d05561a7-352f-4e43-aaf6-1b2b479a56ab)
Clicking on one of these icon marks a task as completed
![image](https://github.com/johnny-camby/react_todo_minimal_api/assets/129853285/7e6dd4d0-3562-48b1-bda3-792b7348f17c)
Clicking on one of these icon deletes a respective task .
![image](https://github.com/johnny-camby/react_todo_minimal_api/assets/129853285/172484ff-1e95-47ad-bca0-6b050dfe3ce5)
![image](https://github.com/johnny-camby/react_todo_minimal_api/assets/129853285/d0caae70-33bf-45ad-a1f4-f09b45fde8fb)

Thank you all 😉





