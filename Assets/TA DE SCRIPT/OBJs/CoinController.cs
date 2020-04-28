using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.Core;
using NavGame.misskiss;

public class CoinController : CollectibleGameOBJ
{
    public string pickupSound;
    public override void Pickup()
    {
        Destroy(gameObject);
        AudioManager.instance.Play(pickupSound, transform.position);
    }

}
