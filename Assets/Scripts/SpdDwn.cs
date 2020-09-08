using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "new skill", menuName = "SpdDownSkill")]
class SpdDwn : SupportSkill
{       

    public override void Use(Critter critter)
    {
        critter.BoostSpeed(-30);
    }
}

