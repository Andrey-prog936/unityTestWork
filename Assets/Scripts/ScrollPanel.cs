using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScrollPanel : MonoBehaviour
{
    [Tooltip("Prefab")]
    [SerializeField] private List<GameObject> puzzleElement;
    [Tooltip("From game board")]
    [SerializeField] private List<GameObject> puzzleElementFinal;
    [SerializeField] private Transform m_ContentContainer;
    public TextMeshProUGUI countPuzzles;
    public string CountPuz;
    public GameObject pauseObject;
    
    private void Start()
    {
        for (int i = 0; i < puzzleElement.Count; i++)
        {
            var itemToMenu = Instantiate(puzzleElement[i]);
            itemToMenu.name = puzzleElement[i].name;
            itemToMenu.transform.SetParent(m_ContentContainer);
            itemToMenu.GetComponent<ControlPuzzle>().parentBoard = GameObject.FindGameObjectWithTag("GameBoard");
            itemToMenu.GetComponent<ControlPuzzle>().form = puzzleElementFinal[i];
            itemToMenu.transform.localScale = new Vector2(0.65f, 0.65f);
        }
        CountPuz = this.gameObject.transform.childCount.ToString();
    }
    private void FixedUpdate()
    {
        countPuzzles.text = this.gameObject.transform.childCount.ToString() + "/" + CountPuz;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puzzle") && collision.gameObject.GetComponent<ControlPuzzle>().firstMove == true)
        {
            collision.gameObject.transform.SetParent(m_ContentContainer, true);
            collision.gameObject.GetComponent<ControlPuzzle>().firstMove = false;
            collision.gameObject.transform.localScale = new Vector2(0.65f, 0.65f);
        }
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}