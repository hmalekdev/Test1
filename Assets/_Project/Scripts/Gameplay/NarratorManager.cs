using TMPro;
using UnityEngine;

namespace Starbend.Test1
{
    public class NarratorManager : MonoBehaviourSingleton<NarratorManager>
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private TextMeshProUGUI message;

        public static void OnSuccess(string msg)
        {
            Ins.Handler(msg, Color.green);
        }

        public static void OnFail(string msg)
        {
            Ins.Handler(msg, Color.red);
        }

        private void Handler(string msg, Color c)
        {
            panel.SetActive(true);
            message.text = msg;
            message.color = c;

            CancelInvoke(nameof(DeactivePanel));
            Invoke(nameof(DeactivePanel), 5);
        }

        private void DeactivePanel()
        {
            panel.SetActive(false);
        }
    }
}
