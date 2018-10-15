using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCollider : MonoBehaviour {

    private Movement playerone;
    private bool runonce;
    public GameObject self;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !runonce)
        {
            playerone = other.GetComponent<Movement>();
            runonce = true;
            GetPower();
        }
    }
    void GetPower()
    {
        /*Esto se puede mejorar con un segundo sistema que nos indique que se consiguio algo*/
        var particles = GetComponent<ParticleSystem>();
        particles.Stop();
        playerone.Powerup();
        Invoke("DeleteSelf", 0.5f);
    }
    void DeleteSelf()
    {
        Destroy(self);
    }
}
