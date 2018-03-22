using System;

namespace ArtemisMissionEditor.Expressions
{
    /// <summary>
    /// Contains all instances of the ExpressionMemberValueEditor class used by the editor.
    /// </summary>
    public static class ExpressionMemberValueEditors
    {
        /// <summary> Value is not edited at all </summary>
        public static ExpressionMemberValueEditor Nothing;
        /// <summary> Value will appear as an uneditable label </summary>
        public static ExpressionMemberValueEditor Label;
        /// <summary> Default editor for a Check</summary>
        public static ExpressionMemberValueEditor DefaultCheck;
        
        // Default editors for all types
        public static ExpressionMemberValueEditor DefaultInteger;
        public static ExpressionMemberValueEditor DefaultBool;
        public static ExpressionMemberValueEditor DefaultDouble;
        public static ExpressionMemberValueEditor DefaultString;
        public static ExpressionMemberValueEditor DefaultBody;
        public static ExpressionMemberValueEditor DefaultPresent;
        
        /// <summary> Root check for actions </summary>
        public static ExpressionMemberValueEditor XmlNameActionCheck;
        /// <summary> Root check for conditions </summary>
        public static ExpressionMemberValueEditor XmlNameConditionCheck;
        public static ExpressionMemberValueEditor CreateType;
        public static ExpressionMemberValueEditor SetVariableCheck;
        public static ExpressionMemberValueEditor AIType;
        public static ExpressionMemberValueEditor PropertyObject;
        public static ExpressionMemberValueEditor PropertyFleet;
        public static ExpressionMemberValueEditor SkyboxIndex;
        public static ExpressionMemberValueEditor Difficulty;
        public static ExpressionMemberValueEditor ShipSystem;
        public static ExpressionMemberValueEditor CountFrom;
        public static ExpressionMemberValueEditor DamageValue;
        public static ExpressionMemberValueEditor TeamIndex;
        public static ExpressionMemberValueEditor TeamAmount;
        public static ExpressionMemberValueEditor TeamAmountF;
        public static ExpressionMemberValueEditor SpecialShipType;
        public static ExpressionMemberValueEditor MonsterType;
        public static ExpressionMemberValueEditor DriveType;
        public static ExpressionMemberValueEditor SensorRange;
        public static ExpressionMemberValueEditor PlayerSlot;
        public static ExpressionMemberValueEditor AnomalyType;
        public static ExpressionMemberValueEditor SpecialCaptainType;
        public static ExpressionMemberValueEditor SpecialSpecialState;
        public static ExpressionMemberValueEditor SpecialSpecialSwitchState;

        public static ExpressionMemberValueEditor MonsterAge;
        public static ExpressionMemberValueEditor NebulaType;
        public static ExpressionMemberValueEditor NebulaTypeOrNone;
        public static ExpressionMemberValueEditor Side;
        public static ExpressionMemberValueEditor Comparator;
        public static ExpressionMemberValueEditor DistanceNebulaCheck;
        public static ExpressionMemberValueEditor ConvertDirectCheck;
        public static ExpressionMemberValueEditor TimerName;
        public static ExpressionMemberValueEditor GMButtonText;
        public static ExpressionMemberValueEditor CommsButtonText;
        public static ExpressionMemberValueEditor GMText;
        public static ExpressionMemberValueEditor ExternalProgramID;
        public static ExpressionMemberValueEditor VariableName;
        public static ExpressionMemberValueEditor NamedAllName;
        public static ExpressionMemberValueEditor NamedStationName;
        public static ExpressionMemberValueEditor NamedGenericMeshName;
        public static ExpressionMemberValueEditor NamedMonsterName;
        public static ExpressionMemberValueEditor NamedEnemyName;
        public static ExpressionMemberValueEditor NamedNeutralName;
        public static ExpressionMemberValueEditor NamedShipName;
        public static ExpressionMemberValueEditor NamedAIShipName;
        public static ExpressionMemberValueEditor NamedAIShipOrMonsterName;
        public static ExpressionMemberValueEditor ScannableObjectName;
        public static ExpressionMemberValueEditor ConsoleList;
        public static ExpressionMemberValueEditor EliteAIType;
        public static ExpressionMemberValueEditor EliteAbilityBits;
        public static ExpressionMemberValueEditor PlayerNames;
        public static ExpressionMemberValueEditor WarpState;
        public static ExpressionMemberValueEditor CommTypes;
        public static ExpressionMemberValueEditor PathEditor;
        public static ExpressionMemberValueEditor HullID;
        public static ExpressionMemberValueEditor RaceKeys;
        public static ExpressionMemberValueEditor HullKeys;
        public static ExpressionMemberValueEditor VariableType;

