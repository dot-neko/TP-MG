using UnityEngine;
public class Barrier_Trigger : MonoBehaviour
{
    public GameObject areabloqueada;
    private WindArea esfera;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            areabloqueada.SetActive(false);
            /*
            esfera =areabloqueada.GetComponent<WindArea>();
            esfera.Desaparecer();
            */
        }
    }
}
