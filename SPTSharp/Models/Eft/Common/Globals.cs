#pragma warning disable
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Eft.Profile;
using System.IO;
using System;
using Newtonsoft.Json;

namespace SPTSharp.Models.Eft.Common
{
    public class Globals
    {
        public long time { get; set; }
        public Config config { get; set; }
        public BotPreset[] bot_presets { get; set; }
        public AudioSettings AudioSettings { get; set; }
        public EnvironmentSettings EnvironmentSettings { get; set; }
        public BotWeaponScattering[] BotWeaponScatterings { get; set; }
        public Dictionary<string, Preset> ItemPresets { get; set; }
    }

    public class Config
    {
        public Content content { get; set; }
        public float AimPunchMagnitude { get; set; }
        public float WeaponSkillProgressRate { get; set; }
        public bool SkillAtrophy { get; set; }
        public Exp exp { get; set; }
        public float t_base_looting { get; set; }
        public float t_base_lockpicking { get; set; }
        public Armor armor { get; set; }
        public int SessionsToShowHotKeys { get; set; }
        public int MaxBotsAliveOnMap { get; set; }
        public int SavagePlayCooldown { get; set; }
        public int SavagePlayCooldownNdaFree { get; set; }
        public float MarksmanAccuracy { get; set; }
        public int SavagePlayCooldownDevelop { get; set; }
        public string TODSkyDate { get; set; }
        public Mastering[] Mastering { get; set; }
        public float GlobalItemPriceModifier { get; set; }
        public bool TradingUnlimitedItems { get; set; }
        public bool MaxLoyaltyLevelForAll { get; set; }
        public float GlobalLootChanceModifier { get; set; }
        public GraphicSettings GraphicSettings { get; set; }
        public int TimeBeforeDeploy { get; set; }
        public int TimeBeforeDeployLocal { get; set; }
        public int TradingSetting { get; set; }
        public TradingSettings TradingSettings { get; set; }
        public ItemsCommonSettings ItemsCommonSettings { get; set; }
        public float LoadTimeSpeedProgress { get; set; }
        public float BaseLoadTime { get; set; }
        public float BaseUnloadTime { get; set; }
        public float BaseCheckTime { get; set; }
        public float BluntDamageReduceFromSoftArmorMod { get; set; }
        public Customization Customization { get; set; }
        public bool UncheckOnShot { get; set; }
        public bool BotsEnabled { get; set; }
        public BufferZone BufferZone { get; set; }
        public ArmorMaterials ArmorMaterials { get; set; }
        public float LegsOverdamage { get; set; }
        public float HandsOverdamage { get; set; }
        public float StomachOverdamage { get; set; }
        public Health Health { get; set; }
        public Rating rating { get; set; }
        public Tournament tournament { get; set; }
        public RagFair RagFair { get; set; }
        public Handbook handbook { get; set; }
        public Probability FractureCausedByFalling { get; set; }
        public Probability FractureCausedByBulletHit { get; set; }
        public float WAVE_COEF_LOW { get; set; }
        public float WAVE_COEF_MID { get; set; }
        public float WAVE_COEF_HIGH { get; set; }
        public float WAVE_COEF_HORDE { get; set; }
        public Stamina Stamina { get; set; }
        public StaminaRestoration StaminaRestoration { get; set; }
        public StaminaDrain StaminaDrain { get; set; }
        public RequirementReferences RequirementReferences { get; set; }
        public RestrictionsInRaid[] RestrictionsInRaid { get; set; }
        public float SkillMinEffectiveness { get; set; }
        public float SkillFatiguePerPoint { get; set; }
        public float SkillFreshEffectiveness { get; set; }
        public int SkillFreshPoints { get; set; }
        public int SkillPointsBeforeFatigue { get; set; }
        public int SkillFatigueReset { get; set; }
        public bool DiscardLimitsEnabled { get; set; }
        public EventSettings EventSettings { get; set; }
        public FavoriteItemsSettings FavoriteItemsSettings { get; set; }
        public VaultingSettings VaultingSettings { get; set; }
        public BTRSettings BTRSettings { get; set; }
        public string[] EventType { get; set; }
        public Xyz WalkSpeed { get; set; }
        public Xyz SprintSpeed { get; set; }
        public SquadSettings SquadSettings { get; set; }
        public float SkillEnduranceWeightThreshold { get; set; }
        public int TeamSearchingTimeout { get; set; }
        public Insurance Insurance { get; set; }
        public float SkillExpPerLevel { get; set; }
        public int GameSearchingTimeout { get; set; }
        public Xyz WallContusionAbsorption { get; set; }
        public WeaponFastDrawSettings WeaponFastDrawSettings { get; set; }
        public SkillsSettings SkillsSettings { get; set; }
        public bool AzimuthPanelShowsPlayerOrientation { get; set; }
        public Aiming Aiming { get; set; }
        public Malfunction Malfunction { get; set; }
        public Overheat Overheat { get; set; }
        public FenceSettings FenceSettings { get; set; }
        public float TestValue { get; set; }
        public Inertia Inertia { get; set; }
        public Ballistic Ballistic { get; set; }
        public RepairSettings RepairSettings { get; set; }
    }

    public class WeaponFastDrawSettings
    {
        public float HandShakeCurveFrequency { get; set; }
        public float HandShakeCurveIntensity { get; set; }
        public float HandShakeMaxDuration { get; set; }
        public float HandShakeTremorIntensity { get; set; }
        public float WeaponFastSwitchMaxSpeedMult { get; set; }
        public float WeaponFastSwitchMinSpeedMult { get; set; }
        public float WeaponPistolFastSwitchMaxSpeedMult { get; set; }
        public float WeaponPistolFastSwitchMinSpeedMult { get; set; }
    }

    public class EventSettings
    {
        public bool EventActive { get; set; }
        public int EventTime { get; set; }
        public EventWeather EventWeather { get; set; }
        public float ExitTimeMultiplier { get; set; }
        public float StaminaMultiplier { get; set; }
        public EventWeather SummonFailedWeather { get; set; }
        public EventWeather SummonSuccessWeather { get; set; }
        public int WeatherChangeTime { get; set; }
    }

    public class EventWeather
    {
        public float Cloudness { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public float Rain { get; set; }
        public float RainRandomness { get; set; }
        public float ScaterringFogDensity { get; set; }
        public Xyz TopWindDirection { get; set; }
        public float Wind { get; set; }
        public int WindDirection { get; set; }
    }

    public class GraphicSettings
    {
        public bool ExperimentalFogInCity { get; set; }
    }

    public class BufferZone
    {
        public float CustomerAccessTime { get; set; }
        public float CustomerCriticalTimeStart { get; set; }
        public float CustomerKickNotifTime { get; set; }
    }

    public class ItemsCommonSettings
    {
        public float ItemRemoveAfterInterruptionTime { get; set; }
    }

    public class TradingSettings
    {
        public BuyoutRestrictions BuyoutRestrictions { get; set; }
    }

    public class BuyoutRestrictions
    {
        public float MinDurability { get; set; }
        public float MinFoodDrinkResource { get; set; }
        public float MinMedsResource { get; set; }
    }

    public class Content
    {
        public string ip { get; set; }
        public int port { get; set; }
        public string root { get; set; }
    }

    public class Exp
    {
        public Heal heal { get; set; }
        public MatchEnd match_end { get; set; }
        public Kill kill { get; set; }
        public Level level { get; set; }
        public LootAttempt[] loot_attempts { get; set; }
        public int expForLockedDoorOpen { get; set; }
        public int expForLockedDoorBreach { get; set; }
        public float triggerMult { get; set; }
    }

    public class Heal
    {
        public float expForHeal { get; set; }
        public float expForHydration { get; set; }
        public float expForEnergy { get; set; }
    }

    public class MatchEnd
    {
        public string README { get; set; }
        public int survived_exp_requirement { get; set; }
        public int survived_seconds_requirement { get; set; }
        public int survived_exp_reward { get; set; }
        public int mia_exp_reward { get; set; }
        public int runner_exp_reward { get; set; }
        public float leftMult { get; set; }
        public float miaMult { get; set; }
        public float survivedMult { get; set; }
        public float runnerMult { get; set; }
        public float killedMult { get; set; }
    }

