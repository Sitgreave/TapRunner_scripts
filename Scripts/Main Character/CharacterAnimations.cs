using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip[] animationClips;

    public void ActionAnimationSwitch(ActionAnimList anim)
    {
        switch (anim)
        {
            case ActionAnimList.walk:
                OffAnotherBoolean("Walk");
                break;
            case ActionAnimList.slowSwim:
                OffAnotherBoolean("SlowSwim");
                break;
          
            case ActionAnimList.jump:
                OffAnotherBoolean("Jump");
                break;
            case ActionAnimList.sneak:
                OffAnotherBoolean("Sneak");
                break;
            case ActionAnimList.crawl:
                OffAnotherBoolean("Crawling");
                break;
            case ActionAnimList.climbing:
                OffAnotherBoolean("Climbing");
                break;
            case ActionAnimList.endChallenge:
                    OffAnotherBoolean("EndChallenge");
                Invoke(nameof(offEndChallenge), 2);
                break;
        }
    }
    public void BaseAnimationSwitch(BaseAnimList anim)
    {
        switch (anim)
        {
            case BaseAnimList.slowRun:
                OffAnotherBoolean("SlowMove");
                break;
            case BaseAnimList.fastRun:
                OffAnotherBoolean("FastMove");
                break;
        }
    }
    public void LoseAnimationSwitch(LoseAnimList anim)
    {
        switch (anim)
        {
            case LoseAnimList.slip:
                OffAnotherBoolean("Slip");
                break;
           
            case LoseAnimList.fall:
                OffAnotherBoolean("Fall");
                break;
            case LoseAnimList.drown:
                OffAnotherBoolean("Drown");
                break;
            case LoseAnimList.swipFall:
                OffAnotherBoolean("SweepFall");
                break;
            case LoseAnimList.lowJump:
                OffAnotherBoolean("LowJump");
                break;
        }
    }

    public void AnimationPlay(string animation)
    {
        animator.Play(animation);
    }

        public float GetClipDuration(LoseAnimList anim)
        {
            float duration = 0;

            switch (anim)
            {
            case LoseAnimList.fall:
                duration = animationClips[0].length;
                break;
            case LoseAnimList.slip:
              duration = animationClips[1].length;
              break;
            }
            return duration;
        }

        public enum BaseAnimList
        {
            slowRun,
            fastRun,
        }

    public enum ActionAnimList
    {
        walk,
        slowSwim,
        fastSwim,
        jump,
        sneak,
        crawl,
        climbing,
        endChallenge,
        win
    }
    public enum LoseAnimList
    {
        slip,
        fall,
        drown,
        stop,
        lowJump,
        swipFall
    }
 

    private  void OffAnotherBoolean(string name)
    {
        animator.SetBool("SlowMove", false);
        animator.SetBool("FastMove", false);
        animator.SetBool("Walk", false);
        animator.SetBool("SlowSwim", false);

        animator.SetBool("Jump", false);
        animator.SetBool("Fall", false);
        animator.SetBool("Sneak", false);
        animator.SetBool("Crawling", false);
        animator.SetBool("LowJump", false);
        animator.SetBool("Climbing", false);
       // if(animator.GetBool("EndChallenge")) Invoke(nameof(offEndChallenge), 2);
        animator.SetBool(name, true);
    }

    private void offEndChallenge()
    {
        animator.SetBool("EndChallenge", false);
    }
    public void WinAnimation()
    {
        animator.SetBool("Win", true);
     
    }
}






