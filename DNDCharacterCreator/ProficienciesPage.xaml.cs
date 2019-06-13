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
    /// Interaction logic for ProficienciesPage.xaml
    /// </summary>
    public partial class ProficienciesPage : Page
    {
        CharacterDetails charDetails = new CharacterDetails();
        
        public ProficienciesPage(CharacterDetails addedDetails)
        {
            charDetails = addedDetails;
            InitializeComponent();
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void SetSkills(object sender, RoutedEventArgs e)
        {
            List<CheckBox> boxesList = new List<CheckBox>();
            var children = LogicalTreeHelper.GetChildren(SkillStack).OfType<CheckBox>();
            
            foreach (var item in FindVisualChildren<CheckBox>(SkillStack))
            {
                var chkCast = item as CheckBox;
                if(chkCast.IsChecked  == true)
                {
                    boxesList.Add(chkCast);
                }

            }
            foreach(CheckBox chkbx in boxesList)
            {
                string checkboxName = chkbx.Name;
                switch(checkboxName)
                {
                    case "AcroSkill":
                        charDetails.ProfAcrobatics = true;
                        break;
                    case "AnimSkill" :
                        charDetails.ProfAnimalHandling = true;
                        break;
                    case "ArcaSkill":
                        charDetails.ProfArcana = true;
                        break;
                    case "AtheSkill":
                        charDetails.ProfAtheletics = true;
                        break;
                    case "DeceSkill":
                        charDetails.ProfDeception = true;
                        break;
                    case "HistSkill":
                        charDetails.ProfHistory = true;
                        break;
                    case "InsiSkill":
                        charDetails.ProfInsight = true;
                        break;
                    case "IntiSkill":
                        charDetails.ProfIntimidation = true;
                        break;
                    case "InveSkill":
                        charDetails.ProfInvestigation = true;
                        break;
                    case "MediSkill":
                        charDetails.ProfMedicine = true;
                        break;
                    case "NatuSkill":
                        charDetails.ProfNature = true;
                        break;
                    case "PercSkill":
                        charDetails.ProfPerception = true;
                        break;
                    case "PerfSkill":
                        charDetails.ProfPerformance = true;
                        break;
                    case "PersSkill":
                        charDetails.ProfPersuasion = true;
                        break;
                    case "ReliSkill":
                        charDetails.ProfReligion = true;
                        break;
                    case "SleiSkill":
                        charDetails.ProfSleightOfHand = true;
                        break;
                    case "SteaSkill":
                        charDetails.ProfStealth = true;
                        break;
                    case "SurvSkill":
                        charDetails.ProfSurvival = true;
                        break;
                }
            }

            EquipmentSelection equipmentSelection = new EquipmentSelection(charDetails);
            this.NavigationService.Navigate(equipmentSelection);
        }


    }
}
