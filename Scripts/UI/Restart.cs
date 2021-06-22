
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public void RestartLevel()
    {
        SceneManager.LoadScene("l1");
    }
}
