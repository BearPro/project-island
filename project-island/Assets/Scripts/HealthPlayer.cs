using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public int Health { get => health; set => health = value; }
    public Slider slider;
    [SerializeField]
    private int health = 100;

    void Start()
    {

    }

    void Update()
    {
        if(this.tag == "Player" && this.health < 14)
        {
            this.Health = 14;
        }
        if (slider != null)
        {
            slider.value = Health;
        }
        if (Health < 0)
        {
            if (this.tag != "Player")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
