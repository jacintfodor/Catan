using Catan.Model.Board;
using Catan.Model.Context.Players;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Catan.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int[,] arr = new int[,] {   { 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0},//0
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//1
                                    { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},//2
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//3
                                    { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},//4
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//5
                                    { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},//6
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//7
                                    { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},//8
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//9
                                    { 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0},//10
                                   };
        int[,] arrVerex = new int[,] {  { 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0},//0
                                        { 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0},//1
                                        { 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0},//2
                                        { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0},//3
                                        { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0},//4
                                        { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1},//5
                                        { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1},//6
                                        { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0},//7
                                        { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0},//8
                                        { 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0},//9
                                        { 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0},//10
                                        { 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0},//11
                                        };
        /** /
        public static String ToXaml(String name = "", String shape = "M86.6025 0 L173.2050 50 173.2050 150 86.6025  200 0 150 0 50z")
        {
            return  "<ControlTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">" +
                    "<Button Content =\"" + name + "\">" +
                    "<Button.Template> " +
                    "<ControlTemplate TargetType=\"{x:Type Button}\"> " +
                    "<Grid Width=\"Auto\" Height=\"Auto\" x:Name=\"Grid\"> " +
                    "<Path Stroke=\"{TemplateBinding BorderBrush}\" Fill=\"{TemplateBinding Background}\" HorizontalAlignment=\"Stretch\" VerticalAlignment=\"Stretch\" Margin=\"0,0,0,0\" Width=\"Auto\" Height=\"Auto\" x:Name=\"Path\" RenderTransformOrigin=\"0.5,0.5\" Stretch=\"Fill\" " +
                    "Data = \"" + shape + "\"/> " +
                    "<TextBlock VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\" Margin=\"0\" x:Name=\"TextBlock\" Text=\"{TemplateBinding Content}\" TextWrapping=\"Wrap\" FontSize=\"{TemplateBinding FontSize}\" FontFamily=\"{TemplateBinding FontFamily}\" FontStyle=\"{TemplateBinding FontStyle}\" FontWeight=\"{TemplateBinding FontWeight}\" FontStretch=\"{TemplateBinding FontStretch}\" Foreground=\"{TemplateBinding Foreground}\"/> " +
                    "</Grid> " +
                    "<ControlTemplate.Triggers> " +
                    "<Trigger Property=\"IsMouseOver\" Value=\"True\"> " +
                    "<Setter Property=\"Background\" Value=\"red\"/> " +
                    "</Trigger> " +
                    "</ControlTemplate.Triggers> " +
                    "</ControlTemplate> " +
                    "</Button.Template> " +
                    "</Button> " +
                    "</ControlTemplate>";
        }
        /**/
        /** /
Background="ForestGreen"
Background="Moccasin"
Background="SlateGray"
Background="Goldenrod"
Background="Firebrick"

        <!-- Background="Orchid" -->
                <!-- Background="DarkOrchid" -->
                <!-- Background="" -->
                <!-- Background="Yellow" -->
                <!-- Background="Orange" -->
                <!-- Background="DodgerBlue" -->
                <!-- Background="DarkBlue" -->
        /**/

        //                 | játékosszínek                                           |     fa    |   gyapjú  |         |    kő   |  gabona  |   tégla |                                         
        public enum Color2 { ORCHID, DARKORCHID, YELLOW, ORANGE, DODGERBLUE, DARKBLUE, FORESTGREEN, PALEGREEN, MOCCASIN, SLATEGRAY, GOLDENROD, FIREBRICK }

        public enum Field { WOOD = 0, WHOOL = 1, ROCK = 2, GRAIN = 3, BRICK = 4 }
        //Forestgreen, Palegreen, Moccasin, Slategray, Goldenrod, Firebrick

        public String FieldTo(Field field)
        {
            String s = "";
            switch (field)
            {
                case Field.WOOD:
                    s = "Forestgreen";
                    break;

                case Field.WHOOL:
                    s = "Palegreen";
                    break;

                case Field.ROCK:
                    s = "Slategray";
                    break;

                case Field.GRAIN:
                    s = "Goldenrod";
                    break;

                case Field.BRICK:
                    s = "Firebrick";
                    break;

                default:
                    break;
            }
            return s;
        }
        public enum Player { P1, P2, P3, PP1, PP2, PP3 }

        public enum Shape { Hexagon, Left, Right, Vertex, Vertical }
        public String ShapeTo(Shape shape)
        {
            String s = "";
            switch (shape)
            {
                case Shape.Hexagon:
                    s = "M86.6025 0 L173.2050 50 173.2050 150 86.6025  200 0 150 0 50z";
                    break;

                case Shape.Left:
                    s = "M0.866025 0 L0.966025 0.173205  0.1 0.673205  0 0.49993z";
                    break;

                case Shape.Right:
                    s = "M0.1 0  L0.966025 0.49993  0.866025 0.673205  0 0.173205z";
                    break;

                case Shape.Vertex:
                    s = "M0.1 0  L0.966025 0.49993  0.866025 0.673205  0 0.173205z";
                    break;

                case Shape.Vertical:
                    s = "M0 0 M0 2 M0 0.5  L0.2 0.5 0.2 1.5 0 1.5z";
                    break;

                default:
                    break;
            }
            return s;
        }
        // hatszög      szám Field
        // út           Player
        // csúcs        Player
        /** /
        public String SetColor(Color color) {
            String c = "";
            switch (color)
            {
                case Color.ORCHID:
                    c = "Orchid";
                    break;

                case Color.DARKORCHID:
                    c = "Darkorchid";
                    break;

                case Color.YELLOW:
                    c = "Yellow";
                    break;

                case Color.ORANGE:
                    c = "Orange";
                    break;

                case Color.DODGERBLUE:
                    c = "Dodgerblue";
                    break;

                case Color.DARKBLUE:
                    c = "Darkblue";
                    break;

                case Color.FORESTGREEN:
                    c = "Forestgreen";
                    break;

                case Color.PALEGREEN:
                    c = "Palegreen";
                    break;

                case Color.MOCCASIN:
                    c = "Moccasin";
                    break;

                case Color.SLATEGRAY:
                    c = "Slategray";
                    break;

                case Color.GOLDENROD:
                    c = "Goldenrod";
                    break;

                case Color.FIREBRICK:
                    c = "Firebrick";
                    break;

                default: break;
            }
            return c;
        }
        /**/
        public String Valami()
        {
            return "";
        }
        public ControlTemplate MakeTemplate(String name = "", Shape shape = Shape.Hexagon, String color1 = "Moccasin", String color2 = "Linen")
        {
            string xaml = "";
            if (shape == Shape.Vertex)
            {
                xaml = "<ControlTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">" +
                            "<Button Content =\"" + name + "\"  BorderBrush=\"gray\"  >" +
                            "<Button.Template>" +
                            "<ControlTemplate TargetType=\"{x:Type Button}\"> " +
                            "<Grid>" +
                            "<Ellipse Fill=\"{TemplateBinding Background}\" Stroke=\"{TemplateBinding BorderBrush}\" >  " +
                            "</Ellipse>" +
                            "<ContentPresenter HorizontalAlignment=\"Center\" VerticalAlignment=\"Center\">" +
                            "</ContentPresenter>" +
                            "</Grid>" +
                            "<ControlTemplate.Triggers>" +
                            "<Trigger Property=\"IsMouseOver\" Value=\"True\">" +
                            "<Setter Property=\"Background\" Value=\"" + color2 + "\" />" +
                            "</Trigger>" +
                            "<Trigger Property=\"IsMouseOver\" Value=\"False\">" +
                            "<Setter Property=\"Background\" Value=\"" + color1 + "\" />" +
                            "</Trigger>" +
                            "</ControlTemplate.Triggers>" +
                            "</ControlTemplate>" +
                            "</Button.Template>" +
                            "</Button>" +
                           "</ControlTemplate>";
                return System.Windows.Markup.XamlReader.Parse(xaml) as ControlTemplate;
            }
            xaml = "<ControlTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">" +
                            "<Button Content =\"" + name + "\">" +
                            "<Button.Template> " +
                            "<ControlTemplate TargetType=\"{x:Type Button}\"> " +
                            "<Grid Width=\"Auto\" Height=\"Auto\" x:Name=\"Grid\"> " +
                            "<Path Stroke=\"{TemplateBinding BorderBrush}\" Fill=\"{TemplateBinding Background}\" HorizontalAlignment=\"Stretch\" VerticalAlignment=\"Stretch\" Margin=\"0,0,0,0\" Width=\"Auto\" Height=\"Auto\" x:Name=\"Path\" RenderTransformOrigin=\"0.5,0.5\" Stretch=\"Fill\" " +
                            "Data = \"" + ShapeTo(shape) + "\"/> " +
                            "<TextBlock VerticalAlignment=\"Center\" HorizontalAlignment=\"Center\" Margin=\"0\" x:Name=\"TextBlock\" Text=\"{TemplateBinding Content}\" TextWrapping=\"Wrap\" FontSize=\"{TemplateBinding FontSize}\" FontFamily=\"{TemplateBinding FontFamily}\" FontStyle=\"{TemplateBinding FontStyle}\" FontWeight=\"{TemplateBinding FontWeight}\" FontStretch=\"{TemplateBinding FontStretch}\" Foreground=\"{TemplateBinding Foreground}\"/> " +
                            "</Grid> " +
                            "<ControlTemplate.Triggers> " +
                            "<Trigger Property=\"IsMouseOver\" Value=\"True\">" +
                            "<Setter Property=\"Background\" Value=\"" + color2 + "\" />" +
                            "</Trigger>" +
                            "<Trigger Property=\"IsMouseOver\" Value=\"False\">" +
                            "<Setter Property=\"Background\" Value=\"" + color1 + "\" />" +
                            "</Trigger>" +
                            "</ControlTemplate.Triggers> " +
                            "</ControlTemplate> " +
                            "</Button.Template> " +
                            "</Button> " +
                            "</ControlTemplate>";
            return System.Windows.Markup.XamlReader.Parse(xaml) as ControlTemplate;
        }
        /** /
        public ControlTemplate MakeCircleTemplate(String name = "", String color1 = "lightblue", String color2 = "Linen") {
            string xaml =   "<ControlTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">" +
                            "<Button Content =\"" + name + "\">" +
                            "<Button.Template>" +
                            "<ControlTemplate TargetType=\"Button\"> " +
                            "<Grid>" +
                            "<Ellipse Fill=\"{TemplateBinding Background}\">" +
                            "</Ellipse>" +
                            "<ContentPresenter HorizontalAlignment=\"Center\" VerticalAlignment=\"Center\">" +
                            "</ContentPresenter>" +
                            "</Grid>" +
                            "<ControlTemplate.Triggers>" +
                            "<Trigger Property=\"IsMouseOver\" Value=\"True\">" +
                            "<Setter Property=\"Background\" Value=\"" + color2 + "\" />" +
                            "</Trigger>" +
                            "<Trigger Property=\"IsMouseOver\" Value=\"False\">" +
                            "<Setter Property=\"Background\" Value=\"" + color1 + "\" />" +
                            "</Trigger>" +
                            "</ControlTemplate.Triggers>" +
                            "</ControlTemplate>" +
                            "</Button.Template>" +
                            "</Button>" +
                           "</ControlTemplate>";
            return System.Windows.Markup.XamlReader.Parse(xaml) as ControlTemplate;
        }
        /**/
        public MainWindow()
        {
            InitializeComponent();
            Button b;
            int count = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            String name = "";
            Random rnd = new Random();
            //int rand = rnd.Next(0, 5);
            Field a = (Field)rnd.Next(0, 5);
            for (int j = 0; j <= 4; j++)
            {
                for (int i = 0; i <= 8; i++)
                {
                    b = new Button();
                    b.FontSize = 18;
                    name = "" + rnd.Next(0, 13);
                    b.Template = MakeTemplate(name, Shape.Hexagon, FieldTo((Field)rnd.Next(0, 5)));
                    Grid.SetRow(b, j + 1);
                    Grid.SetColumn(b, i + 1);
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        if (!((j == 0 || j == 4) && (i == 0 || i == 8))) // hogy a 4 sarokban ne legyen
                        {
                            Hex353.Children.Add(b); // 3/5/3 hex
                            count++;
                        }
                    }
                    else if (i % 2 == 1 && j % 2 == 1)
                    {
                        Hex44.Children.Add(b); // 4/4 hex
                        count++;
                    }
                    else if (j % 2 == 0) //353 |||
                    {
                        b = new Button();
                        name = "";// + count2;
                        b.Template = MakeTemplate(name, Shape.Vertical);
                        Grid.SetRow(b, j + 1);
                        Grid.SetColumn(b, i + 1);
                        Hex353.Children.Add(b);
                        count2++;
                    }
                    else if (i % 2 == 0) //44 |||
                    {
                        b = new Button();
                        name = "";// + count2;
                        b.Template = MakeTemplate(name, Shape.Vertical);
                        Grid.SetRow(b, j + 1);
                        Grid.SetColumn(b, i + 1);
                        Hex44.Children.Add(b);
                        count2++;
                    }
                }
            }
            name = "";
            // 353 || 0. és 10.
            b = new Button();
            b.Template = MakeTemplate(name, Shape.Vertical);
            Grid.SetRow(b, 3);
            Grid.SetColumn(b, 0);
            Hex353.Children.Add(b);
            b = new Button();
            b.Template = MakeTemplate(name, Shape.Vertical);
            Grid.SetRow(b, 3);
            Grid.SetColumn(b, 10);
            Hex353.Children.Add(b);
            //
            for (int j = 0; j <= 10; j += 2)
            {
                for (int i = 1; i < 11; i++)
                {
                    b = new Button();
                    //name = "" + count3;//"" + j + " " + i;
                    if ((i % 2 == 1 && j % 4 == 0) || (i % 2 == 0 && j % 4 == 2))
                    {
                        b.Template = MakeTemplate(name, Shape.Left);
                        Grid.SetRow(b, j + 1);
                        Grid.SetColumn(b, i);
                        if (arr[j, i] == 1)
                        {
                            Edge.Children.Add(b);
                            count3++;
                        }
                    }
                    else if ((i % 2 == 0 && j % 4 == 0) || (i % 2 == 1 && j % 4 == 2))
                    {
                        b.Template = MakeTemplate(name, Shape.Right);
                        Grid.SetRow(b, j + 1);
                        Grid.SetColumn(b, i);
                        if (arr[j, i] == 1)
                        {
                            Edge.Children.Add(b);
                            count3++;
                        }
                    }
                }
            }
            for (int i = 0; i <= 20; i += 2)
            {
                for (int j = 0; j <= 22; j += 2)
                {
                    b = new Button();
                    b.FontSize = 8;
                    //name = "" + count4;
                    Grid.SetRow(b, j);
                    Grid.SetColumn(b, i);
                    b.Template = MakeTemplate(name, Shape.Vertex);//MakeCircleTemplate("" + count4);
                    if (arrVerex[j / 2, i / 2] == 1)
                    {
                        Vertex.Children.Add(b);
                        count4++;
                    }

                }
            }
            b = new Button();
            b.Height = 50;
            b.Width = 100;
            b.Content = "Név2";
            b.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(b, 0);
            Grid.SetColumn(b, 0);
            MainGrid.Children.Add(b);

            b = new Button();
            b.Height = 50;
            b.Width = 100;
            b.Content = "Név3";
            b.HorizontalAlignment = HorizontalAlignment.Right;
            //b.Background = Brushes.Orchid;
            //b.BackColor = Color.LightBlue;
            //b.Background = Background.;  
            Grid.SetRow(b, 0);
            Grid.SetColumn(b, 0);
            MainGrid.Children.Add(b);

            b = new Button();
            b.Height = 50;
            b.Width = 100;
            b.Content = "Aktuális Játékos";
            b.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(b, 3);
            Grid.SetColumn(b, 0);
            MainGrid.Children.Add(b);


        }
    }
}
