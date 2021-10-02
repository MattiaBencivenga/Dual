using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
     
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            LoadOtherDimension();
        }
    }

    public void LoadOtherDimension() 
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Home")
        {
            StartCoroutine(LoadLevel("Level0_3D"));
        }
        else if (sceneName == "Level0_3D")
        {
            StartCoroutine(LoadLevel("Home"));
        }
        else
        {
            Debug.Log("Nessuno dei due casi");
        }
    }

    IEnumerator LoadLevel(string levelName)
    {
        //Play animation
        transition.SetTrigger("StartLoading");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelName);
    }
}
