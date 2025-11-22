using UnityEngine;

public class ShieldPowerUp : PowerUp
{
    public override void ApplyEffect(GameObject player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            pm.hasShield = true;
            Debug.Log("Shield Activated!");
        }
    }
}
