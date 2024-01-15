using ClassesApp.ViewModels;

namespace ClassesApp.Pages;

public partial class ClassPage : ContentPage
{
	public ClassPage(ClassViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }

}