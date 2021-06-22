using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] GameObject _controlPanel;

    private void Start()
    {
        _controlPanel.SetActive(true);
    }
    public void ControlPanelDisable()
    {
        if (_controlPanel.activeSelf)
        {
            _controlPanel.SetActive(false);
        }
    }
}
