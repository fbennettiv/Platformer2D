using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIGame : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    public GameObject diamondBlueEmpty;
    public GameObject diamondGreenEmpty;
    public GameObject diamondRedEmpty;
    public GameObject diamondYellowEmpty;

    public Sprite diamondBlue;
    public Sprite diamondGreen;
    public Sprite diamondRed;
    public Sprite diamondYellow;

    

    public void UpdateHealth(int health)
    {
        switch (health)
        {
            case 0:
                {
                    heart1.GetComponent<SpriteRenderer>().sprite =
                        heartEmpty;
                    heart2.GetComponent<SpriteRenderer>().sprite =
                       heartEmpty;
                    heart3.GetComponent<SpriteRenderer>().sprite =
                       heartEmpty;
                    break;
                }
            case 1:
                {
                    heart1.GetComponent<SpriteRenderer>().sprite =
                       heartHalf;
                    heart2.GetComponent<SpriteRenderer>().sprite =
                       heartEmpty;
                    heart3.GetComponent<SpriteRenderer>().sprite =
                       heartEmpty;
                    break;
                }
            case 2:
                {
                    heart1.GetComponent<SpriteRenderer>().sprite =
                       heartFull;
                    heart2.GetComponent<SpriteRenderer>().sprite =
                       heartEmpty;
                    heart3.GetComponent<SpriteRenderer>().sprite =
                       heartEmpty;
                    break;
                }
            case 3:
                {
                    heart1.GetComponent<SpriteRenderer>().sprite =
                       heartFull;
                    heart2.GetComponent<SpriteRenderer>().sprite =
                       heartHalf;
                    heart3.GetComponent<SpriteRenderer>().sprite =
                       heartEmpty;
                    break;
                }
            case 4:
                {
                    heart1.GetComponent<SpriteRenderer>().sprite =
                       heartFull;
                    heart2.GetComponent<SpriteRenderer>().sprite =
                       heartFull;
                    heart3.GetComponent<SpriteRenderer>().sprite =
                       heartEmpty;
                    break;
                }
            case 5:
                {
                    heart1.GetComponent<SpriteRenderer>().sprite =
                       heartFull;
                    heart2.GetComponent<SpriteRenderer>().sprite =
                       heartFull;
                    heart3.GetComponent<SpriteRenderer>().sprite =
                       heartHalf;
                    break;
                }
            case 6:
                {
                    heart1.GetComponent<SpriteRenderer>().sprite =
                       heartFull;
                    heart2.GetComponent<SpriteRenderer>().sprite =
                       heartFull;
                    heart3.GetComponent<SpriteRenderer>().sprite =
                       heartFull;
                    break;
                }
        }
    }

    public void UpdateDiamond(int diamondNum)
    {
        switch (diamondNum)
        {
            case 1:// Blue
                {
                    diamondBlueEmpty.GetComponent<SpriteRenderer>().sprite =
                        diamondBlue;
                    break;
                }
            case 2: //Green
                {
                    diamondGreenEmpty.GetComponent<SpriteRenderer>().sprite =
                        diamondGreen;
                    break;
                }
            case 3: //Red
                {
                    diamondRedEmpty.GetComponent<SpriteRenderer>().sprite =
                        diamondRed;
                    break;
                }
            case 4: //Yellow
                {
                    diamondYellowEmpty.GetComponent<SpriteRenderer>().sprite =
                        diamondYellow;
                    break;
                }
        }
    }
}

