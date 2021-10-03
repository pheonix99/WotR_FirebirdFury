using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.View.Animation;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WotR_FirebirdFury.Extensions;
using WotR_FirebirdFury.Utilities;

namespace WotR_FirebirdFury.NewContent.NewSpells
{
    class BurstOfRadiance
    {
        public static void AddBurstOfRadiance()
        {
            var BurstOfRadianceBlueprint = Helpers.CreateBlueprint<BlueprintAbility>("BurstOfRadianceSpell", bp =>
            {
                bp.Range = AbilityRange.Long;
                bp.CanTargetSelf = true;
                bp.CanTargetPoint = true;
                bp.CanTargetEnemies = true;
                bp.CanTargetFriends = true;
                bp.SpellResistance = true;
                bp.EffectOnEnemy = AbilityEffectOnUnit.Harmful;
                bp.EffectOnAlly = AbilityEffectOnUnit.Harmful;
                bp.Animation = UnitAnimationActionCastSpell.CastAnimationStyle.Directional;
                bp.AnimationStyle = CastAnimationStyle.CastActionOmni;//TODO see if this can be killed safely once I establish this works
                bp.ActionType = UnitCommand.CommandType.Standard;
                bp.AvailableMetamagic = Metamagic.Quicken | Metamagic.Heighten | Metamagic.Bolstered | Metamagic.Empower | Metamagic.Maximize | Metamagic.Reach | Metamagic.Heighten | Metamagic.CompletelyNormal | Metamagic.Persistent | Metamagic.Selective;
                bp.SetName("Burst Of Radiance");
                bp.SetDescription("This spell fills the area with a brilliant flash of shimmering light. Creatures in the area are blinded for 1d4 rounds, or dazzled for 1d4 rounds if they succeed at a Reflex save. Evil creatures in the area of the burst take 1d4 points of damage per caster level (max 5d4), whether they succeed at the Reflex save or not.");
                bp.AddComponent(Helpers.CreateSpellDescriptor(SpellDescriptor.Good));
                bp.AddComponent(Helpers.CreateSpellDescriptor(SpellDescriptor.Blindness));
                bp.AddComponent(Helpers.CreateSpellDescriptor(SpellDescriptor.SightBased));

                var dazzled = Resources.GetBlueprint<BlueprintBuff>("df6d1025da07524429afbae248845ecc");
                var blinded = Resources.GetBlueprint<BlueprintBuff>("187f88d96a0ef464280706b63635f2af");

                var duration = Helpers.CreateContextDuration(0, diceType: DiceType.D4, diceCount: 1);
                var effect = Helpers.CreateConditionalSaved(Helpers.createContextActionApplyBuff(dazzled, duration, is_from_spell: true),
                                                            Helpers.createContextActionApplyBuff(blinded, duration, is_from_spell: true));

                var damage = Helpers.CreateActionDealDamage(DamageEnergyType.Divine, Helpers.CreateContextDiceValue(DiceType.D4, Helpers.CreateContextValue(AbilityRankType.Default)), isAoE: true);

                var apply_damage = Helpers.CreateConditional(Helpers.CreateContextConditionAlignment(AlignmentComponent.Evil),
                                                             damage);

               
                
                bp.AddComponent(Helpers.CreateRunActions(SavingThrowType.Reflex, effect, apply_damage));

            });
        }
    }
}
