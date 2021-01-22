using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Reveal : MonoBehaviour
{
    Image defaultImage;
    Text revealText;
    [SerializeField, Tooltip("Reference to the Sprite that you want to initially show at beginning of game or on reset of game. " +
        "This will default to what is set in the Source Image of the Image component on this object.")]
    Sprite defaultSprite;
    [SerializeField, Tooltip("Only set reference to this if the LootTable Component is not on the same object as the Reveal Component")] 
    LootTable revealOptions;

    // Awake is called before the first frame update
    void Awake()
    {
        defaultImage = gameObject.GetComponent<Image>();
        revealText = gameObject.GetComponentInChildren<Text>();

        if (defaultSprite == null)
        {
            defaultSprite = defaultImage.sprite;
        }

        if (revealOptions == null)
        {
            revealOptions = gameObject.GetComponent<LootTable>();
        }

        
    }


    //used to call on the button onClick method
    public void GetLoot()
    {
        GameObject result = revealOptions.Select(revealOptions.table);
        DecreaseImage(30.0f);
        defaultImage.sprite = result.GetComponent<Image>().sprite;        
        IncreaseImage(30.0f);
        revealText.text = result.GetComponentInChildren<Text>().text;
        gameObject.name = revealText.text;
        GameManager.Instance.increaseCount(revealText.text);
    }

    //remove old image animation
    private void DecreaseImage(float time)
    {
        while (time > 0.001f)
        {
            defaultImage.fillAmount -= 1.0f / time * Time.deltaTime;
            time -= .1f * Time.deltaTime;
        }

    }

    //show new image animation
    private void IncreaseImage(float time)
    {
        while (time > 0.001f)
        {
            defaultImage.fillAmount += 1.0f / time * Time.deltaTime;
            time -= .1f * Time.deltaTime;
        }
    }

    //reset all buttons to the default status when starting a new game
    public void ResetButton()
    {
        revealText.text = "";
        gameObject.GetComponent<Button>().interactable = true;
        defaultImage.sprite = defaultSprite;
    }
}
