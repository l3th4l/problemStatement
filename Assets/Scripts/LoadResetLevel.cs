using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadResetLevel : MonoBehaviour
{    
    public int main_menu_index = 0;
    public int main_level_index = 1;

    Scene current_scene;

    private void Start()
    {
        current_scene = SceneManager.GetActiveScene();
        print(current_scene.name);
    }

    public void resetScene()
    {
        SceneManager.LoadScene(current_scene.name);
        Time.timeScale = 1;
    }

    public void loadLevel(int level_index)
    {
        SceneManager.LoadScene(level_index);
        Time.timeScale = 1;
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(main_menu_index);
    }
}
