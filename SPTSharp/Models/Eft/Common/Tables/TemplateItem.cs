#pragma warning disable
using System.Drawing;
using System;
using Newtonsoft.Json;

namespace SPTSharp.Models.Eft.Common.Tables
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TemplateItem
    {
        public string _id { get; set; }
        
        public string _name { get; set; }
        
        public string _parent { get; set; }
        
        public string _type { get; set; }
        
        public Props _props { get; set; }
        
        public string _proto { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Props
    {
        public List<object> AllowSpawnOnLocations { get; set; }
        public float? ChangePriceCoef { get; set; }
        public bool? FixedPrice { get; set; }
        public bool? SendToClient { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public float? Weight { get; set; }
        public string BackgroundColor { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? StackMaxSize { get; set; }
        public string Rarity { get; set; }
        public float? SpawnChance { get; set; }
        public int? CreditsPrice { get; set; }
        public string ItemSound { get; set; }
        public Prefab Prefab { get; set; }
        public Prefab UsePrefab { get; set; }
        public int? StackObjectsCount { get; set; }
        public bool? NotShownInSlot { get; set; }
        public bool? ExaminedByDefault { get; set; }
        public int? ExamineTime { get; set; }
        public bool? IsUndiscardable { get; set; }
        public bool? IsUnsaleable { get; set; }
        public bool? IsUnbuyable { get; set; }
        public bool? IsUngivable { get; set; }
        public bool? IsLockedafterEquip { get; set; }
        public bool? IsStationaryWeapon { get; set; }
        public bool? QuestItem { get; set; }
        public int? LootExperience { get; set; }
        public int? ExamineExperience { get; set; }
        public bool? HideEntrails { get; set; }
        public int? RepairCost { get; set; }
        public int? RepairSpeed { get; set; }
        public int? ExtraSizeLeft { get; set; }
        public int? ExtraSizeRight { get; set; }
        public int? ExtraSizeUp { get; set; }
        public int? ExtraSizeDown { get; set; }
        public bool? ExtraSizeForceAdd { get; set; }
        public bool? MergesWithChildren { get; set; }
        public bool? CanSellOnRagfair { get; set; }
        public bool? CanRequireOnRagfair { get; set; }
        public List<string> ConflictingItems { get; set; }
        public bool? Unlootable { get; set; }
        public string UnlootableFromSlot { get; set; }
        public List<string> UnlootableFromSide { get; set; }
        public int? AnimationVariantsNumber { get; set; }
        public bool? DiscardingBlock { get; set; }
        public int? RagFairCommissionModifier { get; set; }
        public bool? IsAlwaysAvailableForInsurance { get; set; }
        public int? DiscardLimit { get; set; }
        public string DropSoundType { get; set; }
        public bool? InsuranceDisabled { get; set; }
        public int? QuestStashMaxCount { get; set; }
        public bool? IsSpecialSlotOnly { get; set; }
        public bool? IsUnremovable { get; set; } //HERE
        public float? knifeHitDelay { get; set; }
        public float? knifeHitSlashRate { get; set; }
        public float? knifeHitStabRate { get; set; }
        public float? knifeHitRadius { get; set; }
        public float? knifeHitSlashDam { get; set; }
        public float? knifeHitStabDam { get; set; }
        public float? knifeDurab { get; set; }
        public int? foodUseTime { get; set; }
        public string foodEffectType { get; set; }
        public int? MaxResource { get; set; }
        public int? Resource { get; set; }
        public bool? DogTagQualities { get; set; }
        public Grid[]? Grids { get; set; }
        public Slot[]? Slots { get; set; }
        public bool? CanPutIntoDuringTheRaid { get; set; }
        public List<string> CantRemoveFromSlotsDuringRaid { get; set; }
        public int? Durability { get; set; }
        public List<string> KeyIds { get; set; }
        public int? Accuracy { get; set; }
        public float? Recoil { get; set; }
        public int? Loudness { get; set; }
        public int? EffectiveDistance { get; set; }
        public float? Ergonomics { get; set; }
        public float? Velocity { get; set; }
        public bool? WithAnimatorAiming { get; set; }
        public bool? RaidModdable { get; set; }
        public bool? ToolModdable { get; set; }
        public bool? BlocksFolding { get; set; }
        public bool? BlocksCollapsible { get; set; }
        public bool? IsAnimated { get; set; }
        public bool? HasShoulderContact { get; set; }
        public int? SightingRange { get; set; }
        public float? DoubleActionAccuracyPenaltyMult { get; set; }
        public int? UniqueAnimationModID { get; set; }
        public string LinkedWeapon { get; set; }
        public bool? UseAmmoWithoutShell { get; set; }
        public object ModesCount { get; set; }
        public string muzzleModType { get; set; }
        public string CustomAimPlane { get; set; }
        public string SightModType { get; set; }
        public int? AimingSensitivity { get; set; }
        public int? SightModesCount { get; set; }
        public List<int> OpticCalibrationDistances { get; set; }
        public int? ScopesCount { get; set; }
        public object AimSensitivity { get; set; }
        public List<List<float>> Zooms { get; set; }
        public List<List<float>> CalibrationDistances { get; set; }
        public float? Intensity { get; set; }
        public string Mask { get; set; }
        public float? MaskSize { get; set; }
        public float? NoiseIntensity { get; set; }
        public float? NoiseScale { get; set; }
        public IColor Color { get; set; }
        public float? DiffuseIntensity { get; set; }
        public string RampPalette { get; set; }
        public float? DepthFade { get; set; }
        public float? RoughnessCoef { get; set; }
        public float? SpecularCoef { get; set; }
        public float? MainTexColorCoef { get; set; }
        public float? MinimumTemperatureValue { get; set; }
        public float? RampShift { get; set; }
        public float? HeatMin { get; set; }
        public float? ColdMax { get; set; }
        public bool? IsNoisy { get; set; }
        public bool? IsFpsStuck { get; set; }
        public bool? IsGlitch { get; set; }
        public bool? IsMotionBlurred { get; set; }
        public bool? IsPixelated { get; set; }
        public int? PixelationBlockCount { get; set; }
        public float? ShiftsAimCamera { get; set; }
        public int? magAnimationIndex { get; set; }
        public List<Slot> Cartridges { get; set; }
        public bool? CanFast { get; set; }
        public bool? CanHit { get; set; }
        public bool? CanAdmin { get; set; }
        public int? LoadUnloadModifier { get; set; }
        public int? CheckTimeModifier { get; set; }
        public int? CheckOverride { get; set; }
        public string ReloadMagType { get; set; }
        public string VisibleAmmoRangesString { get; set; }
        public float? MalfunctionChance { get; set; }
        public int? TagColor { get; set; }
        public string TagName { get; set; }
        public bool? MagazineWithBelt { get; set; }
        public int? BeltMagazineRefreshCount { get; set; }
        public bool? IsMagazineForStationaryWeapon { get; set; }
        public bool? IsShoulderContact { get; set; }
        public bool? Foldable { get; set; }
        public bool? Retractable { get; set; }
        public int? SizeReduceRight { get; set; }
        public float? CenterOfImpact { get; set; }
        public float? ShotgunDispersion { get; set; }
        public bool? IsSilencer { get; set; }
        public float? DurabilityBurnModificator { get; set; }
        public float? HeatFactor { get; set; }
        public float? CoolFactor { get; set; }
        public float? DeviationCurve { get; set; }
        public float? DeviationMax { get; set; }
        public string SearchSound { get; set; }
        public bool? BlocksArmorVest { get; set; }
        public float? speedPenaltyPercent { get; set; }
        public string GridLayoutName { get; set; }
        public float? ContainerSpawnChanceModifier { get; set; }
        public List<string> SpawnExcludedFilter { get; set; }
        public List<object> SpawnFilter { get; set; }
        public List<object> containType { get; set; }
        public float? sizeWidth { get; set; }
        public float? sizeHeight { get; set; }
        public bool? isSecured { get; set; }
        public string spawnTypes { get; set; }
        public List<object> lootFilter { get; set; }
        public string spawnRarity { get; set; }
        public int? minCountSpawn { get; set; }
        public int? maxCountSpawn { get; set; }
        public List<string> openedByKeyID { get; set; }
        public string RigLayoutName { get; set; }
        public List<string> ArmorZone { get; set; }

        // String or int, stupid.
        public dynamic armorClass { get; set; }
        public bool? BluntDamageReduceFromSoftArmor { get; set; }
        public string WeapClass { get; set; }
        public string WeapUseType { get; set; }
        public float? OperatingResource { get; set; }
        public Xyz PostRecoilHorizontalRangeHandRotation { get; set; }
        public Xyz PostRecoilVerticalRangeHandRotation { get; set; }
        public Xyz ProgressRecoilAngleOnStable { get; set; }
        public float? RepairComplexity { get; set; }
        public float? durabSpawnMin { get; set; }
        public float? durabSpawnMax { get; set; }
        public bool? isFastReload { get; set; }
        public float? RecoilForceUp { get; set; }
        public float? RecoilForceBack { get; set; }
        public float? RecoilAngle { get; set; }
        public float? RecoilCamera { get; set; }
        public List<string> WeapFireType { get; set; }
        public float? RecolDispersion { get; set; }
        public float? SingleFireRate { get; set; }
        public bool? CanQueueSecondShot { get; set; }
        public float? bFirerate { get; set; }
        public float? bEffDist { get; set; }
        public float? bHearDist { get; set; }
        public bool? BlockLeftStance { get; set; }
        public bool? IsChamberLoad { get; set; }
        public int? ChamberAmmoCount { get; set; }
        public bool? IsBoltCatch { get; set; }
        public string DefMagType { get; set; }
        public string DefAmmo { get; set; }
        public bool? AdjustCollimatorsToTrajectory { get; set; }
        public float? shotgunDispersion { get; set; }
        public List<Slot> Chambers { get; set; }
        public float? CameraSnap { get; set; }
        public Xyz CameraToWeaponAngleSpeedRange { get; set; }
        public float? CameraToWeaponAngleStep { get; set; }
        public string ReloadMode { get; set; }
        public float? AimPlane { get; set; }
        public Xyz TacticalReloadStiffnes { get; set; }
        public float? TacticalReloadFixation { get; set; }
        public Xyz RecoilCenter { get; set; }
        public Xyz RotationCenter { get; set; }
        public Xyz RotationCenterNoStock { get; set; }
        public List<IShotsGroupSettings> ShotsGroupSettings { get; set; }
        public string FoldedSlot { get; set; }
        public bool? CompactHandling { get; set; }
        public int? IronSightRange { get; set; }
        public bool? IsBeltMachineGun { get; set; }
        public bool? IsFlareGun { get; set; }
        public bool? IsGrenadeLauncher { get; set; }
        public bool? IsOneoff { get; set; }
        public bool? MustBoltBeOpennedForExternalReload { get; set; }
        public bool? MustBoltBeOpennedForInternalReload { get; set; }
        public bool? NoFiremodeOnBoltcatch { get; set; }
        public bool? BoltAction { get; set; }
        public float? HipAccuracyRestorationDelay { get; set; }
        public float? HipAccuracyRestorationSpeed { get; set; }
        public float? HipInnaccuracyGain { get; set; }
        public bool? ManualBoltCatch { get; set; }
        public int? BurstShotsCount { get; set; }
        public float? BaseMalfunctionChance { get; set; }
        public bool? AllowJam { get; set; }
        public bool? AllowFeed { get; set; }
        public bool? AllowMisfire { get; set; }
        public bool? AllowSlide { get; set; }
        public float? DurabilityBurnRatio { get; set; }
        public float? HeatFactorGun { get; set; }
        public float? CoolFactorGun { get; set; }
        public float? CoolFactorGunMods { get; set; }
        public float? HeatFactorByShot { get; set; }
        public bool? AllowOverheat { get; set; }
        public float? DoubleActionAccuracyPenalty { get; set; }
        public float? RecoilPosZMult { get; set; }
        public float? RecoilReturnPathDampingHandRotation { get; set; }
        public float? RecoilReturnPathOffsetHandRotation { get; set; }
        public float? RecoilReturnSpeedHandRotation { get; set; }
        public float? RecoilStableAngleIncreaseStep { get; set; }
        public float? RecoilStableIndexShot { get; set; }
        public float? MinRepairKitDegradation { get; set; }
        public float? MaxRepairKitDegradation { get; set; }
        public bool? BlocksEarpiece { get; set; }
        public bool? BlocksEyewear { get; set; }
        public bool? BlocksHeadwear { get; set; }
        public bool? BlocksFaceCover { get; set; }
        public int? MaxDurability { get; set; }
        public float? Indestructibility { get; set; }
        public List<string> HeadSegments { get; set; }
        public bool? FaceShieldComponent { get; set; }
        public string FaceShieldMask { get; set; }
        public bool? HasHinge { get; set; }
        public string MaterialType { get; set; }
        public Xyz RicochetParams { get; set; }
        public string DeafStrength { get; set; }
        public float? BluntThroughput { get; set; }
        public string ArmorMaterial { get; set; }
        public float? BlindnessProtection { get; set; }
        public string ArmorType { get; set; }
        public List<string> armorColliders { get; set; }
        public List<string> armorPlateColliders { get; set; }
        public float? mousePenalty { get; set; }
        public float? weaponErgonomicPenalty { get; set; }
        public float? Distortion { get; set; }
        public int? CompressorTreshold { get; set; }
        public int? CompressorAttack { get; set; }
        public int? CompressorRelease { get; set; }
        public int? CompressorGain { get; set; }
        public int? CutoffFreq { get; set; }
        public float? Resonance { get; set; }
        public int? CompressorVolume { get; set; }
        public int? AmbientVolume { get; set; }
        public int? DryVolume { get; set; }
        public float? RolloffMultiplier { get; set; }
        public float? HighFrequenciesGain { get; set; }
        public int? ReverbVolume { get; set; }
        public int? medUseTime { get; set; }
        public string medEffectType { get; set; }
        public int? MaxHpResource { get; set; }
        public int? hpResourceRate { get; set; }
        public string StimulatorBuffs { get; set; }
        public int? MaximumNumberOfUsage { get; set; }
        public float? PrimaryDistance { get; set; }
        public float? SecondryDistance { get; set; }
        public float? SlashPenetration { get; set; }
        public float? StabPenetration { get; set; }
        public float? MinRepairDegradation { get; set; }
        public float? MaxRepairDegradation { get; set; }
        public float? PrimaryConsumption { get; set; }
        public float? SecondryConsumption { get; set; }
        public float? DeflectionConsumption { get; set; }
        public Xyz AppliedTrunkRotation { get; set; }
        public Xyz AppliedHeadRotation { get; set; }
        public bool? DisplayOnModel { get; set; }
        public int? AdditionalAnimationLayer { get; set; }
        public float? StaminaBurnRate { get; set; }
        public Xyz ColliderScaleMultiplier { get; set; }
        public string ConfigPathStr { get; set; }
        public int? MaxMarkersCount { get; set; }
        public float? ScaleMin { get; set; }
        public float? ScaleMax { get; set; }
        public float? ApResource { get; set; }
        public float? KrResource { get; set; }
        public float? MaxOpticZoom { get; set; }
        public float? MaxRepairResource { get; set; }
        public List<string> TargetItemFilter { get; set; }
        public float? RepairQuality { get; set; }
        public string RepairType { get; set; }
        public float? StackMinRandom { get; set; }
        public float? StackMaxRandom { get; set; }
        public string ammoCaliber { get; set; }
        public string ammoType { get; set; }
        public int? InitialSpeed { get; set; }
        public float? BallisticCoeficient { get; set; }
        public float? BulletMassGram { get; set; }
        public float? BulletDiameterMilimeters { get; set; }
        public int? Damage { get; set; }
        public int? ammoAccr { get; set; }
        public int? ammoRec { get; set; }
        public int? ammoDist { get; set; }
        public int? buckshotBullets { get; set; }
        public float? PenetrationPower { get; set; }
        public float? PenetrationPowerDiviation { get; set; }
        public float? ammoHear { get; set; }
        public string ammoSfx { get; set; }
        public float? MisfireChance { get; set; }
        public float? MinFragmentsCount { get; set; }
        public float? MaxFragmentsCount { get; set; }
        public float? ammoShiftChance { get; set; }
        public string casingName { get; set; }
        public float? casingEjectPower { get; set; }
        public float? casingMass { get; set; }
        public string casingSounds { get; set; }
        public float? ProjectileCount { get; set; }
        public float? PenetrationChance { get; set; }
        public float? RicochetChance { get; set; }
        public float? FragmentationChance { get; set; }
        public float? Deterioration { get; set; }
        public decimal? SpeedRetardation { get; set; }
        public bool? Tracer { get; set; }
        public string TracerColor { get; set; }
        public float? TracerDistance { get; set; }
        public float? ArmorDamage { get; set; }
        public string Caliber { get; set; }
        public float? StaminaBurnPerDamage { get; set; }
        public float? HeavyBleedingDelta { get; set; }
        public float? LightBleedingDelta { get; set; }
        public bool? ShowBullet { get; set; }
        public bool? HasGrenaderComponent { get; set; }
        public float? FuzeArmTimeSec { get; set; }
        public float? ExplosionStrength { get; set; }
        public float? MinExplosionDistance { get; set; }
        public float? MaxExplosionDistance { get; set; }
        public float? FragmentsCount { get; set; }
        public string FragmentType { get; set; }
        public bool? ShowHitEffectOnExplode { get; set; }
        public string ExplosionType { get; set; }
        public float? AmmoLifeTimeSec { get; set; }
        public Xyz Contusion { get; set; }
        public Xyz ArmorDistanceDistanceDamage { get; set; }
        public Xyz Blindness { get; set; }
        public bool? IsLightAndSoundShot { get; set; }
        public float? LightAndSoundShotAngle { get; set; }
        public float? LightAndSoundShotSelfContusionTime { get; set; }
        public float? LightAndSoundShotSelfContusionStrength { get; set; }
        public float? MalfMisfireChance { get; set; }
        public float? MalfFeedChance { get; set; }
        public List<StackSlot> StackSlots { get; set; }
        public string Type { get; set; }
        public float? EqMin { get; set; }
        public float? EqMax { get; set; }
        public float? Rate { get; set; }
        public string ThrowType { get; set; }
        public float? ExplDelay { get; set; }
        public float? Strength { get; set; }
        public float? ContusionDistance { get; set; }
        public float? ThrowDamMax { get; set; }
        public float? explDelay { get; set; }
        public float? EmitTime { get; set; }
        public bool? CanBeHiddenDuringThrow { get; set; }
        public float? MinTimeToContactExplode { get; set; }
        public string ExplosionEffectType { get; set; }
        public IRandomLootSettings RandomLootSettings { get; set; }
        public float? RecoilCategoryMultiplierHandRotation { get; set; }
        public float? RecoilDampingHandRotation { get; set; }
        public bool? LeanWeaponAgainstBody { get; set; }
        public bool? RemoveShellAfterFire { get; set; }
        public List<string> RepairStrategyTypes { get; set; }
        public bool? IsEncoded { get; set; }
        public string LayoutName { get; set; }
        public Prefab Lower75Prefab { get; set; }
        
        [JsonProperty("effects_health")]
        public object EffectsHealth { get; set; }

        [JsonProperty("effects_damage")]
        public object EffectsDamage { get; set; }
        public float? MaxUsages { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class IHealthEffect
    {
        public string Type { get; set; }
        public float Value { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Prefab
    {
        public string path { get; set; }
        public string rcid { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Grid
    {
        public string _name { get; set; }
        public string _id { get; set; }
        public string _parent { get; set; }
        public GridProps _props { get; set; }
        public string _proto { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GridProps
    {
        public List<GridFilter> filters { get; set; }
        public int cellsH { get; set; }
        public int cellsV { get; set; }
        public int minCount { get; set; }
        public int maxCount { get; set; }
        public int maxWeight { get; set; }
        public bool isSortingTable { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GridFilter
    {
        public List<string> Filter { get; set; }
        public List<string> ExcludedFilter { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Slot
    {
        public string _name { get; set; }
        public string _id { get; set; }
        public string _parent { get; set; }
        public int? _max_count { get; set; }
        public SlotProps _props { get; set; }
        public bool? _required { get; set; }
        public bool? _mergeSlotWithChildren { get; set; }
        public string _proto { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SlotProps
    {
        public List<SlotFilter> filters { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SlotFilter
    {
        public int? AnimationIndex { get; set; }
        public int? Shift { get; set; }
        public bool? locked { get; set; }
        public string Plate { get; set; }
        public List<string> Filter { get; set; }
        public List<string> armorColliders { get; set; }
        public List<string> armorPlateColliders { get; set; }
        public int? MaxStackCount { get; set; }
        public bool? bluntDamageReduceFromSoftArmor { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class StackSlot
    {
        public string _name { get; set; }
        public string _id { get; set; }
        public string _parent { get; set; }
        public int _max_count { get; set; }
        public StackSlotProps _props { get; set; }
        public string _proto { get; set; }
        public object Upd { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class StackSlotProps
    {
        public List<SlotFilter> filters { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class IRandomLootSettings
    {
        public bool AllowToSpawnIdenticalItems { get; set; }
        public bool AllowToSpawnQuestItems { get; set; }
        public List<object> CountByRarity { get; set; }
        public IRandomLootExcluded Excluded { get; set; }
        public List<object> Filters { get; set; }
        public bool FindInRaid { get; set; }
        public int MaxCount { get; set; }
        public int MinCount { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class IRandomLootExcluded
    {
        public List<object> CategoryTemplates { get; set; }
        public List<string> Rarity { get; set; }
        public List<object> Templates { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class EffectsHealth
    {
        public EffectsHealthProps Energy { get; set; }
        public EffectsHealthProps Hydration { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class EffectsHealthProps
    {
        public float Value { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class EffectsDamage
    {
        public IEffectDamageProps Pain { get; set; }
        public IEffectDamageProps LightBleeding { get; set; }
        public IEffectDamageProps HeavyBleeding { get; set; }
        public IEffectDamageProps Contusion { get; set; }
        public IEffectDamageProps RadExposure { get; set; }
        public IEffectDamageProps Fracture { get; set; }
        public IEffectDamageProps DestroyedPart { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class IEffectDamageProps
    {
        public float Delay { get; set; }
        public float Duration { get; set; }
        public float FadeOut { get; set; }
        public float? Cost { get; set; }
        public float? HealthPenaltyMin { get; set; }
        public float? HealthPenaltyMax { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class IColor
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class IShotsGroupSettings
    {
        public int StartShotIndex { get; set; }
        public int EndShotIndex { get; set; }
        public Xyz ShotRecoilRotationStrength { get; set; }
        public Xyz ShotRecoilPositionStrength { get; set; }
        public Xyz ShotRecoilRadianRange { get; set; }

    }
}
