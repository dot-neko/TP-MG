using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour {

    public GameObject lara, pepe, manuel1, miguel1, tablas, manuel2, miguel2, hechicera1, cristal, hechicera2, area_block_2, pepeplaya,anillo,pepeplayaexit, extra1, extra2, area_b1;
    public bool first, escape;
    public int progress = 1;


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
                tablas.SetActive(true);
                Debug.Log("Pepe desaparece del mapa.");
                return;
            case "Tablas":
                progress += 1;
                Destroy(manuel1);
                Destroy(miguel1);
                Destroy(tablas);
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
                cristal.SetActive(true);
                Debug.Log("Inicia quest de viento/cristal");
                return;
            case "Cristal":
                progress += 1;
                Destroy(cristal);
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
                Destroy(area_block_2);
                /*En teoría con esto se deshabilita el trigger dentro del collider del GO*/
                (area_b1.GetComponent<SphereCollider>()).enabled=false;
                Debug.Log("Fin quest de viento/cristal");
                return;
            case "PepePlaya":
                progress += 1;
                Destroy(hechicera2);
                anillo.SetActive(true);
                escape = true;
                Debug.Log("Inicia quest final anillo");
                return;
            case "Anillo":
                progress += 1;
                Destroy(pepeplaya);
                Destroy(anillo);
                pepeplayaexit.SetActive(true);
                Debug.Log("Inicia quest final anillo");
                return;
            case "PepePlayaExit":
                progress += 1;
                Scene scene = SceneManager.GetActiveScene();
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
