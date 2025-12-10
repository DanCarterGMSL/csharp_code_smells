namespace DivergentChange;

public class Tax
{
    public static decimal GetTaxRate(string jurisdiction) =>
        jurisdiction switch
        {
            "EU" => 0.20m,
            "UK" => 0.21m,
            "US" => 0.07m,
            _ => 0.10m
        };
}