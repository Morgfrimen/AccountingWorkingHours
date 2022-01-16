using AccountingWorkingHours.Commands;
using AccountingWorkingHours.Models;
using AccountingWorkingHours.Models.Abstracts;
using AccountingWorkingHours.ViewModels.Abstracts;
using System.Collections.Generic;
using System.Windows.Input;

namespace AccountingWorkingHours.ViewModels;

public sealed class AddPlaceWindowViewModes : BaseViewModel
{
    private string _namePlace;
    private IList<IPlaceModel> PlaceModels { get; }
    public AddPlaceWindowViewModes(IList<IPlaceModel> placeModels)
    {
        PlaceModels = placeModels;
        AddPlace = new RelayCommand((obj) =>
        {
            PlaceModels.Add(new PlaceModel(NamePlace));
            NamePlace = string.Empty;
        });
    }

    public string NamePlace
    {
        get => _namePlace;
        set
        {
            _namePlace = value;
            OnPropertyChanged(nameof(NamePlace));
        }
    }

    public ICommand AddPlace { get; }
}