    public class Kill
    {
        public Combo[] combo { get; set; }
        public int victimLevelExp { get; set; }
        public float headShotMult { get; set; }
        public float expOnDamageAllHealth { get; set; }
        public float longShotDistance { get; set; }
        public float bloodLossToLitre { get; set; }
        public float botExpOnDamageAllHealth { get; set; }
        public float botHeadShotMult { get; set; }
        public int victimBotLevelExp { get; set; }
        public float pmcExpOnDamageAllHealth { get; set; }
        public float pmcHeadShotMult { get; set; }
    }

    public class Combo
    {
        public int percent { get; set; }
    }

    public class Level
    {
        public ExpTable[] exp_table { get; set; }
        public int trade_level { get; set; }
        public int savage_level { get; set; }
        public int clan_level { get; set; }
        public int mastering1 { get; set; }
        public int mastering2 { get; set; }
    }

    public class ExpTable
    {
        public int exp { get; set; }
    }

    public class LootAttempt
    {
        public float k_exp { get; set; }
    }

    public class Armor
    {
        public Class[] @class { get; set; }
    }

    public class Class
    {
        public int resistance { get; set; }
    }

    public class Mastering
    {
        public string Name { get; set; }
        public string[] Templates { get; set; }
        public int Level2 { get; set; }
        public int Level3 { get; set; }
    }

    public class Customization
    {
        public SavageHead SavageHead { get; set; }
        public SavageBody SavageBody { get; set; }
        public SavageFeet SavageFeet { get; set; }
        public CustomizationVoice[] CustomizationVoice { get; set; }
        public BodyParts BodyParts { get; set; }
    }

    public class SavageHead
    {
        public WildHead wild_head_1 { get; set; }
        public WildHead wild_head_2 { get; set; }
        public WildHead wild_head_3 { get; set; }
        public WildHead Wild_Dealmaker_head { get; set; }
        public WildHead Wild_Killa_head { get; set; }
        public WildHead bear_head { get; set; }
        public WildHead bear_head_1 { get; set; }
        public WildHead usec_head_1 { get; set; }
        public WildHead Head_BOSS_Glukhar { get; set; }
        public WildHead Wild_Head_nonMesh { get; set; }
        public WildHead Head_BOSS_Sanitar { get; set; }
        public WildHead wild_head_drozd { get; set; }
        public WildHead wild_head_misha { get; set; }
        public WildHead head_cultist_01 { get; set; }
        public WildHead head_cultist_02 { get; set; }
        public WildHead head_cultist_03 { get; set; }
        public WildHead DefaultUsecHead { get; set; }
        public WildHead usec_head_3 { get; set; }
        public WildHead usec_head_4 { get; set; }
        public WildHead usec_head_5 { get; set; }
    }

    public class WildHead
    {
        public string head { get; set; }
        public bool isNotRandom { get; set; }
        public bool NotRandom { get; set; }
    }

    public class SavageBody
    {
        public WildBody wild_body { get; set; }
        public WildBody wild_body_1 { get; set; }
        public WildBody wild_body_2 { get; set; }
        public WildBody wild_body_3 { get; set; }
        public WildBody Wild_Dealmaker_body { get; set; }
        public WildBody wild_security_body_1 { get; set; }
        public WildBody wild_security_body_2 { get; set; }
        public WildBody wild_Killa_body { get; set; }
        public WildBody wild_pmcBot_body { get; set; }
        public WildBody wild_Shturman_body { get; set; }
        public WildBody wild_Gluhar_body { get; set; }
        public WildBody Tshirt_security_TshirtTatu_01 { get; set; }
        public WildBody Tshirt_security_TshirtTatu_02 { get; set; }
        public WildBody Top_security_Husky { get; set; }
        public WildBody Top_security_Gorka4 { get; set; }
        public WildBody scav_kit_upper_meteor { get; set; }
        public WildBody wild_body_russia1 { get; set; }
        public WildBody Top_BOSS_Sanitar { get; set; }
        public WildBody wild_body_motocross { get; set; }
        public WildBody top_cultist_01 { get; set; }
        public WildBody top_cultist_02 { get; set; }
        public WildBody wild_body_rainparka { get; set; }
        public WildBody wild_body_underarmour { get; set; }
        public WildBody top_boss_tagilla { get; set; }
        public WildBody DefaultUsecBody { get; set; }
        public WildBody usec_upper_acu { get; set; }
        public WildBody usec_upper_commando { get; set; }
        public WildBody usec_upper_aggressor { get; set; }
        public WildBody usec_upper_hoody { get; set; }
        public WildBody usec_upper_pcuironsight { get; set; }
        public WildBody usec_top_beltstaff { get; set; }
        public WildBody usec_upper_flexion { get; set; }
        public WildBody usec_upper_tier3 { get; set; }
        public WildBody usec_upper_pcsmulticam { get; set; }
        public WildBody usec_upper_tier_2 { get; set; }
        public WildBody usec_upper_infiltrator { get; set; }
        public WildBody user_upper_NightPatrol { get; set; }
        public WildBody wild_body_bomber { get; set; }
        public WildBody wild_top_yellowcoat { get; set; }
    }

    public class WildBody
    {
        public string body { get; set; }
        public string hands { get; set; }
        public bool isNotRandom { get; set; }
    }

    public class SavageFeet
    {
        public WildFeet wild_feet { get; set; }
        public WildFeet wild_feet_1 { get; set; }
        public WildFeet wild_feet_2 { get; set; }
        public WildFeet Wild_Dealmaker_feet { get; set; }
        public WildFeet wild_security_feet_1 { get; set; }
        public WildFeet Wild_Killa_feet { get; set; }
        public WildFeet wild_pmcBot_feet { get; set; }
        public WildFeet Pants_BOSS_Glukhar { get; set; }
        public WildFeet Pants_BOSS_Shturman { get; set; }
        public WildFeet Pants_security_Gorka4 { get; set; }
        public WildFeet Pants_security_Flora { get; set; }
        public WildFeet scav_kit_lower_sklon { get; set; }
        public WildFeet Pants_BOSS_Sanitar { get; set; }
        public WildFeet wild_feet_sweatpants { get; set; }
        public WildFeet wild_feet_wasatch { get; set; }
        public WildFeet wild_feet_slimPants { get; set; }
        public WildFeet pants_cultist_01 { get; set; }
        public WildFeet pants_cultist_02 { get; set; }
        public WildFeet wild_feet_scavelite_taclite { get; set; }
        public WildFeet pants_boss_tagilla { get; set; }
        public WildFeet wild_feet_bomber { get; set; }
        public WildFeet wild_pants_yellowcoat { get; set; }
    }

    public class WildFeet
    {
        public string feet { get; set; }
        public bool isNotRandom { get; set; }
        public bool NotRandom { get; set; }
    }

    public class CustomizationVoice
    {
        public string voice { get; set; }
        public string[] side { get; set; }
        public bool isNotRandom { get; set; }
    }

    public class BodyParts
    {
        public string Head { get; set; }
        public string Body { get; set; }
        public string Feet { get; set; }
        public string Hands { get; set; }
    }

    public class ArmorMaterials
    {
        public ArmorType UHMWPE { get; set; }
        public ArmorType Aramid { get; set; }
        public ArmorType Combined { get; set; }
        public ArmorType Titan { get; set; }
        public ArmorType Aluminium { get; set; }
        public ArmorType ArmoredSteel { get; set; }
        public ArmorType Ceramic { get; set; }
        public ArmorType Glass { get; set; }
    }

    public class ArmorType
    {
        public float Destructibility { get; set; }
        public float MinRepairDegradation { get; set; }
        public float MaxRepairDegradation { get; set; }
        public float ExplosionDestructibility { get; set; }
        public float MinRepairKitDegradation { get; set; }
        public float MaxRepairKitDegradation { get; set; }
    }

    public class Health
    {
        public Falling Falling { get; set; }
        public Effects Effects { get; set; }
        public HealPrice HealPrice { get; set; }
        public ProfileHealthSettings ProfileHealthSettings { get; set; }
    }

