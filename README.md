# DateTimeCheckerAPI
In order to fulfil the requirements of my SWT subject, I have developed a fast and simple .NET API called DateTimeCheckerAPI. This API serves as a tool to check dates and retrieve the number of days in a given month.

## Technology
DateTimeCheckerAPI is built on .NET 7, leveraging top-level statements and the minimal API approach for streamlined development.

## Endpoints
- GET /DaysInMonth
   - Parameters: year, month
   - Description: Retrieves the number of days in the specified month and year.

- POST /CheckValidDate
   - Request Body Schema:
   {
     "year": 0,
     "month": 0,
     "day": 0
   }
   - Description: Checks if the provided date is valid and returns a response indicating validity.
