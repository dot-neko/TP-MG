using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public GameObject crater;
    private Transform parent;
    public bool runonce, inrange;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !runonce)
        {
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
        Invoke("Crater", 3.2f);
        Invoke("Death", 3.0f);
        
        
    }
    void Crater()
    {
        crater.SetActive(true);
    }
    void Death()
    {
        if (inrange)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

}
