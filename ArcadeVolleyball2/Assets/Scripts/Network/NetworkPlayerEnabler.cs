using UnityEngine;
using UnityEngine.Networking;

namespace Network
{
    public class NetworkPlayerEnabler : NetworkBehaviour
    {
        [SerializeField] private MonoBehaviour[] behaviours;
        
        
        private void Start()
        {
            if (isLocalPlayer) return;
            foreach (MonoBehaviour behaviour in behaviours)
            {
                behaviour.enabled = false;
            }
        }
    }
}