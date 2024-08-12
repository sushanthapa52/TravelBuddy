using TravelBuddy.ViewModel;

namespace TravelBuddy.Views;

public partial class ChecklistPage : ContentPage
{
	private ChecklistViewModel _checklistViewModel;
	public ChecklistPage(ChecklistViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
		_checklistViewModel = viewModel;
    }
}