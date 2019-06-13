using DNDCharacterCreator.DataModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DNDCharacterCreator
{
    /// <summary>
    /// Interaction logic for BackgroundAndAlignment.xaml
    /// </summary>
    public partial class BackgroundAndAlignment : Page
    {
        CharacterDetails charDetails = new CharacterDetails();
        public BackgroundAndAlignment(CharacterDetails addedDetails)
        {
            charDetails = addedDetails;
            InitializeComponent();
        }

        private void AddBackGroundAndAlignment(object sender, RoutedEventArgs e)
        {
            charDetails.Background = backgroundtxt.Text;
            charDetails.Alignment = alignmenttxt.Text;
            ClassSelectionPage classSelectPage = new ClassSelectionPage(charDetails);
            this.NavigationService.Navigate(classSelectPage);
        }
    }
}
