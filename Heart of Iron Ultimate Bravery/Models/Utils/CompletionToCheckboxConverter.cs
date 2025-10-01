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
            "completed" => true,        // C# boolean, not string "True"
            "incomplete" => false,      // C# boolean, not string "False"  
            "partial" => null,          // C# null, not string "{x:Null}"
            _ => false
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            true => "completed",
            false => "incomplete",
            null => "partial",
            _ => "incomplete"
        };
    }
}