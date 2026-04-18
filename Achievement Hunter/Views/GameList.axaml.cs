using System;
using System.Threading.Tasks;
using Achievement_Hunter.Classes;
using Achievement_Hunter.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;



namespace Achievement_Hunter.Views;

public partial class GameList : UserControl
{

    public GameList()
    {
        InitializeComponent();
    }

    async public void AddNewGame(object? sender, PointerPressedEventArgs e)
    {
        string currentText = "";
        GameListViewModel glvm = null;
        if (DataContext is GameListViewModel viewModel)
        {
            glvm = viewModel;
            currentText = viewModel.GameName;

        }
        var dialog = new AddGameDialog();
        var vm = new AddGameDialogViewModel(dialog, currentText);
        dialog.DataContext = vm;
        PointerUpdateKind pointerUpdateKind = e.GetCurrentPoint(this).Properties.PointerUpdateKind;
        var topLevel = TopLevel.GetTopLevel(this);
        if (pointerUpdateKind == PointerUpdateKind.LeftButtonPressed)
        {
            if (topLevel is Window window)
            {
                GameDialogResponse? result = await dialog.ShowDialog<GameDialogResponse?>(window);
                if (glvm != null)
                {
                    glvm.GameName = "";
                    glvm.FilterList("");
                }

                if (result != null)
                {
                    if (!result.Succeeded)
                    {

                        var warningDialog = new WarningDialog();
                        var warningVm = new WarningDialogViewModel(warningDialog, result.ErrorMessage);
                        warningDialog.DataContext = warningVm;
                        await warningDialog.ShowDialog(window);
                    }
                }
            }

        }
    }

    private void GameDoubleTapped(object? sender, TappedEventArgs args)
    {
        if (DataContext is GameListViewModel viewModel)
        {

            viewModel.RequestNavigation();
        }
    }



}