        static ExpressionMemberValueEditors()
		{
			Nothing = new ExpressionMemberValueEditor(false, false);

			Label = new ExpressionMemberValueEditor(true, false);

            DefaultInteger = new ExpressionMemberValueEditor();
			DefaultDouble = new ExpressionMemberValueEditor();
			DefaultString = new ExpressionMemberValueEditor();
			DefaultBody = new ExpressionMemberValueEditor();
            DefaultBool = new ExpressionMemberValueEditor();
            DefaultBool.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultBool;
            DefaultPresent = new ExpressionMemberValueEditor();
            DefaultPresent.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultPresent;

			CreateType = new ExpressionMemberValueEditor();
			CreateType.AddToDictionary("Anomaly",       "Anomaly");
			CreateType.AddToDictionary("blackHole",     "black hole");
            CreateType.AddToDictionary("enemy",         "enemy");
            CreateType.AddToDictionary("genericMesh",   "generic mesh");
            CreateType.AddToDictionary("monster",       "monster");
            CreateType.AddToDictionary("neutral",       "neutral");
            CreateType.AddToDictionary("player",        "player");
			CreateType.AddToDictionary("station",       "station");
			//CreateType.AddToDictionary("whale",         "whale");
			CreateType.AddToDictionary("asteroids",     "asteroids");
            CreateType.AddToDictionary("mines",         "mines");
            CreateType.AddToDictionary("nebulas",       "nebulas");
			CreateType.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultList; 

			DefaultCheck = new ExpressionMemberValueEditor(true, true, true);
			DefaultCheck.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultCheck;

            XmlNameActionCheck = new ExpressionMemberValueEditor_XmlName();

            XmlNameActionCheck.AddToDictionary("set_difficulty_level", "Set difficulty");
            XmlNameActionCheck.AddToDictionary("set_skybox_index", "Set skybox");
            XmlNameActionCheck.AddToDictionary("end_mission", "End mission");
            XmlNameActionCheck.AddToDictionary("log", "Log new entry");
            XmlNameActionCheck.AddToDictionary("spawn_external_program", "Spawn external program");
            XmlNameActionCheck.NewMenuGroup("Game Options");

            XmlNameActionCheck.AddToDictionary("create", "Create", "Create object(s)");
            XmlNameActionCheck.AddToDictionary("<destroy>", "Destroy", "Destroy object(s)");
            XmlNameActionCheck.NewMenuGroup("Create/Destroy");
            
            XmlNameActionCheck.AddToDictionary("set_comms_button", "Set comms button");
            XmlNameActionCheck.AddToDictionary("clear_comms_button", "Clear comms button");
            XmlNameActionCheck.AddToDictionary("set_gm_button", "Set GM button");
            XmlNameActionCheck.AddToDictionary("clear_gm_button", "Clear GM button");
            XmlNameActionCheck.AddToDictionary("gm_instructions", "GM instructions button");
            XmlNameActionCheck.AddToDictionary("start_getting_keypresses_from", "Start getting keypresses from consoles: ", "Start getting keypresses from consoles");
            XmlNameActionCheck.AddToDictionary("end_getting_keypresses_from", "End getting keypresses from consoles: ", "End getting keypresses from consoles");
            XmlNameActionCheck.NewMenuGroup("Buttons");

            XmlNameActionCheck.AddToDictionary("incoming_comms_text", "Show incoming text message");
            XmlNameActionCheck.AddToDictionary("incoming_message", "Show incoming audio message");
            XmlNameActionCheck.AddToDictionary("warning_popup_message", "Show warning popup message");
            XmlNameActionCheck.AddToDictionary("big_message", "Show big message on main screen");
            XmlNameActionCheck.AddToDictionary("play_sound_now", "Play sound on main screen");
            XmlNameActionCheck.NewMenuGroup("Messages");

            XmlNameActionCheck.AddToDictionary("set_damcon_members", "Set DamCon members");
            XmlNameActionCheck.AddToDictionary("set_player_grid_damage", "Set player ship's damage");
            XmlNameActionCheck.NewMenuGroup("Damage/Damcon");

            XmlNameActionCheck.AddToDictionary("set_timer", "Set timer");
            XmlNameActionCheck.AddToDictionary("set_variable", "Set variable");
            XmlNameActionCheck.NewMenuGroup("Triggers");

            XmlNameActionCheck.AddToDictionary("set_object_property", "Set numeric property");
            XmlNameActionCheck.AddToDictionary("addto_object_property", "Add", "Add to numeric property");
            XmlNameActionCheck.AddToDictionary("copy_object_property", "Copy numeric property");
            XmlNameActionCheck.AddToDictionary("set_ship_text", "Set text properties", "Set text properties of object");
            XmlNameActionCheck.AddToDictionary("set_side_value", "Set side", "Set object's side");
            XmlNameActionCheck.AddToDictionary("set_special", "Set AI ship special", "Set AI ship's special values");
            XmlNameActionCheck.AddToDictionary("set_named_object_tag_state", "Set AI ship tag", "Set AI ship's tag");
            XmlNameActionCheck.AddToDictionary("set_fleet_property", "Set property of fleet");
            XmlNameActionCheck.AddToDictionary("set_monster_tag_data", "Set monster tag", "Set monster's tag");
            XmlNameActionCheck.AddToDictionary("set_player_carried_type", "Set hanger bay contents");
            XmlNameActionCheck.AddToDictionary("set_player_station_carried", "Add replacement fighter to station");
            XmlNameActionCheck.AddToDictionary("clear_player_station_carried", "Remove all replacement fighters from station");
            XmlNameActionCheck.NewMenuGroup("Properties");

            XmlNameActionCheck.AddToDictionary("set_relative_position", "Set relative position", "Set position relative to object");
            XmlNameActionCheck.AddToDictionary("set_to_gm_position", "Set relative to GM position", "Set position relative to GM position");
            XmlNameActionCheck.NewMenuGroup("Position");

            XmlNameActionCheck.AddToDictionary("clear_ai", "Clear AI command stack", "Clear AI commands");
            XmlNameActionCheck.AddToDictionary("add_ai", "Add an AI command", "Add AI command");
            XmlNameActionCheck.AddToDictionary("direct", "Direct generic mesh", "Direct generic mesh to object / position");
            XmlNameActionCheck.NewMenuGroup("AI");

            XmlNameActionCheck.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NestedList;

            XmlNameConditionCheck = new ExpressionMemberValueEditor_XmlName();
			XmlNameConditionCheck.AddToDictionary("if_variable", "Variable");
			XmlNameConditionCheck.AddToDictionary("if_timer_finished", "Timer", "Timer has finished");
			XmlNameConditionCheck.AddToDictionary("if_damcon_members", "Amount of DamCon members");
			XmlNameConditionCheck.AddToDictionary("if_fleet_count", "Ship count", "Ship count (in a fleet)");
			XmlNameConditionCheck.AddToDictionary("if_docked", "Player ship", "Player ship is docked");
			XmlNameConditionCheck.AddToDictionary("if_in_nebula", "Player ship", "Player ship is in nebula");
			XmlNameConditionCheck.AddToDictionary("if_player_is_targeting", "Player ship", "Player ship is targeting");
			XmlNameConditionCheck.AddToDictionary("if_monster_tag_matches", "Monster", "Monster has tag");
			XmlNameConditionCheck.AddToDictionary("if_object_tag_matches", "AI ship", "AI ship has tag");
			XmlNameConditionCheck.AddToDictionary("if_external_program_active", "External program", "External program is running");
			XmlNameConditionCheck.AddToDictionary("if_external_program_finished", "External program", "External program has finished");
			XmlNameConditionCheck.AddToDictionary("<existence>", "Object", "Object exists / doesn't");
            XmlNameConditionCheck.AddToDictionary("<location>", "Object", "Object is located");
            XmlNameConditionCheck.AddToDictionary("if_object_property", "Property", "Object property");
			XmlNameConditionCheck.AddToDictionary("if_distance", "Distance", "Distance between objects");
			XmlNameConditionCheck.AddToDictionary("if_difficulty", "Difficulty level");
			XmlNameConditionCheck.AddToDictionary("if_scan_level", "Scan level of object", "Object scan level");
            XmlNameConditionCheck.AddToDictionary("if_comms_button", "Comms button pressed");
			XmlNameConditionCheck.AddToDictionary("if_gm_key", "GM key pressed", "GM pressed a key");
            XmlNameConditionCheck.AddToDictionary("if_gm_button", "GM Button pressed");
            XmlNameConditionCheck.AddToDictionary("if_client_key", "Client pressed", "Client pressed a key");
			XmlNameConditionCheck.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultCheck;

			SetVariableCheck = new ExpressionMemberValueEditor();
			SetVariableCheck.AddToDictionary("<to>", "to", "to an exact value");
			SetVariableCheck.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultCheck;

            // Add brain stack blocks.  There should be a trailing space if and only if the block uses arguments.
			AIType = new ExpressionMemberValueEditor();

			AIType.AddToDictionary("ATTACK", "ATTACK ");
			AIType.AddToDictionary("AVOID_BLACK_HOLE", "AVOID BLACK HOLE ");
			AIType.AddToDictionary("AVOID_WHALE", "AVOID WHALE ");
			AIType.AddToDictionary("CHASE_FLEET", "CHASE FLEET ");
			AIType.AddToDictionary("CHASE_OTHER_MONSTERS", "CHASE OTHER MONSTERS ");
			AIType.AddToDictionary("CHASE_WHALE", "CHASE WHALE ");
			AIType.AddToDictionary("DEFEND", "DEFEND ");
			AIType.AddToDictionary("FIGHTER_BINGO", "FIGHTER BINGO");
			AIType.AddToDictionary("FOLLOW_COMMS_ORDERS", "FOLLOW COMMS ORDERS");
			AIType.AddToDictionary("FOLLOW_LEADER", "FOLLOW LEADER");
			AIType.AddToDictionary("GUARD_STATION", "GUARD STATION ");
			AIType.AddToDictionary("LAUNCH_FIGHTERS", "LAUNCH FIGHTERS ");
			AIType.AddToDictionary("LEADER_LEADS", "LEADER LEADS");
			AIType.AddToDictionary("PROCEED_TO_EXIT", "PROCEED TO EXIT");
			AIType.AddToDictionary("SPCL_AI", "SPCL AI");
			AIType.AddToDictionary("TRY_TO_BECOME_LEADER", "TRY TO BECOME LEADER");
			AIType.NewMenuGroup("Ship command");

			AIType.AddToDictionary("AVOID_SIGNAL", "AVOID SIGNAL ");
			AIType.AddToDictionary("CHASE_MONSTER", "CHASE MONSTER ");
			AIType.AddToDictionary("CHASE_SIGNAL", "CHASE SIGNAL ");
			AIType.AddToDictionary("DRAGON_NEST", "DRAGON NEST");
			AIType.AddToDictionary("FRENZY_ATTACK", "FRENZY_ATTACK");
			AIType.AddToDictionary("GO_TO_HOLE", "GO TO HOLE ");
			AIType.AddToDictionary("MOVE_WITH_GROUP", "MOVE WITH GROUP ");
			AIType.AddToDictionary("PLAY_IN_ASTEROIDS", "PLAY IN ASTEROIDS");
			AIType.AddToDictionary("RANDOM_PATROL", "RANDOM PATROL ");
			AIType.AddToDictionary("RELEASE_PIRANHAS", "RELEASE PIRANHAS ");
			AIType.AddToDictionary("STAY_CLOSE", "STAY CLOSE ");
			AIType.NewMenuGroup("Monster command");

			AIType.AddToDictionary("CHASE_AI_SHIP", "CHASE AI SHIP ");
			AIType.AddToDictionary("CHASE_ANGER", "CHASE ANGER");
			AIType.AddToDictionary("CHASE_PLAYER", "CHASE PLAYER ");
			AIType.AddToDictionary("CHASE_STATION", "CHASE STATION ");
			AIType.AddToDictionary("DIR_THROTTLE", "DIR THROTTLE ");
			AIType.AddToDictionary("POINT_THROTTLE", "POINT THROTTLE ");
			AIType.AddToDictionary("TARGET_THROTTLE", "TARGET THROTTLE ");
			AIType.NewMenuGroup("Generic command");

			AIType.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NestedList;

			PropertyObject = new ExpressionMemberValueEditor();
            PropertyObject.AddToDictionary("coopAdjustmentValue", "Co-op Adjustment Value");
            PropertyObject.AddToDictionary("nonPlayerWeapon", "Enemy Damage");
            PropertyObject.AddToDictionary("nonPlayerShield", "Enemy Shield");
            PropertyObject.AddToDictionary("nonPlayerSpeed", "Enemy Speed");
            PropertyObject.AddToDictionary("commsObjectMasterVolume", "Game Comms Volume");
            PropertyObject.AddToDictionary("musicObjectMasterVolume", "Game Music Volume");
            PropertyObject.AddToDictionary("soundFXVolume", "Game Sound Volume");
            PropertyObject.AddToDictionary("gameTimeLimit", "Game Time Limit");
            PropertyObject.AddToDictionary("nebulaIsOpaque", "Nebula Hides From Sensors");
            PropertyObject.AddToDictionary("networkTickSpeed", "Network Tick Speed");
            PropertyObject.AddToDictionary("playerWeapon", "Player Damage");
            PropertyObject.AddToDictionary("playerShields", "Player Shield");
            PropertyObject.AddToDictionary("sensorSetting", "Sensor Range");
            PropertyObject.NewMenuGroup("Game Properties");

            PropertyObject.AddToDictionary("positionX", "positionX");
			PropertyObject.AddToDictionary("positionY", "positionY");
			PropertyObject.AddToDictionary("positionZ", "positionZ");
			PropertyObject.AddToDictionary("deltaX", "deltaX");
			PropertyObject.AddToDictionary("deltaY", "deltaY");
			PropertyObject.AddToDictionary("deltaZ", "deltaZ");
			PropertyObject.AddToDictionary("angle", "angle");
			PropertyObject.AddToDictionary("pitch", "pitch");
			PropertyObject.AddToDictionary("roll", "roll");
			PropertyObject.AddToDictionary("sideValue", "sideValue");
			PropertyObject.AddToDictionary("isTagged", "isTagged");
			PropertyObject.AddToDictionary("tagOwnerSide", "tagOwnerSide");
			PropertyObject.NewMenuGroup("All objects");

			PropertyObject.AddToDictionary("blocksShotFlag", "blocksShotFlag");
			PropertyObject.AddToDictionary("pushRadius", "pushRadius");
			PropertyObject.AddToDictionary("pitchDelta", "pitchDelta");
			PropertyObject.AddToDictionary("rollDelta", "rollDelta");
			PropertyObject.AddToDictionary("angleDelta", "angleDelta");
			PropertyObject.AddToDictionary("artScale", "artScale");
			PropertyObject.NewMenuGroup("Generic meshes");

			PropertyObject.AddToDictionary("shieldState", "shieldState");
			PropertyObject.AddToDictionary("canBuild", "canBuild");
			PropertyObject.AddToDictionary("missileStoresHoming", "missileStoresHoming");
			PropertyObject.AddToDictionary("missileStoresNuke", "missileStoresNuke");
			PropertyObject.AddToDictionary("missileStoresMine", "missileStoresMine");
			PropertyObject.AddToDictionary("missileStoresEMP", "missileStoresEMP");
            PropertyObject.AddToDictionary("missileStoresPShock", "missileStoresPShock");
            PropertyObject.AddToDictionary("missileStoresBeacon", "missileStoresBeacon");
            PropertyObject.AddToDictionary("missileStoresProbe", "missileStoresProbe");
            PropertyObject.AddToDictionary("missileStoresTag", "missileStoresTag");
            PropertyObject.NewMenuGroup("Stations");

			PropertyObject.AddToDictionary("throttle", "throttle");
			PropertyObject.AddToDictionary("steering", "steering");
			PropertyObject.AddToDictionary("topSpeed", "topSpeed");
			PropertyObject.AddToDictionary("turnRate", "turnRate");
			PropertyObject.AddToDictionary("shieldStateFront", "shieldStateFront");
			PropertyObject.AddToDictionary("shieldMaxStateFront", "shieldMaxStateFront");
			PropertyObject.AddToDictionary("shieldStateBack", "shieldStateBack");
			PropertyObject.AddToDictionary("shieldMaxStateBack", "shieldMaxStateBack");
			PropertyObject.AddToDictionary("shieldsOn", "shieldsOn");
			PropertyObject.AddToDictionary("triggersMines", "triggersMines");
			PropertyObject.AddToDictionary("systemDamageBeam", "systemDamageBeam");
			PropertyObject.AddToDictionary("systemDamageTorpedo", "systemDamageTorpedo");
			PropertyObject.AddToDictionary("systemDamageTactical", "systemDamageTactical");
			PropertyObject.AddToDictionary("systemDamageTurning", "systemDamageTurning");
			PropertyObject.AddToDictionary("systemDamageImpulse", "systemDamageImpulse");
			PropertyObject.AddToDictionary("systemDamageWarp", "systemDamageWarp");
			PropertyObject.AddToDictionary("systemDamageFrontShield", "systemDamageFrontShield");
			PropertyObject.AddToDictionary("systemDamageBackShield", "systemDamageBackShield");
			PropertyObject.AddToDictionary("shieldBandStrength0", "shieldBandStrength0");
			PropertyObject.AddToDictionary("shieldBandStrength1", "shieldBandStrength1");
			PropertyObject.AddToDictionary("shieldBandStrength2", "shieldBandStrength2");
			PropertyObject.AddToDictionary("shieldBandStrength3", "shieldBandStrength3");
			PropertyObject.AddToDictionary("shieldBandStrength4", "shieldBandStrength4");
			PropertyObject.NewMenuGroup("Shielded ships");

           // PropertyObject.AddToDictionary("setShipSide", "Set Ship Side");
            PropertyObject.AddToDictionary("targetPointX", "targetPointX");
			PropertyObject.AddToDictionary("targetPointY", "targetPointY");
			PropertyObject.AddToDictionary("targetPointZ", "targetPointZ");
			PropertyObject.AddToDictionary("hasSurrendered", "hasSurrendered");
            PropertyObject.AddToDictionary("tauntImmunityIndex", "tauntImmunityIndex");
            PropertyObject.AddToDictionary("eliteAIType", "eliteAIType");
			PropertyObject.AddToDictionary("eliteAbilityBits", "eliteAbilityBits");
			PropertyObject.AddToDictionary("eliteAbilityState", "eliteAbilityState");
			PropertyObject.AddToDictionary("surrenderChance", "surrenderChance");
			PropertyObject.NewMenuGroup("Enemies");

			PropertyObject.AddToDictionary("exitPointX", "exitPointX");
			PropertyObject.AddToDictionary("exitPointY", "exitPointY");
			PropertyObject.AddToDictionary("exitPointZ", "exitPointZ");
			PropertyObject.NewMenuGroup("Neutrals");

			PropertyObject.AddToDictionary("countHoming", "countHoming");
			PropertyObject.AddToDictionary("countNuke", "countNuke");
			PropertyObject.AddToDictionary("countMine", "countMine");
			PropertyObject.AddToDictionary("countEMP", "countEMP");
			PropertyObject.AddToDictionary("countShk", "countShk");
			PropertyObject.AddToDictionary("countBea", "countBea");
			PropertyObject.AddToDictionary("countPro", "countPro");
			PropertyObject.AddToDictionary("countTag", "countTag");
			PropertyObject.AddToDictionary("energy", "energy");
			PropertyObject.AddToDictionary("warpState", "warpState");
			PropertyObject.AddToDictionary("currentRealSpeed", "currentRealSpeed");
			PropertyObject.AddToDictionary("totalCoolant", "totalCoolant");

            // Player properties added in Artemis v2.6.3.
			PropertyObject.AddToDictionary("systemCurCoolantBeam", "systemCurCoolantBeam");
			PropertyObject.AddToDictionary("systemCurCoolantTorpedo", "systemCurCoolantTorpedo");
			PropertyObject.AddToDictionary("systemCurCoolantTactical", "systemCurCoolantTactical");
			PropertyObject.AddToDictionary("systemCurCoolantTurning", "systemCurCoolantTurning");
			PropertyObject.AddToDictionary("systemCurCoolantImpulse", "systemCurCoolantImpulse");
			PropertyObject.AddToDictionary("systemCurCoolantWarp", "systemCurCoolantWarp");
			PropertyObject.AddToDictionary("systemCurCoolantFrontShield", "systemCurCoolantFrontShield");
			PropertyObject.AddToDictionary("systemCurCoolantBackShield", "systemCurCoolantBackShield");

			PropertyObject.AddToDictionary("systemCurHeatBeam", "systemCurHeatBeam");
			PropertyObject.AddToDictionary("systemCurHeatTorpedo", "systemCurHeatTorpedo");
			PropertyObject.AddToDictionary("systemCurHeatTactical", "systemCurHeatTactical");
			PropertyObject.AddToDictionary("systemCurHeatTurning", "systemCurHeatTurning");
			PropertyObject.AddToDictionary("systemCurHeatImpulse", "systemCurHeatImpulse");
			PropertyObject.AddToDictionary("systemCurHeatWarp", "systemCurHeatWarp");
			PropertyObject.AddToDictionary("systemCurHeatFrontShield", "systemCurHeatFrontShield");
			PropertyObject.AddToDictionary("systemCurHeatBackShield", "systemCurHeatBackShield");

			PropertyObject.AddToDictionary("systemCurEnergyBeam", "systemCurEnergyBeam");
			PropertyObject.AddToDictionary("systemCurEnergyTorpedo", "systemCurEnergyTorpedo");
			PropertyObject.AddToDictionary("systemCurEnergyTactical", "systemCurEnergyTactical");
			PropertyObject.AddToDictionary("systemCurEnergyTurning", "systemCurEnergyTurning");
			PropertyObject.AddToDictionary("systemCurEnergyImpulse", "systemCurEnergyImpulse");
			PropertyObject.AddToDictionary("systemCurEnergyWarp", "systemCurEnergyWarp");
			PropertyObject.AddToDictionary("systemCurEnergyFrontShield", "systemCurEnergyFrontShield");
			PropertyObject.AddToDictionary("systemCurEnergyBackShield", "systemCurEnergyBackShield");
			PropertyObject.NewMenuGroup("Players");

			PropertyObject.AddToDictionary("age", "age");
			PropertyObject.NewMenuGroup("Monsters");

			PropertyObject.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NestedList;

			PropertyFleet = new ExpressionMemberValueEditor();
			PropertyFleet.AddToDictionary("fleetSpacing",   "spacing");
			PropertyFleet.AddToDictionary("fleetMaxRadius", "max radius");
			PropertyFleet.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultList;

			SkyboxIndex = new ExpressionMemberValueEditor();
            for (int i = 0; i <= 29; i++)
                SkyboxIndex.AddToDictionary(i.ToString(), i.ToString());
			SkyboxIndex.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListPlusDialog;

			Difficulty = new ExpressionMemberValueEditor();
            for (int i = 0; i <= 11; i++)
                Difficulty.AddToDictionary(i.ToString(), i.ToString());
			Difficulty.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultList;

			ShipSystem = new ExpressionMemberValueEditor();
			ShipSystem.AddToDictionary("systemBeam",            "Primary Beam");
			ShipSystem.AddToDictionary("systemTorpedo",         "Torpedo");
			ShipSystem.AddToDictionary("systemTactical",        "Sensors");
			ShipSystem.AddToDictionary("systemTurning",         "Maneuver");
			ShipSystem.AddToDictionary("systemImpulse",         "Impulse");
			ShipSystem.AddToDictionary("systemWarp",            "Warp");
			ShipSystem.AddToDictionary("systemFrontShield",     "Front Shield");
			ShipSystem.AddToDictionary("systemBackShield",      "Rear Shield");
			ShipSystem.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultList;

			CountFrom = new ExpressionMemberValueEditor();
			CountFrom.AddToDictionary("left",   "left");
			CountFrom.AddToDictionary("top",    "top");
			CountFrom.AddToDictionary("front",  "front");
			CountFrom.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultList;

			DamageValue = new ExpressionMemberValueEditor_Percent();
			DamageValue.AddToDictionary("0.0",  "0%");
			DamageValue.AddToDictionary("0.25", "25%");
			DamageValue.AddToDictionary("0.5",  "50%");
			DamageValue.AddToDictionary("0.75", "75%");
			DamageValue.AddToDictionary("1.0",  "100%");
			DamageValue.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListPlusDialog;

			TeamIndex = new ExpressionMemberValueEditor();
			TeamIndex.AddToDictionary("0", "0");
			TeamIndex.AddToDictionary("1", "1");
			TeamIndex.AddToDictionary("2", "2");
			TeamIndex.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultList;

			TeamAmount = new ExpressionMemberValueEditor();
			TeamAmount.AddToDictionary("0", "0");
			TeamAmount.AddToDictionary("1", "1");
			TeamAmount.AddToDictionary("2", "2");
			TeamAmount.AddToDictionary("3", "3");
			TeamAmount.AddToDictionary("4", "4");
			TeamAmount.AddToDictionary("5", "5");
			TeamAmount.AddToDictionary("6", "6");
			TeamAmount.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultList;

			TeamAmountF = new ExpressionMemberValueEditor();
			TeamAmountF.AddToDictionary("0", "0");
			TeamAmountF.AddToDictionary("1", "1");
			TeamAmountF.AddToDictionary("2", "2");
			TeamAmountF.AddToDictionary("3", "3");
			TeamAmountF.AddToDictionary("4", "4");
			TeamAmountF.AddToDictionary("5", "5");
			TeamAmountF.AddToDictionary("6", "6");
			TeamAmountF.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListPlusDialog;

            SpecialShipType = new ExpressionMemberValueEditor();
            SpecialShipType.AddToDictionary(null,   "Unspecified");
            SpecialShipType.AddToDictionary("-1",   "Nothing");
            SpecialShipType.AddToDictionary("0",    "Upgraded");
            SpecialShipType.AddToDictionary("1",    "Overpowered");
            SpecialShipType.AddToDictionary("2",    "Underpowered");
            //SpecialShipType.AddToDictionary("3",    "Dilapidated");
            SpecialShipType.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

            MonsterType = new ExpressionMemberValueEditor();
            MonsterType.AddToDictionary("0", "Typhon");
            MonsterType.AddToDictionary("1", "Whale");
            MonsterType.AddToDictionary("2", "Shark");
            MonsterType.AddToDictionary("3", "Dragon");
            MonsterType.AddToDictionary("4", "Piranha");
            MonsterType.AddToDictionary("5", "Charybdis");
            MonsterType.AddToDictionary("6", "NSect");
            MonsterType.AddToDictionary("7", "Jelly");
            MonsterType.AddToDictionary("8", "Wreck");
            MonsterType.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

            DriveType = new ExpressionMemberValueEditor();
            DriveType.AddToDictionary("Any", "Any");
            DriveType.AddToDictionary("Warp", "Warp");
            DriveType.AddToDictionary("Jump", "Jump");
            DriveType.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

            VariableType = new ExpressionMemberValueEditor();
            VariableType.AddToDictionary("", "Float");
            VariableType.AddToDictionary("yes", "Integer");
            VariableType.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

            SensorRange = new ExpressionMemberValueEditor();
            SensorRange.AddToDictionary("0", "Unlimited");
            SensorRange.AddToDictionary("1", "33K");
            SensorRange.AddToDictionary("2", "16K");
            SensorRange.AddToDictionary("3", "11K");
            SensorRange.AddToDictionary("4", "8K");
            SensorRange.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;


            AnomalyType = new ExpressionMemberValueEditor();
            AnomalyType.AddToDictionary("0", "Energy");
            AnomalyType.AddToDictionary("1", "DamCon");
            AnomalyType.AddToDictionary("2", "Heat");
            AnomalyType.AddToDictionary("3", "Scan");
            AnomalyType.AddToDictionary("4", "Beam");
            AnomalyType.AddToDictionary("5", "Speed");
            AnomalyType.AddToDictionary("6", "Shield");
            AnomalyType.AddToDictionary("7", "Code Case");
            AnomalyType.AddToDictionary("8", "Beacon");
            AnomalyType.AddToDictionary("9", "Space Junk");
            AnomalyType.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

            SpecialCaptainType = new ExpressionMemberValueEditor();
            SpecialCaptainType.AddToDictionary(null,   "Unspecified");
            SpecialCaptainType.AddToDictionary("-1",   "Nothing");
            SpecialCaptainType.AddToDictionary("0",    "Cowardly");
            SpecialCaptainType.AddToDictionary("1",    "Brave");
            SpecialCaptainType.AddToDictionary("2",    "Bombastic");
            SpecialCaptainType.AddToDictionary("3",    "Seething");
            SpecialCaptainType.AddToDictionary("4",    "Duplicitous");
            SpecialCaptainType.AddToDictionary("5",    "Exceptional");
            SpecialCaptainType.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

            SpecialSpecialSwitchState = new ExpressionMemberValueEditor();
            SpecialSpecialSwitchState.AddToDictionary(null, "add");
            SpecialSpecialSwitchState.AddToDictionary("clear", "Clear");
            SpecialSpecialSwitchState.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

            SpecialSpecialState = new ExpressionMemberValueEditor();
            SpecialSpecialState.AddToDictionary(null, "Unspecified");
            SpecialSpecialState.AddToDictionary("Stealth", "Stealth");
            SpecialSpecialState.AddToDictionary("LowVis", "LowVis");
            SpecialSpecialState.AddToDictionary("Cloak", "Cloak");
            SpecialSpecialState.AddToDictionary("HET", "HET");
            SpecialSpecialState.AddToDictionary("Warp", "Warp");
            SpecialSpecialState.AddToDictionary("Teleport", "Teleport");
            SpecialSpecialState.AddToDictionary("Tractor", "Tractor");
            SpecialSpecialState.AddToDictionary("Drones", "Drones");
            SpecialSpecialState.AddToDictionary("AntiMine", "AntiMine");
            SpecialSpecialState.AddToDictionary("AntiTorp", "AntiTorp");
            SpecialSpecialState.AddToDictionary("ShldDrain", "ShldDrain");
            SpecialSpecialState.AddToDictionary("ShldVamp", "ShldVamp");
            SpecialSpecialState.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

            Side = new ExpressionMemberValueEditor();
            Side.AddToDictionary(null,  "Default");
            Side.AddToDictionary("0",   "0 (No side)");
            Side.AddToDictionary("1",   "1 (Enemy)");
            Side.AddToDictionary("2",   "2 (Player)");
            Side.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListPlusDialogWithFirstSeparated;

            NebulaTypeOrNone = new ExpressionMemberValueEditor();
            NebulaTypeOrNone.AddToDictionary("0", "not in a");
            NebulaTypeOrNone.AddToDictionary("1", "in a Purple");
            NebulaTypeOrNone.AddToDictionary("2", "in a Blue");
            NebulaTypeOrNone.AddToDictionary("3", "in a Yellow");
            NebulaTypeOrNone.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

            NebulaType = new ExpressionMemberValueEditor();
            NebulaType.AddToDictionary(null, "Default");
            NebulaType.AddToDictionary("1",  "Purple");
            NebulaType.AddToDictionary("2",  "Blue");
            NebulaType.AddToDictionary("3",  "Yellow");
            NebulaType.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

            MonsterAge = new ExpressionMemberValueEditor();
            MonsterAge.AddToDictionary(null, "Default");
            MonsterAge.AddToDictionary("1",  "1 (Young)");
            MonsterAge.AddToDictionary("2",  "2 (Mature)");
            MonsterAge.AddToDictionary("3",  "3 (Ancient)");
            MonsterAge.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultListWithFirstSeparated;

			Comparator = new ExpressionMemberValueEditor();
			Comparator.AddToDictionary("GREATER",       ">");
			Comparator.AddToDictionary("GREATER_EQUAL", ">=");
			Comparator.AddToDictionary("EQUALS",        "=");
			Comparator.AddToDictionary("NOT",           "!=");
			Comparator.AddToDictionary("LESS_EQUAL",    "<=");
			Comparator.AddToDictionary("LESS",          "<");
			Comparator.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultList;

			DistanceNebulaCheck = new ExpressionMemberValueEditor();
			DistanceNebulaCheck.AddToDictionary("anywhere", "anywhere", "anywhere on the map");
			DistanceNebulaCheck.AddToDictionary("anywhere2", "anywhere", "anywhere outside a nebula or up to ... if inside");
			DistanceNebulaCheck.AddToDictionary("closer than", "closer than", "closer than ... if outside a nebula or up to ... if inside");
			DistanceNebulaCheck.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultCheck;

			ConvertDirectCheck = new ExpressionMemberValueEditor();
			ConvertDirectCheck.AddToDictionary("Do nothing", "(Click here to convert)", "Do nothing");
			ConvertDirectCheck.AddToDictionary("Convert to add_ai", "YOU SHOULD NEVER SEE THIS", "Convert to add_ai");
			ConvertDirectCheck.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultCheck;

			TimerName = new ExpressionMemberValueEditor();
			TimerName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_TimerNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { TimerName.InvalidateContextMenuStrip(); });

