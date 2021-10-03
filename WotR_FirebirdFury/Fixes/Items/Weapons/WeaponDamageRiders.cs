using HarmonyLib;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdFury.Config;

namespace FirebirdFury.Fixes.Items.Weapons
{
    static class WeaponDamageRiders
    {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;

            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;
                Main.LogHeader("Patching Weapon Damage Riders");

                PatchMindPiercer();
                void PatchMindPiercer()
                {
                    if (ModSettings.Fixes.Items.Weapons.IsDisabled("BladeOfTheMerciful")) { return; }
                    
                    var MindPiercerEnchant = Resources.GetBlueprint<BlueprintWeaponEnchantment>("14b57d538298ae04e8ac048adb73c2b2");
                    AddInitiatorAttackWithWeaponTrigger MindPiercerRider = (AddInitiatorAttackWithWeaponTrigger)MindPiercerEnchant.Components.FirstOrDefault(x => x is AddInitiatorAttackWithWeaponTrigger);
                    Conditional MindPiercerRiderConditional = (Conditional)MindPiercerRider.Action.Actions[0];//I can afford this because this is a length one list
                    ContextActionDealDamage MindPiercerRiderDamage = (ContextActionDealDamage)MindPiercerRiderConditional.IfTrue.Actions.FirstOrDefault(x => x is ContextActionDealDamage);
                    MindPiercerRiderDamage.DamageType.Physical.Material = Kingmaker.Enums.Damage.PhysicalDamageMaterial.ColdIron;
                    //MindPiercerRiderDamage.DamageType.Physical.Enhancement = 1; This doesn't make it peirce DR/magic
                    Main.LogPatch("Patched", MindPiercerEnchant);
                }
            }

             
        }
    }
}
