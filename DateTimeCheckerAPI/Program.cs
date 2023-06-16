using DateTimeCheckerAPI;
using DateTimeCheckerAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

//Get days in month POST
/*app.MapPost("/GetDaysInMonth", ([FromBody] YearMonth yearMonth) =>
{
	var month = yearMonth.Month;
	var year = yearMonth.Year;

	if (month < 1 || month > 12)
	{
		return Results.BadRequest("Input data for Month is out range!");
	}
	else if (year < 1000 || year > 3000)
	{
		return Results.BadRequest("Input data for Year is out range!");
	}

	var result = Checker.DaysInMonth(year, month);
	if (result == 0)
	{
		return Results.BadRequest("Invalid month or year");
	}
	else
	{
		return Results.Ok(result);
	}
}
);*/

app.MapGet("/DaysInMonth", (int year, int month) =>
{
	if (month < 1 || month >= 12) //Bug here 👈(ﾟヮﾟ👈)
	{
		return Results.BadRequest("Input data for Month is out range!");
	}
	else if (year < 1000 || year > 3000)
	{
		return Results.BadRequest("Input data for Year is out range!");
	}

	var result = Checker.DaysInMonth(year, month);
	if (result == 0)
	{
		return Results.BadRequest("Invalid month or year");
	}
	else
	{
		return Results.Ok(result);
	}
});

/*app.MapGet("/CheckValidDate", (int year, int month, int day) =>
{
	if (day.GetType() != typeof(int))
	{
		return Results.BadRequest("Input data for Day is incorrect format!");
	}
	else if (month.GetType() != typeof(int))
	{
		return Results.BadRequest("Input data for Month is incorrect format!");
	}
	else if (year.GetType() != typeof(int))
	{
		return Results.BadRequest("Input data for Year is incorrect format!");
	}

	// bug here
	if (day < 1 || day >= 31)
	{
		return Results.BadRequest("Input data for Date is out range!");
	}
	else if (month < 1 || month > 12)
	{
		return Results.BadRequest("Input data for Month is out range!");
	}
	else if (year < 1000 || year > 3000)
	{
		return Results.BadRequest("Input data for Year is out range!");
	}


	var result = Checker.IsValidDate(year, month, day);
	if (result)
	{

		var dateTime = DateTime.Parse($"{year}/{month}/{day}");
		var message = $"The date {dateTime.ToString("D")} is valid";
		return Results.Ok(message);
	}
	else
	{
		var message = $"The date is invalid";
		return Results.BadRequest(message);
	}
});*/


app.MapPost("/CheckValidDate", ([FromBody] Date date) =>
{
	var day = date.Day;
	var month = date.Month;
	var year = date.Year;

	if (day.GetType() != typeof(int))
	{
		return Results.BadRequest("Input data for Day is incorrect format!");
	}
	else if (month.GetType() != typeof(int))
	{
		return Results.BadRequest("Input data for Month is incorrect format!");
	}
	else if (year.GetType() != typeof(int))
	{
		return Results.BadRequest("Input data for Year is incorrect format!");
	}

	if (day < 1 || day > 31) //Bug here 👈(ﾟヮﾟ👈)
	{
		return Results.BadRequest("Input data for Date is out range!");
	}
	else if (month < 1 || month > 12)
	{
		return Results.BadRequest("Input data for Month is out range!");
	}
	else if (year < 1000 || year > 3000)
	{
		return Results.BadRequest("Input data for Year is out range!");
	}


	var result = Checker.IsValidDate(year, month, day);
	if (result)
	{
		var dateTime = DateTime.Parse($"{year}/{month}/{day}");
		var message = $"The date {dateTime.ToString("D")} is valid";
		return Results.Ok(message);
		//return Results.Unauthorized();
	}
	else
	{
		var message = $"The date is invalid";
		return Results.BadRequest(message);
	}
});

app.Run();

record YearMonth(int Year, int Month);
record Date(int Year, int Month, int Day);