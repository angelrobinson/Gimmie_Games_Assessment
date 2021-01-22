using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private static int miniCounter;
    private static int minorCounter;
    private static int maxiCounter;
    private static int majorCounter;
    private static int grandCounter;
    private static int mainCounter;

    List<Reveal> ReelItems;
    EndGame winningPanel;


    //Awake is called before Start methods
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("There is already an Instance of this game running");
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        miniCounter = 0;
        minorCounter = 0;
        maxiCounter = 0;
        majorCounter = 0;
        grandCounter = 0;

        //find the EndGame script
        winningPanel = FindObjectOfType<EndGame>();

        //find all buttons with the reveal component on it
        ReelItems = FindObjectsOfType<Reveal>().ToList();

        //make sure buttons are interactable
        foreach (var item in ReelItems)
        {
            item.ResetButton();
        }
    }

    //reset game to start a new one
    public void ResetGame()
    {
        winningPanel.ResetGameClicked();
        Start();
    }

    public void increaseCount(string type)
    {
        switch (type)
        {
            case "Mini":
                miniCounter++;
                //Debug.Log("Mini: " + miniCounter);
                break;
            case "Minor":
                minorCounter++;
                //Debug.Log("Minor: " + minorCounter);
                break;
            case "Maxi":
                maxiCounter++;
                //Debug.Log("Maxi: " + maxiCounter);
                break;
            case "Major":
                majorCounter++;
                //Debug.Log("Major: " + majorCounter);
                break;
            case "Grand":
                grandCounter++;
                //Debug.Log("Grand: " + grandCounter);
                break;
            default:
                break;
        }

        mainCounter++;
        //Debug.Log("Main: " + mainCounter);

        CheckVictory();
    }

    private void CheckVictory()
    {
        //Debug.Log("Checking Victory");
        if (miniCounter == 3)
        {
            //Debug.Log("Mini winner");
            winningPanel.ShowEndGame("Mini");
        }
        else if (minorCounter == 3)
        {
            //Debug.Log("Minor winner");
            winningPanel.ShowEndGame("Minor");
        }
        else if (maxiCounter == 3)
        {
            //Debug.Log("Maxi winner");
            winningPanel.ShowEndGame("Maxi");
        }
        else if (majorCounter == 3)
        {
           //Debug.Log("Major winner");
            winningPanel.ShowEndGame("Major");
        }
        else if (grandCounter == 3)
        {
            //Debug.Log("Grand winner");
            winningPanel.ShowEndGame("Grand");
        }
        else if (mainCounter == 15)
        {
            //Debug.Log("None");
            winningPanel.ShowEndGame("None");
        }
        //else { Debug.Log("No winner yet"); }
    }

    public void ExitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif

    }

}
