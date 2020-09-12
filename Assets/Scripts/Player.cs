using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Expandable]
    [SerializeField] private List<Critter> aliveCritters = new List<Critter>();
    [Expandable]
    [SerializeField] private List<Critter> deadCritters = new List<Critter>();

    private void Start()
    {
        foreach (Critter critter in aliveCritters)
            critter.Init();

        RemoveDead();

        //Ver que las skills sean entre 1 y 3 y sean únicas
        if (aliveCritters.Count < 1)
        {
            throw new Exception("Debe de tener almenos 1 Critter");
        }
        else if (aliveCritters.Count <= 3)
        {
            if (!IsUnique(aliveCritters))
                throw new Exception("No son Critters diferentes");
        }
        else
        {
            List<Critter> crittersTemp = new List<Critter>();

            for (int i = 0; i < 3; i++)
                crittersTemp.Add(aliveCritters[i]);

            if (!IsUnique(crittersTemp))
                throw new Exception("No son Critters diferentes, además son más de 3");
        }
    }

    private bool IsUnique(List<Critter> critters)
    {
        foreach (Critter critter in critters)
            if (critters.Count(c => c == critter) > 1)
                return false;
        return true;
    }

    public void AddCritter(Critter critter)
    {
        if (critter.IsDead)
            deadCritters.Add(critter);
        else
            aliveCritters.Add(critter);
    }

    public void RemoveCritter(Critter critter)
    {
        /* foreach (Critter critter_ in aliveCritters)
        {
            if (critter_ == critter)
            {
                aliveCritters.Remove(critter);
                deadCritters.Add(critter);
                break;
            }
        } */
        if (aliveCritters.Count > 0)
        {
            aliveCritters.RemoveAt(0);
            deadCritters.Add(critter);
        }
    }

    public void RemoveDead()
    {
        foreach (Critter critter_ in aliveCritters)
        {
            if (critter_.IsDead)
            {
                aliveCritters.Remove(critter_);
                deadCritters.Add(critter_);
            }
        }
    }


    public List<Critter> AliveCritters { get => aliveCritters; }

    public List<Critter> DeadCritters { get => aliveCritters; }

}

