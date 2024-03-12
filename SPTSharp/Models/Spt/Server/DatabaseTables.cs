using SPTSharp.Models.Eft.Common.Tables;

namespace SPTSharp.Models.Spt.Server
{
    public class DatabaseTables
    {
        public DatabaseTables() { }

        public LocaleBase Locales { get; set; } = new LocaleBase();

        public Templates templates = new Templates();

    }

    public class Templates
    {
        public List<string> character = new List<string>();
        //public Dictionary<string, STemplateItem> items;
        //public Dictionary<string, SQuest>;
        //public SRepeatableQuestDatabase;
        //public SHandbookBase handbook;
        //public Dictionary<string, SCustomizationItem> customization;
        //public Profiles profiles = new Profiles();
        public Dictionary<string, float> prices = new Dictionary<string, float>();
        //public SDefaultEquipmentPresets[] defaultEquipmentPresets;
        //public SAchievement[] achievements;
    }
}
