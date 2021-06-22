using System.Collections;
using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    [SerializeField] Character character;
    public float minSpeed;
    public float maxSpeed;

    public Rigidbody myRigidbody;
    public float currentSpeed;

    public MoveState moveState;


    private void Start()
    {

        SlowMove();
    }

    private void FixedUpdate()
    {
        if (character.iLive)
        {
            Vector3 vector3 = Vector3.forward * currentSpeed * Time.deltaTime;
            myRigidbody.MovePosition(myRigidbody.position + vector3);
            if (Stamina.currentStamina <= 0) character.Lose();
        }
    }
    public void FastMove()
    {

        if (character.iLive)
        {
            moveState = MoveState.fast;

            if (character.iReady)
            {
                character.animations.BaseAnimationSwitch(CharacterAnimations.BaseAnimList.fastRun);
            }
        }
    }

    public void SlowMove()
    {
        if (character.iLive)
        {
            moveState = MoveState.slow;
            if (character.iReady)
            {
                character.animations.BaseAnimationSwitch(CharacterAnimations.BaseAnimList.slowRun);
            }
        }
    }




    public enum MoveState
    {
        fast,
        slow,
        nothing
    }



    public void UnlockRigidbodyConstraints()
    {
        myRigidbody.constraints = RigidbodyConstraints.None;
        myRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

}
