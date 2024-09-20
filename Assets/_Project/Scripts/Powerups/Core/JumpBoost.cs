using System.Collections;
using UnityEngine;

namespace Starbend.Test1
{
    [CreateAssetMenu(menuName = "PowerUps/JumpBoost")]
    public class JumpBoost : PowerUp
    {
        [SerializeField] private float jumpMultiplier = 1.5f;

        public override void ApplyPowerUp(PlayerController player)
        {
            player.BoostJump(jumpMultiplier);
        }
    }
}
