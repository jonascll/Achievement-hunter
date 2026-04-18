using System;
using System.Threading.Tasks;
using Achievement_Hunter.Classes;
using Achievement_Hunter.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;



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
        GameListViewModel gmlvm = null;
        if (DataContext is GameListViewModel viewModel)
        {
            gmlvm = viewModel;
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
                if (result != null)
                {
                    if (result?.ResponseObject is Game gameObject && result.Succeeded)
                    {
                        if (gmlvm != null)
                        {
                            gmlvm.Games.Add(gameObject);
                        }


                    }

                    if (!result.Succeeded)
                    {

                        var warningDialog = new WarningDialog();
                        var warningVm = new WarningDialogViewModel(warningDialog, result.ErrorMessage);
                        warningDialog.DataContext = warningVm;
                        await warningDialog.ShowDialog(window);
                    }
                }
                else
                {

                    var warningDialog = new WarningDialog();
                    var warningVm = new WarningDialogViewModel(warningDialog, "Something went terribly wrong");
                    warningDialog.DataContext = warningVm;
                    await warningDialog.ShowDialog(window);
                }


            }

        }
    }



}