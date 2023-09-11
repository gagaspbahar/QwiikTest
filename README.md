# Simple WebAPI

## Description

This is a simple WebAPI on .NET Core. This application is made for learning purposes.

## How to run

- Clone this repository
- run `dotnet restore`
- run `dotnet run` or `dotnet watch run` to run the application

## Endpoints

### POST /api/triangle

This is a function to accept three integer values that represent the lengths of the sides of a triangle and returns a string that classifies the triangle's type.

### GET /api/fibonacci/{number}

This is a function to accept an integer value n and returns Fibonacci sequence up until the nth value.

### POST /api/sort

This is a function to accept an array of integers and returns the sorted array.

## Other Information

### Swagger

When running the app, Swagger will be accessible in the following URL: `http://localhost:5062/swagger/index.html`

### Postman

Postman collection is included in this repository.

