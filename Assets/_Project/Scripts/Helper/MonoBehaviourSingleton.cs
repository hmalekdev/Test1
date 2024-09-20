using UnityEngine;

namespace Starbend.Test1
{
    public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
    {
        private static T _ins;
        public static T Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = FindAnyObjectByType<T>();
                }

                return _ins;
            }
        }
    }
}
