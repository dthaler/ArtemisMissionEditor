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
    /// This check is for "type" in [if_property] statement, it is hidden since "add to property" statement has property name as a member.
    /// </summary>
    public sealed class ExpressionMemberCheck_PropertyIf : ExpressionMemberCheck
	{
        /// <summary>
        /// This function is called when check needs to decide which list of ExpressionMembers to output. 
        /// After it is called, SetValue will be called, to allow for error correction. 
        /// </summary>
        /// <example>If input is wrong, decide will choose something, and then the input will be corrected in the SetValue function</example>
        public override string Decide(ExpressionMemberContainer container)
		{
			string type = container.GetAttribute("property", ExpressionMemberValueDescriptions.Property.DefaultIfNull);

			switch (type)
			{
                // Global properties.
				case "nonPlayerSpeed":			return "<DEFAULT_GLOBAL>";
				case "nebulaIsOpaque":			return "<DEFAULT_GLOBAL>";
				case "sensorSetting":			return "<DEFAULT_GLOBAL>";
				case "nonPlayerShield":			return "<DEFAULT_GLOBAL>";
				case "nonPlayerWeapon":			return "<DEFAULT_GLOBAL>";
				case "playerWeapon":			return "<DEFAULT_GLOBAL>";
				case "playerShields":			return "<DEFAULT_GLOBAL>";
				case "coopAdjustmentValue":		return "<DEFAULT_GLOBAL>";
				case "musicObjectMasterVolume":	return "<DEFAULT_GLOBAL>";
				case "commsObjectMasterVolume":	return "<DEFAULT_GLOBAL>";
				case "soundFXVolume":			return "<DEFAULT_GLOBAL>";
				case "networkTickSpeed":		return "<DEFAULT_GLOBAL>";
				case "gameTimeLimit":			return "<DEFAULT_GLOBAL>";
				//EVERYTHING
				case "positionX":				return "<DEFAULT>";
				case "positionY": 				return "<DEFAULT>";
				case "positionZ": 				return "<DEFAULT>";
				case "deltaX": 					return "<DEFAULT>";
				case "deltaY": 					return "<DEFAULT>";
				case "deltaZ": 					return "<DEFAULT>";
				case "angle": 					return "<DEFAULT>";
				case "pitch": 					return "<DEFAULT>";
				case "roll": 					return "<DEFAULT>";
                case "sideValue":               return "<DEFAULT>";
				//VALUES FOR GENERIC MESHES		
				case "blocksShotFlag": 			return "<DEFAULT>";
				case "pushRadius": 				return "<DEFAULT>";
				case "pitchDelta": 				return "<DEFAULT>";
				case "rollDelta": 				return "<DEFAULT>";
				case "angleDelta": 				return "<DEFAULT>";
				case "artScale": 				return "<DEFAULT>";
				//VALUES FOR STATIONS			
				case "shieldState": 			return "<DEFAULT>";
				case "canBuild": 				return "<DEFAULT>";
				case "missileStoresHoming": 	return "<DEFAULT>";
				case "missileStoresNuke": 		return "<DEFAULT>";
				case "missileStoresMine": 		return "<DEFAULT>";
                case "missileStoresECM":        return "<OBSOLETE_MISSILESTORESECM>";
                case "missileStoresEMP": 		return "<DEFAULT>";
                case "missileStoresPShock":     return "<DEFAULT>";
                case "missileStoresBeacon":     return "<DEFAULT>";
                case "missileStoresProbe":      return "<DEFAULT>";
                case "missileStoresTag":        return "<DEFAULT>";
                //VALUES FOR SHIELDED SHIPS		
                case "throttle": 				return "<DEFAULT>";
				case "steering": 				return "<DEFAULT>";
				case "topSpeed": 				return "<DEFAULT>";
				case "turnRate": 				return "<DEFAULT>";
				case "shieldStateFront": 		return "<DEFAULT>";
				case "shieldMaxStateFront": 	return "<DEFAULT>";
				case "shieldStateBack": 		return "<DEFAULT>";
				case "shieldMaxStateBack": 		return "<DEFAULT>";
				case "shieldsOn": 				return "<DEFAULT>";
				case "triggersMines": 			return "<DEFAULT>";
				case "systemDamageBeam": 		return "<DEFAULT>";
				case "systemDamageTorpedo": 	return "<DEFAULT>";
				case "systemDamageTactical": 	return "<DEFAULT>";
				case "systemDamageTurning": 	return "<DEFAULT>";
				case "systemDamageImpulse": 	return "<DEFAULT>";
				case "systemDamgeWarp": 		return "<DEFAULT>";
				case "systemDamageFrontShield":	return "<DEFAULT>";
				case "systemDamageBackShield": 	return "<DEFAULT>";
				case "shieldBandStrength0": 	return "<DEFAULT>";
				case "shieldBandStrength1": 	return "<DEFAULT>";
				case "shieldBandStrength2": 	return "<DEFAULT>";
				case "shieldBandStrength3": 	return "<DEFAULT>";
				case "shieldBandStrength4": 	return "<DEFAULT>";
				//VALUES FOR ENEMIES			
				case "targetPointX": 			return "<DEFAULT>";
				case "targetPointY": 			return "<DEFAULT>";
				case "targetPointZ": 			return "<DEFAULT>";
				case "hasSurrendered": 			return "<DEFAULT>";
                case "tauntImmunityIndex":      return "<DEFAULT>";
				case "eliteAIType": 			return "<DEFAULT>";
				case "eliteAbilityBits": 		return "<DEFAULT>";
				case "eliteAbilityState": 		return "<DEFAULT>";
				case "surrenderChance":			return "<DEFAULT>";
				//VALUES FOR NEUTRALS			
				case "exitPointX": 				return "<DEFAULT>";
				case "exitPointY": 				return "<DEFAULT>";
				case "exitPointZ": 				return "<DEFAULT>";
				//VALUES FOR PLAYERS			
				case "countHoming": 			return "<DEFAULT>";
				case "countNuke": 				return "<DEFAULT>";
				case "countMine": 				return "<DEFAULT>";
                case "countECM":                return "<OBSOLETE_COUNTECM>";
                case "countEMP": 				return "<DEFAULT>";
				case "countShk": 				return "<DEFAULT>";
				case "countBea": 				return "<DEFAULT>";
				case "countPro": 				return "<DEFAULT>";
				case "countTag": 				return "<DEFAULT>";
				case "energy": 					return "<DEFAULT>";
				case "warpState":				return "<DEFAULT>";
				case "currentRealSpeed":		return "<DEFAULT>";
                case "totalCoolant":            return "<DEFAULT>";
                case "systemCurCoolantBeam":         return "<DEFAULT>";
                case "systemCurCoolantTorpedo":      return "<DEFAULT>";
                case "systemCurCoolantTactical":     return "<DEFAULT>";
                case "systemCurCoolantTurning":      return "<DEFAULT>";
                case "systemCurCoolantImpulse":      return "<DEFAULT>";
                case "systemCurCoolantWarp":         return "<DEFAULT>";
                case "systemCurCoolantFrontShield":  return "<DEFAULT>";
                case "systemCurCoolantBackShield":   return "<DEFAULT>";
                case "systemCurHeatBeam":            return "<DEFAULT>";
                case "systemCurHeatTorpedo":         return "<DEFAULT>";
                case "systemCurHeatTactical":        return "<DEFAULT>";
                case "systemCurHeatTurning":         return "<DEFAULT>";
                case "systemCurHeatImpulse":         return "<DEFAULT>";
                case "systemCurHeatWarp":            return "<DEFAULT>";
                case "systemCurHeatFrontShield":     return "<DEFAULT>";
                case "systemCurHeatBackShield":      return "<DEFAULT>";
                case "systemCurEnergyBeam":          return "<DEFAULT>";
                case "systemCurEnergyTorpedo":       return "<DEFAULT>";
                case "systemCurEnergyTactical":      return "<DEFAULT>";
                case "systemCurEnergyTurning":       return "<DEFAULT>";
                case "systemCurEnergyImpulse":       return "<DEFAULT>";
                case "systemCurEnergyWarp":          return "<DEFAULT>";
                case "systemCurEnergyFrontShield":   return "<DEFAULT>";
                case "systemCurEnergyBackShield":    return "<DEFAULT>";
				//DEFAULT CASE
				default:
					return "<UNKNOWN_PROPERTY>";
			}
		}

        /// <summary>
        /// Called after Decide has made its choice, or, as usual for ExpressionMembers, after user edited the value through a Dialog.
        /// For checks, SetValue must change the attributes/etc of the statement according to the newly chosen value
        /// <example>If you chose "Use GM ...", SetValue will set "use_gm_..." attribute to ""</example>
        /// </summary>
        protected override void SetValueInternal(ExpressionMemberContainer container, string value)
		{
            if (value == "<OBSOLETE_COUNTECM>")
            {
                // Convert countECM to countEMP.
                value = "<DEFAULT>";
                container.SetAttribute("property", "countEMP");
            }

            if (value == "<OBSOLETE_MISSILESTORESECM>")
            {
                // Convert missileStoresECM to missileStoresEMP.
                value = "<DEFAULT>";
                container.SetAttribute("property", "missileStoresEMP");
            }

            //if (value == "<INVALID_PROPERTY>")
            //{
            //    value = "<DEFAULT>";
            //    container.SetAttribute("property", "positionX");
            //}
            if (Mission.Current.Loading && value == "<UNKNOWN_PROPERTY>")
				Log.Add("Warning! Unknown property " + container.GetAttribute("property") + " detected in event: " + container.Statement.Parent.Name + "!");

			base.SetValueInternal(container, value);
		}

		/// <summary>
		/// Adds "(type) "
		/// </summary>
        private void ____Add_Property_Name_Value(List<ExpressionMember> eML, ExpressionMemberValueDescription name = null, ExpressionMemberValueDescription value = null)
		{
            name = name ?? ExpressionMemberValueDescriptions.NameAll;
            value = value ?? ExpressionMemberValueDescriptions.Flt_NegInf_PosInf;
            
			eML.Add(new ExpressionMember("<property>", ExpressionMemberValueDescriptions.Property, "property"));
			eML.Add(new ExpressionMember("of "));
			eML.Add(new ExpressionMember("<>", name, "name", true));
			eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Comparator, "comparator"));
			eML.Add(new ExpressionMember("<>", value, "value", true));
		}

        /// <summary>
        /// Represents a single member in an expression, which provides branching via checking a condition.
        /// This check is for "type" in [if_property] statement, it is hidden since "add to property" statement has property name as a member.
        /// </summary>
        public ExpressionMemberCheck_PropertyIf()
			: base()
		{
			List<ExpressionMember> eML;

			#region <DEFAULT>    (...)

			eML = this.Add("<DEFAULT>");
			
			____Add_Property_Name_Value(eML);
			
			#endregion

			#region <DEFAULT_GLOBAL>    (...)

			eML = this.Add("<DEFAULT_GLOBAL>");
            
			eML.Add(new ExpressionMember("<property>", ExpressionMemberValueDescriptions.Property, "property"));
			eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Comparator, "comparator"));
			eML.Add(new ExpressionMember("<>", ExpressionMemberValueDescriptions.Flt_NegInf_PosInf, "value", true));
			
			#endregion

			#region <UNKNOWN_PROPERTY>

			eML = this.Add("<UNKNOWN_PROPERTY>");
			____Add_Property_Name_Value(eML);
			eML.Add(new ExpressionMember("(WARNING! UNKNOWN PROPERTY NAME)"));

			#endregion
		}
	}
}
