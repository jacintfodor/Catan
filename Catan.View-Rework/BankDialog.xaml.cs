using Catan.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Catan.View_Rework
{
    /// <summary>
    /// Interaction logic for BankDialog.xaml
    /// </summary>
    public partial class BankDialog : Window
    {

        Dictionary<ResourceEnum, Button> _resourceButtons = new ();

        public BankDialog(ResourceEnum resource)
        {
            InitializeComponent();
            _resourceButtons.Add(ResourceEnum.Crop,     CropButton);
            _resourceButtons.Add(ResourceEnum.Ore,      OreButton);
            _resourceButtons.Add(ResourceEnum.Wood,     WoodButton);
            _resourceButtons.Add(ResourceEnum.Brick,    BrickButton);
            _resourceButtons.Add(ResourceEnum.Wool,     WoolButton);

            if (_resourceButtons.ContainsKey(resource))
            {
                _resourceButtons[resource].IsEnabled = false;
            }
        }

        public ResourceEnum Result { get; set; } = ResourceEnum.Desert;

        private void Crop_Click(object sender, RoutedEventArgs e)
        {
            Result = ResourceEnum.Crop;
            Close();
        }

        private void Ore_Click(object sender, RoutedEventArgs e)
        {
            Result = ResourceEnum.Ore;
            Close();
        }

        private void Wood_Click(object sender, RoutedEventArgs e)
        {
            Result = ResourceEnum.Wood;
            Close();
        }

        private void Brick_Click(object sender, RoutedEventArgs e)
        {
            Result = ResourceEnum.Brick;
            Close();
        }

        private void Wool_Click(object sender, RoutedEventArgs e)
        {
            Result = ResourceEnum.Wool;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Result = ResourceEnum.Desert;
            Close();
        }
    }
}
