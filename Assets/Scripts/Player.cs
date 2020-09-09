using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class Player : MonoBehaviour
{
    [SerializeField] private Critter[] critters;

    private void Start()
    {
        //Ver que las skills sean entre 1 y 3 y sean únicas
        if (critters.Length < 1)
        {
            throw new Exception("Debe de tener almenos 1 Critter");
        }
        else if (critters.Length <= 3)
        {
            if (!IsUnique(critters))
                throw new Exception("No son Critters diferentes");
        }
        else
        {
            Critter[] crittersTemp = new Critter[3];

            for (int i = 0; i < 3; i++)
                crittersTemp[i] = critters[i];

            if (!IsUnique(crittersTemp))
                throw new Exception("No son Critters diferentes, además son más de 3");
        }
    }

    private bool IsUnique(Critter[] critters)
    {
        foreach (Critter critter in critters)
            if (critters.Count(c => c == critter) > 1)
                return false;
        return true;
    }

    public void AddCritter(Critter critter)
    {
        List<Critter> listTemp = critters.ToList();
        listTemp.Add(critter);
        critters = listTemp.ToArray();
    }

    public void RemoveCritter(Critter critter)
    {
        for (int i = 0; i < critters.Length; i++)
        {
            if (critter == critters[i])
            {
                critters[i] = null;
                break;
            }
        }
    }


    internal Critter[] Critters { get => critters; }
}

