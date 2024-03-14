#pragma warning disable
using System.Drawing;
using System;
using Newtonsoft.Json;

namespace SPTSharp.Models.Eft.Common.Tables
{
    public class TemplateItem
    {
        [JsonProperty("_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string _id { get; set; }
        
        [JsonProperty("_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string _name { get; set; }
        
        [JsonProperty("_parent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string _parent { get; set; }
        
        [JsonProperty("_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string _type { get; set; }
        
        [JsonProperty("_props", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Props _props { get; set; }
        
        [JsonProperty("_proto", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string _proto { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Props
    {
        public List<object> AllowSpawnOnLocations { get; set; }
        public int? BeltMagazineRefreshCount { get; set; }
        public double? ChangePriceCoef { get; set; }
        public bool? FixedPrice { get; set; }
        public bool? SendToClient { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public double? Weight { get; set; }
        public string BackgroundColor { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public int? StackMaxSize { get; set; }
        public string Rarity { get; set; }
        public double? SpawnChance { get; set; }
        public double? CreditsPrice { get; set; }
        public string ItemSound { get; set; }
        public Prefab Prefab { get; set; }
        public Prefab UsePrefab { get; set; }
        public int? StackObjectsCount { get; set; }
        public bool? NotShownInSlot { get; set; }
        public bool? ExaminedByDefault { get; set; }
        public double? ExamineTime { get; set; }
        public bool? IsUndiscardable { get; set; }
        public bool? IsUnsaleable { get; set; }
        public bool? IsUnbuyable { get; set; }
        public bool? IsUngivable { get; set; }
        public bool? IsUnremovable { get; set; }
        public bool? IsLockedafterEquip { get; set; }
        public bool? IsSpecialSlotOnly { get; set; }
        public bool? IsStationaryWeapon { get; set; }
        public bool? QuestItem { get; set; }
        public int? QuestStashMaxCount { get; set; }
        public double? LootExperience { get; set; }
        public double? ExamineExperience { get; set; }
        public bool? HideEntrails { get; set; }
        public bool? InsuranceDisabled { get; set; }
        public double? RepairCost { get; set; }
        public double? RepairSpeed { get; set; }
        public double? ExtraSizeLeft { get; set; }
        public double? ExtraSizeRight { get; set; }
        public double? ExtraSizeUp { get; set; }
        public double? ExtraSizeDown { get; set; }
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
        public string DropSoundType { get; set; }
        public double? RagFairCommissionModifier { get; set; }
        public bool? IsAlwaysAvailableForInsurance { get; set; }
        public int? DiscardLimit { get; set; }
        public int? MaxResource { get; set; }
        public int? Resource { get; set; }
        public bool? DogTagQualities { get; set; }
        public List<Grid> Grids { get; set; }
        public List<Slot> Slots { get; set; }
        public bool? CanPutIntoDuringTheRaid { get; set; }
        public List<string> CantRemoveFromSlotsDuringRaid { get; set; }
        public List<string> KeyIds { get; set; }
        public int? TagColor { get; set; }
        public string TagName { get; set; }
        public int? Durability { get; set; }
        public int? Accuracy { get; set; }
        public float? Recoil { get; set; }
        public int? Loudness { get; set; }
        public int? EffectiveDistance { get; set; }
        public float? Ergonomics { get; set; }
        public float? Velocity { get; set; }
        public bool? WithAnimatorAiming { get; set; }
        public bool? RaidModdable { get; set; }
        public bool? ToolModdable { get; set; }
        public int? UniqueAnimationModID { get; set; }
        public bool? BlocksFolding { get; set; }
        public bool? BlocksCollapsible { get; set; }
        public bool? IsAnimated { get; set; }
        public bool? HasShoulderContact { get; set; }
        public int? SightingRange { get; set; }
        public float? DoubleActionAccuracyPenaltyMult { get; set; }
        public object ModesCount { get; set; }
        public float? DurabilityBurnModificator { get; set; }
        public float? HeatFactor { get; set; }
        public float? CoolFactor { get; set; }
        public string MuzzleModType { get; set; }
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
        public bool? IsMagazineForStationaryWeapon { get; set; }
        public float? NoiseIntensity { get; set; }
        public float? NoiseScale { get; set; }
        public IColor Color { get; set; }
        public float? DiffuseIntensity { get; set; }
        public bool? MagazineWithBelt { get; set; }
        public bool? HasHinge { get; set; }
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
        public int? MagAnimationIndex { get; set; }
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
        public bool? IsShoulderContact { get; set; }
        public bool? Foldable { get; set; }
        public bool? Retractable { get; set; }
        public double? SizeReduceRight { get; set; }
        public double? CenterOfImpact { get; set; }
        public double? ShotgunDispersion { get; set; }
        public bool? IsSilencer { get; set; }
        public double? DeviationCurve { get; set; }
        public double? DeviationMax { get; set; }
        public string SearchSound { get; set; }
        public bool? BlocksArmorVest { get; set; }
        public double? SpeedPenaltyPercent { get; set; }
        public string GridLayoutName { get; set; }
        public double? ContainerSpawnChanceModifier { get; set; }
        public List<string> SpawnExcludedFilter { get; set; }
        public List<object> SpawnFilter { get; set; }
        public List<object> ContainType { get; set; }
        public double? SizeWidth { get; set; }
        public double? SizeHeight { get; set; }
        public bool? IsSecured { get; set; }
        public string SpawnTypes { get; set; }
        public List<object> LootFilter { get; set; }
        public string SpawnRarity { get; set; }
        public int? MinCountSpawn { get; set; }
        public int? MaxCountSpawn { get; set; }
        public List<string> OpenedByKeyID { get; set; }
        public string RigLayoutName { get; set; }
        public int? MaxDurability { get; set; }
        public List<string> ArmorZone { get; set; }
        public string ArmorClass { get; set; }
        public List<string> ArmorColliders { get; set; }
        public List<string> ArmorPlateColliders { get; set; }
        public bool? BluntDamageReduceFromSoftArmor { get; set; }
        public double? MousePenalty { get; set; }
        public double? WeaponErgonomicPenalty { get; set; }
        public double? BluntThroughput { get; set; }
        public string ArmorMaterial { get; set; }
        public string ArmorType { get; set; }
        public string WeapClass { get; set; }
        public string WeapUseType { get; set; }
        public string AmmoCaliber { get; set; }
        public double? OperatingResource { get; set; }
        public Xyz PostRecoilHorizontalRangeHandRotation { get; set; }
        public Xyz PostRecoilVerticalRangeHandRotation { get; set; }
        public Xyz ProgressRecoilAngleOnStable { get; set; }
        public double? RepairComplexity { get; set; }
        public double? DurabSpawnMin { get; set; }
        public double? DurabSpawnMax { get; set; }
        public bool? IsFastReload { get; set; }
        public double? RecoilForceUp { get; set; }
        public double? RecoilForceBack { get; set; }
        public double? RecoilAngle { get; set; }
        public double? RecoilCamera { get; set; }
        public List<string> WeapFireType { get; set; }
        public double? RecolDispersion { get; set; }
        public double? SingleFireRate { get; set; }
        public bool? CanQueueSecondShot { get; set; }
        public double? BFirerate { get; set; }
        public double? BEffDist { get; set; }
        public double? BHearDist { get; set; }
        public bool? BlockLeftStance { get; set; }
        public bool? IsChamberLoad { get; set; }
        public int? ChamberAmmoCount { get; set; }
        public bool? IsBoltCatch { get; set; }
        public string DefMagType { get; set; }
        public string DefAmmo { get; set; }
        public bool? AdjustCollimatorsToTrajectory { get; set; }
        public double? shotgunDispersion { get; set; }
        public List<Slot> Chambers { get; set; }
        public double? CameraSnap { get; set; }
        public Xyz CameraToWeaponAngleSpeedRange { get; set; }
        public double? CameraToWeaponAngleStep { get; set; }
        public string ReloadMode { get; set; }
        public double? AimPlane { get; set; }
        public Xyz TacticalReloadStiffnes { get; set; }
        public double? TacticalReloadFixation { get; set; }
        public Xyz RecoilCenter { get; set; }
        public Xyz RotationCenter { get; set; }
        public Xyz RotationCenterNoStock { get; set; }
        public List<IShotsGroupSettings> ShotsGroupSettings { get; set; }
        public string FoldedSlot { get; set; }
        public bool? CompactHandling { get; set; }
        public double? MinRepairDegradation { get; set; }
        public double? MaxRepairDegradation { get; set; }
        public double? IronSightRange { get; set; }
        public bool? IsBeltMachineGun { get; set; }
        public bool? IsFlareGun { get; set; }
        public bool? IsGrenadeLauncher { get; set; }
        public bool? IsOneoff { get; set; }
        public bool? MustBoltBeOpennedForExternalReload { get; set; }
        public bool? MustBoltBeOpennedForInternalReload { get; set; }
        public bool? NoFiremodeOnBoltcatch { get; set; }
        public bool? BoltAction { get; set; }
        public double? HipAccuracyRestorationDelay { get; set; }
        public double? HipAccuracyRestorationSpeed { get; set; }
        public double? HipInnaccuracyGain { get; set; }
        public bool? ManualBoltCatch { get; set; }
        public int? BurstShotsCount { get; set; }
        public double? BaseMalfunctionChance { get; set; }
        public bool? AllowJam { get; set; }
        public bool? AllowFeed { get; set; }
        public bool? AllowMisfire { get; set; }
        public bool? AllowSlide { get; set; }
        public double? DurabilityBurnRatio { get; set; }
        public double? HeatFactorGun { get; set; }
        public double? CoolFactorGun { get; set; }
        public double? CoolFactorGunMods { get; set; }
        public double? HeatFactorByShot { get; set; }
        public bool? AllowOverheat { get; set; }
        public double? DoubleActionAccuracyPenalty { get; set; }
        public double? RecoilPosZMult { get; set; }
        public double? RecoilReturnPathDampingHandRotation { get; set; }
        public double? RecoilReturnPathOffsetHandRotation { get; set; }
        public double? RecoilReturnSpeedHandRotation { get; set; }
        public double? RecoilStableAngleIncreaseStep { get; set; }
        public double? RecoilStableIndexShot { get; set; }
        public double? MinRepairKitDegradation { get; set; }
        public double? MaxRepairKitDegradation { get; set; }
        public bool? BlocksEarpiece { get; set; }
        public bool? BlocksEyewear { get; set; }
        public bool? BlocksHeadwear { get; set; }
        public bool? BlocksFaceCover { get; set; }
        public double? Indestructibility { get; set; }
        public List<string> HeadSegments { get; set; }
        public bool? FaceShieldComponent { get; set; }
        public string FaceShieldMask { get; set; }
        public string MaterialType { get; set; }
        public Xyz RicochetParams { get; set; }
        public string DeafStrength { get; set; }
        public double? BlindnessProtection { get; set; }
        public double? Distortion { get; set; }
        public double? CompressorTreshold { get; set; }
        public double? CompressorAttack { get; set; }
        public double? CompressorRelease { get; set; }
        public double? CompressorGain { get; set; }
        public double? CutoffFreq { get; set; }
        public double? Resonance { get; set; }
        public double? RolloffMultiplier { get; set; }
        public double? ReverbVolume { get; set; }
        public double? CompressorVolume { get; set; }
        public double? AmbientVolume { get; set; }
        public double? DryVolume { get; set; }
        public double? HighFrequenciesGain { get; set; }
        public double? FoodUseTime { get; set; }
        public string FoodEffectType { get; set; }
        public string StimulatorBuffs { get; set; }
        public object EffectsHealth { get; set; }
        
        [JsonProperty("effects_damage")]
        public object EffectsDamage { get; set; }

        public int? MaximumNumberOfUsage { get; set; }
        public double? KnifeHitDelay { get; set; }
        public double? KnifeHitSlashRate { get; set; }
        public double? KnifeHitStabRate { get; set; }
        public double? KnifeHitRadius { get; set; }
        public double? KnifeHitSlashDam { get; set; }
        public double? KnifeHitStabDam { get; set; }
        public double? KnifeDurab { get; set; }
        public double? PrimaryDistance { get; set; }
        public double? SecondryDistance { get; set; }
        public double? SlashPenetration { get; set; }
        public double? StabPenetration { get; set; }
        public double? PrimaryConsumption { get; set; }
        public double? SecondryConsumption { get; set; }
        public double? DeflectionConsumption { get; set; }
        public Xyz AppliedTrunkRotation { get; set; }
        public Xyz AppliedHeadRotation { get; set; }
        public bool? DisplayOnModel { get; set; }
        public int? AdditionalAnimationLayer { get; set; }
        public double? StaminaBurnRate { get; set; }
        public Xyz ColliderScaleMultiplier { get; set; }
        public string ConfigPathStr { get; set; }
        public int? MaxMarkersCount { get; set; }
        public double? ScaleMin { get; set; }
        public double? ScaleMax { get; set; }
        public double? MedUseTime { get; set; }
        public string MedEffectType { get; set; }
        public double? MaxHpResource { get; set; }
        public double? HpResourceRate { get; set; }
        public double? ApResource { get; set; }
        public double? KrResource { get; set; }
        public double? MaxOpticZoom { get; set; }
        public double? MaxRepairResource { get; set; }
        public List<string> TargetItemFilter { get; set; }
        public double? RepairQuality { get; set; }
        public string RepairType { get; set; }
        public double? StackMinRandom { get; set; }
        public double? StackMaxRandom { get; set; }
        public string AmmoType { get; set; }
        public double? InitialSpeed { get; set; }
        public double? BallisticCoeficient { get; set; }
        public double? BulletMassGram { get; set; }
        public double? BulletDiameterMilimeters { get; set; }
        public double? Damage { get; set; }
        public double? AmmoAccr { get; set; }
        public double? AmmoRec { get; set; }
        public double? AmmoDist { get; set; }
        public double? BuckshotBullets { get; set; }
        public double? PenetrationPower { get; set; }
        public double? PenetrationPowerDiviation { get; set; }
        public double? AmmoHear { get; set; }
        public string AmmoSfx { get; set; }
        public double? MisfireChance { get; set; }
        public double? MinFragmentsCount { get; set; }
        public double? MaxFragmentsCount { get; set; }
        public double? AmmoShiftChance { get; set; }
        public string CasingName { get; set; }
        public double? CasingEjectPower { get; set; }
        public double? CasingMass { get; set; }
        public string CasingSounds { get; set; }
        public double? ProjectileCount { get; set; }
        public double? PenetrationChance { get; set; }
        public double? RicochetChance { get; set; }
        public double? FragmentationChance { get; set; }
        public double? Deterioration { get; set; }
        public double? SpeedRetardation { get; set; }
        public bool? Tracer { get; set; }
        public string TracerColor { get; set; }
        public double? TracerDistance { get; set; }
        public double? ArmorDamage { get; set; }
        public string Caliber { get; set; }
        public double? StaminaBurnPerDamage { get; set; }
        public double? HeavyBleedingDelta { get; set; }
        public double? LightBleedingDelta { get; set; }
        public bool? ShowBullet { get; set; }
        public bool? HasGrenaderComponent { get; set; }
        public double? FuzeArmTimeSec { get; set; }
        public double? ExplosionStrength { get; set; }
        public double? MinExplosionDistance { get; set; }
        public double? MaxExplosionDistance { get; set; }
        public double? FragmentsCount { get; set; }
        public string FragmentType { get; set; }
        public bool? ShowHitEffectOnExplode { get; set; }
        public string ExplosionType { get; set; }
        public double? AmmoLifeTimeSec { get; set; }
        public Xyz Contusion { get; set; }
        public Xyz ArmorDistanceDistanceDamage { get; set; }
        public Xyz Blindness { get; set; }
        public bool? IsLightAndSoundShot { get; set; }
        public double? LightAndSoundShotAngle { get; set; }
        public double? LightAndSoundShotSelfContusionTime { get; set; }
        public double? LightAndSoundShotSelfContusionStrength { get; set; }
        public double? MalfMisfireChance { get; set; }
        public double? MalfFeedChance { get; set; }
        public List<StackSlot> StackSlots { get; set; }
        public string Type { get; set; }
        public double? EqMin { get; set; }
        public double? EqMax { get; set; }
        public double? Rate { get; set; }
        public string ThrowType { get; set; }
        public double? ExplDelay { get; set; }
        public double? Strength { get; set; }
        public double? ContusionDistance { get; set; }
        public double? ThrowDamMax { get; set; }
        public double? explDelay { get; set; }
        public double? EmitTime { get; set; }
        public bool? CanBeHiddenDuringThrow { get; set; }
        public double? MinTimeToContactExplode { get; set; }
        public string ExplosionEffectType { get; set; }
        public string LinkedWeapon { get; set; }
        public bool? UseAmmoWithoutShell { get; set; }
        public IRandomLootSettings RandomLootSettings { get; set; }
        public double? RecoilCategoryMultiplierHandRotation { get; set; }
        public double? RecoilDampingHandRotation { get; set; }
        public bool? LeanWeaponAgainstBody { get; set; }
        public bool? RemoveShellAfterFire { get; set; }
        public List<string> RepairStrategyTypes { get; set; }
        public bool? IsEncoded { get; set; }
        public string LayoutName { get; set; }
        public Prefab Lower75Prefab { get; set; }
        public double? MaxUsages { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class IHealthEffect
    {
        public string Type { get; set; }
        public double Value { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Prefab
    {
        public string Path { get; set; }
        public string Rcid { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Grid
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Parent { get; set; }
        public GridProps Props { get; set; }
        public string Proto { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GridProps
    {
        public List<GridFilter> Filters { get; set; }
        public int CellsH { get; set; }
        public int CellsV { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public int MaxWeight { get; set; }
        public bool IsSortingTable { get; set; }
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
        public string Name { get; set; }
        public string Id { get; set; }
        public string Parent { get; set; }
        public SlotProps Props { get; set; }
        public int? MaxCount { get; set; }
        public bool? Required { get; set; }
        public bool? MergeSlotWithChildren { get; set; }
        public string Proto { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SlotProps
    {
        public List<SlotFilter> Filters { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SlotFilter
    {
        public double? Shift { get; set; }
        public bool? Locked { get; set; }
        public string Plate { get; set; }
        public List<string> ArmorColliders { get; set; }
        public List<string> ArmorPlateColliders { get; set; }
        public List<string> Filter { get; set; }
        public int? AnimationIndex { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class StackSlot
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Parent { get; set; }
        public int MaxCount { get; set; }
        public StackSlotProps Props { get; set; }
        public string Proto { get; set; }
        public object Upd { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class StackSlotProps
    {
        public List<SlotFilter> Filters { get; set; }
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
        public double Value { get; set; }
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
        public double Delay { get; set; }
        public double Duration { get; set; }
        public double FadeOut { get; set; }
        public double? Cost { get; set; }
        public double? HealthPenaltyMin { get; set; }
        public double? HealthPenaltyMax { get; set; }
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
        public int EndShotIndex { get; set; }
        public Xyz ShotRecoilPositionStrength { get; set; }
        public Xyz ShotRecoilRadianRange { get; set; }
        public Xyz ShotRecoilRotationStrength { get; set; }
        public int StartShotIndex { get; set; }
    }
}
