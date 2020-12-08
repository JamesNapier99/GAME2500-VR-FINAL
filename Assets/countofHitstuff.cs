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
    public GameObject green1;
    public GameObject green2;
    public GameObject green3;
    public GameObject green4;
    int count = 0;


    public void aNewHit(GameObject person, int color)
    {
        string character = person.name;
        switch (color)
        {
            case 1:

                if (one == true)
                {
                    person.GetComponent<ishit>().personishit();
                    one = false;
                    arrowR = character;
                    person.GetComponent<Test_script>().shot();
                }
                else
                {
                    isMatch(character, arrowR, "Arrow_R(Clone)");
                    one = true;
                }
                break;
            case 2:

                if (two == true)
                {
                    person.GetComponent<ishit>().personishit();
                    two = false;
                    arrowY = character;
                    GameObject.Find(character).GetComponent<Test_script>().shot();
                }
                else
                {
                    isMatch(character, arrowY, "Arrow_Y");
                    two = true;
                }
                break;
            case 3:
              
                if (three == true)
                {
                    person.GetComponent<ishit>().personishit();
                    three = false;
                    arrowG = character;
                    GameObject.Find(character).GetComponent<Test_script>().shot();
                }
                else
                {
                    person.GetComponent<ishit>().personishit();
                    isMatch(character, arrowG, "Arrow_G");
                    three = true;

                }
                break;
            case 4:

                if (four == true)
                {
                    four = false;
                    arrowB = character;
                    GameObject.Find(character).GetComponent<Test_script>().shot();
                }
                else
                {
                    isMatch(character, arrowB, "Arrow_B");
                    four = true;

                }
                break;
        }
    }

    private void isMatch(string nearest, string color, string arrowColor)
    {

        if ((nearest == "woman2" || nearest == "randomdude")&& (color == "woman2" || color == "randomdude"))
            {
                green1.SetActive(true);
                GameObject.Find(nearest).SetActive(false);
                GameObject.Find(color).SetActive(false);
            GameObject.Find(arrowColor).SetActive(false);
            count++;
            }
        else if ((nearest == "mechanic" || nearest == "randomwoman")&&(color == "mechanic" || color == "randomwoman"))
            {
                green2.SetActive(true);
                GameObject.Find(nearest).SetActive(false);
                GameObject.Find(color).SetActive(false);
            GameObject.Find(arrowColor).SetActive(false);
            count++;
            }
        else if ((nearest == "farmer" || nearest == "woman3") && (color == "woman3" || color == "farmer"))
            {
                green3.SetActive(true);
                GameObject.Find(nearest).SetActive(false);
                GameObject.Find(color).SetActive(false);
            GameObject.Find(arrowColor).SetActive(false);
            count++;
            }
        else if ((nearest == "salesman" || nearest == "cop") && (color == "salesman" || color == "cop"))
            {
                green4.SetActive(true);
                GameObject.Find(nearest).SetActive(false);
                GameObject.Find(color).SetActive(false);
            GameObject.Find(arrowColor).SetActive(false);
            count++;
            }
        else
        {
            GameObject.Find(color).GetComponent<Test_script>().failed();
            GameObject.Find(color).GetComponent<ishit>().personunhit();
            GameObject.Find("Timer").GetComponent<TimerText>().PairPenalty();
           
        }

    }
}
