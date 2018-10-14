using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void Jugar()
    {
        SceneManager.LoadScene("sceneone");
    }
    public void Salir()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }

}
