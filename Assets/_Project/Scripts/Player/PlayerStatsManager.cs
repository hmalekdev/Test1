using TMPro;
using UnityEngine;

namespace Starbend.Test1
{
    public class PlayerStatsManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI speedTxt, jumpTxt;

        private void OnEnable()
        {
            PlayerController.OnChangeMoveSpeed += SpeedHandler;
            PlayerController.OnChangeJumpForce += JumpHandler;
        }

        private void OnDisable()
        {
            PlayerController.OnChangeMoveSpeed -= SpeedHandler;
            PlayerController.OnChangeJumpForce -= JumpHandler;
        }

        private void SpeedHandler(float speed)
        {
            speedTxt.text = $"Speed: <color=yellow>{speed}</color>";
        }

        private void JumpHandler(float jump)
        {
            jumpTxt.text = $"Jump: <color=yellow>{jump}</color>";
        }

    }
}
