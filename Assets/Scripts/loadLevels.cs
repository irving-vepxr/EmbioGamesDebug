using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadLevels : MonoBehaviour {

	public void loadLevel1()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void loadStore()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void exit()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
