using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class MenuButtonClicker : MonoBehaviour
{
    [SerializeField] Button NewGameButton;
    [SerializeField] Button ContinueButton;
    [SerializeField] Button SettingsButton;
    [SerializeField] Button ExitButton;
    private Button[] buttons;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        buttons = new []{ NewGameButton, ContinueButton, SettingsButton, ExitButton };
        buttons[index].gameObject.GetComponent<RawImage>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("DPad_Vertical_P1")!=0)
        {
            buttons[index].gameObject.GetComponent<RawImage>().color = Color.white;
            index -= (int)Input.GetAxis("DPad_Vertical_P1");
            index = (index+4) % 4;
            buttons[index].gameObject.GetComponent<RawImage>().color = Color.red;
            Thread.Sleep(300);
        }
        if (Input.GetButtonDown("AButton_P1"))
        {
            ClickButton(index);
        }
    }

    private void ClickButton(int ind)
    {
        switch (index)
        {
            case 0:
                SceneManager.LoadScene("Level");
                break;
            case 1:
                //SceneManager.LoadScene();
                break;
            case 2:
                //SceneManager.LoadScene();
                break;
            case 3:
                Application.Quit(0);
                break;
            default:
                break;
        }
    }
}
