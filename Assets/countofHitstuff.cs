using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countofHitstuff : MonoBehaviour
{
    string arrowR;
    string arrowY;
    string arrowG;
    string arrowB;
    bool one=true;
    bool two=true;
    bool three=true;
    bool four=true;

    public void aNewHit(string character, int color)
    {
        if (color == 1){
            if (one == true)
            {
                one = false;
                arrowR = character;
            }
            else
            {
                isMatch(character, arrowR);
            }

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
        if (nearest == "mechanic" || nearest == "randomwoman")
        {
            if (arrow == "mechanic" || arrow == "randomwoman")
            {
                  GameObject.Find("Love Sheet").SetActive(false);
            }
        }
        if (nearest == "farmer" || nearest == "woman3")
        {
            if (arrow == "woman3" || arrow == "farmer")
            {
                 GameObject.Find("Love Sheet").SetActive(false);
            }
        }
        if (nearest == "salesman" || nearest == "cop")
        {
            if (arrow == "salesman" || arrow == "cop")
            {
                 GameObject.Find("Love Sheet").SetActive(false);
            }
        }
    }
}
