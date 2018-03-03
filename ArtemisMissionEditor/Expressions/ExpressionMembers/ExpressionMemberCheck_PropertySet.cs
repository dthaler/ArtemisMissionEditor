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
    /// This check is for "type" in [set_property] statement, it is hidden since "add to property" statement has property name as a member.
    /// </summary>
    public sealed class ExpressionMemberCheck_PropertySet : ExpressionMemberCheck
    {
        private static readonly Dictionary<string, string> MappedPropertyType = new Dictionary<string, string> {
            // Global properties.
            { "nonPlayerSpeed",          "<ENMYSP>" },
            { "nebulaIsOpaque",          "<NEBULAROP>" },
            { "sensorSetting",           "<SENSOR>" },
            { "nonPlayerShield",         "<ENMYSP>" },
            { "nonPlayerWeapon",         "<ENMYSP>" },
            { "playerWeapon",            "<ENMYSP>" },
            { "playerShields",           "<ENMYSP>" },
            { "coopAdjustmentValue",     "<DEFAULT>" },
            { "musicObjectMasterVolume", "<DEFAULT>" },
            { "commsObjectMasterVolume", "<DEFAULT>" },
            { "soundFXVolume",           "<DEFAULT>" },
            { "gameTimeLimit",           "<DEFAULT>" },
            { "networkTickSpeed",        "<DEFAULT>" },

            // Properties on all objects.
            { "positionX",               "<FLT0...100K>" },
            { "positionY",               "<FLT-100K...100K>" },
            { "positionZ",               "<FLT0...100K>" },
            { "deltaX",                  "<FLT-100K...100K>" },
            { "deltaY",                  "<FLT-100K...100K>" },
            { "deltaZ",                  "<FLT-100K...100K>" },
            { "angle",                   "<DEFAULT>" },
            { "pitch",                   "<DEFAULT>" },
            { "roll",                    "<DEFAULT>" },
            { "sideValue",               "<DEFAULT>" },

            // GenericMesh properties.
            { "blocksShotFlag",          "<BOOLYESNO>" },
            { "pushRadius",              "<FLT-+INF>" },
            { "pitchDelta",              "<DEFAULT>" },
            { "rollDelta",               "<DEFAULT>" },
            { "angleDelta",              "<DEFAULT>" },
            { "artScale",                "<DEFAULT>" },

            // Station properties.
            { "shieldState",             "<FLT-+INF>" },
            { "canBuild",                "<BOOLYESNO>" },
            { "missileStoresHoming",     "<INT0...+INF>" },
            { "missileStoresNuke",       "<INT0...+INF>" },
            { "missileStoresMine",       "<INT0...+INF>" },
            { "missileStoresECM",        "<OBSOLETE_MISSILESTORESECM>" },
            { "missileStoresEMP",        "<INT0...+INF>" },
            { "missileStoresPShock",     "<INT0...+INF>" },
            { "missileStoresBeacon",     "<INT0...+INF>" },
            { "missileStoresProbe",      "<INT0...+INF>" },
            { "missileStoresTag",        "<INT0...+INF>" },

            // Properties on shielded ships.
            { "throttle",                "<DEFAULT>" },
            { "steering",                "<DEFAULT>" },
            { "topSpeed",                "<DEFAULT>" },
            { "turnRate",                "<DEFAULT>" },
            { "shieldStateFront",        "<INT-+INF>" },
            { "shieldMaxStateFront",     "<INT-+INF>" },
            { "shieldStateBack",         "<INT-+INF>" },
            { "shieldMaxStateBack",      "<INT-+INF>" },
            { "shieldsOn",               "<BOOLYESNO>" },
            { "triggersMines",           "<BOOLYESNO>" },
            { "systemDamageBeam",        "<DEFAULT>" },
            { "systemDamageTorpedo",     "<DEFAULT>" },
            { "systemDamageTactical",    "<DEFAULT>" },
            { "systemDamageTurning",     "<DEFAULT>" },
            { "systemDamageImpulse",     "<DEFAULT>" },
            { "systemDamageWarp",        "<DEFAULT>" },
            { "systemDamageFrontShield", "<DEFAULT>" },
            { "systemDamageBackShield",  "<DEFAULT>" },
            { "shieldBandStrength0",     "<DEFAULT>" },
            { "shieldBandStrength1",     "<DEFAULT>" },
            { "shieldBandStrength2",     "<DEFAULT>" },
            { "shieldBandStrength3",     "<DEFAULT>" },
            { "shieldBandStrength4",     "<DEFAULT>" },

            // Properties on enemies.
            { "targetPointX",            "<FLT0...100K>" },
            { "targetPointY",            "<FLT-100K...100K>" },
            { "targetPointZ",            "<FLT0...100K>" },
            { "hasSurrendered",          "<BOOLYESNO>" },
            { "tauntImmunityIndex",      "<tII1_3>" },
            { "eliteAIType",             "<ELITEAITYPE>" },
            { "eliteAbilityBits",        "<ELITEABILITYBITS>" },
            { "eliteAbilityState",       "<DEFAULT>" },
            { "surrenderChance",         "<INT0...100>" },

            // Properties on neutrals.
            { "exitPointX",              "<FLT0...100K>" },
            { "exitPointY",              "<FLT-100K...100K>" },
            { "exitPointZ",              "<FLT0...100K>" },

            // Properties on players.
            { "countHoming",                 "<INT0...+INF>" },
            { "countNuke",                   "<INT0...+INF>" },
            { "countMine",                   "<INT0...+INF>" },
            { "countECM",                    "<OBSOLETE_COUNTECM>" },
            { "countEMP",                    "<INT0...+INF>" },
            { "countShk",                    "<INT0...+INF>" },
            { "countBea",                    "<INT0...+INF>" },
            { "countPro",                    "<INT0...+INF>" },
            { "countTag",                    "<INT0...+INF>" },
            { "energy",                      "<INT0...+INF>" },
            { "warpState",                   "<INT0...4>" },
            { "currentRealSpeed",            "<READ_ONLY>" },
            { "totalCoolant",                "<INT0...+INF>" },
            { "systemCurCoolantBeam",        "<INT0...+INF>" },
            { "systemCurCoolantTorpedo",     "<INT0...+INF>" },
            { "systemCurCoolantTactical",    "<INT0...+INF>" },
            { "systemCurCoolantTurning",     "<INT0...+INF>" },
            { "systemCurCoolantImpulse",     "<INT0...+INF>" },
            { "systemCurCoolantWarp",        "<INT0...+INF>" },
            { "systemCurCoolantFrontShield", "<INT0...+INF>" },
            { "systemCurCoolantBackShield",  "<INT0...+INF>" },
            { "systemCurHeatBeam",           "<DEFAULT>" },
            { "systemCurHeatTorpedo",        "<DEFAULT>" },
            { "systemCurHeatTactical",       "<DEFAULT>" },
            { "systemCurHeatTurning",        "<DEFAULT>" },
            { "systemCurHeatImpulse",        "<DEFAULT>" },
            { "systemCurHeatWarp",           "<DEFAULT>" },
            { "systemCurHeatFrontShield",    "<DEFAULT>" },
            { "systemCurHeatBackShield",     "<DEFAULT>" },
            { "systemCurEnergyBeam",         "<DEFAULT>" },
            { "systemCurEnergyTorpedo",      "<DEFAULT>" },
            { "systemCurEnergyTactical",     "<DEFAULT>" },
            { "systemCurEnergyTurning",      "<DEFAULT>" },
            { "systemCurEnergyImpulse",      "<DEFAULT>" },
            { "systemCurEnergyWarp",         "<DEFAULT>" },
            { "systemCurEnergyFrontShield",  "<DEFAULT>" },
            { "systemCurEnergyBackShield",   "<DEFAULT>" }
        };

        /// <summary>
        /// This function is called when check needs to decide which list of ExpressionMembers to output. 
        /// After it is called, SetValue will be called, to allow for error correction. 
        /// </summary>
        /// <example>If input is wrong, decide will choose something, and then the input will be corrected in the SetValue function</example>
        public override string Decide(ExpressionMemberContainer container)
        {
            string type = container.GetAttribute("property", ExpressionMemberValueDescriptions.Property.DefaultIfNull);
            foreach (var item in MappedPropertyType)
            {
                if (item.Key == type)
                {
                    return item.Value;
                }
                if (item.Key.ToLower() == type.ToLower())
                {
                    return "<WRONGCASE>";
                }
            }

            return "<UNKNOWN_PROPERTY>";
        }

        /// <summary>
        /// Called after Decide has made its choice, or, as usual for ExpressionMembers, after user edited the value through a Dialog.
        /// For checks, SetValue must change the attributes/etc of the statement according to the newly chosen value
        /// <example>If you chose "Use GM ...", SetValue will set "use_gm_..." attribute to ""</example>
        /// </summary>
        protected override void SetValueInternal(ExpressionMemberContainer container, string value)
        {
            if (value == "<WRONGCASE>")
            {
                string type = container.GetAttribute("property", ExpressionMemberValueDescriptions.Property.DefaultIfNull);
                foreach (var item in MappedPropertyType)
                {
                    if (item.Key.ToLower() == type.ToLower())
                    {
                        // Convert property name to correct case.
                        value = item.Value;
                        container.SetAttribute("property", item.Key);
                        break;
                    }
                }
            }
            if (value == "<OBSOLETE_COUNTECM>")
            {
                // Convert countECM to countEMP.
                value = "<INT0...+INF>";
                container.SetAttribute("property", "countEMP");
            }

            if (value == "<OBSOLETE_MISSILESTORESECM>")
            {
                // Convert missileStoresECM to missileStoresEMP.
                value = "<INT0...+INF>";
                container.SetAttribute("property", "missileStoresEMP");
            }

            if (value == "<BOOLYESNO>")
            {
                string flag = container.GetAttribute("value");
                if (flag == null || !Helper.IntTryParse(flag))
                    container.SetAttribute("value","0");
                else if (Helper.StringToInt(flag) == 1)
                    container.SetAttribute("value", "1");
                else
                    container.SetAttribute("value", "0");
            }
            //if (value == "<INVALID_PROPERTY>")
            //{
            //    value = "<DEFAULT>";
            //    container.SetAttribute("property", "positionX");
            //}
            if (Mission.Current.Loading && value == "<READ_ONLY>")
                Log.Add("Warning! Attempt to set read-only property " + container.GetAttribute("property") + " detected in event: " + container.Statement.Parent.Name + "!");
            if (Mission.Current.Loading && value == "<UNKNOWN_PROPERTY>")
                Log.Add("Warning! Unknown property " + container.GetAttribute("property") + " detected in event: "+container.Statement.Parent.Name+"!");

            base.SetValueInternal(container, value);
        }

        /// <summary>
        /// Adds "(type) "
        /// </summary>
        private void ____Add_Property(List<ExpressionMember> eML)
        {
            eML.Add(new ExpressionMember("<property>", ExpressionMemberValueDescriptions.Property, "property"));
        }

        /// <summary>
        /// Adds "
        /// </summary>
        /// 
        /// <summary>
        /// Adds "for object [selected by gm or named]"
        /// </summary>
        private void ____Add_Name(List<ExpressionMember> eML, ExpressionMemberValueDescription name = null)
        {
            name = name ?? ExpressionMemberValueDescriptions.NameAll;

            eML.Add(new ExpressionMember("for "));
            eML.Add(new ExpressionMember("object "));
            eML.Add(new ExpressionMemberCheck_Name_GM_Slot(name));
        }
        //private void ____Add_Name(List<ExpressionMember> eML)
        //{
        //    name = name ?? ExpressionMemberValueDescriptions.NameAll;

        //    eML.Add(new ExpressionMember("for "));
        //    eML.Add(new ExpressionMember("object "));
        //    eML.Add(new ExpressionMemberCheck_Name_GM(name));
        //    eML.Add(new ExpressionMember("name "));
        //    eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.NameAll, "name"));
        //}

        /// <summary>
        /// Represents a single member in an expression, which provides branching via checking a condition.
        /// This check is for "type" in [set_property] statement, it is hidden since "add to property" statement has property name as a member.
        /// </summary>
        public ExpressionMemberCheck_PropertySet()
            : base()
        {
            List<ExpressionMember> eML;

            eML = this.Add("<SENSOR>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.SensorRange, "value"));
            //____Add_Name(eML);

            eML = this.Add("<NEBULAROP>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Bool_Yes_No, "value"));
            //____Add_Name(eML);

            eML = this.Add("<ENMYSP>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Int_0_PosInf, "value"));
            eML.Add(new ExpressionMember("%.  (valid appears to be 40% - 300%)"));
            //____Add_Name(eML);

            eML = this.Add("<ENMYSH>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Int_0_PosInf, "value"));
            //____Add_Name(eML);

            eML = this.Add("<ENMYWP>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Int_0_PosInf, "value"));
            //____Add_Name(eML);



            #region <INT-+INF>    (push radius)

            eML = this.Add("<INT-+INF>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Int_NegInf_PosInf, "value"));
            ____Add_Name(eML);

            #endregion

            #region <FLT-+INF>    (push radius)

            eML = this.Add("<FLT-+INF>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Flt_NegInf_PosInf, "value"));
            ____Add_Name(eML);

            #endregion

            #region <INT0...+INF>    (amount of missiles)

            eML = this.Add("<INT0...+INF>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>",ExpressionMemberValueDescriptions.Int_0_PosInf, "value"));
            ____Add_Name(eML);

            #endregion

            #region <FLT0...+INF>    (coordinate x-z)

            eML = this.Add("<FLT0...+INF>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Flt_0_PosInf, "value"));
            ____Add_Name(eML);

            #endregion

            #region <INT0...100>    (surrenderChance)

            eML = this.Add("<INT0...100>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Int_0_100, "value"));
            ____Add_Name(eML);

            #endregion

            #region <INT0...4>    (warpState)

            eML = this.Add("<INT0...4>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Int_0_4, "value"));
            ____Add_Name(eML);

            #endregion
            
            #region <FLT0...100K>    (coordinate x-z)

            eML = this.Add("<FLT0...100K>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Flt_0_100k, "value"));
            ____Add_Name(eML);

            #endregion
            eML = this.Add("<tII1_3>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.tII1_3, "value"));
            ____Add_Name(eML);

//#endregion
           

            #region <FLT-100K...100K>    (coordinate y, delta)

            eML = this.Add("<FLT-100K...100K>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Flt_Minus100k_100k, "value"));
            ____Add_Name(eML);

            #endregion

            #region <BOOLYESNO>    (coordinate y, delta)

            eML = this.Add("<BOOLYESNO>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Bool_Yes_No, "value"));
            ____Add_Name(eML);

            #endregion

            #region <ELITEAITYPE> (eliteAIType)

            eML = this.Add("<ELITEAITYPE>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.EliteAIType, "value"));
            ____Add_Name(eML);

            #endregion

            #region <ELITEABILITYBITS> (eliteAbilityBits)

            eML = this.Add("<ELITEABILITYBITS>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.EliteAbilityBits, "value"));
            ____Add_Name(eML);

            #endregion

            #region <DEFAULT>    (...)

            eML = this.Add("<DEFAULT>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.ValueF, "value"));
            ____Add_Name(eML);

            #endregion

            #region <READ_ONLY>

            eML = this.Add("<READ_ONLY>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.ValueF, "value"));
            ____Add_Name(eML);
            eML.Add(new ExpressionMember("(WARNING! THIS PROPERTY IS READ ONLY)"));

            #endregion
            
            #region <UNKNOWN_PROPERTY>  

            eML = this.Add("<UNKNOWN_PROPERTY>");
            ____Add_Property(eML);
            eML.Add(new ExpressionMember("to "));
            eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.ValueF, "value"));
            ____Add_Name(eML);
            eML.Add(new ExpressionMember("(WARNING! UNKNOWN PROPERTY NAME)"));

            #endregion
        }
    }
}
