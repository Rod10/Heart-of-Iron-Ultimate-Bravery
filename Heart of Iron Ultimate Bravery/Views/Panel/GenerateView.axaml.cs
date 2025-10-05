using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Heart_of_Iron_Ultimate_Bravery.Views.Panel;

public partial class GenerateView : UserControl
{
    public GenerateView()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Avalonia.Controls.Button test = (Avalonia.Controls.Button)sender;
        Console.WriteLine(test.Name);
    }
}