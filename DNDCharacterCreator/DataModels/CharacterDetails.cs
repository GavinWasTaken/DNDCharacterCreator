using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDCharacterCreator.DataModels
{
    public class CharacterDetails
    {
        
        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public string Class { get; set; }
        public string Background { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        
        //Stats
        public int StrenghtScore { get; set; }
        public int DexterityScore { get; set; }
        public int ConstitutionScore { get; set; }
        public int IntelligenceScore { get; set; }
        public int WisdomScore { get; set; }
        public int CharismaScore { get; set; }

        //Profieciencies
        //Str
        public bool ProfAtheletics { get; set; }
        //Dex
        public bool ProfAcrobatics { get; set; }
        public bool ProfSleightOfHand { get; set; }
        public bool ProfStealth { get; set; }
        //Con
        //No skill with constitution
        //Int
        public bool ProfArcana { get; set; }
        public bool ProfHistory { get; set; }
        public bool ProfInvestigation { get; set; }
        public bool ProfNature { get; set; }
        public bool ProfReligion { get; set; }
        //Wis
        public bool ProfAnimalHandling { get; set; }
        public bool ProfInsight { get; set; }
        public bool ProfMedicine { get; set; }
        public bool ProfPerception { get; set; }
        public bool ProfSurvival { get; set; }
        //Chr
        public bool ProfDeception { get; set; }
        public bool ProfIntimidation { get; set; }
        public bool ProfPerformance { get; set; }
        public bool ProfPersuasion { get; set; }

        public int ArmorClass { get; set; }
        public string Weapon1 { get; set; }
        public string Weapon2 { get; set; }
        public string Weapon3 { get; set; }
        public int Speed { get; set; }

    }
}
