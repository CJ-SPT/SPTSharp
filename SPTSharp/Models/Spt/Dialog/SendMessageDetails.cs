#pragma warning disable
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Eft.Profile;
using SPTSharp.Models.Enums;

namespace SPTSharp.Models.Spt.Dialog
{
    public class SendMessageDetails
    {
        /** Player id */
        public string recipientId { get; set; }
        /** Who is sending this message */
        public EMessageType sender { get; set; }
        /** Optional - leave blank to use sender value */
        public EMessageType? dialogType { get; set; }
        /** Optional - if sender is USER these details are used */
        public UserDialogInfo senderDetails { get; set; }
        /** Optional - the trader sending the message */
        // ETraders - String hack!!!
        public string trader { get; set; }
        /** Optional - used in player/system messages, otherwise templateId is used */
        public string messageText { get; set; }
        /** Optional - Items to send to player */
        public Item[] items { get; set; }
        /** Optional - How long items will be stored in mail before expiry */
        public int? itemsMaxStorageLifetimeSeconds { get; set; }
        /** Optional - Used when sending messages from traders who send text from locale json */
        public string templateId { get; set; }
        /** Optional - ragfair related */
        public SystemData systemData { get; set; }
        /** Optional - Used by ragfair messages */
        public MessageContentRagfair ragfairDetails { get; set; }
        /** OPTIONAL - allows modification of profile settings via mail */
        public ProfileChangeEvent[] profileChangeEvents { get; set; }
    }

    public class ProfileChangeEvent
    {
        public string _id { get; set; }
        public EProfileChangeEventType Type { get; set; }
        public int value { get; set; }
        public string entity { get; set; }
    }
}
