using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private float _decreaseAtSlow; 
    private float _decreaseAtFast;
    private const float _standartDecraseAtSlow = .3f;
    private const float _standartDecraseAtFast = .7f;

    public static float currentStamina;
    [SerializeField] private float _maxStamina;

    public Image bar;
    public CharacterMoving characterMoving;

    private void Update()
    {
        FillStaminaBar();
    }

    private void Start()
    {
        currentStamina = _maxStamina;
        StandartStaminaDecreasing();
        StartCoroutine(GroundStaminaDecrease());
    }



    IEnumerator GroundStaminaDecrease()
    {

        while (true)
        {

            if (currentStamina > 0)
            {
                if (characterMoving.moveState == CharacterMoving.MoveState.slow)
                {
                    currentStamina -= _decreaseAtSlow / 30;
                }
                if (characterMoving.moveState == CharacterMoving.MoveState.fast)
                {
                    currentStamina -= _decreaseAtFast / 30;
                }
            }
            if(characterMoving.moveState == CharacterMoving.MoveState.nothing) { break; }
            yield return new WaitForSeconds(0.01f);
            //StopCoroutine(GroundStaminaDecrease());
        }
    }
    public void StaminaDecreasing(float DecreaseAtSlow, float DecreaseAtFast)
    {
        _decreaseAtSlow = DecreaseAtSlow;
        _decreaseAtFast = DecreaseAtFast;
    }
    public void StandartStaminaDecreasing()
    {
        _decreaseAtFast = _standartDecraseAtFast;
        _decreaseAtSlow = _standartDecraseAtSlow;
    }
    private void FillStaminaBar()
    {
        if (currentStamina >= 0)
            bar.fillAmount = currentStamina / _maxStamina;
    }

}
