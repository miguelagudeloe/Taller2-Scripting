using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "new skill", menuName = "Skills/SpdDownSkill")]
class SpdDwn : SupportSkill
{
    [SerializeField] float debuf = 30;

    public override void Use(Critter critter)
    {
        critter.BoostSpeed(-debuf);
    }
}
