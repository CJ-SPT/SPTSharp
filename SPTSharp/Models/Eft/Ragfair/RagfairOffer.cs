#pragma warning disable
using SPTSharp.Models.Eft.Common.Tables;

namespace SPTSharp.Models.Eft.Ragfair
{
    public class RagfairOffer
    {
        public SellResult[]? sellResult {  get; set; }
        public string _id { get; set; }
        public Item[] items { get; set; }
        public OfferRequirement[] requirements { get; set; }
        public string root { get; set; }
        public int intId { get; set; }

        /** Handbook price */
        public int itemsCost { get; set; }

        /** Rouble price */
        public int requirementsCost { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public bool sellInOnePiece { get; set; }
        public int loyaltyLevel { get; set; }
        public int? buyRestrictionMax { get; set; }
        public int? buyRestrictionCurrent { get; set; }
        public bool locked { get; set; }
        public bool unlimitedCount { get; set; }

        /** Rouble price */
        public int summaryCost { get; set; }
        public bool notAvailable { get; set; }

        /** TODO - implement this value - not currently used */
        public int CurrentItemCount { get; set; }
        public bool priority { get; set; }
    }

    public class OfferRequirement
    {
        public string _tpl {  get; set; }
        public string count { get; set; }
        public bool onlyFunctional { get; set; }
    }

    public class RagfairOfferUser
    {
        public string id { get; set; }
        public string? nickname { get; set; }
        public float? rating { get; set; }

        // EMemberCategory string hack!
        public string memberCategory { get; set; }
        public string? avatar { get; set; }
        public bool? isRatingGrowing { get; set; }
    }

    public class SellResult
    {
        public int sellTime { get; set; }
        public int amount { get; set; }
    }
}
