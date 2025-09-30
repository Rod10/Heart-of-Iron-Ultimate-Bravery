using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Heart_of_Iron_Ultimate_Bravery.Models.Utils;

public class CompletionToCheckboxConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value?.ToString()?.ToLower() switch
        {
            "completed" => "True",
            "incomplete" => "False",
            "partial" => "{x:Null}",
            _ => "False"
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            "True" => "completed",
            "False" => "incomplete",
            "{x:Null}" => "partial",
            _ => "incomplete"
        };
    }
}