    public class Falling
    {
        public float DamagePerMeter { get; set; }
        public float SafeHeight { get; set; }
    }

    public class Effects
    {
        public Existence Existence { get; set; }
        public Dehydration Dehydration { get; set; }
        public BreakPart BreakPart { get; set; }
        public Contusion Contusion { get; set; }
        public Disorientation Disorientation { get; set; }
        public Exhaustion Exhaustion { get; set; }
        public LowEdgeHealth LowEdgeHealth { get; set; }
        public RadExposure RadExposure { get; set; }
        public Stun Stun { get; set; }
        public Intoxication Intoxication { get; set; }
        public Regeneration Regeneration { get; set; }
        public Wound Wound { get; set; }
        public Berserk Berserk { get; set; }
        public Flash Flash { get; set; }
        public MedEffect MedEffect { get; set; }
        public Pain Pain { get; set; }
        public PainKiller PainKiller { get; set; }
        public SandingScreen SandingScreen { get; set; }
        public MusclePainEffect MildMusclePain { get; set; }
        public MusclePainEffect SevereMusclePain { get; set; }
        public Stimulator Stimulator { get; set; }
        public Tremor Tremor { get; set; }
        public ChronicStaminaFatigue ChronicStaminaFatigue { get; set; }
        public Fracture Fracture { get; set; }
        public HeavyBleeding HeavyBleeding { get; set; }
        public LightBleeding LightBleeding { get; set; }
        public BodyTemperature BodyTemperature { get; set; }
    }

    public class Existence
    {
        public float EnergyLoopTime { get; set; }
        public float HydrationLoopTime { get; set; }
        public float EnergyDamage { get; set; }
        public float HydrationDamage { get; set; }
        public float DestroyedStomachEnergyTimeFactor { get; set; }
        public float DestroyedStomachHydrationTimeFactor { get; set; }
    }

    public class Dehydration
    {
        public float DefaultDelay { get; set; }
        public float DefaultResidueTime { get; set; }
        public float BleedingHealth { get; set; }
        public float BleedingLoopTime { get; set; }
        public float BleedingLifeTime { get; set; }
        public float DamageOnStrongDehydration { get; set; }
        public float StrongDehydrationLoopTime { get; set; }
    }

    public class BreakPart
    {
        public float DefaultDelay { get; set; }
        public float DefaultResidueTime { get; set; }
        public int HealExperience { get; set; }
        public int OfflineDurationMin { get; set; }
        public int OfflineDurationMax { get; set; }
        public int RemovePrice { get; set; }
        public bool RemovedAfterDeath { get; set; }
        public Probability BulletHitProbability { get; set; }
        public Probability FallingProbability { get; set; }
    }

    public class Contusion
    {
        public float Dummy { get; set; }
    }

    public class Disorientation
    {
        public float Dummy { get; set; }
    }

    public class Exhaustion
    {
        public float DefaultDelay { get; set; }
        public float DefaultResidueTime { get; set; }
        public float Damage { get; set; }
        public float DamageLoopTime { get; set; }
    }

    public class LowEdgeHealth
    {
        public float DefaultDelay { get; set; }
        public float DefaultResidueTime { get; set; }
        public float StartCommonHealth { get; set; }
    }

    public class RadExposure
    {
        public float Damage { get; set; }
        public float DamageLoopTime { get; set; }
    }

    public class Stun
    {
        public float Dummy { get; set; }
    }

    public class Intoxication
    {
        public int DefaultDelay { get; set; }
        public int DefaultResidueTime { get; set; }
        public int DamageHealth { get; set; }
        public int HealthLoopTime { get; set; }
        public int OfflineDurationMin { get; set; }
        public int OfflineDurationMax { get; set; }
        public bool RemovedAfterDeath { get; set; }
        public int HealExperience { get; set; }
        public int RemovePrice { get; set; }
    }

    public class Regeneration
    {
        public float LoopTime { get; set; }
        public float MinimumHealthPercentage { get; set; }
        public float Energy { get; set; }
        public float Hydration { get; set; }
        public BodyHealth BodyHealth { get; set; }
        public Influences Influences { get; set; }
    }

    public class BodyHealth
    {
        public BodyHealthValue Head { get; set; }
        public BodyHealthValue Chest { get; set; }
        public BodyHealthValue Stomach { get; set; }
        public BodyHealthValue LeftArm { get; set; }
        public BodyHealthValue RightArm { get; set; }
        public BodyHealthValue LeftLeg { get; set; }
        public BodyHealthValue RightLeg { get; set; }
    }

    public class BodyHealthValue
    {
        public float Value { get; set; }
    }

    public class Influences
    {
        public Influence LightBleeding { get; set; }
        public Influence HeavyBleeding { get; set; }
        public Influence Fracture { get; set; }
        public Influence RadExposure { get; set; }
        public Influence Intoxication { get; set; }
    }

    public class Influence
    {
        public float HealthSlowDownPercentage { get; set; }
        public float EnergySlowDownPercentage { get; set; }
        public float HydrationSlowDownPercentage { get; set; }
    }

    public class Wound
    {
        public float WorkingTime { get; set; }
        public float ThresholdMin { get; set; }
        public float ThresholdMax { get; set; }
    }

    public class Berserk
    {
        public float DefaultDelay { get; set; }
        public float WorkingTime { get; set; }
        public float DefaultResidueTime { get; set; }
    }

    public class Flash
    {
        public float Dummy { get; set; }
    }

    public class MedEffect
    {
        public float LoopTime { get; set; }
        public float StartDelay { get; set; }
        public float DrinkStartDelay { get; set; }
        public float FoodStartDelay { get; set; }
        public float DrugsStartDelay { get; set; }
        public float MedKitStartDelay { get; set; }
        public float MedicalStartDelay { get; set; }
        public float StimulatorStartDelay { get; set; }
    }

    public class Pain
    {
        public int TremorDelay { get; set; }
        public int HealExperience { get; set; }
    }

    public class PainKiller
    {
        public float Dummy { get; set; }
    }

    public class SandingScreen
    {
        public float Dummy { get; set; }
    }

    public class MusclePainEffect
    {
        public float GymEffectivity { get; set; }
        public float OfflineDurationMax { get; set; }
        public float OfflineDurationMin { get; set; }
        public float TraumaChance { get; set; }
    }

    public class Stimulator
    {
        public float BuffLoopTime { get; set; }
        public Buffs Buffs { get; set; }
    }

    public class Buffs
    {
        public List<Buff> BuffsSJ1TGLabs { get; set; }
        public List<Buff> BuffsSJ6TGLabs { get; set; }
        public List<Buff> BuffsPropital { get; set; }
        public List<Buff> BuffsZagustin { get; set; }
        public List<Buff> BuffseTGchange { get; set; }
        public List<Buff> BuffsAdrenaline { get; set; }
        public List<Buff> BuffsGoldenStarBalm { get; set; }
        public List<Buff> Buffs_drink_aquamari { get; set; }
        public List<Buff> Buffs_drink_maxenergy { get; set; }
        public List<Buff> Buffs_drink_milk { get; set; }
        public List<Buff> Buffs_drink_tarcola { get; set; }
        public List<Buff> Buffs_drink_hotrod { get; set; }
        public List<Buff> Buffs_drink_juice_army { get; set; }
        public List<Buff> Buffs_drink_water { get; set; }
        public List<Buff> Buffs_food_borodinskiye { get; set; }
        public List<Buff> Buffs_food_condensed_milk { get; set; }
        public List<Buff> Buffs_food_emelya { get; set; }
        public List<Buff> Buffs_food_mayonez { get; set; }
        public List<Buff> Buffs_food_mre { get; set; }
        public List<Buff> Buffs_food_sugar { get; set; }
        public List<Buff> Buffs_drink_vodka { get; set; }
        public List<Buff> Buffs_drink_jack { get; set; }
        public List<Buff> Buffs_drink_moonshine { get; set; }
        public List<Buff> Buffs_drink_purewater { get; set; }
        public List<Buff> Buffs_3bTG { get; set; }
        public List<Buff> Buffs_AHF1M { get; set; }
        public List<Buff> Buffs_L1 { get; set; }
        public List<Buff> Buffs_MULE { get; set; }
        public List<Buff> Buffs_Meldonin { get; set; }
        public List<Buff> Buffs_Obdolbos { get; set; }
        public List<Buff> Buffs_P22 { get; set; }
        public List<Buff> Buffs_KultistsToxin { get; set; }
        public List<Buff> Buffs_BodyTemperature { get; set; }
        public List<Buff> Buffs_Antidote { get; set; }
        public List<Buff> Buffs_melee_bleed { get; set; }
        public List<Buff> Buffs_melee_blunt { get; set; }
        public List<Buff> Buffs_hultafors { get; set; }
        public List<Buff> Buffs_drink_vodka_BAD { get; set; }
        public List<Buff> Buffs_food_alyonka { get; set; }
        public List<Buff> Buffs_food_slippers { get; set; }
        public List<Buff> Buffs_knife { get; set; }
    }

