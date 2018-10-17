using UnityEngine;
public class WindArea : MonoBehaviour {
    private Animator anim_1;
    private void Start()
    {
        CheckAssignAnimator();
    }
    void CheckAssignAnimator()
    {
        if (GetComponent<Animator>() != null)
        {
            /*
            anim_1 = GetComponent<Animator>();
            anim_1.Play(0);
            */

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Movement>().InsideWindzone();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Movement>().OutsideWindzone();
        }
    }
    public void Desaparecer()
    {
        /*anim_1.Play(0);*/
    }
}
