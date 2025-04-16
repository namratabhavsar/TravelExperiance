# TravelExperianceManagement
This API allows you to manage travel experiences, including trips, activities, and user-related data.

## Key Features

**RESTful APIs**: The backend of the application exposes APIs to interact with travel data.
**Swagger UI**: Interactive API documentation for easy testing and exploration of the available endpoints.
**ASP.NET Core**: Utilized for building the web API.
**AutoMapper**: Used to map domain models to DTOs and vice versa.
**SQL Server**: The application uses SQL Server to store the data in three main tables: Trips, Activities, and Destinations.

## Database Structure
1. **Trips**: Stores information about travel trips.
   - `TripId` (Primary Key)
   - `User`: Name of the user taking the trip.
   - `Title`: Title of the trip.
   - `StartDate`: Start date of the trip.
   - `EndDate`: End date of the trip.
   - `CreatedAt`: Timestamp for when the trip was created.

2. **Activities**: Stores activities that are part of a trip.
   - `ActivityId` (Primary Key)
   - `TripId` (Foreign Key to Trips)
   - `ActivityName`: Name of the activity.
   - `Duration`: Duration of the activity.
   - `Cost`: Cost associated with the activity.
   - `CreatedAt`: Timestamp for when the activity was created.

3. **Destinations**: Stores the destination details for activities.
   - `DestinationId` (Primary Key)
   - `DestinationName`: Name of the destination.
   - `Country`: Country where the destination is located.
   - `City`: City where the destination is located.

## API Endpoints

1.***GET all trips***
GET: https://localhost:portnumber/api/Trips

2.***GET trip by Id***
GET : https://localhost:portnumber/api/Trips/{id}

3.***POST a trip***
 POST: https://localhost:portnumber/api/Trips

 4.***Update trip***
PUT : https://localhost:portnumber/api/Trips/{id}

 5.***Delete trip***
 DELETE: https://localhost:portnumber/api/Trips/{id}


 **How To Run the Project**

### 1. **Clone the Repository**
https://github.com/yourusername/TravelExperienceManagement.git

Clone the project repository to your local machine.

git clone https://github.com/yourusername/TravelExperienceManagement.git

Ensure Your Connection String is Correcect in appsettings.json
(Change for connecting to SQL server according to your connection string)

Restore Dependencies if required
***Nuget PM Console*** : Restore-Packages

Apply Migrations
***Nuget PM Console*** : Update-Database

***Assumptions*** : **Destinations** table already exists with travel destinations provided.
Script provided below 

INSERT INTO Destinations(DestinationName)
VALUES
('Banff National Park'),
('Whistler'),
('Niagara Falls'),
('Prince Edward Island'),
('Gros Morne National Park'),
('Jasper National Park'),
('Tofino'),
('Algonquin Provincial Park'),
('Cape Breton Highlands'),
('Churchill (Polar Bears)'),
('Whitehorse'),
('Charlottetown'),
('Mont-Tremblant'),
('Fundy National Park');

