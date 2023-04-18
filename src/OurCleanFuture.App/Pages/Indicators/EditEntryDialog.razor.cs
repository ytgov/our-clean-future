using Microsoft.AspNetCore.Components;
using MudBlazor;
using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Pages.Indicators;

public partial class EditEntryDialog
{
    [CascadingParameter]
    MudDialogInstance MudDialog { get; set; } = null!;

    [Parameter]
    public int[] Years { get; set; } = null!;

    [Parameter]
    public Indicator Indicator { get; set; } = null!;

    [Parameter]
    public Entry Entry { get; set; } = null!;
    private bool _isValid = true;
    private int SelectedYear { get; set; }

    private BiannualInterval SelectedBiannualInterval { get; set; }

    private QuarterlyInterval SelectedQuarterlyInterval { get; set; }

    private decimal? TempValue { get; set; }

    private MudAutocomplete<int> YearAutocomplete { get; set; } = new();

    [Inject]
    private ISnackbar Snackbar { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        var periodLength = Entry.EndDate.Month - Entry.StartDate.Month + 1;
        if (Indicator.CollectionInterval == CollectionInterval.Annual)
        {
            if (periodLength != 12)
            {
                Snackbar.Add(
                    $"The period of the entry ({periodLength} months) does not match the indicator's collection interval. The collection interval must be changed to match the entry period before editing.",
                    Severity.Error
                );
                MudDialog.Cancel();
            }
        }
        else if (Indicator.CollectionInterval == CollectionInterval.Biannual)
        {
            if (periodLength != 6)
            {
                Snackbar.Add(
                    $"The period of the entry ({periodLength} months) does not match the indicator's collection interval. The collection interval must be changed to match the entry period before editing.",
                    Severity.Error
                );
                MudDialog.Cancel();
            }

            switch (Entry.EndDate.Month)
            {
                case 6:
                    SelectedBiannualInterval = BiannualInterval.JanuaryToJune;
                    break;
                case 12:
                    SelectedBiannualInterval = BiannualInterval.JulyToDecember;
                    break;
            }
        }
        else if (Indicator.CollectionInterval == CollectionInterval.Quarterly)
        {
            if (periodLength != 3)
            {
                Snackbar.Add(
                    $"The period of the entry ({periodLength} months) does not match the indicator's collection interval. The collection interval must be changed to match the entry period before editing.",
                    Severity.Error
                );
                MudDialog.Cancel();
            }

            switch (Entry.EndDate.Month)
            {
                case 3:
                    SelectedQuarterlyInterval = QuarterlyInterval.JanuaryToMarch;
                    break;
                case 6:
                    SelectedQuarterlyInterval = QuarterlyInterval.AprilToJune;
                    break;
                case 9:
                    SelectedQuarterlyInterval = QuarterlyInterval.JulyToSeptember;
                    break;
                case 12:
                    SelectedQuarterlyInterval = QuarterlyInterval.OctoberToDecember;
                    break;
            }
        }

        SelectedYear = Entry.StartDate.Year;
        TempValue = Entry.Value;
        await base.OnInitializedAsync();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        // We must re-validate the SelectedYear after the component is initialized, or else the component will erroneously remain in an invalid state.
        YearAutocomplete.Validate();
        return base.OnAfterRenderAsync(firstRender);
    }

    private void Cancel()
    {
        MudDialog.Cancel();
    }

    private IEnumerable<string> ValidateYear(int year)
    {
        if (!Years.Contains(year))
        {
            yield return $"Year must be between {Years[0]} and {Years[Years.Length - 1]}";
        }
    }

    private void AddEntry()
    {
        if (TempValue is not null)
        {
            Entry.Value = (decimal)TempValue;
            if (Indicator.CollectionInterval == CollectionInterval.Annual)
            {
                Entry.StartDate = new DateTime(SelectedYear, 1, 1);
                Entry.EndDate = new DateTime(SelectedYear, 12, 31);
            }
            else if (Indicator.CollectionInterval == CollectionInterval.Biannual)
            {
                switch (SelectedBiannualInterval)
                {
                    case BiannualInterval.JanuaryToJune:
                        Entry.StartDate = new DateTime(SelectedYear, 1, 1);
                        Entry.EndDate = new DateTime(SelectedYear, 6, 30);
                        break;
                    case BiannualInterval.JulyToDecember:
                        Entry.StartDate = new DateTime(SelectedYear, 7, 1);
                        Entry.EndDate = new DateTime(SelectedYear, 12, 31);
                        break;
                }
            }
            else
            {
                switch (SelectedQuarterlyInterval)
                {
                    case QuarterlyInterval.JanuaryToMarch:
                        Entry.StartDate = new DateTime(SelectedYear, 1, 1);
                        Entry.EndDate = new DateTime(SelectedYear, 3, 31);
                        break;
                    case QuarterlyInterval.AprilToJune:
                        Entry.StartDate = new DateTime(SelectedYear, 4, 1);
                        Entry.EndDate = new DateTime(SelectedYear, 6, 30);
                        break;
                    case QuarterlyInterval.JulyToSeptember:
                        Entry.StartDate = new DateTime(SelectedYear, 7, 1);
                        Entry.EndDate = new DateTime(SelectedYear, 9, 30);
                        break;
                    case QuarterlyInterval.OctoberToDecember:
                        Entry.StartDate = new DateTime(SelectedYear, 10, 1);
                        Entry.EndDate = new DateTime(SelectedYear, 12, 31);
                        break;
                }
            }

            MudDialog.Close(DialogResult.Ok(Entry));
        }
    }

    private async Task<IEnumerable<int>> SearchYears(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Years;
        return await Task.FromResult(Years.Where(y => Convert.ToString(y).Contains(value)));
    }

    private bool CheckIfValueIsLikelyUsingTheWrongUnit()
    {
        var unit = Indicator.UnitOfMeasurement.Symbol;
        var entries = Indicator.Entries;

        return unit != "count"
            && unit != "$"
            && unit != "%"
            && entries.Any()
            && entries.Max(e => e.Value) != 0
            && (
                TempValue / 100 > entries.Max(e => e.Value)
                || TempValue * 100 < entries.Min(e => e.Value)
            );
    }
}
