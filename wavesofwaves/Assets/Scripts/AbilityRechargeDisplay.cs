using UnityEngine;
using UnityEngine.UI;

public class AbilityRechargeDisplay : MonoBehaviour
{
    public enum Abilities { Water, Light }
    public Abilities ability;

    private Image icon;
    private PlayerController player;
	
	void Start ()
    {
        icon = GetComponent<Image>();
        player = FindObjectOfType<PlayerController>();
	}
	
	void Update ()
    {
        if (ability == Abilities.Water)
        {
            if (player.waterTimer > 0)
            {

                icon.fillAmount = (player.waterTimer / player.waterCooldown);
            }
            else
            {
                icon.fillAmount = 0;
            }
        }
        else if (ability == Abilities.Light)
        {
            if (player.lightTimer > 0)
            {

                icon.fillAmount = (player.lightTimer / player.lightCooldown);
            }
            else
            {
                icon.fillAmount = 0;
            }
        }
    }
}
