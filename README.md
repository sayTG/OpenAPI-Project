# OpenAPI Project

This project consists of 3 major parts
- CompliantAPI.Tests
- CompliantAPI
- Compliant-Frontend

## COMPLIANTAPI.TESTS
Xunit framework is used for the unit testing.
Steps to run the project:
- Open the project in visual studio
- Run all the tests in the test explorer

## COMPLIANTAPI
This project is a .Net core project that uses .NET 6.
Steps to run the project:
- Open the project in visual studio
- Run the project on IIS server and use swagger to query the endpoints and test.

## COMPLIANT-FRONTEND
This project uses AngularJS.
Steps to run the project:
- Open the project in visual studio code
- Install node packages using "npm install" on the command line
- Find the environmental.ts file and edit the BASE_URL to the url the compliantAPI was hosted on the IIS  server
- Run "ng serve" on the command line
- Test the application

## VIRTUALIZATION

### USING DOCKER FILE
  ### COMPLIANTAPI
  - Use docker command to build and run the API docker image in a container.
  ### COMPLIANT-FRONTEND
  - Find the environmental.ts file and edit the BASE_URL to the url the COMPLIANTAPI docker container port is running
  - Use docker command to build and run the FRONTEND docker image in a container.
  - Test the application

### USING DOCKER COMPOSE
**As at the time of writing this README I have some issues with my docker compose
- Open the project in Visual studio and run the compose yml file using the docker compose commands on the terminal.


