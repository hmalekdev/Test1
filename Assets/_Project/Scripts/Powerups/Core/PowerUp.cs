using UnityEngine;

namespace Starbend.Test1
{
    public abstract class PowerUp : ScriptableObject
    {
        public string powerUpName;

        public abstract void ApplyPowerUp(PlayerController player);
    }
}
