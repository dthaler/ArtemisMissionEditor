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
    /// This check is for default/specified side for [create] statement.
    /// </summary>
    public sealed class ExpressionMemberCheck_Side : ExpressionMemberCheck
    {
        /// <summary>
        /// This function is called when check needs to decide which list of ExpressionMembers to output. 
        /// After it is called, SetValue will be called, to allow for error correction. 
        /// </summary>
        /// <example>If input is wrong, decide will choose something, and then the input will be corrected in the SetValue function</example>
        public override string Decide(ExpressionMemberContainer container)
        {
            if (container.GetAttribute("sideValue") != null)
                return Choices[1]; // "... side #"

            // The attribute on incoming_comms_text was called "side" prior to Artemis 2.6.
            if (container.GetAttribute("side") != null)
            {
                return "<OBSOLETE_SIDE>";
            }

            return Choices[0]; // "... default side" 
        }

        /// <summary>
        /// Called after Decide has made its choice, or, as usual for ExpressionMembers, after user edited the value through a Dialog.
        /// For checks, SetValue must change the attributes/etc of the statement according to the newly chosen value
        /// <example>If you chose "Use GM ...", SetValue will set "use_gm_..." attribute to ""</example>
        /// </summary> 
        protected override void SetValueInternal(ExpressionMemberContainer container, string value)
        {
            if (value == "<OBSOLETE_SIDE>")
            {
                // Convert "side" attribute to "sideValue" attribute.
                value = Choices[1]; // "... side #"
                container.SetAttribute("sideValue", container.GetAttribute("side"));
            }

            base.SetValueInternal(container, value);
        }

        /// <summary>
        /// Represents a single member in an expression, which provides branching via checking a condition.
        /// This check is for default/specified side for [create] statement.
        /// </summary>
        public ExpressionMemberCheck_Side()
            : base("", ExpressionMemberValueDescriptions.Blank)
        {
            List<ExpressionMember> eML;
            
            eML = this.Add("default"); //Choices[0]
            eML.Add(new ExpressionMember("default", ExpressionMemberValueDescriptions.SideValue, "sideValue"));
            eML.Add(new ExpressionMember("side "));

            eML = this.Add("specified"); //Choices[1]
            eML.Add(new ExpressionMember("side "));
            eML.Add(new ExpressionMember("default", ExpressionMemberValueDescriptions.SideValue, "sideValue"));
        }
    }
}
