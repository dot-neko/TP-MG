using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();

	}
    //Ha
	public void StartDialogue (Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);

        //Tomo el nombre del personaje
        nameText.text = dialogue.name;

        //Limpio lo que pueda existir de antes en la cola
        sentences.Clear();

        //Encolo las sentencias de dialogo
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
