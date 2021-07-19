# Football Crimes

#### Running the application  

##### Frontend
Please see the README.md in FootballCrimes.Web for starting the frontend of the application.

#### Backend
1. Add a appsettings.Development.json file to the FootballCrimes.API Project using the same properties as appsettings.json
2. Add your SQL Server connection string and your api key for https://www.football-data.org/ to ConnectionStrings.DefaultConnection and ApiKeys.FootballData respectively
3. Start the application with FootballCrimes.API as the startup project using either Visual Studio or the command line

#### Note
The initial run of the application will take some time - this is because it is gathering the data necessary to populate the database.  
I have also deployed the front end to https://and-tech-frontend.azurewebsites.net/ and api to https://and-tech-server.azurewebsites.net/swagger

#### Attributions
Crime data was taken from https://data.police.uk/ under [Open Government Licence V3](https://www.nationalarchives.gov.uk/doc/open-government-licence/version/3/)  
Football data provided by the Football-Data.org API  
Postcode data from https://postcodes.io/about  
