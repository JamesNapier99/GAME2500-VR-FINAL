using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.UnloadScene("Start Menu");
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        GameObject[] gameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);
        for (int i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));
    }
}
