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

using DNDCharacterCreator.DataModels;

namespace DNDCharacterCreator
{
    /// <summary>
    /// Interaction logic for CharacterRacePage.xaml
    /// </summary>
    public partial class CharacterRacePage : Page
    {
        CharacterDetails charDetails = new CharacterDetails();

        public CharacterRacePage(CharacterDetails addedDetails)
        {
            charDetails = addedDetails;
            InitializeComponent();
        } 

        private void AddRace(object sender, RoutedEventArgs e)
        {
            charDetails.Race = raceTxt.Text;
        }

    }
}
