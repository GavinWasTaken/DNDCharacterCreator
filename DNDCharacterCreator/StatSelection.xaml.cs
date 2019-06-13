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
    /// Interaction logic for StatSelection.xaml
    /// </summary>
    public partial class StatSelection : Page
    {
        CharacterDetails charDetails = new CharacterDetails();
        public StatSelection(CharacterDetails addedDetails)
        {
            charDetails = addedDetails;
            InitializeComponent();
        }

        private void IncreaseDecrease(object sender, RoutedEventArgs e)
        {
            string btnName = ((Button)sender).Name;
            int TxtBxVal;
            switch(btnName)
            {
                case "StrIncrease":
                    TxtBxVal = int.Parse(StrTxtBx.Text);
                    StrTxtBx.Text = (++TxtBxVal).ToString();
                    break;

                case "StrDecrease":
                    TxtBxVal = int.Parse(StrTxtBx.Text);
                    StrTxtBx.Text = (--TxtBxVal).ToString();
                    break;

                case "DexIncrease":
                    TxtBxVal = int.Parse(DexTxtBx.Text);
                    DexTxtBx.Text = (++TxtBxVal).ToString();
                    break;

                case "DexDecrease":
                    TxtBxVal = int.Parse(DexTxtBx.Text);
                    DexTxtBx.Text = (--TxtBxVal).ToString();
                    break;

                case "ConIncrease":
                    TxtBxVal = int.Parse(ConTxtBx.Text);
                    ConTxtBx.Text = (++TxtBxVal).ToString();
                    break;

                case "ConDecrease":
                    TxtBxVal = int.Parse(ConTxtBx.Text);
                    ConTxtBx.Text = (--TxtBxVal).ToString();
                    break;

                case "IntIncrease":
                    TxtBxVal = int.Parse(IntTxtBx.Text);
                    IntTxtBx.Text = (++TxtBxVal).ToString();
                    break;

                case "IntDecrease":
                    TxtBxVal = int.Parse(IntTxtBx.Text);
                    IntTxtBx.Text = (--TxtBxVal).ToString();
                    break;

                case "WisIncrease":
                    TxtBxVal = int.Parse(WisTxtBx.Text);
                    WisTxtBx.Text = (++TxtBxVal).ToString();
                    break;

                case "WisDecrease":
                    TxtBxVal = int.Parse(WisTxtBx.Text);
                    WisTxtBx.Text = (--TxtBxVal).ToString();
                    break;

                case "ChrIncrease":
                    TxtBxVal = int.Parse(ChrTxtBx.Text);
                    ChrTxtBx.Text = (++TxtBxVal).ToString();
                    break;

                case "ChrDecrease":
                    TxtBxVal = int.Parse(ChrTxtBx.Text);
                    ChrTxtBx.Text = (--TxtBxVal).ToString();
                    break;
            }

        }

        private void SetStats(object sender, RoutedEventArgs e)
        {
            charDetails.StrenghtScore = int.Parse(StrTxtBx.Text);
            charDetails.DexterityScore = int.Parse(DexTxtBx.Text);
            charDetails.ConstitutionScore = int.Parse(ConTxtBx.Text);
            charDetails.IntelligenceScore = int.Parse(IntTxtBx.Text);
            charDetails.WisdomScore = int.Parse(WisTxtBx.Text);
            charDetails.CharismaScore = int.Parse(ChrTxtBx.Text);

            ProficienciesPage profPage = new ProficienciesPage(charDetails);
            this.NavigationService.Navigate(profPage);
        }
    }
}
