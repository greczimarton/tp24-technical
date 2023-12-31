# TP-24 Technical Test

This is my solution for the take home technical assignment interview round @TP-24.
It took around 2 days to complete the assignment.

### Prerequisites
 - Docker
 - Visual Studio (I used 2022 Community)
 - .NET 7.0 SDK (for testing purposes)

### Technologies used
 - ASP.NET Core 7.0 WebAPI
 - Entity Framework Core
 - PostgreSQL
 - Docker
 - XUnit

### How to run it?
 - Clone the repository
 - Open project in terminal
 - Run ```docker-compose up -d```
 - Open a browser and navigate to https://localhost:8001/swagger/index.html
 - Use the Swagger UI to test the API
   - I added ```example.json``` containing some sample data
   - Copy its contents and paste it into the request body of the POST request
 - You can also connect to the Postgres database: localhost:8002
   - Username: password
   - Password: username

### Assumptions:
 - The API will always receive a valid JSON input. Only the optional values can be null
 - The Date fields are sent in ISO 8601 format
 - The number fields are sent in decimal format
 - When checking for example ```DueDate < ClosedDate```, the API only checks the date part, it ignores the time part

### How does it work?
#### 1. The API parses the received JSON into a list of Debtor objects
   - Each debtor contains a list of Receivables and list of DebtorAddresses
   - It also has some other properties, about the debtor like Name and Reference

#### 2. The API then stores these objects in a database
   - I use Entity Framework Core and PostgreSQL as the database

#### 3. The API then calls the logic layer:
- It builds a Statistics for each Debtor
- The Statistics contains the following information:
     - Data about the debtor
     - Currency: DEFAULT Currency (EUR)
     - Metrics:
       - All: All receivables of the debtor
       - Cancelled: Receivables which are cancelled
         - Cancelled is not null and true
       - Closed: Receivables which are closed
         - ClosedDate is not null
         - ClosedDate is before the current date
         - PaidValue == OpeningValue
         - From Closed receivables ClosedLate receivables are also calculated
           - ClosedLate: Receivables which are closed after their DueDate 
       - Open: All the receivables which are not **closed**
         - Late: Open Receivables with DueDate **after** the current date
       - DueIn7Days: Receivables which are not closed and their DueDate is **within** 7 days
 - The API then returns the Statistics in a JSON format
   - If an exception occured during the process, the API returns a 500 Internal Server Error with the exception message
 
### Testing
Unfortunately I didn't have enough time to set this up in docker properly, therefore you have to open the project in your favourite editor and run the tests there

#### About the tests
I wrote 10 tests each of them containing multiple inputs. The total amount of test cases are 24. (Just like in the company name :D)

I divided the test the following way:
 - Unit tests:
   - Sorting tests: Tests if the API puts the receivables in the correct groups 
   - Summing tests: Tests if the API can sum the receivables correctly, paying attention to the different currencies
     - I only tested the logic with cancelled receivables, because the other metrics are calculated the same way
 - Integration tests:
   - I send a JSON input and check if the API returns the correct JSON output
   - In the integration tests, I use a second endpoint which doesn't work with the DB at all.
     - I wanted to setup an in-memory database for this, but I didn't have enough time to do it
     - therefore I went with this is quick and easy approach which doesn't affect tests that much

### Upgrades
 - I would add a proper logging system
 - I would add a proper error handling system
 - I would add live currency exchange rates

### Conclusion
Thanks for reading about my solution. I really enjoyed working on this assignment. 
I learned a lot of new things and I had a lot of fun.
Unfortunately I didn't have enough time to implement everything I wanted, 
especially the storage and db part were rushed.
I hope my solution works on your machine as well.
I'm looking forward to hearing from you.
