using System.Windows;
using System.Windows.Controls;

namespace AuThink.Desktop.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
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
