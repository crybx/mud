﻿using Objects.Mob;
using System.Collections.Generic;

namespace Objects.Race.Interface
{
    public interface IRace
    {
        double ExperanceModifier { get; }
        List<MobileObject.MobileAttribute> RaceAttributes { get; }



        /// <summary>
        ///Values 1+        = Resistance 
        ///Values = 1       = Normal Damage
        ///Values 1 - 0     = Weakness
        ///Values = 0       = Immune
        ///Values 0-        = Absorb Damage
        /// </summary>
        #region DamageType
        decimal Acid { get; set; }
        decimal Bludgeon { get; set; }
        decimal Cold { get; set; }
        decimal Fire { get; set; }
        decimal Force { get; set; }
        decimal Lightning { get; set; }
        decimal Necrotic { get; set; }
        decimal Pierce { get; set; }
        decimal Poison { get; set; }
        decimal Psychic { get; set; }
        decimal Radiant { get; set; }
        decimal Slash { get; set; }
        decimal Thunder { get; set; }
        #endregion DamageType

        string ToString();
    }
}