using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuThink.Desktop.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Page
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void ChooselanguageButton_Loaded(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;

            if (AuThink.Desktop.Properties.Settings.Default.Language == "Hr" && radioButton.Name == "ChooseCroatianButton")
            {
                radioButton.IsChecked = true;
            }
            else if (AuThink.Desktop.Properties.Settings.Default.Language == "En" && radioButton.Name == "ChooseEnglishButton")
            {
                radioButton.IsChecked = true;
            }
        }
    }
}
