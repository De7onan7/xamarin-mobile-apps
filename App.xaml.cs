using Xamarin.Forms;

namespace TemPage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // ВАЖНО: Указываем какая страница запускается первой
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}