using SINNO_FOOTBALL.ViewModels;
using Microsoft.Maui.Layouts;

namespace SINNO_FOOTBALL.Views;

public partial class CardPage : ContentPage
{
    [Obsolete]
    public CardPage()
    {
        InitializeComponent();

        var number = 7;
        var position = "LW";
        var statsDict = new Dictionary<string, int>()
        {
            {"Pac", 100 },
            {"Sho", 100 },
            {"Pas", 100 },
            {"Dri", 100 },
            {"Def", 100 },
            {"Phy", 100 },
            {"GKH", 100 }
        };
        statsDict.Remove(position == "GK" ? "Sho" : "GKH");

        var vieModel = new CardPageViewModel();
        BindingContext = vieModel;

        var gridLayout = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition()
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) },
            }
        };

        // Draw card background
        var stackLayout = new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Margin = new Thickness { Left = 20, Right = 20 }
        };

        var img = new Image
        {
            Source = "card_bg.png"
        };

        var tappedGestureRecognizer = new TapGestureRecognizer()
        {
            Command = vieModel.GoToDetailCommand
        };

        img.GestureRecognizers.Add(tappedGestureRecognizer);

        gridLayout.SetRowSpan(img, 3);
        gridLayout.SetColumnSpan(img, 2);
        gridLayout.Children.Add(img);

        // Draw avatar
        var avatar = new Image
        {
            Source = "khai_nd.png"
        };

        gridLayout.SetRow(avatar, 0);
        gridLayout.SetRowSpan(avatar, 2);
        gridLayout.SetColumn(avatar, 1);
        gridLayout.Children.Add(avatar);

        // Add number, position
        var numpoContainer = new FlexLayout
        {
            Direction = FlexDirection.ColumnReverse
        };

        var numpoInnerContainer = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Spacing = 10,
        };

        var numLabel = new Label
        {
            Text = number.ToString(),
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            HorizontalTextAlignment = TextAlignment.Center
        };
        var posLabel = new Label
        {
            Text = position,
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            HorizontalTextAlignment = TextAlignment.Center
        };
        var image = new Image
        {
            Source = "flag_of_vietnam.svg",
            WidthRequest = 50,
            BackgroundColor = Colors.White
        };

        numpoInnerContainer.Children.Add(numLabel);
        numpoInnerContainer.Children.Add(posLabel);
        numpoInnerContainer.Children.Add(image);
        numpoContainer.Children.Add(numpoInnerContainer);
        gridLayout.SetColumn(numpoContainer, 0);
        gridLayout.SetRow(numpoContainer, 0);
        gridLayout.Children.Add(numpoContainer);

        // Init bottom grid
        var bottomGrid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition()
            }            
        };

        // Add name label to bottom
        var nameLabel = new Label
        {
            Text = "Nguyễn Duy Khai",
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 20,
            FontAttributes = FontAttributes.Bold
        };
        bottomGrid.SetRow(nameLabel, 0);
        bottomGrid.Children.Add(nameLabel);

        // Add stats label to bottom
        var statsContainer = new FlexLayout
        {
            Direction = FlexDirection.Row,
            JustifyContent = FlexJustify.SpaceAround,
            Margin = new Thickness { Left = 20, Right = 20 },
        };

        foreach (var item in statsDict)
        {
            var statLabel = new Label
            {
                Text = $"{item.Key}\n{item.Value}",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center
            };

            statsContainer.Children.Add(statLabel);
        }

        bottomGrid.SetRow(statsContainer, 1);
        bottomGrid.Children.Add(statsContainer);

        gridLayout.SetRow(bottomGrid, 2);
        gridLayout.SetColumnSpan(bottomGrid, 2);
        gridLayout.Children.Add(bottomGrid);

        stackLayout.Children.Add(gridLayout);

        Content = stackLayout;
    }
}