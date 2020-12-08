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
   public AudioClip success;
    public AudioClip fail;
    public AudioClip gameMusic;
    public AudioClip endGame;

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
                    isMatch(character, arrowR);
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
                    isMatch(character, arrowY);
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
                    isMatch(character, arrowG);
                    three = true;

                }
                break;
            case 4:

                if (four == true)
                {
                    person.GetComponent<ishit>().personishit();
                    four = false;
                    arrowB = character;
                    GameObject.Find(character).GetComponent<Test_script>().shot();
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
        //failure();
        if ((nearest == "woman2" || nearest == "randomdude") && (color == "woman2" || color == "randomdude"))
        {
            green1.SetActive(true);

            GameObject.Find("Timer").GetComponent<TimerText>().endgame();
            GameObject.Find(nearest).SetActive(false);
            GameObject.Find(color).SetActive(false);
            successful();
            //GameObject.Find(arrowColor).SetActive(false);
        }
        else if ((nearest == "mechanic" || nearest == "randomwoman") && (color == "mechanic" || color == "randomwoman"))
        {

            
            green2.SetActive(true);
            GameObject.Find("Timer").GetComponent<TimerText>().endgame();
            GameObject.Find(nearest).SetActive(false);
            GameObject.Find(color).SetActive(false);
           successful();
           // GameObject.Find(arrowColor).SetActive(false);
        }
        else if ((nearest == "farmer" || nearest == "woman3") && (color == "woman3" || color == "farmer"))
        {
            green3.SetActive(true);

            GameObject.Find("Timer").GetComponent<TimerText>().endgame();
            GameObject.Find(nearest).SetActive(false);
            GameObject.Find(color).SetActive(false);
           successful();
           // GameObject.Find(arrowColor).SetActive(false);
        }
        else if ((nearest == "salesman" || nearest == "cop") && (color == "salesman" || color == "cop"))
        {
            green4.SetActive(true);

            GameObject.Find("Timer").GetComponent<TimerText>().endgame();
            GameObject.Find(nearest).SetActive(false);
            GameObject.Find(color).SetActive(false);
           successful();
          //  GameObject.Find(arrowColor).SetActive(false);
        }
        else
        {
            GameObject.Find(color).GetComponent<Test_script>().failed();
            GameObject.Find(color).GetComponent<ishit>().personunhit();
            GameObject.Find("Timer").GetComponent<TimerText>().PairPenalty();
            failure();

        }

    }
    void failure()
{
       AudioSource audio = GetComponent<AudioSource>();
        audio.clip = fail;
        audio.loop = false;
        audio.Play(0);
        Invoke("StopAudio", 2.0f);
 }

    private void StopAudio()
    {
        GetComponent<AudioSource>().Stop();
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = gameMusic;
        audio.loop = true;
        audio.Play(0);

    }
    void successful()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = success;
        audio.loop = false;
        audio.Play(0);
        Invoke("StopAudio", 2.0f);
    }
   public void endSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = endGame;
        audio.loop = false;
        audio.Play(0);
        Invoke("StopAudio", 6.0f);

    }
}