    public class Buff
    {
        public string BuffType { get; set; }
        public float Chance { get; set; }
        public float Delay { get; set; }
        public float Duration { get; set; }
        public float Value { get; set; }
        public bool AbsoluteValue { get; set; }
        public string SkillName { get; set; }
    }

    public class Tremor
    {
        public float DefaultDelay { get; set; }
        public float DefaultResidueTime { get; set; }
    }

    public class ChronicStaminaFatigue
    {
        public float EnergyRate { get; set; }
        public float WorkingTime { get; set; }
        public float TicksEvery { get; set; }
        public float EnergyRatePerStack { get; set; }
    }

    public class Fracture
    {
        public int DefaultDelay { get; set; }
        public int DefaultResidueTime { get; set; }
        public int HealExperience { get; set; }
        public int OfflineDurationMin { get; set; }
        public int OfflineDurationMax { get; set; }
        public int RemovePrice { get; set; }
        public bool RemovedAfterDeath { get; set; }
        public Probability BulletHitProbability { get; set; }
        public Probability FallingProbability { get; set; }
    }

    public class HeavyBleeding
    {
        public float DefaultDelay { get; set; }
        public float DefaultResidueTime { get; set; }
        public float DamageEnergy { get; set; }
        public float DamageHealth { get; set; }
        public int EnergyLoopTime { get; set; }
        public int HealthLoopTime { get; set; }
        public float DamageHealthDehydrated { get; set; }
        public int HealthLoopTimeDehydrated { get; set; }
        public int LifeTimeDehydrated { get; set; }
        public int EliteVitalityDuration { get; set; }
        public int HealExperience { get; set; }
        public int OfflineDurationMin { get; set; }
        public int OfflineDurationMax { get; set; }
        public int RemovePrice { get; set; }
        public bool RemovedAfterDeath { get; set; }
        public Probability Probability { get; set; }
    }

    public class Probability
    {
        public string FunctionType { get; set; }
        public float K { get; set; }
        public float B { get; set; }
        public float Threshold { get; set; }
    }

    public class LightBleeding
    {
        public float DefaultDelay { get; set; }
        public float DefaultResidueTime { get; set; }
        public float DamageEnergy { get; set; }
        public float DamageHealth { get; set; }
        public int EnergyLoopTime { get; set; }
        public int HealthLoopTime { get; set; }
        public float DamageHealthDehydrated { get; set; }
        public int HealthLoopTimeDehydrated { get; set; }
        public int LifeTimeDehydrated { get; set; }
        public int EliteVitalityDuration { get; set; }
        public int HealExperience { get; set; }
        public int OfflineDurationMin { get; set; }
        public int OfflineDurationMax { get; set; }
        public int RemovePrice { get; set; }
        public bool RemovedAfterDeath { get; set; }
        public Probability Probability { get; set; }
    }

    public class BodyTemperature
    {
        public float DefaultBuildUpTime { get; set; }
        public float DefaultResidueTime { get; set; }
        public float LoopTime { get; set; }
    }

    public class HealPrice
    {
        public float HealthPointPrice { get; set; }
        public float HydrationPointPrice { get; set; }
        public float EnergyPointPrice { get; set; }
        public int TrialLevels { get; set; }
        public int TrialRaids { get; set; }
    }

    public class ProfileHealthSettings
    {
        public BodyPartsSettings BodyPartsSettings { get; set; }
        public HealthFactorsSettings HealthFactorsSettings { get; set; }
        public string DefaultStimulatorBuff { get; set; }
    }

    public class BodyPartsSettings
    {
        public BodyPartsSetting Head { get; set; }
        public BodyPartsSetting Chest { get; set; }
        public BodyPartsSetting Stomach { get; set; }
        public BodyPartsSetting LeftArm { get; set; }
        public BodyPartsSetting RightArm { get; set; }
        public BodyPartsSetting LeftLeg { get; set; }
        public BodyPartsSetting RightLeg { get; set; }
    }

    public class BodyPartsSetting
    {
        public float Minimum { get; set; }
        public float Maximum { get; set; }
        public float Default { get; set; }
        public float EnvironmentDamageMultiplier { get; set; }
        public float OverDamageReceivedMultiplier { get; set; }
    }

    public class HealthFactorsSettings
    {
        public HealthFactorSetting Energy { get; set; }
        public HealthFactorSetting Hydration { get; set; }
        public HealthFactorSetting Temperature { get; set; }
        public HealthFactorSetting Poisoning { get; set; }
        public HealthFactorSetting Radiation { get; set; }
    }

    public class HealthFactorSetting
    {
        public float Minimum { get; set; }
        public float Maximum { get; set; }
        public float Default { get; set; }
    }

    public class Rating
    {
        public int levelRequired { get; set; }
        public int limit { get; set; }
        public Categories categories { get; set; }
    }

    public class Categories
    {
        public bool experience { get; set; }
        public bool kd { get; set; }
        public bool surviveRatio { get; set; }
        public bool avgEarnings { get; set; }
        public bool pmcKills { get; set; }
        public bool raidCount { get; set; }
        public bool longestShot { get; set; }
        public bool timeOnline { get; set; }
        public bool inventoryFullCost { get; set; }
        public bool ragFairStanding { get; set; }
    }

    public class Tournament 
    {
        public TournamentCategories categories { get; set; }
        public int limit { get; set; }
        public int levelRequired { get; set; }
    }

    public class TournamentCategories
    {
        public bool dogtags { get; set; }
    }

    public class RagFair
    {
        public bool enabled { get; set; }
        public bool priceStabilizerEnabled { get; set; }
        public bool includePveTraderSales { get; set; }
        public float priceStabilizerStartIntervalInHours { get; set; }
        public int minUserLevel { get; set; }
        public float communityTax { get; set; }
        public float communityItemTax { get; set; }
        public float communityRequirementTax { get; set; }
        public float offerPriorityCost { get; set; }
        public float offerDurationTimeInHour { get; set; }
        public float offerDurationTimeInHourAfterRemove { get; set; }
        public float priorityTimeModifier { get; set; }
        public float maxRenewOfferTimeInHour { get; set; }
        public float renewPricePerHour { get; set; }
        public MaxActiveOfferCount[] maxActiveOfferCount { get; set; }
        public float balancerRemovePriceCoefficient { get; set; }
        public int balancerMinPriceCount { get; set; }
        public float balancerAveragePriceCoefficient { get; set; }
        public int delaySinceOfferAdd { get; set; }
        public float uniqueBuyerTimeoutInDays { get; set; }
        public float ratingSumForIncrease { get; set; }
        public float ratingIncreaseCount { get; set; }
        public float ratingSumForDecrease { get; set; }
        public float ratingDecreaseCount { get; set; }
        public float maxSumForIncreaseRatingPerOneSale { get; set; }
        public float maxSumForDecreaseRatingPerOneSale { get; set; }
        public MaxSumForRarity maxSumForRarity { get; set; }
        public float ChangePriceCoef { get; set; }
        public bool balancerUserItemSaleCooldownEnabled { get; set; }
        public int balancerUserItemSaleCooldown { get; set; }
        public int youSellOfferMaxStorageTimeInHour { get; set; }
        public int yourOfferDidNotSellMaxStorageTimeInHour { get; set; }
        public bool isOnlyFoundInRaidAllowed { get; set; }
        public int sellInOnePiece { get; set; }
    }

