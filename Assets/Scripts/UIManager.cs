using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{

    public GameObject currentMenu;

    public List<Button> buttons;

    public string password;

    public TextMeshProUGUI passwordtxt;

    public int characterLimit = 6;



    public static UIManager Instance;

    private bool showUI;

    private void Awake()=> Instance = this;


    



    private void Start()
    {
        foreach (Button button in buttons)
            button.onClick.AddListener(() => OnButtonClick(button));
        
    }

    private void OnButtonClick(Button clickedButton)
    {
        string buttonText = clickedButton.GetComponentInChildren<TextMeshProUGUI>().text.Replace("\n", "").Replace("\r", "").Trim();

        passwordtxt.text=LimitTextLength(passwordtxt.text, characterLimit,buttonText);

    }

    public void DeleteText()
    {
        if (passwordtxt.text.Length > 0)
            passwordtxt.text = passwordtxt.text.Substring(0, passwordtxt.text.Length - 1); 
        
    }

    private string LimitTextLength(string passwordtext, int limit,string buttontext)
    {
        
        if (passwordtext.Length >= limit)
            return passwordtext[..limit];
        else
        {
            passwordtext += buttontext;
            return passwordtext; 
        }
    }

    

    public void CheckPassword()
    {
        if(passwordtxt.text.Length == characterLimit)
        {
            if (passwordtxt.text == password)
                CharacterManager.Instance.openDoor = true;
            else
                Debug.Log("Password is uncorrect");
        }
        
    }
}
