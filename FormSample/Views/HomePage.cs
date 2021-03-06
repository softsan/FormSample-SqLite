﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs;

namespace FormSample.Views
{
    using FormSample.Helpers;

    using Xamarin.Forms;
    using Xamarin.Forms.Labs.Controls;
    

    public class HomePage : ContentPage
    {
        private INetworkService _network { get; set; }
        int count = 1;

        private bool IsNetworkAvailable()
        {
            var x = DependencyService.Get<INetworkService>().IsReachable();
            return x;
        }

        private async Task GoToLoginPage()
        {
            if (string.IsNullOrWhiteSpace(Settings.GeneralSettings))
            {
                var page = new LoginPage();
                await Navigation.PushModalAsync(page);
            }
        }

        public HomePage()
        {
            // var t = this.IsNetworkAvailable();
            this.GoToLoginPage();

            
            Title = "Home";
            this.BackgroundColor = Color.White;
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(0,0,0,0)
            };

            var grid = new Grid
            {
                RowSpacing = 10,
                    ColumnSpacing=10
            };
            double width = 175;
            double height = 150;

            Image imgReferContractor = new Image(){
                WidthRequest = width,
                HeightRequest=height,
                Aspect = Aspect.AspectFill
            };
            imgReferContractor.Source = ImageSource.FromFile("homeheader.jpg");
            Button referContractorButton = new Button()
                {
                    Text = "Refer a contractor",
                    TextColor = Color.Black,
                    BackgroundColor =  new Color(255,255,255,0.5),// Color.Transparent,
                    VerticalOptions = LayoutOptions.End
                };
          
            Image imgMyContractor = new Image(){
                Aspect = Aspect.AspectFill,
                WidthRequest = width,
                HeightRequest=height
            };
            imgMyContractor.Source = ImageSource.FromFile("MyContractors.jpg");
            Button  myContractorButton = new Button()
                {
                    Text = "My contractors",
                    TextColor = Color.Black,
                    BackgroundColor =  new Color(255,255,255,0.5),// Color.Transparent,
                    VerticalOptions = LayoutOptions.End
                };

            Image imgAboutUs = new Image(){
                WidthRequest = width,
                HeightRequest=height,
                Aspect = Aspect.AspectFill
            };
            imgAboutUs.Source = ImageSource.FromFile("aboutus.jpg");
            Button  aboutUsButton = new Button()
                {
                    Text = "About us",
                    TextColor = Color.Black,
                    BackgroundColor =  new Color(255,255,255,0.5),// Color.Transparent,
                    VerticalOptions = LayoutOptions.End
                };

            Image imgAmendDetail = new Image(){
                WidthRequest = width,
                HeightRequest=height,
                Aspect = Aspect.AspectFill
            };
            imgAmendDetail.Source = ImageSource.FromFile("AmendDetail.jpg");
            Button  amendDetailButton = new Button()
                {
                    Text = "Amend details",
                    TextColor = Color.Black,
                    BackgroundColor =  new Color(255,255,255,0.5),// Color.Transparent,
                    VerticalOptions = LayoutOptions.End
                };

            Image imgPayChart = new Image(){
                WidthRequest = width,
                HeightRequest=height,
                Aspect = Aspect.AspectFill
            };
            imgPayChart.Source = ImageSource.FromFile("PayCalculator.jpg");
            Button  payChartButton = new Button()
                {
                    Text = "Pay chart",
                    TextColor = Color.Black,
                    BackgroundColor =  new Color(255,255,255,0.5),// Color.Transparent,
                    VerticalOptions = LayoutOptions.End
                };

            Image imgPayCalc = new Image(){
                WidthRequest = width,
                HeightRequest=height,
                Aspect = Aspect.AspectFill
            };
            imgPayCalc.Source = ImageSource.FromFile("PayChart.jpg");
            Button  payCalcButton = new Button()
                {
                    Text = "Pay calculator",
                    TextColor = Color.Black,
                    BackgroundColor =  new Color(255,255,255,0.5),// Color.Transparent,
                    VerticalOptions = LayoutOptions.End
                };


            grid.Children.Add(imgReferContractor, 0, 0); // Left, First element
            grid.Children.Add(referContractorButton, 0, 0);
            grid.Children.Add(imgMyContractor, 1, 0); // Right, First element  new Label { Text = "My Contractors" }
            grid.Children.Add(myContractorButton, 1, 0);
            grid.Children.Add(imgAboutUs , 0, 1); // Left, Second element new Label { Text = "About us" }
            grid.Children.Add(aboutUsButton, 0, 1);
            grid.Children.Add(imgAmendDetail, 1, 1); // Right, Second element new Label { Text = "Amend detail" }
            grid.Children.Add(amendDetailButton, 1, 1);
            grid.Children.Add(imgPayChart, 0, 2); // Left, Thrid element
            grid.Children.Add(payChartButton, 0, 2);
            grid.Children.Add(imgPayCalc, 1, 2); // Right, Thrid element
            grid.Children.Add(payCalcButton, 1, 2);


            var tapGestureRecognizer = new TapGestureRecognizer ();
            tapGestureRecognizer.Tapped += (sender, e) =>
            {
                App.RootPage.NavigateTo("Refer a contractor");
            };

            imgReferContractor.GestureRecognizers.Add(tapGestureRecognizer);


            var myContractorGestureRecognizer = new TapGestureRecognizer ();
            myContractorGestureRecognizer.Tapped += (sender, e) => DisplayAlert("Message","Image clicked","OK");
            imgMyContractor.GestureRecognizers.Add(myContractorGestureRecognizer);

            var downloadButton = new Button { Text = "Download terms and condition" };
             
            downloadButton.Clicked += delegate
            {
                    downloadButton.Text = string.Format("Thanks! {0} clicks.", count++);
            };

            var contactUsButton = new Button { Text = "Contact us" };

            contactUsButton.Clicked += delegate
                {
                    contactUsButton.Text = string.Format("Thanks! {0} clicks.", count++);
                };

           
            ////grid.Children.Add(gridButton, 0, 3); // Left, Third element
            ////grid.Children.Add(new Label { Text = " " }, 1, 3);

            // layout.Children.Add(gridButton);
            // layout.Children.Add(grid);

            layout.Children.Add (new ScrollView{VerticalOptions = LayoutOptions.FillAndExpand,HorizontalOptions= LayoutOptions.Fill, Content = grid });
            layout.Children.Add (downloadButton);
            layout.Children.Add(contactUsButton);
            Content = layout;
        }
    }
}
