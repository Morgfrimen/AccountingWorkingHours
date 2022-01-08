using System.Windows;
using AccountingWorkingHours.ViewModels.Abstracts;

namespace AccountingWorkingHours.Views
{
    /// <summary>
    /// Логика взаимодействия для AddPlaceWindow.xaml
    /// </summary>
    public partial class AddPlaceWindow : Window
    {
        public AddPlaceWindow(IAddPlaceWindowViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
