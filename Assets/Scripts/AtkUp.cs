using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


    [CreateAssetMenu(fileName = "new skill",menuName = "AtkUpSkill")]
    class AtkUp : SupportSkill
    {
               
        public override void Use(Critter critter)
        {
            critter.BoostAttack(20);
        }
    }

