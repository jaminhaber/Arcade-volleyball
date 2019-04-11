using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerSync : NetworkBehaviour
{

    [SyncVar]
    private Vector2 pos;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Command]
    private void CmdPositionToServer()
    {
        
    }
}
