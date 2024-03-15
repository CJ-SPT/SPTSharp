using SPTSharp.Models.Eft.Common;
using SPTSharp.Models.Eft.Common.Tables;

namespace SPTSharp.Models.Spt.Server
{
    public class DatabaseTables
    {
        public DatabaseTables() { }

        public LocaleBase Locales { get; set; } = new LocaleBase();

        public Templates templates = new Templates();

        public Dictionary<string, Trader> traders = new Dictionary<string, Trader>();
        
        public Globals globals = new Globals();

        public SettingsBase settings = new SettingsBase();
    }

    public class Templates
    {
        public List<string> character = new List<string>();
        public Dictionary<string, TemplateItem> items = new Dictionary<string, TemplateItem>();
        
        //public Dictionary<string, Quest>;
        //public RepeatableQuestDatabase;
        //public HandbookBase handbook;
        public Dictionary<string, CustomizationItem> customization = new Dictionary<string, CustomizationItem>();
        public ProfileTemplates profiles = new ProfileTemplates();
        public Dictionary<string, float> prices = new Dictionary<string, float>();
        //public DefaultEquipmentPresets[] defaultEquipmentPresets;
        //public Achievement[] achievements; 
    }
}
