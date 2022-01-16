using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using AccountingWorkingHours.Commands;
using AccountingWorkingHours.Models.Abstracts;
using AccountingWorkingHours.ViewModels.Abstracts;

namespace AccountingWorkingHours.ViewModels;

public sealed class RemovePlaceWindowViewModel : BaseViewModel
{
    public RemovePlaceWindowViewModel(IList<IPlaceModel> placeModels, IPlaceModel? place)
    {
        var model = place;
        PlaceModels = placeModels;
        RemovePlaceCommand = new RelayCommand(obj =>
        {
            if (model is null || !PlaceModels.Remove(model))
            {
                _ = MessageBox.Show("Объект уже был удален", "Уведомление", MessageBoxButton.OK,
                    MessageBoxImage.Warning,
                    MessageBoxResult.OK);
                return;
            }

            var window = obj as Window;
            window!.DialogResult = true;
            window.Close();
        });
    }

    private IList<IPlaceModel> PlaceModels { get; }

    public ICommand RemovePlaceCommand { get; }
}