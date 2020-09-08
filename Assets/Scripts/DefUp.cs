using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

    [CreateAssetMenu(fileName = "new skill", menuName = "DefUpSkill")]
    class DefUp : SupportSkill
    {
        
        public override void Use(Critter critter)
        {
            critter.BoostDefense(20);
        }
    }