    public class MaxActiveOfferCount
    {
        public float from { get; set; }
        public float to { get; set; }
        public int count { get; set; }
    }

    public class RarityMaxSum 
    {
        public float value { get; set; }
    }

    public class MaxSumForRarity
    {
        public RarityMaxSum Common { get; set; }
        public RarityMaxSum Rare { get; set; }
        public RarityMaxSum Superrare { get; set; }
        public RarityMaxSum Not_exist { get; set; }
    }

    public class Handbook
    {
        public string defaultCategory { get; set; }
    }

    public class Stamina
    {
        public float Capacity { get; set; }
        public float SprintDrainRate { get; set; }
        public float BaseRestorationRate { get; set; }
        public float JumpConsumption { get; set; }
        public float GrenadeHighThrow { get; set; }
        public float GrenadeLowThrow { get; set; }
        public float AimDrainRate { get; set; }
        public float AimRangeFinderDrainRate { get; set; }
        public float OxygenCapacity { get; set; }
        public float OxygenRestoration { get; set; }
        public Xyz WalkOverweightLimits { get; set; }
        public Xyz BaseOverweightLimits { get; set; }
        public Xyz SprintOverweightLimits { get; set; }
        public Xyz WalkSpeedOverweightLimits { get; set; }
        public Xyz CrouchConsumption { get; set; }
        public Xyz WalkConsumption { get; set; }
        public Xyz StandupConsumption { get; set; }
        public Xyz TransitionSpeed { get; set; }
        public float SprintAccelerationLowerLimit { get; set; }
        public float SprintSpeedLowerLimit { get; set; }
        public float SprintSensitivityLowerLimit { get; set; }
        public Xyz AimConsumptionByPose { get; set; }
        public Xyz RestorationMultiplierByPose { get; set; }
        public Xyz OverweightConsumptionByPose { get; set; }
        public float AimingSpeedMultiplier { get; set; }
        public float WalkVisualEffectMultiplier { get; set; }
        public float WeaponFastSwitchConsumption { get; set; }
        public float HandsCapacity { get; set; }
        public float HandsRestoration { get; set; }
        public float ProneConsumption { get; set; }
        public float BaseHoldBreathConsumption { get; set; }
        public Xyz SoundRadius { get; set; }
        public float ExhaustedMeleeSpeed { get; set; }
        public float FatigueRestorationRate { get; set; }
        public float FatigueAmountToCreateEffect { get; set; }
        public float ExhaustedMeleeDamageMultiplier { get; set; }
        public float FallDamageMultiplier { get; set; }
        public float SafeHeightOverweight { get; set; }
        public float SitToStandConsumption { get; set; }
        public bool StaminaExhaustionCausesJiggle { get; set; }
        public bool StaminaExhaustionStartsBreathSound { get; set; }
        public bool StaminaExhaustionRocksCamera { get; set; }
        public Xyz HoldBreathStaminaMultiplier { get; set; }
        public Xyz PoseLevelIncreaseSpeed { get; set; }
        public Xyz PoseLevelDecreaseSpeed { get; set; }
        public Xyz PoseLevelConsumptionPerNotch { get; set; }
    }

    public class StaminaRestoration
    {
        public float LowerLeftPoint { get; set; }
        public float LowerRightPoint { get; set; }
        public float LeftPlatoPoint { get; set; }
        public float RightPlatoPoint { get; set; }
        public float RightLimit { get; set; }
        public float ZeroValue { get; set; }
    }

    public class StaminaDrain
    {
        public float LowerLeftPoint { get; set; }
        public float LowerRightPoint { get; set; }
        public float LeftPlatoPoint { get; set; }
        public float RightPlatoPoint { get; set; }
        public float RightLimit { get; set; }
        public float ZeroValue { get; set; }
    }

    public class RequirementReferences
    {
        public List<Alpinist> Alpinist { get; set; }
    }

    public class Alpinist
    {
        public string Requirement { get; set; }
        public string Id { get; set; }
        public int Count { get; set; }
        public string RequiredSlot { get; set; }
        public string RequirementTip { get; set; }
    }

    public class RestrictionsInRaid
    {
        public string TemplateId { get; set; }
        public float Value { get; set; }
    }

    public class FavoriteItemsSettings
    {
        public int WeaponStandMaxItemsCount { get; set; }
        public int PlaceOfFameMaxItemsCount { get; set; }
    }

    public class VaultingSettings
    {
        public bool IsActive { get; set; }
        public float VaultingInputTime { get; set; }
        public VaultingGridSettings GridSettings { get; set; }
        public VaultingMovesSettings MovesSettings { get; set; }
    }

    public class VaultingGridSettings
    {
        public float GridSizeX { get; set; }
        public float GridSizeY { get; set; }
        public float GridSizeZ { get; set; }
        public float SteppingLengthX { get; set; }
        public float SteppingLengthY { get; set; }
        public float SteppingLengthZ { get; set; }
        public float GridOffsetX { get; set; }
        public float GridOffsetY { get; set; }
        public float GridOffsetZ { get; set; }
        public float OffsetFactor { get; set; }
    }

    public class VaultingMovesSettings
    {
        public VaultingSubMoveSettings VaultSettings { get; set; }
        public VaultingSubMoveSettings ClimbSettings { get; set; }
    }

    public class VaultingSubMoveSettings
    {
        public bool IsActive { get; set; }
        public float MaxWithoutHandHeight { get; set; }
        public Xyz SpeedRange { get; set; }
        public MoveRestrictions MoveRestrictions { get; set; }
        public MoveRestrictions AutoMoveRestrictions { get; set; }
    }

    public class MoveRestrictions
    {
        public bool IsActive { get; set; }
        public float MinDistantToInteract { get; set; }
        public float MinHeight { get; set; }
        public float MaxHeight { get; set; }
        public float MinLength { get; set; }
        public float MaxLength { get; set; }
    }

    public class BTRSettings
    {
        public List<string> LocationsWithBTR { get; set; }
        public int BasePriceTaxi { get; set; }
        public int AddPriceTaxi { get; set; }
        public int CleanUpPrice { get; set; }
        public int DeliveryPrice { get; set; }
        public float ModDeliveryCost { get; set; }
        public float BearPriceMod { get; set; }
        public float UsecPriceMod { get; set; }
        public float ScavPriceMod { get; set; }
        public float CoefficientDiscountCharisma { get; set; }
        public int DeliveryMinPrice { get; set; }
        public int TaxiMinPrice { get; set; }
        public int BotCoverMinPrice { get; set; }
        public Dictionary<string, BtrMapConfig> MapsConfigs { get; set; }
        public float DiameterWheel { get; set; }
        public float HeightWheel { get; set; }
        public float HeightWheelMaxPosLimit { get; set; }
        public float HeightWheelMinPosLimit { get; set; }
        public float SnapToSurfaceWheelsSpeed { get; set; }
        public float CheckSurfaceForWheelsTimer { get; set; }
        public float HeightWheelOffset { get; set; }
    }

    public class BtrMapConfig
    {
        public string mapID { get; set; }
        public List<BtrMapConfig> pathsConfigurations { get; set; }
    }

    public class BtrPathConfig
    {
        public string id { get; set; }
        public string enterPoint { get; set; }
        public string exitPoint { get; set; }
        public List<string> pathPoints { get; set; }
        public bool once { get; set; }
        public bool circle { get; set; }
        public int circleCount { get; set; }
    }

    public class SquadSettings
    {
        public int CountOfRequestsToOnePlayer { get; set; }
        public int SecondsForExpiredRequest { get; set; }
        public int SendRequestDelaySeconds { get; set; }
    }

    public class Insurance
    {
        public float MaxStorageTimeInHour { get; set; }
    }

