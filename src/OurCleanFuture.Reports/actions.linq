<Query Kind="Statements">
  <Connection>
    <ID>7fca0928-d340-43b2-8965-90ced98a73b9</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="EF7Driver" PublicKeyToken="469b5aa5a4331a8c">EF7Driver.StaticDriver</Driver>
    <CustomAssemblyPath>C:\Users\jhodgins\source\repos\ytgov-env\our-clean-future\src\OurCleanFuture.Data\bin\Debug\net6.0\OurCleanFuture.Data.dll</CustomAssemblyPath>
    <CustomTypeName>OurCleanFuture.Data.AppDbContext</CustomTypeName>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAqEU91o4KiEeKBG+qj9AJsQAAAAACAAAAAAADZgAAwAAAABAAAACfv0dvNi3TuwVplynBG1uaAAAAAASAAACgAAAAEAAAAHuaoM2o13XvcE7sMGuTpIxIAAAARq6jhOEc4F9rpvyIRE+oENYn7zHONCbY72zdtMP/YxbMtpqAahFr7hcDPhutQrBw8V1IubW8dc41Z1jfgHTALUXq4QZJyyZoFAAAABHfvv+DqmNtA3xlg9SaLVClGdCj</CustomCxString>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <UseDbContextOptions>true</UseDbContextOptions>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
  <Reference Relative="..\OurCleanFuture.App\bin\Debug\net6.0\OurCleanFuture.App.dll">C:\Users\jhodgins\source\repos\ytgov-env\our-clean-future\src\OurCleanFuture.App\bin\Debug\net6.0\OurCleanFuture.App.dll</Reference>
  <Reference Relative="..\OurCleanFuture.App\bin\Debug\net6.0\OurCleanFuture.Data.dll">C:\Users\jhodgins\source\repos\ytgov-env\our-clean-future\src\OurCleanFuture.App\bin\Debug\net6.0\OurCleanFuture.Data.dll</Reference>
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
	ActionInternalStatusUpdatedDate = a.InternalStatusUpdatedDate.Value.LocalDateTime,
	ActionInternalStatusUpdatedBy = a.InternalStatusUpdatedBy,
	ActionExternalStatus = a.ExternalStatus.GetDisplayName(),
	ActionExternalStatusUpdatedBy = a.ExternalStatusUpdatedBy,
	ActionExternalStatusUpdatedDate = a.ExternalStatusUpdatedDate.Value.LocalDateTime,
	ActionActualCompletionDate = a.ActualCompletionDate.ToString(),
	ActionTargetCompletionDate = a.TargetCompletionDate.ToString(),
	AreaTitle = a.Objective.Area.Title,
	ObjectiveTitle = a.Objective.Title,
	IndicatorCount = a.Indicators.Count,
	LastUpdated = EF.Property<DateTime>(a, "ValidFrom"),
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
	public string? ActionInternalStatusUpdatedBy { get; set; }
	public DateTime? ActionInternalStatusUpdatedDate { get; set; }
	public string? ActionExternalStatus { get; set; }
	public string? ActionExternalStatusUpdatedBy { get; set; }
	public DateTime? ActionExternalStatusUpdatedDate { get; set; }
	public string? ActionActualCompletionDate { get; set; }
	public string? ActionTargetCompletionDate { get; set; }
	public string? AreaTitle { get; set; }
	public string? ObjectiveTitle { get; set; }
	public int IndicatorCount { get; set; }
	public DateTime LastUpdated { get; set; }
	public string Link { get; set; }
}

#nullable disable

