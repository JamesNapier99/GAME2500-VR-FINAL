using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
