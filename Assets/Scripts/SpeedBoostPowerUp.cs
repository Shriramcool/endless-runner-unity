using UnityEngine;

public class SpeedBoostPowerUp : PowerUp
{
    public float extraSpeed = 4f;

    public override void ApplyEffect(GameObject player)
    {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();

        if (pm != null)
        {
            pm.ActivateSpeedBoost(extraSpeed, duration);
        }
    }
}
