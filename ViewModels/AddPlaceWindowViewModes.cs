using System.Collections.Generic;
using System.Windows.Input;
using AccountingWorkingHours.Commands;
using AccountingWorkingHours.Models;
using AccountingWorkingHours.ViewModels.Abstracts;

namespace AccountingWorkingHours.ViewModels;

public sealed class AddPlaceWindowViewModes : BaseViewModel
{
    private string? _namePlace;

    public AddPlaceWindowViewModes(IList<PlaceModel> placeModels)
    {
        PlaceModels = placeModels;
        AddPlace = new RelayCommand(obj =>
        {
            PlaceModels.Add(new PlaceModel(NamePlace));
            NamePlace = string.Empty;
        });
    }

    public ICommand AddPlace { get; }

    public string? NamePlace
    {
        get => _namePlace;
        set
        {
            _namePlace = value;
            OnPropertyChanged(nameof(NamePlace));
        }
    }

    private IList<PlaceModel> PlaceModels { get; }
}