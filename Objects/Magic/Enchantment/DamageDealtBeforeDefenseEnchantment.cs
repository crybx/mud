﻿using Objects.Global;
using Objects.Mob.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Objects.Magic.Enchantment
{
    public class DamageDealtBeforeDefenseEnchantment : BaseEnchantment
    {
        [ExcludeFromCodeCoverage]
        public bool TargetIsDefender { get; set; }

        public DamageDealtBeforeDefenseEnchantment(bool targetIsDefender = true)
        {
            TargetIsDefender = targetIsDefender;
        }

        public override void DamageBeforeDefense(IMobileObject attacker, IMobileObject defender, int damageAmount, string attackerDescription = null)
        {
            if (GlobalReference.GlobalValues.Random.PercentDiceRoll(ActivationPercent))
            {
                Parameter.ObjectRoom = attacker?.Room ?? defender?.Room;
                Parameter.Defender = defender;
                Parameter.Attacker = attacker;
                Parameter.Description = attackerDescription;
                if (TargetIsDefender)
                {
                    Parameter.Target = defender;
                }
                else
                {
                    Parameter.Target = attacker;
                }
                Effect.ProcessEffect(Parameter);
            }
        }
    }
}
