# MappingSystem
This project contains a C# class library for mapping objects between different data models, such as mapping hotel reservations from external vendors to internal reservation models. The project also includes unit tests to verify the mapping functionality.

## Sample Classes
The sample classes can be seen in the DataModels folder in the MappingSystem

### The class handles three scenarios.
1. When the classes are simple
2. When there are nested classes.
3. When there is a custom map functionality for any given class

# Instructions to get things to work

### Clone the Repository
To get started, clone the repository to your local machine:

`git clone https://github.com/prashanthbenny2008/MappingClass.git`

`cd MappingClass`

### Build the Solution
To build the project, run the following command:
 
 `dotnet build`

This will restore the necessary dependencies and compile the class library and test projects.

### Running the Project
There is no specific entry point for the class library since it is designed to be used as part of a larger application. However, you can run and debug unit tests to verify the mapping functionality.

### Running Tests
There are unit tests included in the MappingSystem.Tests project to verify that object mapping works as expected.

You can run the unit tests from the command line using the following command:
 
 `dotnet test`
 
This will build and run all the tests in the solution, displaying the results in the terminal.