    public class SkillsSettings
    {
        public float SkillProgressRate { get; set; }
        public float WeaponSkillProgressRate { get; set; }
        public float WeaponSkillRecoilBonusPerLevel { get; set; }
        public HideoutManagement HideoutManagement { get; set; }
        public Crafting Crafting { get; set; }
        public Metabolism Metabolism { get; set; }
        public Immunity Immunity { get; set; }
        public Endurance Endurance { get; set; }
        public Strength Strength { get; set; }
        public Vitality Vitality { get; set; }
        public HealthSkillProgress Health { get; set; }
        public StressResistance StressResistance { get; set; }
        public Throwing Throwing { get; set; }
        public RecoilControl RecoilControl { get; set; }
        public WeaponSkills Pistol { get; set; }
        public WeaponSkills Revolver { get; set; }
        public IEnumerable<WeaponSkills> SMG { get; set; }
        public WeaponSkills Assault { get; set; }
        public WeaponSkills Shotgun { get; set; }
        public WeaponSkills Sniper { get; set; }
        public IEnumerable<WeaponSkills> LMG { get; set; }
        public IEnumerable<WeaponSkills> HMG { get; set; }
        public IEnumerable<WeaponSkills> Launcher { get; set; }
        public IEnumerable<WeaponSkills> AttachedLauncher { get; set; }
        public MeleeSkill Melee { get; set; }
        public WeaponSkills DMR { get; set; }
        public IEnumerable<WeaponSkills> BearAssaultoperations { get; set; }
        public IEnumerable<WeaponSkills> BearAuthority { get; set; }
        public IEnumerable<WeaponSkills> BearAksystems { get; set; }
        public IEnumerable<WeaponSkills> BearHeavycaliber { get; set; }
        public IEnumerable<WeaponSkills> BearRawpower { get; set; }
        public IEnumerable<WeaponSkills> UsecArsystems { get; set; }
        public IEnumerable<WeaponSkills> UsecDeepweaponmodding_Settings { get; set; }
        public IEnumerable<WeaponSkills> UsecLongrangeoptics_Settings { get; set; }
        public IEnumerable<WeaponSkills> UsecNegotiations { get; set; }
        public IEnumerable<WeaponSkills> UsecTactics { get; set; }
        public IEnumerable<WeaponSkills> BotReload { get; set; }
        public CovertMovement CovertMovement { get; set; }
        public IEnumerable<WeaponSkills> FieldMedicine { get; set; }
        public Search Search { get; set; }
        public IEnumerable<WeaponSkills> Sniping { get; set; }
        public IEnumerable<WeaponSkills> ProneMovement { get; set; }
        public IEnumerable<WeaponSkills> FirstAid { get; set; }
        public ArmorSkills LightVests { get; set; }
        public ArmorSkills HeavyVests { get; set; }
        public IEnumerable<WeaponSkills> WeaponModding { get; set; }
        public IEnumerable<WeaponSkills> AdvancedModding { get; set; }
        public IEnumerable<WeaponSkills> NightOps { get; set; }
        public IEnumerable<WeaponSkills> SilentOps { get; set; }
        public IEnumerable<WeaponSkills> Lockpicking { get; set; }
        public WeaponTreatment WeaponTreatment { get; set; }
        public MagDrills MagDrills { get; set; }
        public IEnumerable<WeaponSkills> Freetrading { get; set; }
        public IEnumerable<WeaponSkills> Auctions { get; set; }
        public IEnumerable<WeaponSkills> Cleanoperations { get; set; }
        public IEnumerable<WeaponSkills> Barter { get; set; }
        public IEnumerable<WeaponSkills> Shadowconnections { get; set; }
        public IEnumerable<WeaponSkills> Taskperformance { get; set; }
        public Perception Perception { get; set; }
        public Intellect Intellect { get; set; }
        public Attention Attention { get; set; }
        public Charisma Charisma { get; set; }
        public Memory Memory { get; set; }
        public Surgery Surgery { get; set; }
        public AimDrills AimDrills { get; set; }
        public IEnumerable<WeaponSkills> BotSound { get; set; }
        public TroubleShooting TroubleShooting { get; set; }
    }

    public class MeleeSkill
    {
        public BuffSettings BuffSettings { get; set; }
    }

    public class ArmorSkills
    {
        public int BuffMaxCount { get; set; }
        public BuffSettings BuffSettings { get; set; }
        public ArmorCounters Counters { get; set; }
        public float MoveSpeedPenaltyReductionHVestsReducePerLevel { get; set; }
        public float RicochetChanceHVestsCurrentDurabilityThreshold { get; set; }
        public float RicochetChanceHVestsEliteLevel { get; set; }
        public float RicochetChanceHVestsMaxDurabilityThreshold { get; set; }
        public float MeleeDamageLVestsReducePerLevel { get; set; }
        public float MoveSpeedPenaltyReductionLVestsReducePerLevel { get; set; }
        public float WearAmountRepairLVestsReducePerLevel { get; set; }
        public float WearChanceRepairLVestsReduceEliteLevel { get; set; }
    }

    public class ArmorCounters
    {
        public SkillCounter armorDurability { get; set; }
    }

    public class HideoutManagement
    {
        public float SkillPointsPerAreaUpgrade { get; set; }
        public float SkillPointsPerCraft { get; set; }
        public float ConsumptionReductionPerLevel { get; set; }
        public float SkillBoostPercent { get; set; }
        public SkillPointsRate SkillPointsRate { get; set; }
        public EliteSlots EliteSlots { get; set; }
    }

    public class SkillPointsRate
    {
        public SkillPointRate Generator { get; set; }
        public SkillPointRate AirFilteringUnit { get; set; }
        public SkillPointRate WaterCollector { get; set; }
        public SkillPointRate SolarPower { get; set; }
    }

    public class SkillPointRate
    {
        public float ResourceSpent { get; set; }
        public float PointsGained { get; set; }
    }

    public class EliteSlots
    {
        public EliteSlot Generator { get; set; }
        public EliteSlot AirFilteringUnit { get; set; }
        public EliteSlot WaterCollector { get; set; }
        public EliteSlot BitcoinFarm { get; set; }
    }

    public class EliteSlot
    {
        public int Slots { get; set; }
        public int Container { get; set; }
    }

    public class Crafting
    {
        public float PointsPerCraftingCycle { get; set; }
        public int CraftingCycleHours { get; set; }
        public float PointsPerUniqueCraftCycle { get; set; }
        public int UniqueCraftsPerCycle { get; set; }
        public float CraftTimeReductionPerLevel { get; set; }
        public float ProductionTimeReductionPerLevel { get; set; }
        public int EliteExtraProductions { get; set; }
        public float CraftingPointsToInteligence { get; set; }
    }

    public class Metabolism
    {
        public float HydrationRecoveryRate { get; set; }
        public float EnergyRecoveryRate { get; set; }
        public float IncreasePositiveEffectDurationRate { get; set; }
        public float DecreaseNegativeEffectDurationRate { get; set; }
        public float DecreasePoisonDurationRate { get; set; }
    }

    public class Immunity
    {
        public float ImmunityMiscEffects { get; set; }
        public float ImmunityPoisonBuff { get; set; }
        public float ImmunityPainKiller { get; set; }
        public float HealthNegativeEffect { get; set; }
        public float StimulatorNegativeBuff { get; set; }
    }

    public class Endurance
    {
        public float MovementAction { get; set; }
        public float SprintAction { get; set; }
        public float GainPerFatigueStack { get; set; }
        public List<DependentSkillRatio> DependentSkillRatios { get; set; }
        public Dictionary<string, Dictionary<string, float>> QTELevelMultipliers { get; set; }
    }

    public class DependentSkillRatio
    {
        public string Skill { get; set; }
        public float Ratio { get; set; }
    }

    public class Strength
    {
        public List<DependentSkillRatio> DependentSkillRatios { get; set; }
        public float SprintActionMin { get; set; }
        public float SprintActionMax { get; set; }
        public float MovementActionMin { get; set; }
        public float MovementActionMax { get; set; }
        public float PushUpMin { get; set; }
        public float PushUpMax { get; set; }
        public List<QTELevelMultiplier> QTELevelMultipliers { get; set; }
        public float FistfightAction { get; set; }
        public float ThrowAction { get; set; }
    }

