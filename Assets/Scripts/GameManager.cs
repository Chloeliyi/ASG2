using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject StartMenu;

    public GameObject LogInMenu;

    public GameObject SignUpMenu;

    public GameObject GameMenu;

    public GameObject ProfileMenu;

    public GameObject AdminMenu;

    public GameObject QuizMenu;

    public GameObject LeaderMenu;

    public Material mat1;

    private void Start()
    {
        StartMenu.gameObject.SetActive(true);
        SignUpMenu.gameObject.SetActive(false);
        LogInMenu.gameObject.SetActive(false);
        AdminMenu.gameObject.SetActive(false);
        GameMenu.gameObject.SetActive(false);
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

    public void OnAdminButton()
    {
        StartMenu.gameObject.SetActive(false);
        AdminMenu.gameObject.SetActive(true);
    }

    public void OnBackButton()
    {
        StartMenu.gameObject.SetActive(true);
        SignUpMenu.gameObject.SetActive(false);
        LogInMenu.gameObject.SetActive(false);
        AdminMenu.gameObject.SetActive(false);
        GameMenu.gameObject.SetActive(false);
    }

    public void OnGameStart()
    {
        RenderSettings.skybox = mat1;
    }

    public void OnProfileButton()
    {
        GameMenu.gameObject.SetActive(false);
        ProfileMenu.gameObject.SetActive(true);
    }

    public void OnProfileBackButton()
    {
        GameMenu.gameObject.SetActive(true);
        ProfileMenu.gameObject.SetActive(false);
    }

    public void OnLeaderButton()
    {
        GameMenu.gameObject.SetActive(false);
        LeaderMenu.gameObject.SetActive(true);
    }

    public void OnLeaderBackButton()
    {
        GameMenu.gameObject.SetActive(true);
        LeaderMenu.gameObject.SetActive(false);
    }
}
