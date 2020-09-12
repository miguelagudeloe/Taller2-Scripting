using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayingCritters : MonoBehaviour
{
    [SerializeField] GameObject playerCritter;
    [SerializeField] GameObject enemyCritter;

    private void OnEnable()
    {
        Referee.OnPlayerCritterChange += PlayerCritterChange;
        Referee.OnEnemyCritterChange += EnemyCritterChange;
    }

    private void OnDisable()
    {
        Referee.OnPlayerCritterChange -= PlayerCritterChange;
        Referee.OnEnemyCritterChange -= EnemyCritterChange;
    }

    void PlayerCritterChange()
    {
        Critter critter = Referee.Instance.CritterPlayer;
        if (critter == null)
            playerCritter.SetActive(false);
        else
        {
            if (!playerCritter.activeInHierarchy)
                playerCritter.SetActive(true);

            GameObject critterObj = critter.transform.gameObject;
            SpriteRenderer renderer = critterObj.GetComponentInChildren<SpriteRenderer>();
            Animator anim = critterObj.GetComponentInChildren<Animator>();

            playerCritter.GetComponent<SpriteRenderer>().sprite = renderer.sprite;
            playerCritter.GetComponent<Animator>().runtimeAnimatorController = anim.runtimeAnimatorController;
        }
    }

    void EnemyCritterChange()
    {
        Critter critter = Referee.Instance.CritterEnemy;
        if (critter == null)
            enemyCritter.SetActive(false);
        else
        {
            if (!enemyCritter.activeInHierarchy)
                enemyCritter.SetActive(true);

            GameObject critterObj = critter.transform.gameObject;
            SpriteRenderer renderer = critterObj.GetComponentInChildren<SpriteRenderer>();
            Animator anim = critterObj.GetComponentInChildren<Animator>();

            enemyCritter.GetComponent<SpriteRenderer>().sprite = renderer.sprite;
            enemyCritter.GetComponent<Animator>().runtimeAnimatorController = anim.runtimeAnimatorController;
        }
    }

}
