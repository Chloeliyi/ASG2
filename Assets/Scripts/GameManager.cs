using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public GameObject LocationMenu;

    public GameObject ExhibitOneButton;

    public GameObject ExhibitTwoButton;

    public GameObject PreviousLocationButton;

    public GameObject QuizMenu;

    public GameObject LeaderMenu;

    public GameObject MusicMenu;

    public GameObject PuzzleMenu;

    public GameObject GameDirectionMenu;

    public GameObject QuizDirection;

    public GameObject StartQuiz;

    public GameObject QuizQns;

    public GameObject PuzzleDirection;

    public GameObject MainMenuDirection;

    public GameObject PlayerMenus;

    public GameObject LogOutMenu;

    public GameObject CheckpointMenu;

    public GameObject ZoomInMenu;

    public GameObject ZoomInImage;

    [SerializeField] private Material[] Museum;

    [SerializeField] private Sprite[] ZoomInSprite;

    [SerializeField] private int Walk;

    [SerializeField] private int SpriteImage;

    [SerializeField] private TextMeshProUGUI CheckpointText;
    [SerializeField] public int checkpoints = 0;

    private void Start()
    {
        PlayerMenus.gameObject.SetActive(true);
        StartMenu.gameObject.SetActive(true);
        SignUpMenu.gameObject.SetActive(false);
        LogInMenu.gameObject.SetActive(false);
        AdminMenu.gameObject.SetActive(false);
        GameMenu.gameObject.SetActive(false);
        GameDirectionMenu.gameObject.SetActive(false);
        LogOutMenu.gameObject.SetActive(false);
        CheckpointMenu.gameObject.SetActive(false);
        ZoomInMenu.gameObject.SetActive(false);

        Walk = 0;
        RenderSettings.skybox = Museum[Walk];

        SpriteImage = 0;
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
        Walk ++;
        RenderSettings.skybox = Museum[Walk];
        LocationMenu.gameObject.SetActive(true);
        ExhibitOneButton.gameObject.SetActive(true);
        ExhibitTwoButton.gameObject.SetActive(true);
        PreviousLocationButton.gameObject.SetActive(false);
        LogOutMenu.gameObject.SetActive(true);

        CheckpointMenu.gameObject.SetActive(true);
        CheckpointText.text = "Checkpoint : " + checkpoints;

        PlayerMenus.gameObject.SetActive(false);

        GameDirectionMenu.gameObject.SetActive(true);
        QuizDirection.gameObject.SetActive(false);
        PuzzleDirection.gameObject.SetActive(false);
        MainMenuDirection.gameObject.SetActive(true);
        
    }

    public void GoToExhibitOne()
    {
        Walk = 2;
        RenderSettings.skybox = Museum[Walk];

        QuizDirection.gameObject.SetActive(true);
        MainMenuDirection.gameObject.SetActive(false);
        ZoomInMenu.gameObject.SetActive(true);
            
        ExhibitOneButton.gameObject.SetActive(false);
        
    }

     public void GoToExhibitTwo()
    {
        Walk = 3;
        RenderSettings.skybox = Museum[Walk];

        PuzzleDirection.gameObject.SetActive(true);
        MainMenuDirection.gameObject.SetActive(false);  
        ZoomInMenu.gameObject.SetActive(true);

        ExhibitTwoButton.gameObject.SetActive(false);
        
    }

    public void PreviousLocation()
    {
        Walk --;
        RenderSettings.skybox = Museum[Walk];

        if (Walk == 1)
        {
            ExhibitOneButton.gameObject.SetActive(true);
            ExhibitTwoButton.gameObject.SetActive(true);
            PreviousLocationButton.gameObject.SetActive(false);

            MainMenuDirection.gameObject.SetActive(true);
        }
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
        /*Walk = 2;
        RenderSettings.skybox = Museum[Walk];*/

        LogOutMenu.gameObject.SetActive(false);
        CheckpointMenu.gameObject.SetActive(false);
        ZoomInMenu.gameObject.SetActive(false);
    }

    public void QuizComplete()
    {
        QuizMenu.gameObject.SetActive(false);
        QuizDirection.gameObject.SetActive(true);
        /*MainMenuDirection.gameObject.SetActive(true);*/

        LogOutMenu.gameObject.SetActive(true);
        CheckpointMenu.gameObject.SetActive(true);

        ZoomInMenu.gameObject.SetActive(true);

        PreviousLocationButton.gameObject.SetActive(true);
    }

    public void PuzzleStart()
    {
        PuzzleMenu.gameObject.SetActive(true);
        PuzzleDirection.gameObject.SetActive(false);

        LogOutMenu.gameObject.SetActive(false);
        CheckpointMenu.gameObject.SetActive(false);
    }

    public void PuzzleComplete()
    {
        PuzzleMenu.gameObject.SetActive(false);
        PuzzleDirection.gameObject.SetActive(true);
        /*MainMenuDirection.gameObject.SetActive(true);*/

        LogOutMenu.gameObject.SetActive(true);
        CheckpointMenu.gameObject.SetActive(true);

        PreviousLocationButton.gameObject.SetActive(true);
    }

    public void GoToMenu()
    {
        PlayerMenus.gameObject.SetActive(true);
        GameMenu.gameObject.SetActive(true);
        GameDirectionMenu.gameObject.SetActive(false);
        LocationMenu.gameObject.SetActive(false);
        Walk = 0;
        RenderSettings.skybox = Museum[Walk];

        LogOutMenu.gameObject.SetActive(false);
        CheckpointMenu.gameObject.SetActive(false);
    }

    public void ZoomInPhoto()
    {
        ZoomInImage.gameObject.SetActive(true);
        ZoomInMenu.gameObject.SetActive(false);
        QuizDirection.gameObject.SetActive(false);

        if (Walk == 2)
        {
            ZoomInImage.gameObject.GetComponent<Image>().sprite = ZoomInSprite[SpriteImage];
        }
    }

    public void ZoomOutPhoto()
    {
        ZoomInImage.gameObject.SetActive(false);
        ZoomInMenu.gameObject.SetActive(true);
        QuizDirection.gameObject.SetActive(true);
    }
}
