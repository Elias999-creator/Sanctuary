using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        var Player = collision.GetComponent<CharController_Motor>();
        if (Player)
        {
            CharController_Motor.instance.KillPlayer();
        }
    }
}