			ExternalProgramID = new ExpressionMemberValueEditor();
			ExternalProgramID.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_ExternalProgramIDList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { ExternalProgramID.InvalidateContextMenuStrip(); });


			VariableName = new ExpressionMemberValueEditor();
			VariableName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_VariableNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { VariableName.InvalidateContextMenuStrip(); });

			GMButtonText = new ExpressionMemberValueEditor();
			GMButtonText.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_GMButtonTextList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { GMButtonText.InvalidateContextMenuStrip(); });

			CommsButtonText = new ExpressionMemberValueEditor();
			CommsButtonText.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_CommsButtonTextList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { CommsButtonText.InvalidateContextMenuStrip(); });

			NamedAllName = new ExpressionMemberValueEditor();
			NamedAllName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NamedAllNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { NamedAllName.InvalidateContextMenuStrip(); });
			
			NamedStationName = new ExpressionMemberValueEditor();
			NamedStationName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NamedStationNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { NamedStationName.InvalidateContextMenuStrip(); });

			NamedGenericMeshName = new ExpressionMemberValueEditor();
			NamedGenericMeshName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NamedGenericMeshNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { NamedGenericMeshName.InvalidateContextMenuStrip(); });

			NamedMonsterName = new ExpressionMemberValueEditor();
			NamedMonsterName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NamedMonsterNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { NamedMonsterName.InvalidateContextMenuStrip(); });

			NamedEnemyName = new ExpressionMemberValueEditor();
			NamedEnemyName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NamedEnemyNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { NamedEnemyName.InvalidateContextMenuStrip(); });

			NamedNeutralName = new ExpressionMemberValueEditor();
			NamedNeutralName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NamedNeutralNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { NamedNeutralName.InvalidateContextMenuStrip(); });

            NamedShipName = new ExpressionMemberValueEditor();
            NamedShipName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NamedShipNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { NamedShipName.InvalidateContextMenuStrip(); });

            NamedAIShipName = new ExpressionMemberValueEditor();
            NamedAIShipName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NamedAIShipNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { NamedAIShipName.InvalidateContextMenuStrip(); });

            NamedAIShipOrMonsterName = new ExpressionMemberValueEditor();
            NamedAIShipOrMonsterName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_NamedAIShipOrMonsterNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { NamedAIShipOrMonsterName.InvalidateContextMenuStrip(); });

            ScannableObjectName = new ExpressionMemberValueEditor();
            ScannableObjectName.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_ScannableObjectNameList;
            Mission.NamesListUpdated += new EventHandler<NamesListUpdatedEventArgs>((s, e) => { ScannableObjectName.InvalidateContextMenuStrip(); });

            CommTypes = new ExpressionMemberValueEditor_CommTypes();

			ConsoleList = new ExpressionMemberValueEditor_ConsoleList();

			EliteAIType = new ExpressionMemberValueEditor();
			EliteAIType.AddToDictionary("0",    "behave like a normal ship");
			EliteAIType.AddToDictionary("0.0",  "behave like a normal ship");
			EliteAIType.AddToDictionary("1",    "follow nearest normal fleet");
			EliteAIType.AddToDictionary("1.0",  "follow nearest normal fleet");
			EliteAIType.AddToDictionary("2",    "ignore everything except players");
			EliteAIType.AddToDictionary("2.0",  "ignore everything except players");
			EliteAIType.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultList;

			EliteAbilityBits = new ExpressionMemberValueEditor_AbilityBits();

			PlayerNames = new ExpressionMemberValueEditor();
			PlayerNames.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_PlayerListPlusDialog;

			WarpState = new ExpressionMemberValueEditor();
			WarpState.AddToDictionary("0", "0");
			WarpState.AddToDictionary("1", "1");
			WarpState.AddToDictionary("2", "2");
			WarpState.AddToDictionary("3", "3");
			WarpState.AddToDictionary("4", "4");
			WarpState.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_DefaultList;

            PathEditor = new ExpressionMemberValueEditor_PathEditor();

			HullID = new ExpressionMemberValueEditor_HullID();
			HullID.PrepareContextMenuStripMethod = ExpressionMemberValueEditor.PrepareContextMenuStrip_HullIDList;
            VesselData.VesselDataChanged += new EventHandler<VesselDataChangedEventArgs>((s, e) => { HullID.InvalidateContextMenuStrip(); });
	
			RaceKeys = new ExpressionMemberValueEditor_RaceKeys();
            VesselData.VesselDataChanged += new EventHandler<VesselDataChangedEventArgs>((s, e) => { RaceKeys.InvalidateContextMenuStrip(); });

			HullKeys = new ExpressionMemberValueEditor_HullKeys();
            VesselData.VesselDataChanged += new EventHandler<VesselDataChangedEventArgs>((s, e) => { HullKeys.InvalidateContextMenuStrip(); });
		}
    }
}
