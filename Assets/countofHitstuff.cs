﻿using System.Collections;
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
    public GameObject green1;
    public GameObject green2;
    public GameObject green3;
    public GameObject green4;
    int count = 0;


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
                    one = true;
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
                    two = true;
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
                    three = true;
                   
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
                    four = true;
                }
                break;
        }
    }

    private void isMatch(string nearest, string color)
    {

        if ((nearest == "woman2" || nearest == "randomdude")&& (color == "woman2" || color == "randomdude"))
            {
                green1.SetActive(true);
                GameObject.Find(nearest).SetActive(false);
                GameObject.Find(color).SetActive(false);
                count++;
            }
        else if ((nearest == "mechanic" || nearest == "randomwoman")&&(color == "mechanic" || color == "randomwoman"))
            {
                green2.SetActive(true);
                GameObject.Find(nearest).SetActive(false);
                GameObject.Find(color).SetActive(false);
                count++;
            }
        else if ((nearest == "farmer" || nearest == "woman3") && (color == "woman3" || color == "farmer"))
            {
                green3.SetActive(true);
                GameObject.Find(nearest).SetActive(false);
                GameObject.Find(color).SetActive(false);
                count++;
            }
        else if ((nearest == "salesman" || nearest == "cop") && (color == "salesman" || color == "cop"))
            {
                green4.SetActive(true);
                GameObject.Find(nearest).SetActive(false);
                GameObject.Find(color).SetActive(false);
                count++;
            }
        else
        {
            GameObject.Find(color).GetComponent<Test_script>().failed();
            GameObject.Find(nearest).GetComponent<Test_script>().failed();
           
        }

    }
}
