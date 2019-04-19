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
    /// Interaction logic for CharacterNamePage.xaml
    /// </summary>
    public partial class CharacterNamePage : Page
    {
        public CharacterNamePage()
        {
            InitializeComponent();
        }

        private void AddNames(object sender, RoutedEventArgs e)
        {
            string charName = CharacterNameTxt.Text;
            string playerName = PlayerNameTxt.Text;

            CharacterDetails CharacterDetails = new CharacterDetails();

            CharacterDetails.CharacterName = charName;
            CharacterDetails.PlayerName = playerName;

            CharacterRacePage racePage = new CharacterRacePage(CharacterDetails);
            this.NavigationService.Navigate(racePage);
            
        }

    }
}
