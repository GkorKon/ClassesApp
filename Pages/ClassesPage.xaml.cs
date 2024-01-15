using ClassesApp.Models;
using ClassesApp.ViewModels;

namespace ClassesApp.Pages;

public partial class ClassesPage : ContentPage
{
	public ClassesPage()
	{
		InitializeComponent();

		BindingContext = new ClassViewModel();
	}

}