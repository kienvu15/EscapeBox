using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] GameBegin gameBegin;

    private void Update()
    {
        if(!gameBegin.gameBegin) return;
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Application.Quit();
        }
    }
}
