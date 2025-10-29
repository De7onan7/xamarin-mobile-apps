using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FLPage_FM_CS
{
    class NamedColorPage : ContentPage
    {
        public NamedColorPage()
        {
            // Добавление информации об авторах
            Label authorsLabel = new Label
            {
                Text = "Мухамедшина Э.Э., Федорова Е.Д. Группа: БИ07",
                FontSize = 16,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#27AE60"),
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = new Thickness(10, 8),
                Margin = new Thickness(0, 0, 0, 20),
                FontAttributes = FontAttributes.Bold
            };

            // Элемент управления BoxView для отображения цвета
            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                CornerRadius = 10
            };
            boxView.SetBinding(BoxView.ColorProperty, "Color");

            // Заголовок с названием цвета
            Label colorNameLabel = new Label
            {
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("#2C3E50"),
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 0, 0, 20)
            };
            colorNameLabel.SetBinding(Label.TextProperty, "Name");

            // Функция для формирования шести элементов управления Label
            Func<string, string, Label> CreateLabel = (string source, string fmt) =>
            {
                Label label = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.FromHex("#2C3E50"),
                    FontAttributes = FontAttributes.Bold,
                    Margin = new Thickness(0, 5)
                };
                label.SetBinding(Label.TextProperty,
                new Binding(source, BindingMode.OneWay, null, null, fmt));
                return label;
            };

            // Построение страницы
            Content = new StackLayout
            {
                BackgroundColor = Color.FromHex("#ECF0F1"),
                Padding = new Thickness(20),
                Children =
                {
                    authorsLabel,
                    colorNameLabel,
                    boxView,
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Start,
                        Margin = new Thickness(0, 20, 0, 0),
                        Children =
                        {
                            CreateLabel ("Color.R", "R = {0:F2}"),
                            CreateLabel ("Color.G", "G = {0:F2}"),
                            CreateLabel ("Color.B", "B = {0:F2}"),
                        }
                    },
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Start,
                        Margin = new Thickness(0, 20, 0, 0),
                        Children =
                        {
                            CreateLabel ("Color.Hue", "Hue = {0:F2}"),
                            CreateLabel ("Color.Saturation", "Saturation = {0:F2}"),
                            CreateLabel ("Color.Luminosity", "Luminosity = {0:F2}")
                        }
                    }
                }
            };
        }
    }
}
