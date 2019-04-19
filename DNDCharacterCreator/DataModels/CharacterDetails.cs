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
        
        public int StrenghtScore { get; set; }
        public int DexterityScore { get; set; }
        public int ConstitutionScore { get; set; }
        public int IntelligenceScore { get; set; }
        public int WisdomScore { get; set; }
        public int CharismaScore { get; set; }

        public int ArmorClass { get; set; }
        public int Speed { get; set; }

    }
}
