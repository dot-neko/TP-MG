using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCollider : MonoBehaviour {

    private Movement playerone;
    private bool runonce;
    public GameObject self;
    private Animator rotation_anim;
    private void Start()
    {
        rotation_anim=GetComponent<Animator>();
        rotation_anim.Play(0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !runonce)
        {
            playerone = other.GetComponentInChildren<Movement>();
            runonce = true;
            GetPower();
        }
    }
    void GetPower()
    {
        /*Esto se puede mejorar con un segundo sistema que nos indique que se consiguio algo*/
        var particles = (self.GetComponentInChildren<ParticleSystem>()).main;
        var sound=self.GetComponentInChildren<AudioSource>();
        sound.Play(0);
        /*rotation_anim.Play(1);*/
        particles.loop=false;
        playerone.Powerup();
        Invoke("DeleteSelf", 4.0f);
    }

    void DeleteSelf()
    {
        Destroy(self);
    }
}
