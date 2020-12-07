using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countofHitstuff : MonoBehaviour
{
    string arrowR;
    string arrowY;
    string arrowG;
    string arrowB;
    bool one = true;
    bool two = true;
    bool three = true;
    bool four = true;
    public GameObject green4;

    public void aNewHit(string character, int color)
    {
        switch (color)
        {
            case 1:

                if (one == true)
                {
                    one = false;
                    arrowR = character;
                }
                else
                {
                    isMatch(character, arrowR);
                }
                break;
            case 2:

                if (two == true)
                {
                    two = false;
                    arrowY = character;
                }
                else
                {
                    isMatch(character, arrowY);
                }
                break;
            case 3:
                if (three == true)
                {
                    three = false;
                    arrowG = character;
                }
                else
                {
                    isMatch(character, arrowG);
                }
                break;
            case 4:

                if (four == true)
                {
                    four = false;
                    arrowB = character;
                }
                else
                {
                    isMatch(character, arrowB);
                }
                break;
        }
    }

    private void isMatch(string nearest, string arrow)
    {
        if (nearest == "woman2" || nearest == "randomdude")
        {
            if (arrow == "woman2" || arrow == "randomdude")
            {
                GameObject.Find("Love Sheet").SetActive(false);
            }
        }
        else if (nearest == "mechanic" || nearest == "randomwoman")
        {
            if (arrow == "mechanic" || arrow == "randomwoman")
            {
                GameObject.Find("Love Sheet").SetActive(false);
            }
        }
        else if (nearest == "farmer" || nearest == "woman3")
        {
            if (arrow == "woman3" || arrow == "farmer")
            {
                GameObject.Find("Love Sheet").SetActive(false);
            }
        }
        else if (nearest == "salesman" || nearest == "cop")
        {
            if (arrow == "salesman" || arrow == "cop")
            {
                green4.SetActive(true);
            }
        }
        else
        {
        //    GameObject.Find(nearest).GetComponent<Test_script>().failed();
            GameObject.Find(nearest).SetActive(false);
        }

    }
}
