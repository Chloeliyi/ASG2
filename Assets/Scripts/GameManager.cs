using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject StartMenu;

    public GameObject LogInMenu;

    public GameObject SignUpMenu;

    private void Start()
    {
        StartMenu.gameObject.SetActive(true);
        SignUpMenu.gameObject.SetActive(false);
        LogInMenu.gameObject.SetActive(false);
    }

    public void OnLogInButton()
    {
        StartMenu.gameObject.SetActive(false);
        LogInMenu.gameObject.SetActive(true);
    }

    public void OnSignUpButton()
    {
        StartMenu.gameObject.SetActive(false);
        SignUpMenu.gameObject.SetActive(true);
    }
}
