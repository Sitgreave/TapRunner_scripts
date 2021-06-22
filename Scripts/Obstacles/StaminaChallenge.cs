
using System.Collections;
using UnityEngine;

public class StaminaChallenge : StandartObstacle
{
    [SerializeField] private float fastMoveCost;
    [SerializeField] private float slowMoveCost;
 


    public override void CharacterEscape()
    {
        character.animations.ActionAnimationSwitch(CharacterAnimations.ActionAnimList.endChallenge);

    }
    override public void CharacterHere() {
        base.CharacterHere();

        character.stamina.StaminaDecreasing(slowMoveCost, fastMoveCost);
        StartCoroutine(CheckOnStamina());
    }
  
    protected IEnumerator CheckOnStamina()
    {
        while (characterHere)
        {
            if (Stamina.currentStamina <= 0)
            {
                character.Lose();

            }
            yield return new WaitForSeconds(0.05f);
        }
        StopCoroutine(CheckOnStamina());
    }
}
