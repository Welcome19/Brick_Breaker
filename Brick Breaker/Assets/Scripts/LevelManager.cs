using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public Paddle paddle;

	public void LoadLevel(string name)
    {
        Bricks.breakableCount = 0;
        Application.LoadLevel(name);    
    }
    public void QuitLevel()
    {
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        Bricks.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1); 
    }
    public void BrickDestroyed()
    {
        if(Bricks.breakableCount<=0)
        {
            LoadNextLevel();
        }
    }
}
