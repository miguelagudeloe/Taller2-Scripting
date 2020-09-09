using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "new skill", menuName = "Skills/AtkUpSkill")]
class AtkUp : SupportSkill
{
    [SerializeField] float debuf = 20;

    public override void Use(Critter critter)
    {
        critter.BoostAttack(debuf);
    }
}
