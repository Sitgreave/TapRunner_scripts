using System.Collections;
using UnityEngine;

public class StandartObstacle : Obstacle
{

    [SerializeField] protected CharacterMoving.MoveState DangerousMove;
    [SerializeField] protected CharacterAnimations.LoseAnimList LoseAnimOnEnter;
    [SerializeField] protected bool NotNeedChecking;

   private void Start()
    {
        CharacterEnter = CharacterHere;
        CharacterExit = CharacterEscape;
    }
    protected IEnumerator CheckOnDangerousMovement()
    {
        while (characterHere)
        {
            if (character.moving.moveState == DangerousMove)
                character.Lose();
            if (Stamina.currentStamina <= 0)
                character.Lose();
            
            yield return new WaitForSeconds(0.05f);
        }
        StopCoroutine(CheckOnDangerousMovement());
    }


    protected bool BadSpeed()
    {
        switch (DangerousMove)
        {
            case CharacterMoving.MoveState.fast:
                if (character.moving.currentSpeed > character.moving.minSpeed)
                    return true;
                break;
            case CharacterMoving.MoveState.slow:
                if (character.moving.currentSpeed < character.moving.maxSpeed)
                    return true;
                break;
        }
        return false;
    }

    virtual public void CharacterEscape()
    {
      //
    }
    virtual public void CharacterHere()
    {
        character.CurrentDangerousMove = DangerousMove;
        if (BadSpeed() || character.moving.moveState == DangerousMove)
        {
           
            characterHere = false;
            character.CurrentLoseAnim = LoseAnimOnEnter;
            if (NeedUnlockConstraints) character.moving.UnlockRigidbodyConstraints();
            character.Lose();
        }
        else
          if(!NotNeedChecking) StartCoroutine(CheckOnDangerousMovement());
    }
}
