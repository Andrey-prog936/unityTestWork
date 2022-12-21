using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinS : MonoBehaviour
{
    private int fullElement;
    public static int myElement;
    public GameObject myPuzzl;
    public GameObject winPanel;

    private void Start()
    {
        fullElement = myPuzzl.transform.childCount;
    }
    private void FixedUpdate()
    {
        if (fullElement == myElement)
        {
            winPanel.SetActive(true);
        }
        else
        {
            winPanel.SetActive(false);
        }
    }
    public void ExitToMainMenu()
    {
        myElement = 0;
        SceneManager.LoadScene("Menu");
    }
    public static void AddElement()
    {
        myElement++;
    }
}
