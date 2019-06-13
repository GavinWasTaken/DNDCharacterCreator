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
    /// Interaction logic for ClassSelectionPage.xaml
    /// </summary>
    public partial class ClassSelectionPage : Page
    {
        CharacterDetails charDetails = new CharacterDetails();
        public ClassSelectionPage(CharacterDetails addedDetails)
        {
            charDetails = addedDetails;
            InitializeComponent();
        }

        private void ClassSelection(object sender, RoutedEventArgs e)
        {
            charDetails.Class = classSelectiontxt.Text;
            StatSelection statSelection = new StatSelection(charDetails);
            this.NavigationService.Navigate(statSelection);
        }
    }
}
