using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {
    private Animation m_Animation;
    // Use this for initialization
    void Start () {
        m_Animation = GetComponentInChildren<Animation>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        m_Animation.Play("panic");
    }
}
