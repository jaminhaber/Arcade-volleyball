using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager i;

    public GameState GameState;


    private void Awake()
    {
        if (i == null) i = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            Loader.i.LoadMenu();
    }
}
