using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Critter
{
    // Atributos
    [SerializeField] private string name;
    [SerializeField] private float baseAttack;
    [SerializeField] private float baseDefense;
    [SerializeField] private float baseSpeed;
    [SerializeField] private float maxHP;
    [SerializeField]
    private float hp;
    [SerializeField] private Affinity.AffinityType affinity;
    [Expandable]
    [SerializeField] private Skill[] moveSet;



    private float attackBoost;
    private float defenseBoost;
    private float speedBoost;

    private bool isDead;

    private Dictionary<string, int> atributesUpgraded = new Dictionary<string, int>
    {
        { "Attack",  0 },
        { "Defense", 0 },
        { "Speed",   0 }
    };


    public void Start()
    {
        hp = maxHP;

        // A estos no les hacemos excepción porque podemos clampearlos
        baseAttack = Mathf.Clamp(baseAttack, 10, 100);
        baseDefense = Mathf.Clamp(baseDefense, 10, 100);
        baseSpeed = Mathf.Clamp(baseSpeed, 1, 50);

        //Ver que las skills sean entre 1 y 3 y sean únicas
        if (moveSet.Length < 1)
        {
            throw new Exception("Debe de tener almenos 1 skill");
        }
        else if (moveSet.Length <= 3)
        {
            if (!IsUnique(moveSet))
                throw new Exception("No son Skills diferentes");
        }
        else
        {
            Skill[] skillsTemp = new Skill[3];

            for (int i = 0; i < 3; i++)
                skillsTemp[i] = moveSet[i];

            if (!IsUnique(skillsTemp))
                throw new Exception("No son Skills diferentes, además son más de 3");

            moveSet = skillsTemp;
        }

        hp = (hp > 0) ? hp : 1;

        ResetBoost();
    }

    private bool IsUnique(Skill[] moveSet)
    {
        foreach (Skill skill in moveSet)
            if (moveSet.Count(s => s == skill) > 1)
                return false;
        return true;
    }

    public void ResetBoost()
    {
        attackBoost = 1;
        defenseBoost = 1;
        speedBoost = 1;
    }

    public void BoostAttack(float porcent)
    {
        if (atributesUpgraded["Attack"] < 3)
        {
            attackBoost += porcent / 100;
            atributesUpgraded["Attack"] += 1;
        }
    }

    public void BoostDefense(float porcent)
    {
        if (atributesUpgraded["Defense"] < 3)
        {
            defenseBoost += porcent / 100;
            atributesUpgraded["Defense"] += 1;
        }
    }

    public void BoostSpeed(float porcent)
    {
        if (atributesUpgraded["Speed"] < 3)
        {
            speedBoost += porcent / 100;
            atributesUpgraded["Speed"] += 1;
        }
    }

    public float Attack(AttackSkill skill, Critter enemy)
    {
        float affinityMultiplayer = Affinity.InteractValue(skill.Affinity, enemy.AffinityCritter);
        return (AttackValue + skill.Power) * affinityMultiplayer;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        isDead = (hp <= 0);
    }

    public override string ToString()
    {
        return Name;
    }

    public string Name { get => name; }
    public float BaseAttack { get => baseAttack; }
    public float AttackValue { get => baseAttack * attackBoost; }
    public float BaseDefense { get => baseDefense; }
    public float DefenseValue { get => baseDefense * defenseBoost; }
    public float BaseSpeed { get => baseSpeed; }
    public float SpeedValue { get => baseSpeed * speedBoost; }
    internal Affinity.AffinityType AffinityCritter { get => affinity; }
    internal Skill[] MoveSet { get => moveSet; }
    public float Hp { get => hp; }
    public float MaxHP { get => maxHP; }
    public bool IsDead { get => isDead; }
}

