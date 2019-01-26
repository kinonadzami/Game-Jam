using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHudInfo : MonoBehaviour
{
    public GameObject Player;
    public Image Portrait, HP, HPhide;
    public Text PlayerName;
    public Sprite HanselHead, HrettleHead;

    void Start()
    {
        PlayerName.text = Player.GetComponent<PlayerInfo>().Name;
        if(PlayerName.text == "Hansel")
        {
            Portrait.sprite = HanselHead;
        }
        if (PlayerName.text == "Hrettle")
        {
            Portrait.sprite = HrettleHead;
        }
        HPhide.GetComponent<Image>().fillAmount = (3 - Player.GetComponent<PlayerInfo>().HP) * 0.333333333f;
    }

    void Update()
    {
        HPhide.GetComponent<Image>().fillAmount = (3 - Player.GetComponent<PlayerInfo>().HP) * 0.333333333f;
    }
}
