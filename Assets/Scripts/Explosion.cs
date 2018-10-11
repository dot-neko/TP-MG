using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public GameObject crater;
    private Movement playerone;
    private Animation playerone_anim;
    private Transform parent;
    public bool runonce, inrange;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !runonce)
        {
            playerone = other.GetComponent<Movement>();
            playerone_anim = other.gameObject.GetComponentInChildren<Animation>();
            Explode();
            runonce = true;
            inrange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        inrange = false;
    }
    void Explode()
    {
        var track = GetComponentInChildren<ParticleSystem>();
        track.Play();
        Invoke("Crater", 1.6f);
        Invoke("Death", 1.5f);

    }
    void Crater()
    {
        crater.SetActive(true);
    }
    void Death()
    {
        if (inrange)
        {
            playerone.Death();
            playerone_anim.CrossFade("DeathSW");
            Invoke("Reload", 1.7f);
        }
    }
    void Reload()
    {
        playerone_anim.Stop();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
