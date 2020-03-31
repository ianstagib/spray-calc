# spray-calc
- Agrovision.API
----------------
Web API project built in .NET Core 3.1, utilising sqlite for its database, NUnit tests, EntityFramework Core Db First, Async / Await throughout, Microsoft dependency injection. The structure was chosen to be fairly representative of the approach I usually follow with a project in order to minimise unwanted dependencies. Sqlite is not usually the database I would work with but I wanted the project to be as self contained as possible so as to make it easier for you, the evaluator, to work with it. Sqlite is not known for its support for multi-threaded applications and thus if any of the unit tests fail then just re-run the individual ones and it will pass.

- Agrovision-Web-Angular
------------------------
Angular project utilising angular material for its CSS styling. I purposefully chose to have the calculation logic in the front end because the nature of this logic is not critical or a security risk. I believe in keeping business logic in the back end but for the purposes of this calculator I wanted to have real time changes to the output on input changes.


Running the solution
--------------------
Restore nuget packages. Debug / Run the API project. It should serve on localhost:5000.
Run NPM Install to install dependencies. NG serve the angular project. It should serve on localhost:4200.
