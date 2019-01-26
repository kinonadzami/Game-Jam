using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHudInfo : MonoBehaviour
{
    public GameObject Player;
    public Image Portrait, HP, HPhide;
    public Text PlayerName;

    void Start()
    {
        PlayerName.text = Player.GetComponent<PlayerInfo>().Name;
        HPhide.GetComponent<Image>().fillAmount = (3 - Player.GetComponent<PlayerInfo>().HP) * 0.333333333f;
    }

    void Update()
    {
        HPhide.GetComponent<Image>().fillAmount = (3 - Player.GetComponent<PlayerInfo>().HP) * 0.333333333f;
    }
}
