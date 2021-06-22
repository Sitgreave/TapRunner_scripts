
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool iLive;


    public CharacterAnimations animations;
    public ControlPanel controlPanel;
    public CharacterMoving moving;
    public bool iReady;

    public Animator cameraAnimator;//
    public CharacterAnimations.ActionAnimList CurrentBaseAnim;
    public CharacterAnimations.LoseAnimList CurrentLoseAnim;
    public CharacterMoving.MoveState CurrentDangerousMove;
    public Stamina stamina;

    public GameObject WinPanel;
    public GameObject LosePanel;
    private Panel panel;
    private void Start()
    {
        panel = gameObject.AddComponent<Panel>();
        iReady = true;
        iLive = true;
        Time.timeScale = 1;
        panel.ClosePanel(WinPanel);
        panel.ClosePanel(LosePanel);
    }

    private void StopTime() { Time.timeScale = 0; panel.ActivatePanel(LosePanel); iLive = false; }



    public void Win()
    {
        animations.WinAnimation();
        moving.moveState = CharacterMoving.MoveState.nothing;
        moving.currentSpeed = 0;
        cameraAnimator.SetBool("end", true);
        LevelHolder.currentLevel += 1;
        SaveSystem.SaveStates();
        panel.ActivatePanel(WinPanel);
    }

    public void OnBridge(bool here)
    {
        cameraAnimator.SetBool("rotate", here);
    }
    public void Lose()
    {
        iLive = false;
        moving.currentSpeed = 0;
        animations.LoseAnimationSwitch(CurrentLoseAnim);
        Invoke(nameof(StopTime), 2);
    }
    public void Lose(float time)
    {
        iLive = false;
        animations.LoseAnimationSwitch(CurrentLoseAnim);
        Invoke(nameof(StopTime), time);
    }

}
