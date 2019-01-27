using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialMusic : MonoBehaviour
{
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Awake()
    {
        SoundManager.PlayMusic("Swinging Pants");
        //SoundManager.PlayMusic("Nordic Title");
    }
    void Start()
    {
        //SoundManager.PlayMusic("Swinging Pants");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
