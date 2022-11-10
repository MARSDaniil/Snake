using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject settingPanel;
    public void PlayFreeGame()
    {
        SceneManager.LoadScene("FreePlay");
    }
    public void Box()
    {
        SceneManager.LoadScene("Box");
    }
    public void RandomObstale()
    {
        SceneManager.LoadScene("RandomLand");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
