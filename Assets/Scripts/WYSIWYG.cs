using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WYSIWYG : MonoBehaviour
{
    List<int> Grid = new List<int>();
    string[] ReelStrip = { "C", "A", "Coin", "D", "B", "A", "B", "C", "Coin", "A", "D", "C", "B", "A", "Coin", "C", "D", "A" };
    int multiplyer = 0;
    int result = 0;

    // Start is called before the first frame update
    void Start()
    {
        //initialize the grid with random picks from the reelstrip
        for (int i = 0; i < 15; i++)
        {
            int random = Random.Range(0, ReelStrip.Length);

            if (string.Equals(ReelStrip[random], "Coin"))
            {
                //get random number between 1-100
                int valueChance = (int)(Random.value * 100);

                //get value of the coin based on the weight table
                if (valueChance >= 0 && valueChance < 60)
                {
                    Grid.Add(50);
                }
                else if (valueChance >= 60 && valueChance < 75)
                {
                    Grid.Add(75);
                }
                else if (valueChance >= 75 && valueChance < 85)
                {
                    Grid.Add(125);
                }
                else if (valueChance >= 85 && valueChance < 95)
                {
                    Grid.Add(275);
                }
                else if (valueChance >= 95 && valueChance < 98)
                {
                    Grid.Add(500);
                }
                else if (valueChance >= 98 && valueChance < 100)
                {
                    Grid.Add(1000);
                }
            }
            else
            {
                //if item is not "Coin" then value is zero
                Grid.Add(0);
            }
        }

        //if all items in grid are coins, we need to figure out a multiplier
        if (!Grid.Contains(0))
        {
            int ranMultiply = (int)(Random.value * 100);

            if (ranMultiply >= 0 && ranMultiply < 60)
            {
                multiplyer = 2;
            }
            else if (ranMultiply >= 60 && ranMultiply < 80)
            {
                multiplyer = 3;
            }
            else if (ranMultiply >= 80 && ranMultiply < 100)
            {
                multiplyer = 4;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //call this to add the value of the turned over coin result 
    public void TurnedOver(int value)
    {
        //if coin turned over, need to add to result
        result += value; 
    }

    //use to check if there is a multiplyer and if so then add to result
    public void CalculateResult()
    {
        if (multiplyer != 0)
        {
            result = result * multiplyer;
        }
    }
}
