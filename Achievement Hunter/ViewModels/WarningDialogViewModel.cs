using System.Threading.Tasks;
using Achievement_Hunter.ViewModels;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Achievement_Hunter.ViewModels;

public partial class WarningDialogViewModel : ViewModelBase
{

    private readonly Window _dialog;
    [ObservableProperty] string _warning;


    public WarningDialogViewModel(Window dialog, string warning)
    {
        this._dialog = dialog;
        this._warning = warning;
    }

    [RelayCommand]
    public async Task Confirm()
    {
        _dialog.Close();
    }

}