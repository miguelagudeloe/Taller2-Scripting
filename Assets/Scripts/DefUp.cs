using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "new skill", menuName = "Skills/DefUpSkill")]
class DefUp : SupportSkill
{
    [SerializeField] float debuf = 20;

    public override void Use(Critter critter)
    {
        critter.BoostDefense(debuf);
    }
}
