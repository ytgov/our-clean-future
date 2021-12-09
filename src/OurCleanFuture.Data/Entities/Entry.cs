﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class Entry
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [Precision(22, 6)]
    public decimal Value { get; set; }
    [StringLength(500, ErrorMessage = "{0} has a maximum length of {1} characters.")]
    public string Note { get; set; } = "";
    [StringLength(100)]
    public string UpdatedBy { get; set; } = "";

    public Indicator Indicator { get; set; } = null!;

    public string ValueToString()
    {
        // Switching on Id here, as end users have access to change the Name and Symbol.
        var result = Indicator.UnitOfMeasurement.Id switch {
            // Count
            2 => Value.ToString("n0"),
            // Dollars
            4 => Value.ToString("c"),
            // All other units
            _ => $"{Value:n} {Indicator.UnitOfMeasurement.Symbol}",
        };
        return result;
    }
}