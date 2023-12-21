using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject StartMenu;

    public GameObject LogInMenu;

    public GameObject SignUpMenu;

    public GameObject GameMenu;

    public GameObject ProfileMenu;

    public GameObject UpdateProfileMenu;

    public GameObject UpdateNameMenu;

    public GameObject AdminMenu;

    public GameObject QuizMenu;

    public GameObject LeaderMenu;

    public GameObject MusicMenu;

    public GameObject PuzzleMenu;

    public GameObject DirectionMenu;

    public GameObject QuizDirection;

    public GameObject StartQuiz;

    public GameObject QuizQns;

    public GameObject PuzzleDirection;

    public GameObject PlayerMenus;

    public GameObject LogOutMenu;

    public GameObject CheckpointMenu;

    [SerializeField] private Material[] Museum;

    private int Walk;

    [SerializeField] private TextMeshProUGUI CheckpointText;
    public int checkpoints = 0;

    private void Start()
    {
        PlayerMenus.gameObject.SetActive(true);
        StartMenu.gameObject.SetActive(true);
        SignUpMenu.gameObject.SetActive(false);
        LogInMenu.gameObject.SetActive(false);
        AdminMenu.gameObject.SetActive(false);
        GameMenu.gameObject.SetActive(false);
        DirectionMenu.gameObject.SetActive(false);
        LogOutMenu.gameObject.SetActive(false);
        CheckpointMenu.gameObject.SetActive(false);

        Walk = 0;
        RenderSettings.skybox = Museum[Walk];
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
        //RenderSettings.skybox = mat1;
        Walk ++;
        RenderSettings.skybox = Museum[Walk];
        DirectionMenu.gameObject.SetActive(true);
        LogOutMenu.gameObject.SetActive(true);
        CheckpointMenu.gameObject.SetActive(true);
        CheckpointText.text = "Checkpoint : " + checkpoints;
        PlayerMenus.gameObject.SetActive(false);
        
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

    public void OnProfileUpdateBackButton()
    {
        ProfileMenu.gameObject.SetActive(true);
        UpdateProfileMenu.gameObject.SetActive(false);
    }

    public void OnUpdateName()
    {
        UpdateProfileMenu.gameObject.SetActive(true);
        UpdateNameMenu.gameObject.SetActive(true);
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

    public void OnMusicButton()
    {
        GameMenu.gameObject.SetActive(false);
        MusicMenu.gameObject.SetActive(true);
    }

    public void OnMusicBackButton()
    {
        GameMenu.gameObject.SetActive(true);
        MusicMenu.gameObject.SetActive(false);
    }

    public void QuizStart()
    {
        QuizMenu.gameObject.SetActive(true);
        QuizDirection.gameObject.SetActive(false);
        PuzzleDirection.gameObject.SetActive(false);
        Walk = 3;
        RenderSettings.skybox = Museum[Walk];

        LogOutMenu.gameObject.SetActive(false);
        CheckpointMenu.gameObject.SetActive(false);
    }

    public void QuizComplete()
    {
        QuizMenu.gameObject.SetActive(false);
        QuizDirection.gameObject.SetActive(true);
        PuzzleDirection.gameObject.SetActive(true);
        Walk = 2;
        RenderSettings.skybox = Museum[Walk];

        LogOutMenu.gameObject.SetActive(true);
        CheckpointMenu.gameObject.SetActive(true);
    }

    public void PuzzleStart()
    {
        PuzzleMenu.gameObject.SetActive(true);
        QuizDirection.gameObject.SetActive(false);
        PuzzleDirection.gameObject.SetActive(false);
        Walk = 4;
        RenderSettings.skybox = Museum[Walk];

        LogOutMenu.gameObject.SetActive(false);
        CheckpointMenu.gameObject.SetActive(false);
    }

    public void PuzzleComplete()
    {
        PuzzleMenu.gameObject.SetActive(false);
        QuizDirection.gameObject.SetActive(true);
        PuzzleDirection.gameObject.SetActive(true);
        Walk = 2;
        RenderSettings.skybox = Museum[Walk];

        LogOutMenu.gameObject.SetActive(true);
        CheckpointMenu.gameObject.SetActive(true);
    }
}
