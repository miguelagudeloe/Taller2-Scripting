using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField]
    private Slider sliderPlayer;
    [SerializeField]
    private Slider sliderAI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        sliderPlayer.maxValue = Referee.Instance.Critter1.MaxHP;
        sliderAI.maxValue = Referee.Instance.Critter2.MaxHP;

        sliderPlayer.value = Referee.Instance.Critter1.Hp;
        sliderAI.value = Referee.Instance.Critter2.Hp;

            

    }
}
