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
  <Reference Relative="..\OurCleanFuture.App\bin\Debug\net6.0\OurCleanFuture.Data.dll">C:\Users\jhodgins\source\repos\our-clean-future\src\OurCleanFuture.App\bin\Debug\net6.0\OurCleanFuture.Data.dll</Reference>
</Query>

using OurCleanFuture.Data.Entities;
using OurCleanFuture.App.Extensions;

#nullable enable

Actions.Select(a => new ActionViewModel
{
	Organization = a.Leads.FirstOrDefault().Organization.Name,
	Department = a.Leads.FirstOrDefault().Branch.Department.ShortName,
	Branch = a.Leads.FirstOrDefault().Branch.Name,
	ActionId = a.Id,
	ActionNumber = a.Number,
	ActionTitle = a.Title,
	ActionDirectorsCommittees = a.DirectorsCommittees.ToFriendlyName(),
	ActionInternalStatus = a.InternalStatus.GetDisplayName(),
	ActionExternalStatus = a.ExternalStatus.GetDisplayName(),
	ActionActualCompletionDate = a.ActualCompletionDate.ToString(),
	ActionTargetCompletionDate = a.TargetCompletionDate.ToString(),
	AreaTitle = a.Objective.Area.Title,
	ObjectiveTitle = a.Objective.Title,
	IndicatorCount = a.Indicators.Count,
	Link = $"https://ourcleanfuture.ynet.gov.yk.ca/actions/details/{a.Id}"
}).AsNoTracking().OrderBy(a => a.ActionId).Dump();

public class ActionViewModel
{
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
	public int IndicatorCount { get; set; }
	public string Link { get; set; }
}

#nullable disable

