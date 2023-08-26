<Query Kind="Statements">
  <Connection>
    <ID>7fca0928-d340-43b2-8965-90ced98a73b9</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="EF7Driver" PublicKeyToken="469b5aa5a4331a8c">EF7Driver.StaticDriver</Driver>
    <CustomAssemblyPath>C:\Users\jhodgins\source\repos\ytgov-env\our-clean-future\src\OurCleanFuture.Data\bin\Debug\net7.0\OurCleanFuture.Data.dll</CustomAssemblyPath>
    <CustomTypeName>OurCleanFuture.Data.AppDbContext</CustomTypeName>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA8G3L47roBEC09Oj833mpUgAAAAACAAAAAAADZgAAwAAAABAAAAAUjinwp41jcwu0ZU+/lEDeAAAAAASAAACgAAAAEAAAAJeunNpQ66I/4DU3akPKEl1oAAAAk87FY5ENUMIhfCWlI+JDfl9DN++1QrjyXAV5RSDHPEnP8mIOF2Zy/OL6QJr6yZIt94Yd0gchLHzZ864k9olJvBcDhZfS82ETIlMHjf/bw5xFzNaxLbM5wuWoi/l9IJKHnaLHdr9xw8EUAAAAHdzQm59qRuk/cW/89zjt+Z9b5+k=</CustomCxString>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <UseDbContextOptions>true</UseDbContextOptions>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
  <Reference Relative="..\OurCleanFuture.App\bin\Debug\net6.0\OurCleanFuture.App.dll">C:\Users\jhodgins\source\repos\ytgov-env\our-clean-future\src\OurCleanFuture.App\bin\Debug\net6.0\OurCleanFuture.App.dll</Reference>
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
	TargetCompletionDate = (i.Target == null ? default : i.Target.CompletionDate.ToString()),
	UnitOfMeasurement = i.UnitOfMeasurement.Symbol,
	ViewLink = $"https://ourcleanfuture.ynet.gov.yk.ca/indicators/details/{i.Id}",
	EditLink = $"https://ourcleanfuture.ynet.gov.yk.ca/indicators/edit/{i.Id}"
}).AsNoTracking().OrderBy(i => i.IndicatorId).Dump();

public class IndicatorLastEntryViewModel
{
	public int IndicatorId { get; set; }
	public string IndicatorTitle { get; set; } = null!;
	public string IndicatorDescription { get; set; } = null!;
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
	public string? TargetCompletionDate { get; set; }
	public string UnitOfMeasurement { get; set; } = null!;
	public string ViewLink { get; set; } = null!;
	public string EditLink { get; set; } = null!;
}

#nullable disable

