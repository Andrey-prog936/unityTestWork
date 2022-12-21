using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelLevel;
    [SerializeField] private GameObject playPanel;
    [SerializeField] private GameObject pauseMenu;

    public void PlayGame()
    {
        panelLevel.SetActive(true);
        playPanel.SetActive(false);
    }
    public void BackButton()
    {
        panelLevel.SetActive(false);
        playPanel.SetActive(true);
    }
    public void PlayGameScene1()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void PlayGameScene2()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void PlayGameScene3()
    {
        SceneManager.LoadScene("Level_3");
    }

}
