using BingMapLesson.Models;
using BingMapLesson.ViewModels.PageViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BingMapLesson.Views.Pages;


public partial class MapPageView : Page, INotifyPropertyChanged
{
    private ObservableCollection<AvtoBus> buses;
    public ObservableCollection<AvtoBus> Buses { get => buses; set { buses = value; OnPropertyChanged(); } }

    public MapPageView()
    {
        InitializeComponent();
        DataContext = new MapPageViewModel();
        List<string> Numbers = new List<string>();

        foreach (var item in AllBuses.Buses)
        {

            var pin = new Pushpin();
            
            ControlTemplate customPushpinTemplate = new ControlTemplate(typeof(Pushpin));

            
            FrameworkElementFactory gridFactory = new FrameworkElementFactory(typeof(Grid));

           
            FrameworkElementFactory ellipseFactory = new FrameworkElementFactory(typeof(Ellipse));
            ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Blue);
            ellipseFactory.SetValue(Ellipse.WidthProperty, 20.0);
            ellipseFactory.SetValue(Ellipse.HeightProperty, 20.0);

            
            FrameworkElementFactory labelFactory = new FrameworkElementFactory(typeof(Label));
            labelFactory.SetValue(Label.ContentProperty, item.attributes.DISPLAY_ROUTE_CODE);
            labelFactory.SetValue(Label.HorizontalContentAlignmentProperty, HorizontalAlignment.Center);
            labelFactory.SetValue(Label.VerticalContentAlignmentProperty, VerticalAlignment.Center);
            labelFactory.SetValue(Label.ForegroundProperty, Brushes.Black);

            
            gridFactory.AppendChild(ellipseFactory);
            gridFactory.AppendChild(labelFactory);

            
            customPushpinTemplate.VisualTree = gridFactory;

            pin.Location = new Location(Convert.ToDouble(item.attributes.LATITUDE), Convert.ToDouble(item.attributes.LONGITUDE));
            var text = new Label() { };
            text.Content = item.attributes.DISPLAY_ROUTE_CODE;
            pin.Content = text;
            pin.FontSize = 8;
          
            pin.ToolTip = item.attributes.ROUTE_NAME;



            if (text.Content.ToString() == "7A")
            {
                
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Red);
            }

