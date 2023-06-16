# DateTimeCheckerAPI
This is simple .Net API to use check date.
Two main function are check a date and get days in month.

## Tech
My project build on .Net 7.
I use top-level statements and minimal API for this project.

## End-point
- Get /DaysInMonth
   - Parameters: year, month
- Post /CheckValidDate:
  - Body schema: 
  {
  "year": 0,
  "month": 0,
  "day": 0
  }
