using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FLPage_FM_CS
{
    class MainPage : FlyoutPage
    {
        public MainPage()
        {
            Title = "FlyoutPage Demo";

            // Добавление информации об авторах
            Label authorsLabel = new Label
            {
                Text = "Авторы: Абанкина Т., Варенцова Д., Нуреева А., Щербаков А. Группа БИ02",
                FontSize = 16,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#2C3E50"),
                HorizontalOptions = LayoutOptions.Fill,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = new Thickness(10, 8),
                Margin = new Thickness(0, 0, 0, 10),
                FontAttributes = FontAttributes.Bold
            };

            Label header = new Label
            {
                Text = "FlyoutPage",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                Margin = new Thickness(0, 10)
            };

            // Массив объектов NamedColor
            NamedColor[] namedColors = {
                new NamedColor ("Aqua", Color.Aqua),
                new NamedColor ("Black", Color.Black),
                new NamedColor ("Blue", Color.Blue),
                new NamedColor ("Fuchsia", Color.Fuchsia),
                new NamedColor ("Gray", Color.Gray),
                new NamedColor ("Green", Color.Green),
                new NamedColor ("Lime", Color.Lime),
                new NamedColor ("Maroon", Color.Maroon),
                new NamedColor ("Navy", Color.Navy),
                new NamedColor ("Olive", Color.Olive),
                new NamedColor ("Purple", Color.Purple),
                new NamedColor ("Red", Color.Red),
                new NamedColor ("Silver", Color.Silver),
                new NamedColor ("Teal", Color.Teal),
                new NamedColor ("White", Color.White),
                new NamedColor ("Yellow", Color.Yellow)
            };

            // Создание элемента управления ListView для flyout page.
            ListView listView = new ListView
            {
                ItemsSource = namedColors,
                Margin = new Thickness(10, 0),
                BackgroundColor = Color.FromHex("#34495E"),
                SeparatorColor = Color.FromHex("#7F8C8D")
            };

            // Установка шаблона для элементов ListView
            listView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Name");
                textCell.TextColor = Color.White;
                // У TextCell нет свойства BackgroundColor, поэтому убираем эту строку
                return textCell;
            });

            // Формирование flyout page с помощью элемента управления ListView.
            Flyout = new ContentPage
            {
                Title = "Color List",
                BackgroundColor = Color.FromHex("#2C3E50"),
                Content = new StackLayout
                {
                    BackgroundColor = Color.FromHex("#2C3E50"),
                    Children = {
                        authorsLabel,
                        header,
                        listView
                    }
                }
            };

            // Создание detail page с использованием класса NamedColorPage
            NamedColorPage detailPage = new NamedColorPage();
            Detail = detailPage;

            // Define a selected handler for the ListView.
            listView.ItemSelected += (sender, args) => {
                // Set the BindingContext of the detail page.
                Detail.BindingContext = args.SelectedItem;
                // Hide the flyout page
                IsPresented = false;
            };

            // Initialize the ListView selection.
            listView.SelectedItem = namedColors[5];
            FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
        }
    }
}

