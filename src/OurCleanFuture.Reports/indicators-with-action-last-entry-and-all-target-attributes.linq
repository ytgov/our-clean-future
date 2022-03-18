<Query Kind="Statements">
  <Connection>
    <ID>868cc442-f3aa-4e2b-8edb-63377bfcf3ed</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="EF7Driver" PublicKeyToken="469b5aa5a4331a8c">EF7Driver.StaticDriver</Driver>
    <CustomAssemblyPath>C:\Users\jhodgins\source\repos\our-clean-future\src\OurCleanFuture.Data\bin\Debug\net6.0\OurCleanFuture.Data.dll</CustomAssemblyPath>
    <CustomTypeName>OurCleanFuture.Data.AppDbContext</CustomTypeName>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAhbq4zDRmf0mpgTsJ2dMQJgAAAAACAAAAAAAQZgAAAAEAACAAAACH8Uueu1xAufZx5Nx7wk+lqhRNnSSmd05vWVhNraJMngAAAAAOgAAAAAIAACAAAAAo5/6epBAAc8IskP+EhZ9YjO6GQGM+132LWM1h8Cs0dGAAAAASGr7v1xK9da81CjMyV9GYS6Xkc9VBW+UeeaCKAkR4rv8e3XxyuVHWATSrr5RGtMMEcLskZWoj4S0gpY+LhZ5M9VdxisJO7QrtxefwFG++xvURDC2c7tMmaglp2G3bT35AAAAAriOux+nX/4qr5QdA2uE11ChPRHOHZarbKnCKUzfoyc9NIMsjsjOphEOhj4z9rva818ztupaupQeYqNYqrKMcCg==</CustomCxString>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <UseDbContextOptions>true</UseDbContextOptions>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
  <Reference Relative="..\OurCleanFuture.App\bin\Debug\net6.0\OurCleanFuture.App.dll">C:\Users\jhodgins\source\repos\our-clean-future\src\OurCleanFuture.App\bin\Debug\net6.0\OurCleanFuture.App.dll</Reference>
</Query>

using OurCleanFuture.Data.Entities;
using OurCleanFuture.App.Extensions;

#nullable enable


Indicators.Select(i => new IndicatorLastEntryViewModel
{
	IndicatorId = i.Id,
	IndicatorTitle = i.Title,
	IndicatorDescription = i.Description,
	Organization = i.Leads.FirstOrDefault().Organization.Name,
	Department = i.Leads.FirstOrDefault().Branch.Department.ShortName,
	Branch = i.Leads.FirstOrDefault().Branch.Name,
	ActionId = (i.Action == null ? null : i.Action.Id),
	ActionNumber = (i.Action == null ? default : i.Action.Number),
	ActionTitle = (i.Action == null ? default : i.Action.Title),
	ActionDirectorsCommittees = (i.Action == null ? default : i.Action.DirectorsCommittees.ToFriendlyName()),
	ActionInternalStatus = (i.Action == null ? default : i.Action.InternalStatus.GetDisplayName()),
	ActionExternalStatus = (i.Action == null ? default : i.Action.ExternalStatus.GetDisplayName()),
	ActionActualCompletionDate = (i.Action == null ? default : i.Action.ActualCompletionDate.ToString()),
	ActionTargetCompletionDate = (i.Action == null ? default : i.Action.TargetCompletionDate.ToString()),
	AreaTitle = (i.Action == null ? i.Objective!.Area.Title : i.Action.Objective.Area.Title),
	ObjectiveTitle = (i.Objective == null ? i.Action!.Objective.Title : i.Objective.Title),
	CollectionInterval = i.CollectionInterval.ToString(),
	LastEntryDate = i.Entries.OrderBy(e => e.EndDate).LastOrDefault().EndDate.Date.ToString(),
	LastEntryBy = i.Entries.OrderBy(e => e.EndDate).LastOrDefault().UpdatedBy,
	LastEntryValue = (i.Entries.OrderBy(e => e.EndDate).LastOrDefault().Value as double?),
	TargetDescription = (i.Target == null ? default : i.Target.Description),
	TargetValue = (i.Target == null ? default : i.Target.Value as double?),
	TargetStartDate = (i.Target == null ? default : i.Target.StartDate.ToString()),
	TargetEndDate = (i.Target == null ? default : i.Target.EndDate.ToString()),
	UnitOfMeasurement = i.UnitOfMeasurement.Symbol,
	Link = $"https://ourcleanfuture.ynet.gov.yk.ca/indicators/details/{i.Id}"
}).AsNoTracking().OrderBy(i => i.IndicatorId).Dump();

public class IndicatorLastEntryViewModel
{
	public int IndicatorId { get; set; }
	public string IndicatorTitle { get; set; } = null!;
	public string IndicatorDescription {get; set; } = null!;
	public string? Organization { get; set; }
	public string? Department { get; set; }
	public string? Branch { get; set; }
	public int? ActionId { get; set; }
	public string? ActionNumber { get; set; }
	public string? ActionTitle { get; set; }
	public string? ActionDirectorsCommittees { get; set; }
	public string? ActionInternalStatus { get; set; }
	public string? ActionExternalStatus { get; set; }
	public string? ActionActualCompletionDate { get; set; }
	public string? ActionTargetCompletionDate { get; set; }
	public string? AreaTitle { get; set; }
	public string? ObjectiveTitle { get; set; }
	public string? CollectionInterval { get; set; }
	public string? LastEntryDate { get; set; }
	public string? LastEntryBy { get; set; }
	public double? LastEntryValue { get; set; }
	public string? TargetDescription { get; set; }
	public double? TargetValue { get; set; }
	public string? TargetStartDate { get; set; }
	public string? TargetEndDate { get; set; }
	public string UnitOfMeasurement { get; set; } = null!;
	public string Link { get; set; } = null!;
}

#nullable disable

