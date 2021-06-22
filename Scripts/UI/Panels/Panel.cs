using UnityEngine;

public class Panel : MonoBehaviour
{
    
    public void ActivatePanel(GameObject panel)
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
    }

    public void ClosePanel(GameObject panel)
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
    }


}
