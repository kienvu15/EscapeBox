using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject[] firstGroup;
    public GameObject[] secondGroup;

    public Activator button;

    public Material normal;
    public Material tranparent;

    public bool canPush;

    private void OnTriggerEnter(Collider collision)
    {
        if (canPush)
        {
            if (collision.CompareTag("Cube") || collision.CompareTag("Player"))
            {
                foreach (GameObject first in firstGroup)
                {
                    first.GetComponent<Renderer>().material = normal;
                    first.GetComponent<Collider>().isTrigger = false;
                }

                foreach (GameObject second in secondGroup)
                {
                    second.GetComponent<Renderer>().material = tranparent;
                    second.GetComponent<Collider>().isTrigger = true;
                }
                GetComponent<Renderer>().material = tranparent;
                button.GetComponent<Renderer>().material = normal;
                button.canPush = true;
            }
        }
    }
}
