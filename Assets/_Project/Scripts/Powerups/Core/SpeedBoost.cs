using System.Collections;
using UnityEngine;

namespace Starbend.Test1
{
    [CreateAssetMenu(menuName = "PowerUps/SpeedBoost")]
    public class SpeedBoost : PowerUp
    {
        [SerializeField] private float speedMultiplier = 1.5f;

        public override void ApplyPowerUp(PlayerController player)
        {
            player.BoostSpeed(speedMultiplier);
        }
    }

}
