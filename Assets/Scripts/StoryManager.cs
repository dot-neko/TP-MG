using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour {

    public GameObject lara, pepe, manuel1, miguel1, manuel2, miguel2, hechicera1, hechicera2, pepeplaya, pepeplayaexit, extra1, extra2;
    public bool first, tablas, cristales, escape;
    public int progress = 1;
    public Animator animator;


    public void Update_Story(Transform character)
    {
        string name = character.name;
        switch (name)
        {
            case "Lara":
                first = true;
                progress += 1;
                Debug.Log("Lara desaparece con un efecto de magia");
                return;
            case "Pepe":
                progress += 1;
                Destroy(lara);
                return;
            case "Manuel":
                progress += 1;
                Destroy(pepe);
                Debug.Log("Pepe desaparece del mapa.");
                return;
            case "Tablas":
                progress += 1;
                tablas = true;
                Destroy(manuel1);
                Destroy(miguel1);
                manuel2.SetActive(true);
                miguel2.SetActive(true);
                Debug.Log("Los dos hermanos son reemplazados por las versiones con nuevo dialogo");
                return;
            case "Miguel2":
                progress += 1;
                hechicera1.SetActive(true);
                Debug.Log("Finalizado quest de tablas.");
                return;
            case "Hechicera":
                progress += 1;
                Destroy(manuel2);
                Destroy(miguel2);
                Debug.Log("Inicia quest de viento/cristal");
                return;
            case "Cristal":
                progress += 1;
                cristales = true;
                Destroy(hechicera1);
                hechicera2.SetActive(true);
                Debug.Log("La hechicera es reemplazada por la nueva version");
                return;
            case "Hechicera Salida":
                progress += 1;
                Destroy(extra1);
                extra2.SetActive(true);
                extra2.GetComponentInChildren<Animation>().Play("DeadGuard");
                pepeplaya.SetActive(true);
                Debug.Log("Fin quest de viento/cristal");
                return;
            case "PepePlaya":
                progress += 1;
                Destroy(hechicera2);
                escape = true;
                Debug.Log("Inicia quest final anillo");
                return;
            case "Anillo":
                progress += 1;
                Destroy(pepeplaya);
                pepeplayaexit.SetActive(true);
                Debug.Log("Inicia quest final anillo");
                return;
            case "PepePlayaExit":
                progress += 1;
                animator.SetBool("IsOpen", true);
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.UnloadSceneAsync(scene.name);
                SceneManager.LoadScene("endgame");
                Debug.Log("Fin quest final anillo. Fin del juego.");
                return;
        }   
    }
    public bool Check_Status(int status)
    {
        bool check = false;
        if (status == progress || status == 0)
        {
            check = true;
        }
        return check;
    }
}
