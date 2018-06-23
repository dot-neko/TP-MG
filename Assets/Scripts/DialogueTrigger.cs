using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public int story_id;
    public Dialogue dialoge;
    private Animation m_Animation;
    private Transform character;
    private bool runonce;

    private void Start()
    {
        character = GetComponent<Transform>();
        runonce = false;
    }
    void OnTriggerEnter(Collider other)
    {
        bool check = FindObjectOfType<StoryManager>().Check_Status(story_id);
        if (other.tag == "Player" && !runonce && check)
        {
            if (tag == "StoryCharacters")
            {
                m_Animation = GetComponent<Animation>();
                m_Animation.Play("talk");
            }           
            TriggerDialogue();
            runonce = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (m_Animation)
        {
            m_Animation.Play("idle");
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialoge);
        Story(); 
    }
    public void Story()
    {
        FindObjectOfType<StoryManager>().Update_Story(character);//Aca deberia enviar el estado actual de la historia.
    }
}
