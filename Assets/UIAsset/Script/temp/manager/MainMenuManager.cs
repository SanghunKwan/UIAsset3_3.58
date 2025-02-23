using UnityEngine;
using UnityEngine.SceneManagement;

namespace SGA.Temp
{

    public class MainMenuManager : MonoBehaviour
    {

        public void GameQuit()
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        }
        public void LoadGameScene()
        {
            SceneManager.LoadSceneAsync(0);
        }
    }

}