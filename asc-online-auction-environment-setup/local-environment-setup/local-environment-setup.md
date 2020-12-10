## ASC Online Auction Platform - Local Environment Setup

#
### Seting up the backend
#

1. Open the solution in "auctionplatform\ASC.Online.AuctionApp" path in Visual Studio 2019. You should have .NET CORE 3.1 SDK install in your machine. 
2. Resolve the dependencies and build the solution. 

### Setting up the local DB
#
3. Set "ASC.Online.AuctionApp.MockDataSeed" project as the startup project and run it. This will create an initial database in your local visual studio to begin with. Migrations scripts are already created for initial data seeding. (change the connectionstring as per your local environment)


4. Check the SQL Server Object Explorer and verify the DB is created. If all goes well, you should see a DB named "ACSAuctionDB".  
   
5. Set "ASC.Online.AuctionApp.SessionSetup.Api" project as the starup project and run the application. 
   
6. By now you should see the swagger documentation opens up in your default browser and the CRUD operations related "Auction Session" should be available for you. (Please refer to the attached screen)


### Setting the Web front end (Angular Project)
#
7. Open the "auctionplatform\ASC.Online.AuctionWeb" folder content in VS Code. (Or any preffered IDE to run an Angular project)
   
8. Type "npm i" in your integrated terminal. 

    ``` npm i ```
9. Once the node-modules are successfully updated to your local environment,     type ``` ng serve -o ```. This will build and run your Angular application and open a new browser window. (Please refer the attachemnt)

10. Click on the "Auction Sessions" button in case. Note that this is an initial sketch of the web front end and need to apply UI/UX during the development phase. 