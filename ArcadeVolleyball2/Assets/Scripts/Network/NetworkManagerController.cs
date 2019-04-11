using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

#pragma warning disable 618

public class NetworkManagerController : NetworkBehaviour
{

    public int PORT = 7777;
    public string IP = "localhost";

    [SerializeField] private Button hostButton;
    [SerializeField] private Button JoinButton;
    
    void Start()
    {
        if (hostButton != null) hostButton.onClick.AddListener(HostGame);
        if (JoinButton != null) JoinButton.onClick.AddListener(JoinGame);
    }

    public void HostGame()
    {
        NetworkManager.singleton.networkPort = PORT;
        NetworkLobbyManager.singleton.StartServer();
//        NetworkLobbyManager.singleton.StartHost();
        Loader.i.LoadGame();

    }

    public void JoinGame()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
