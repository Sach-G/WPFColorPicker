using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;

namespace WPFColorList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<SystemColor> Colors { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            InitColors();
        }

        public void InitColors()
        {
            Colors = new List<SystemColor>();
            var colors = Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor knowColor in colors)
            {
                Color color = Color.FromKnownColor(knowColor);
                if (!color.IsSystemColor)
                    Colors.Add(new SystemColor(color));
            }
            Colors.Sort((x, y) => x.HexA.CompareTo(y.HexA));
        }

        private void MenuItem_Click_Name(object sender, RoutedEventArgs e)
        {
            var selected = (SystemColor)DgvColors.SelectedValue;
            Clipboard.SetText(selected.ColorName);
        }

        private void MenuItem_Click_Hex(object sender, RoutedEventArgs e)
        {
            var selected = (SystemColor)DgvColors.SelectedValue;
            Clipboard.SetText(selected.Hex);
        }

        private void MenuItem_Click_RGB(object sender, RoutedEventArgs e)
        {
            var selected = (SystemColor)DgvColors.SelectedValue;
            Clipboard.SetText(selected.RGB);
        }

        private void MenuItem_Click_Details(object sender, RoutedEventArgs e)
        {
            var selected = (SystemColor)DgvColors.SelectedValue;
            Clipboard.SetText(string.Format("{0} - ({1}) ({2})", selected.ColorName, selected.Hex, selected.RGB));
        }
    }
}