    public class QTELevelMultiplier
    {
        public int Level { get; set; }
        public float Multiplier { get; set; }
    }

    public class Vitality
    {
        public float DamageTakenAction { get; set; }
        public float HealthNegativeEffect { get; set; }
    }

    public class HealthSkillProgress
    {
        public float SkillProgress { get; set; }
    }

    public class StressResistance
    {
        public float HealthNegativeEffect { get; set; }
        public float LowHPDuration { get; set; }
    }

    public class Throwing
    {
        public float ThrowAction { get; set; }
    }

    public class RecoilControl
    {
        public float RecoilAction { get; set; }
        public float RecoilBonusPerLevel { get; set; }
    }

    public class WeaponSkills
    {
        public float WeaponReloadAction { get; set; }
        public float WeaponShotAction { get; set; }
        public float WeaponFixAction { get; set; }
        public float WeaponChamberAction { get; set; }
    }

    public class CovertMovement
    {
        public float MovementAction { get; set; }
    }

    public class Search
    {
        public float SearchAction { get; set; }
        public float FindAction { get; set; }
    }

    public class WeaponTreatment
    {
        public int BuffMaxCount { get; set; }
        public BuffSettings BuffSettings { get; set; }
        public WeaponTreatmentCounters Counters { get; set; }
        public float DurLossReducePerLevel { get; set; }
        public float SkillPointsPerRepair { get; set; }
        public List<object> Filter { get; set; }
        public float WearAmountRepairGunsReducePerLevel { get; set; }
        public float WearChanceRepairGunsReduceEliteLevel { get; set; }
    }

    public class WeaponTreatmentCounters
    {
        public SkillCounter firearmsDurability { get; set; }
    }

    public class BuffSettings
    {
        public float CommonBuffChanceLevelBonus { get; set; }
        public float CommonBuffMinChanceValue { get; set; }
        public float? CurrentDurabilityLossToRemoveBuff { get; set; }
        public float? MaxDurabilityLossToRemoveBuff { get; set; }
        public float RareBuffChanceCoff { get; set; }
        public float ReceivedDurabilityMaxPercent { get; set; }
    }

    public class MagDrills
    {
        public float RaidLoadedAmmoAction { get; set; }
        public float RaidUnloadedAmmoAction { get; set; }
        public float MagazineCheckAction { get; set; }
    }

    public class Perception
    {
        public List<SkillRatio> DependentSkillRatios { get; set; }
        public float OnlineAction { get; set; }
        public float UniqueLoot { get; set; }
    }

    public class SkillRatio
    {
        public float Ratio { get; set; }
        public string SkillId { get; set; }
    }

    public class Intellect
    {
        public IntellectCounters Counters { get; set; }
        public float ExamineAction { get; set; }
        public float SkillProgress { get; set; }
        public float RepairAction { get; set; }
        public float WearAmountReducePerLevel { get; set; }
        public float WearChanceReduceEliteLevel { get; set; }
        public float RepairPointsCostReduction { get; set; }
    }

    public class IntellectCounters
    {
        public SkillCounter armorDurability { get; set; }
        public SkillCounter firearmsDurability { get; set; }
        public SkillCounter meleeWeaponDurability { get; set; }
    }

    public class SkillCounter
    {
        public float divisor { get; set; }
        public int points { get; set; }
    }

    public class Attention
    {
        public List<SkillRatio> DependentSkillRatios { get; set; }
        public float ExamineWithInstruction { get; set; }
        public float FindActionFalse { get; set; }
        public float FindActionTrue { get; set; }
    }

    public class Charisma
    {
        public BonusSettings BonusSettings { get; set; }
        public CharismaSkillCounters Counters { get; set; }
        public float SkillProgressInt { get; set; }
        public float SkillProgressAtn { get; set; }
        public float SkillProgressPer { get; set; }
    }

    public class CharismaSkillCounters
    {
        public SkillCounter insuranceCost { get; set; }
        public SkillCounter repairCost { get; set; }
        public SkillCounter repeatableQuestCompleteCount { get; set; }
        public SkillCounter restoredHealthCost { get; set; }
        public SkillCounter scavCaseCost { get; set; }
    }

    public class BonusSettings
    {
        public EliteBonusSettings EliteBonusSettings { get; set; }
        public LevelBonusSettings LevelBonusSettings { get; set; }
    }

    public class EliteBonusSettings
    {
        public float FenceStandingLossDiscount { get; set; }
        public int RepeatableQuestExtraCount { get; set; }
        public float ScavCaseDiscount { get; set; }
    }

    public class LevelBonusSettings
    {
        public float HealthRestoreDiscount { get; set; }
        public float HealthRestoreTraderDiscount { get; set; }
        public float InsuranceDiscount { get; set; }
        public float InsuranceTraderDiscount { get; set; }
        public float PaidExitDiscount { get; set; }
        public float RepeatableQuestChangeDiscount { get; set; }
    }

    public class Memory
    {
        public float AnySkillUp { get; set; }
        public float SkillProgress { get; set; }
    }

    public class Surgery
    {
        public float SurgeryAction { get; set; }
        public float SkillProgress { get; set; }
    }

    public class AimDrills
    {
        public float WeaponShotAction { get; set; }
    }

    public class TroubleShooting
    {
        public float MalfRepairSpeedBonusPerLevel { get; set; }
        public float SkillPointsPerMalfFix { get; set; }
        public float EliteDurabilityChanceReduceMult { get; set; }
        public float EliteAmmoChanceReduceMult { get; set; }
        public float EliteMagChanceReduceMult { get; set; }
    }

    public class Aiming
    {
        public Xyz ProceduralIntensityByPose { get; set; }
        public float AimProceduralIntensity { get; set; }
        public float HeavyWeight { get; set; }
        public float LightWeight { get; set; }
        public float MaxTimeHeavy { get; set; }
        public float MinTimeHeavy { get; set; }
        public float MaxTimeLight { get; set; }
        public float MinTimeLight { get; set; }
        public float RecoilScaling { get; set; }
        public float RecoilDamping { get; set; }
        public float CameraSnapGlobalMult { get; set; }
        public Xyz RecoilXIntensityByPose { get; set; }
        public Xyz RecoilYIntensityByPose { get; set; }
        public Xyz RecoilZIntensityByPose { get; set; }
        public bool RecoilCrank { get; set; }
        public float RecoilHandDamping { get; set; }
        public float RecoilConvergenceMult { get; set; }
        public float RecoilVertBonus { get; set; }
        public float RecoilBackBonus { get; set; }
    }

    public class Malfunction
    {
        public float AmmoMalfChanceMult { get; set; }
        public float MagazineMalfChanceMult { get; set; }
        public float MalfRepairHardSlideMult { get; set; }
        public float MalfRepairOneHandBrokenMult { get; set; }
        public float MalfRepairTwoHandsBrokenMult { get; set; }
        public bool AllowMalfForBots { get; set; }
        public int ShowGlowAttemptsCount { get; set; }
        public float OutToIdleSpeedMultForPistol { get; set; }
        public float IdleToOutSpeedMultOnMalf { get; set; }
        public float TimeToQuickdrawPistol { get; set; }
        public Xyz DurRangeToIgnoreMalfs { get; set; }
        public float DurFeedWt { get; set; }
        public float DurMisfireWt { get; set; }
        public float DurJamWt { get; set; }
        public float DurSoftSlideWt { get; set; }
        public float DurHardSlideMinWt { get; set; }
        public float DurHardSlideMaxWt { get; set; }
        public float AmmoMisfireWt { get; set; }
        public float AmmoFeedWt { get; set; }
        public float AmmoJamWt { get; set; }
        public float OverheatFeedWt { get; set; }
        public float OverheatJamWt { get; set; }
        public float OverheatSoftSlideWt { get; set; }
        public float OverheatHardSlideMinWt { get; set; }
        public float OverheatHardSlideMaxWt { get; set; }
    }

