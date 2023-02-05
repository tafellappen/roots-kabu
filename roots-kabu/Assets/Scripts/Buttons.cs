using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameClicked() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void ReplayClicked() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Titlescreen");
    }
}
