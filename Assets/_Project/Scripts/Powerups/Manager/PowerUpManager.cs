using UnityEngine;

namespace Starbend.Test1
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private PowerUp powerUp;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (!collision.TryGetComponent(out PlayerController player)) return;

                powerUp.ApplyPowerUp(player);
                gameObject.SetActive(false);

                NarratorManager.OnSuccess(powerUp.powerUpName);
            }
        }
    }

}
