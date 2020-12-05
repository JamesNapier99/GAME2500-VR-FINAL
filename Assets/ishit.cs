using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ishit : MonoBehaviour
{
    bool shot = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public bool isPersonhit()
    {
        return shot;
    }
    public void personishit()
    {
        shot = true;
    }
}
