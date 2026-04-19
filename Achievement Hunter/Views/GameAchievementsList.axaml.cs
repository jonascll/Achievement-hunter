using Achievement_Hunter.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Achievement_Hunter.Views;

public partial class GameAchievementsList : UserControl
{
    public GameAchievementsList()
    {
        InitializeComponent();
    }

    async public void NavigateBackToGameList(object? sender, PointerPressedEventArgs e)
    {
        PointerUpdateKind pointerUpdateKind = e.GetCurrentPoint(this).Properties.PointerUpdateKind;
        if (DataContext is GameAchievementListViewModel viewModel)
        {
            viewModel.NavigateBack();
        }
    }
}