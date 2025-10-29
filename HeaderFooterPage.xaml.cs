using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace TemPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderFooterPage : ContentPage
    {
        ControlTemplate OrangeTemplate;
        ControlTemplate GreenTemplate;
        public static readonly BindableProperty
        HeaderTextProperty =
        BindableProperty.Create(nameof(HeaderText),
        typeof(string),
        typeof(HeaderFooterPage),
        default(string));
        public string HeaderText
        {
            get => (string)GetValue(HeaderTextProperty);
            set => SetValue(HeaderTextProperty, value);
        }
        bool original = true;
        public bool OriginalTemplate
        {
            get { return original; }
        }
        public HeaderFooterPage()
        {
            InitializeComponent();
            OrangeTemplate =
            (ControlTemplate)Resources["OrangeTemplate"];
            GreenTemplate =
            (ControlTemplate)Resources["GreenTemplate"];
        }
        void OnChangeTheme(object sender, EventArgs e)
        {
            original = !original;
            ControlTemplate =
            (original) ? OrangeTemplate : GreenTemplate;
        }
    }
}