            else if (text.Content.ToString() == "7B")
            {
                
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Green);
            }

            else if (text.Content.ToString() == "14")
            {
                
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Yellow);

            }
            else if (text.Content.ToString() == "2")
            {
               
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Orange);
            }

            else if (text.Content.ToString() == "205")
            {
                
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Blue);
            }

            else if (text.Content.ToString() == "3")
            {
                
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Gray);
            }

            else if (text.Content.ToString() == "17")
            {
               
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DimGray);
            }

            else if (text.Content.ToString() == "88")
            {
                
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkKhaki);
            }

            else if (text.Content.ToString() == "6")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkGoldenrod);
            }

            else if (text.Content.ToString() == "1")
            {
                
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkMagenta);
            }

            else if (text.Content.ToString() == "88A")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkSalmon);
            }

            else if (text.Content.ToString() == "125")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkGreen);
            }

            else if (text.Content.ToString() == "13")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Coral);
            }

            else if (text.Content.ToString() == "M8")
            {
                
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkBlue);
            }

            else if (text.Content.ToString() == "211")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Linen);
            }

            else if (text.Content.ToString() == "127")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Lime);
            }

            else if (text.Content.ToString() == "Q1")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.LimeGreen);
            }

            else if (text.Content.ToString() == "35")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.SteelBlue);
            }

            else if (text.Content.ToString() == "32")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Pink);
            }

            else if (text.Content.ToString() == "21")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkViolet);
            }


            else if (text.Content.ToString() == "30")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkTurquoise);
            }

            else if (text.Content.ToString() == "24")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkOrchid);
            }

            else if (text.Content.ToString() == "11")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Orchid);
            }


            else if (text.Content.ToString() == "175")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.MediumOrchid);
            }

            else if (text.Content.ToString() == "10")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.CornflowerBlue);
            }

            else if (text.Content.ToString() == "5")
            {
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Cornsilk);
            }
            pin.Template = customPushpinTemplate;
            map.Children.Add(pin);

            int d = 0;
            foreach (var num in Numbers)
            {
                if (num == text.Content.ToString())
                {
                    d++;
                }
            }

            if (d == 0)
            {
                Numbers.Add(text.Content.ToString());
            }


        }

        foreach (var num in Numbers)
        {
            choiceCombo.Items.Add(num.ToString());
        }

    }

    private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        choiceCombo.SelectedIndex = 0;

        var builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json");

        var data = builder.Build();
        var key = data.GetSection("MapKeys")["Key_1"];

        map.CredentialsProvider = new ApplicationIdCredentialsProvider(key);

    }
    private void showBus(object sender, SelectionChangedEventArgs e)
    {
        var folder = new DirectoryInfo("../../../DataBase");
        var fullPath = folder + "/bakubusApi.json";
        var jsonText = File.ReadAllText(fullPath);
        var buses = JsonSerializer.Deserialize<BakuBus>(jsonText);
        Buses = new ObservableCollection<AvtoBus>(buses!.BUS);



        int r = new Random().Next(0, 256);
        int g = new Random().Next(0, 256);
        int b = new Random().Next(0, 256);

        Map map2 = new Map();
        map2.Name = "map";
        map2.Width = 670;
        map2.HorizontalAlignment = HorizontalAlignment.Right;
        map2.ZoomLevel = 12;
        map2.Center = new Location(40.41510077752684, 49.85309228999294);
        map2.Mode = new AerialMode(true);

        map.Children.Clear();
        foreach (var item in Buses)
        {
            if (item.attributes.DISPLAY_ROUTE_CODE.ToString() == choiceCombo.SelectedItem.ToString())
            {
                var pin = new Pushpin();

                ControlTemplate customPushpinTemplate = new ControlTemplate(typeof(Pushpin));


                FrameworkElementFactory gridFactory = new FrameworkElementFactory(typeof(Grid));


                FrameworkElementFactory ellipseFactory = new FrameworkElementFactory(typeof(Ellipse));
                ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Blue);
                ellipseFactory.SetValue(Ellipse.WidthProperty, 20.0);
                ellipseFactory.SetValue(Ellipse.HeightProperty, 20.0);


                FrameworkElementFactory labelFactory = new FrameworkElementFactory(typeof(Label));
                labelFactory.SetValue(Label.ContentProperty, item.attributes.DISPLAY_ROUTE_CODE);
                labelFactory.SetValue(Label.HorizontalContentAlignmentProperty, HorizontalAlignment.Center);
                labelFactory.SetValue(Label.VerticalContentAlignmentProperty, VerticalAlignment.Center);
                labelFactory.SetValue(Label.ForegroundProperty, Brushes.Black);


                gridFactory.AppendChild(ellipseFactory);
                gridFactory.AppendChild(labelFactory);


                customPushpinTemplate.VisualTree = gridFactory;

                pin.Location = new Location(Convert.ToDouble(item.attributes.LATITUDE), Convert.ToDouble(item.attributes.LONGITUDE));
                var text = new Label() { };
                text.Content = item.attributes.DISPLAY_ROUTE_CODE;
                pin.Content = text;
                pin.FontSize = 8;

                pin.ToolTip = item.attributes.ROUTE_NAME;



                if (text.Content.ToString() == "7A")
                {

                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Red);
                }

                else if (text.Content.ToString() == "7B")
                {

                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Green);
                }

                else if (text.Content.ToString() == "14")
                {

                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Yellow);

                }
                else if (text.Content.ToString() == "2")
                {

                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Orange);
                }

                else if (text.Content.ToString() == "205")
                {

                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Blue);
                }

                else if (text.Content.ToString() == "3")
                {

                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Gray);
                }

                else if (text.Content.ToString() == "17")
                {

                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DimGray);
                }

                else if (text.Content.ToString() == "88")
                {

                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkKhaki);
                }

                else if (text.Content.ToString() == "6")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkGoldenrod);
                }

                else if (text.Content.ToString() == "1")
                {

                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkMagenta);
                }

                else if (text.Content.ToString() == "88A")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkSalmon);
                }

                else if (text.Content.ToString() == "125")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkGreen);
                }

                else if (text.Content.ToString() == "13")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Coral);
                }

                else if (text.Content.ToString() == "M8")
                {

                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkBlue);
                }

                else if (text.Content.ToString() == "211")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Linen);
                }

                else if (text.Content.ToString() == "127")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Lime);
                }

                else if (text.Content.ToString() == "Q1")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.LimeGreen);
                }

                else if (text.Content.ToString() == "35")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.SteelBlue);
                }

                else if (text.Content.ToString() == "32")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Pink);
                }

                else if (text.Content.ToString() == "21")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkViolet);
                }


                else if (text.Content.ToString() == "30")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkTurquoise);
                }

                else if (text.Content.ToString() == "24")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.DarkOrchid);
                }

                else if (text.Content.ToString() == "11")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Orchid);
                }


                else if (text.Content.ToString() == "175")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.MediumOrchid);
                }

                else if (text.Content.ToString() == "10")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.CornflowerBlue);
                }

                else if (text.Content.ToString() == "5")
                {
                    ellipseFactory.SetValue(Ellipse.FillProperty, Brushes.Cornsilk);
                }
                pin.Template = customPushpinTemplate;
                map.Children.Add(pin);

            }
        }
    }


    //-------------------------------------------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}