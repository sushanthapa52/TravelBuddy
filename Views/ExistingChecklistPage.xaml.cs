using TravelBuddy.ViewModel;

namespace TravelBuddy.Views;

public partial class ExistingChecklistPage : ContentPage
{
	private ExistingChecklistVIewModel _existingChecklistVIewModel;


    public ExistingChecklistPage(ExistingChecklistVIewModel existingChecklistVIewModel)
	{
		InitializeComponent();
		_existingChecklistVIewModel = existingChecklistVIewModel;
		BindingContext = _existingChecklistVIewModel;
       // _existingChecklistVIewModel.LoadChecklistAsync("qpHwEijpbhe8zqYX1OxrdRRF03F2"); // Pass the actual userId here

    }

}