﻿using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class UnitOfMeasurement
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Symbol { get; set; } = "";

    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Symbol)) {
            return Name;
        }
        else {
            return Symbol;
        }
    }
}
