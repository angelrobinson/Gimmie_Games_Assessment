using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGame : MonoBehaviour
{
    Image endGameSprite;
    public Button resetButton;
    public Button endButton;

    public List<Sprite> victorySprites;
    // Start is called before the first frame update
    void Start()
    {
        //get reference to the sprite and button on victory panel
        endGameSprite = GetComponentInChildren<Image>();

        //disable the sprite and button        
        endGameSprite.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
        endButton.gameObject.SetActive(false);
    }


    /// <summary>
    /// Show the victory image to end the game
    /// </summary>
    /// <param name="victoryType">string representation of victory type. If no winner, put "None"</param>
    public void ShowEndGame(string victoryType)
    {
        //Debug.Log("ShowEndGame called!");

        foreach (var item in victorySprites)
        {
            if (item.name.Contains(victoryType))
            {
                endGameSprite.sprite = item;
                break;
            }
        }

        //enable the sprite and button
        endGameSprite.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        endButton.gameObject.SetActive(true);
    }

    public void ResetGameClicked()
    {
        Start();
    }


}
