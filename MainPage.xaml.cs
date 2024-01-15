using ClassesApp.Pages;

namespace ClassesApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }



        private async void ClassesBtn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new ClassesPage() );
        }
    }

}