    public class Overheat
    {
        public float MinOverheat { get; set; }
        public float MaxOverheat { get; set; }
        public float OverheatProblemsStart { get; set; }
        public float ModHeatFactor { get; set; }
        public float ModCoolFactor { get; set; }
        public float MinWearOnOverheat { get; set; }
        public float MaxWearOnOverheat { get; set; }
        public float MinWearOnMaxOverheat { get; set; }
        public float MaxWearOnMaxOverheat { get; set; }
        public float OverheatWearLimit { get; set; }
        public float MaxCOIIncreaseMult { get; set; }
        public float MinMalfChance { get; set; }
        public float MaxMalfChance { get; set; }
        public float DurReduceMinMult { get; set; }
        public float DurReduceMaxMult { get; set; }
        public float BarrelMoveRndDuration { get; set; }
        public float BarrelMoveMaxMult { get; set; }
        public float FireratePitchMult { get; set; }
        public float FirerateReduceMinMult { get; set; }
        public float FirerateReduceMaxMult { get; set; }
        public float FirerateOverheatBorder { get; set; }
        public bool EnableSlideOnMaxOverheat { get; set; }
        public float StartSlideOverheat { get; set; }
        public float FixSlideOverheat { get; set; }
        public float AutoshotMinOverheat { get; set; }
        public float AutoshotChance { get; set; }
        public float AutoshotPossibilityDuration { get; set; }
        public float MaxOverheatCoolCoef { get; set; }
    }

    public class FenceSettings
    {
        public string FenceId { get; set; }
        public Dictionary<string, FenceLevel> Levels { get; set; }
        public float paidExitStandingNumerator { get; set; }
    }

    public class FenceLevel
    {
        public float SavageCooldownModifier { get; set; }
        public float ScavCaseTimeModifier { get; set; }
        public float PaidExitCostModifier { get; set; }
        public float BotFollowChance { get; set; }
        public float ScavEquipmentSpawnChanceModifier { get; set; }
        public float PriceModifier { get; set; }
        public bool HostileBosses { get; set; }
        public bool HostileScavs { get; set; }
        public bool ScavAttackSupport { get; set; }
        public float ExfiltrationPriceModifier { get; set; }
        public int AvailableExits { get; set; }
        public float BotApplySilenceChance { get; set; }
        public float BotGetInCoverChance { get; set; }
        public float BotHelpChance { get; set; }
        public float BotSpreadoutChance { get; set; }
        public float BotStopChance { get; set; }
        public float PriceModTaxi { get; set; }
        public float PriceModDelivery { get; set; }
        public float PriceModCleanUp { get; set; }
        public Xyz DeliveryGridSize { get; set; }
        public bool CanInteractWithBtr { get; set; }
    }

    public class Inertia
    {
        public Xyz InertiaLimits { get; set; }
        public float InertiaLimitsStep { get; set; }
        public Xyz ExitMovementStateSpeedThreshold { get; set; }
        public Xyz WalkInertia { get; set; }
        public float FallThreshold { get; set; }
        public Xyz SpeedLimitAfterFallMin { get; set; }
        public Xyz SpeedLimitAfterFallMax { get; set; }
        public Xyz SpeedLimitDurationMin { get; set; }
        public Xyz SpeedLimitDurationMax { get; set; }
        public Xyz SpeedInertiaAfterJump { get; set; }
        public float BaseJumpPenaltyDuration { get; set; }
        public float DurationPower { get; set; }
        public float BaseJumpPenalty { get; set; }
        public float PenaltyPower { get; set; }
        public Xyz InertiaTiltCurveMin { get; set; }
        public Xyz InertiaTiltCurveMax { get; set; }
        public Xyz InertiaBackwardCoef { get; set; }
        public Xyz TiltInertiaMaxSpeed { get; set; }
        public Xyz TiltStartSideBackSpeed { get; set; }
        public Xyz TiltMaxSideBackSpeed { get; set; }
        public Xyz TiltAcceleration { get; set; }
        public int AverageRotationFrameSpan { get; set; }
        public Xyz SprintSpeedInertiaCurveMin { get; set; }
        public Xyz SprintSpeedInertiaCurveMax { get; set; }
        public Xyz SprintBrakeInertia { get; set; }
        public Xyz SprintTransitionMotionPreservation { get; set; }
        public Xyz WeaponFlipSpeed { get; set; }
        public Xyz PreSprintAccelerationLimits { get; set; }
        public Xyz SprintAccelerationLimits { get; set; }
        public Xyz SideTime { get; set; }
        public Xyz DiagonalTime { get; set; }
        public Xyz MaxTimeWithoutInput { get; set; }
        public float MinDirectionBlendTime { get; set; }
        public Xyz MoveTimeRange { get; set; }
        public Xyz ProneDirectionAccelerationRange { get; set; }
        public Xyz ProneSpeedAccelerationRange { get; set; }
        public Xyz MinMovementAccelerationRangeRight { get; set; }
        public Xyz MaxMovementAccelerationRangeRight { get; set; }
    }

    public class Ballistic
    {
        public float GlobalDamageDegradationCoefficient { get; set; }
    }

    public class RepairSettings
    {
        public ItemEnhancementSettings ItemEnhancementSettings { get; set; }
        public int MinimumLevelToApplyBuff { get; set; }
        public RepairStrategies RepairStrategies { get; set; }
        public int armorClassDivisor { get; set; }
        public float durabilityPointCostArmor { get; set; }
        public float durabilityPointCostGuns { get; set; }
    }

    public class ItemEnhancementSettings
    {
        public PriceModifier DamageReduction { get; set; }
        public PriceModifier MalfunctionProtections { get; set; }
        public PriceModifier WeaponSpread { get; set; }
    }

    public class PriceModifier
    {
        [JsonProperty("PriceModifier")]
        public float priceModifier { get; set; }
    }

    public class RepairStrategies
    {
        public RepairStrategy Armor { get; set; }
        public RepairStrategy Firearms { get; set; }
    }

    public class RepairStrategy
    {
        public IEnumerable<string> BuffTypes { get; set; }
        public IEnumerable<string> Filter { get; set; }
    }

    public class BotPreset
    {
        public bool UseThis { get; set; }
        public string Role { get; set; }
        public string BotDifficulty { get; set; }
        public float VisibleAngle { get; set; }
        public float VisibleDistance { get; set; }
        public float ScatteringPerMeter { get; set; }
        public float HearingSense { get; set; }
        public float SCATTERING_DIST_MODIF { get; set; }
        public float MAX_AIMING_UPGRADE_BY_TIME { get; set; }
        public float FIRST_CONTACT_ADD_SEC { get; set; }
        public float COEF_IF_MOVE { get; set; }
    }

    public class AudioSettings
    {
        public IEnumerable<AudioGroupPreset> AudioGroupPresets { get; set; }
    }

    public class AudioGroupPreset
    {
        public float AngleToAllowBinaural { get; set; }
        public bool DisabledBinauralByDistance { get; set; }
        public float DistanceToAllowBinaural { get; set; }
        public int GroupType { get; set; }
        public float HeightToAllowBinaural { get; set; }
        public string Name { get; set; }
        public bool OcclusionEnabled { get; set; }
        public float OcclusionIntensity { get; set; }
        public float OverallVolume { get; set; }
    }

    public class EnvironmentSettings
    {
        public float SnowStepsVolumeMultiplier { get; set; }
        public IEnumerable<SurfaceMultiplier> SurfaceMultipliers { get; set; }
    }

    public class SurfaceMultiplier
    {
        public string SurfaceType { get; set; }
        public float VolumeMult { get; set; }
    }

    public class BotWeaponScattering
    {
        public string Name { get; set; }
        public float PriorityScatter1meter { get; set; }
        public float PriorityScatter10meter { get; set; }
        public float PriorityScatter100meter { get; set; }
    }

    public class Preset
    {
        public string _id { get; set; }
        public string _type { get; set; }
        public bool _changeWeaponName { get; set; }
        public string _name { get; set; }
        public string _parent { get; set; }
        public IEnumerable<Item> _items { get; set; }
        public string _encyclopedia { get; set; }
    }
}
