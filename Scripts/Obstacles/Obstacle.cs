using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public abstract class Obstacle : MonoBehaviour
{
    protected Character character;

    protected bool characterHere;

    private bool allowExit = true;

    protected delegate void CharacterActions();
    protected CharacterActions CharacterEnter, CharacterExit;
    [SerializeField] protected bool NeedUnlockConstraints;
    [SerializeField] protected CharacterAnimations.ActionAnimList BaseAnim;
    [SerializeField] protected CharacterAnimations.LoseAnimList LoseAnim;
    bool ChallengeComplete = false;


    //  [SerializeField] protected Character.Location Location;

    private void OnTriggerEnter(Collider other)
    {
        if (!ChallengeComplete)
        {
            if (other.CompareTag("Player"))
            {

                if (allowExit && character == null)
                {

                    character = other.gameObject.GetComponent<Character>();
                    character.iReady = false;
                    characterHere = true;
                    character.CurrentBaseAnim = BaseAnim;
                    character.CurrentLoseAnim = LoseAnim;
                    //character.location = Location;
                    CharacterStartChallenge();
                    BlockExit(0.2f);
                    //character.moving.moveState = CharacterMoving.MoveState.slow;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!ChallengeComplete)
        {
            if (allowExit)
            {
                if (other.CompareTag("Player"))
                {
                    character.stamina.StandartStaminaDecreasing();
                    CharacterEndChallenge();
                    BlockExit(1f);
                    ChallengeComplete = true;
                    StagesHolder.StagePassedCount++;

                }
            }
        }
    }
    private void BlockExit(float blockTime)
    {
        allowExit = false;
        Invoke(nameof(AllowExitOn), blockTime);
    }
    private void AllowExitOn()
    {
        allowExit = true;
    }

    private void Ready() { character.iReady = true; }
    private void CharacterStartChallenge()
    {
        //Debug.Log("SAD");
        CharacterEnter?.Invoke();
        if (characterHere)
        {
            character.animations.ActionAnimationSwitch(BaseAnim);
            //character.iReady = true;
            Invoke(nameof(Ready), .3f);
            // character.location = Location;
        }
        Invoke(nameof(SlowState), .1f);
    }
    private void SlowState() { character.moving.SlowMove(); }
    private void CharacterEndChallenge()
    {
        if (!ChallengeComplete)
        {
            CharacterExit?.Invoke();
            // character.location = Character.Location.ground;
            characterHere = false;
           
            Debug.Log("DAS");
            Destroy(gameObject, 8);
            character.CurrentLoseAnim = CharacterAnimations.LoseAnimList.slip;
            //  character.iLive = true;
            //character.moving.SlowMove();
            //character.animations.BaseAnimationSwitch(CharacterAnimations.BaseAnimList.slowRun);
        }
    }
}
