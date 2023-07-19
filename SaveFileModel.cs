using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Save_Editor
{
    [Serializable]
    public class SaveFileModel
    {
        public SaveFileModel DeepCopy()
        {
            var copy = (SaveFileModel)this.MemberwiseClone();
            return copy;
        }

        public static SaveFileModel Load(string path)
        {
            string rawData = Encoding.UTF8.GetString(File.ReadAllBytes(path));
            var save = SaveEncryptionManager.process(rawData);
            SaveFileModel savingDataClass;
            try
            {
                return savingDataClass = (SaveFileModel)JsonConvert.DeserializeObject<SaveFileModel>(save);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                return savingDataClass = (SaveFileModel)JsonConvert.DeserializeObject<SaveFileModel>(rawData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        public void Save(string path, bool encrypt = true)
        {
            var content = JsonConvert.SerializeObject(this);
            var save = encrypt ? SaveEncryptionManager.process(content) : content;
            File.WriteAllBytes(path, Encoding.UTF8.GetBytes(save));
        }


        public int date_year;

        public int date_month;

        public int date_day;

        public int date_hour;

        public int date_minute;

        public int[] buildingsLvls;

        public int[] heroSkillsLvls;

        public int[] freeSkillPoints;

        public int[] locationsLvls;

        public int[] itemsEquipmentValues;

        public int[] itemsUsedValues;

        public int[] itemsArtifactsValues;

        public int gold;

        public int gems;

        public int ads;

        public int tutorial;

        public int CheckUltimateBonus;

        public int chekcTutorial;

        public string questsDaily;

        public int questDate;

        public int join;

        public int rate;

        public int maxRaids;

        public int defaultSkill_warrior1;

        public int defaultSkill_warrior2;

        public int defaultSkill_warrior3;

        public int defaultSkill_archer1;

        public int defaultSkill_archer2;

        public int defaultSkill_archer3;

        public int defaultSkill_wizard1;

        public int defaultSkill_wizard2;

        public int defaultSkill_wizard3;

        public int defaultSkill_hunter1;

        public int defaultSkill_hunter2;

        public int defaultSkill_hunter3;

        public int defaultSkill_berserk1;

        public int defaultSkill_berserk2;

        public int defaultSkill_berserk3;

        public int defaultSkill_necr1;

        public int defaultSkill_necr2;

        public int defaultSkill_necr3;

        public AllPets[] allPets;

        public string[] curPet;

        public int[] attributes_End;

        public int[] attributes_Str;

        public int[] attributes_Agl;

        public int[] attributes_Int;

        public string[] chestContent;

        public int chestSize;

        public string[] chestContent2;

        public int chestSize2;

        public int[] locationsScore;

        public int[] achievements;

        public int[] mobs;

        public int[] mobsMax;

        public int[] mobsUppers;

        public int[] towerModifiers;

        public string forgeProgress_stoneEffects;

        public string forgeProgress_knownRecipes;

        public string forgeProgress_knownRecipesDuplicates;

        public string forgeProgress_knownRecipesWithSteel;

        public int oblivionPriceMob;

        public string[] character_statistics;

        public string[] character_statistics_current;

        public string[] characters_progress;

        public string[] characters_inventory;

        public string[] characters_currentFloor;

        public string[] characters_clearedFloor;

        public string[] characters_clearedMod;

        public string[] characters_currentScore;

        public bool manualEdited;


        [Serializable]
        public class AllPets
        {
            public Pet[] pets;
        }

        [Serializable]
        public class Pet
        {
            public int opened;
            public int hp;
            public int dmg;
            public int spd;
        }

        public int GetJobSP(Job job)
        {
            return freeSkillPoints[(int) job];
        }

        public void SetJobSP(Job job, int sp)
        {
            freeSkillPoints[(int)job] = sp;
        }
    }
}
