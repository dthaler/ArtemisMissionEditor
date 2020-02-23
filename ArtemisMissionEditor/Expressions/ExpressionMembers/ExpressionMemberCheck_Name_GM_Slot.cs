using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace ArtemisMissionEditor.Expressions
{
    /// <summary>
    /// Represents a single member in an expression, which provides branching via checking a condition.
    /// This check is for name vs gm selection in multiple statements that do something to/with an object.
    /// </summary>
    public sealed class ExpressionMemberCheck_Name_GM_Slot : ExpressionMemberCheck
    {
        private static readonly string NameChoice = "with name";
        private static readonly string UseGMChoice = "selected by GM ";
        private static readonly string PlayerSlotChoice = "in player slot";

        private string NameAttributeName { get; set; }
        private string PlayerSlotAttributeName { get; set; }
        private string UseGMSelectionAttributeName { get; set; }

        /// <summary>
        /// This function is called when check needs to decide which list of ExpressionMembers to output.
        /// After it is called, SetValue will be called, to allow for error correction.
        /// </summary>
        /// <example>If input is wrong, decide will choose something, and then the input will be corrected in the SetValue function</example>
        public override string Decide(ExpressionMemberContainer container)
        {
            if (container.GetAttribute(NameAttributeName) != null)
            {
                return NameChoice;
            }

            if (container.GetAttribute(UseGMSelectionAttributeName) != null)
            {
                return UseGMChoice;
            }

            if (container.GetAttribute(PlayerSlotAttributeName) != null)
            {
                return PlayerSlotChoice;
            }

            // Default is name.
            return NameChoice;
        }

        /// <summary>
        /// Called after Decide has made its choice, or, as usual for ExpressionMembers, after user edited the value through a Dialog.
        /// For checks, SetValue must change the attributes/etc of the statement according to the newly chosen value
        /// <example>If you chose "Use GM ...", SetValue will set "use_gm_..." attribute to "" if it was null</example>
        /// </summary>
        protected override void SetValueInternal(ExpressionMemberContainer container, string value)
        {
            if (value == NameChoice)
            {
                container.SetAttribute(UseGMSelectionAttributeName, null);
                container.SetAttribute(PlayerSlotAttributeName, null);
                container.SetAttributeIfNull(NameAttributeName, "");
            }
            if (value == UseGMChoice)
            {
                container.SetAttribute(NameAttributeName, null);
                container.SetAttribute(PlayerSlotAttributeName, null);
                container.SetAttributeIfNull(UseGMSelectionAttributeName, "");
            }
            if (value == PlayerSlotChoice)
            {
                container.SetAttribute(UseGMSelectionAttributeName, null);
                container.SetAttribute(NameAttributeName, null);
                container.SetAttributeIfNull(PlayerSlotAttributeName, "");
            }
            base.SetValueInternal(container, value);
        }

        /// <summary>
        /// Represents a single member in an expression, which provides branching via checking a condition.
        /// This check is for name vs gm selection in multiple statements that do something to/with an object.
        /// </summary>
        public ExpressionMemberCheck_Name_GM_Slot(
            ExpressionMemberValueDescription name = null,
            bool mandatory = true,
            string nameAttributeName = "name",
            string useGMSelectionAttributeName = "use_gm_selection",
            string playerSlotAttributeName = "player_slot")
            : base("", ExpressionMemberValueDescriptions.Check_Name_GMSelection)
        {
            name = name ?? ExpressionMemberValueDescriptions.Name;

            NameAttributeName = nameAttributeName;
            PlayerSlotAttributeName = playerSlotAttributeName;
            UseGMSelectionAttributeName = useGMSelectionAttributeName;

            List<ExpressionMember> eML;

            if (NameAttributeName != "<none>")
            {
                eML = this.Add(NameChoice);
                eML.Add(new ExpressionMember("<>", name, NameAttributeName, mandatory));
            }

            if (UseGMSelectionAttributeName != "<none>")
            {
                eML = this.Add(UseGMChoice);
                eML.Add(new ExpressionMember("", ExpressionMemberValueDescriptions.UseGM, UseGMSelectionAttributeName));
            }

            if (PlayerSlotChoice != "<none>")
            {
                eML = this.Add(PlayerSlotChoice);
                eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.UseSlot, PlayerSlotAttributeName, true));
            }
        }
    }
}
