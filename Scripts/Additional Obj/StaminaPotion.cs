
using UnityEngine;

public class StaminaPotion : MonoBehaviour
{
    FootSteps footSteps;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            footSteps =  other.gameObject.GetComponent<FootSteps>();
            footSteps.BottleBrabPlay();
            if (100 - Stamina.currentStamina - 40 >= 0) Stamina.currentStamina += 40;
            else Stamina.currentStamina = 100;
            Destroy(gameObject);
        }
    }
}
