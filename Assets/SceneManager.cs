using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTools : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        mySceneTools = Game.Object.FindObjectofType(sceneTools sceneTools);
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChanger(string name)
    {
        sceneManager.LoadScene(name);
    }
}
