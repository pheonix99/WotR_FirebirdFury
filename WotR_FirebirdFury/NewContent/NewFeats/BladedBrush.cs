using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using WotR_FirebirdFury.Extensions;
using WotR_FirebirdFury.Config;
//using TabletopTweaks.Extensions;
//using TabletopTweaks.NewComponents;
using WotR_FirebirdFury.Utilities;

namespace WotR_FirebirdFury.NewContent.NewFeats
{
    static class BladedBrush
    {
        public static void AddBladedBrush()
        {
            /*
            var Glaive = Resources.GetBlueprint<BlueprintWeaponType>("");
            var weapon_focus = Resources.GetBlueprint<BlueprintParametrizedFeature>("");
         

            var BladedBrush = Helpers.CreateBlueprint<BlueprintFeature>("BladedBrush", bp =>
            {
                bp.SetName("Bladed Brush");
                bp.SetDescription($"You know how to balance a polearm perfectly, striking with artful, yet deadly precision.{System.Environment.NewLine}You can use the Weapon Finesse feat to apply your Dexterity modifier instead of your Strength modifier to attack rolls with a glaive sized for you, even though it isn’t a light weapon. When wielding a glaive, you can treat it as a one-handed piercing or slashing melee weapon and as if you were not making attacks with your off-hand for all feats and class abilities that require such a weapon (such as a duelist’s or swashbuckler’s precise strike).");
                bp.Ranks = 1;
                bp.ReapplyOnLevelUp = true;
                bp.IsClassFeature = true;
                bp.Groups = new FeatureGroup[] { FeatureGroup.Feat };
                bp.AddComponent(Helpers.Create<AttackStatReplacementEnforced>(c => {
                    c.ReplacementStat = StatType.Dexterity;
                    c.m_WeaponTypes = new BlueprintWeaponTypeReference[] {
                        Glaive.ToReference<BlueprintWeaponTypeReference>()
                    };
                    c.CheckWeaponTypes = true;
                }));

                bp.AddPrerequisiteFeature(COTWHelpers.createPrerequisiteParametrizedFeatureWeapon(weapon_focus, WeaponCategory.Glaive, false));
            });
            */
        }
    }

}

