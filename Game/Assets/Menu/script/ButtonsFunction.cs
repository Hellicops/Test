using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsFunction : MonoBehaviour
    
{
    public bool visible;
    public void NewGame()
    {
        Application.LoadLevel(1);
    }
    public void Levels()
    {
        Application.LoadLevel(2);
    }
    public void Level1()
    {
        Application.LoadLevel(1);
    }
    public void Level2()
    {

    }
    public void Level3()
    {

    }
    public void Level4()
    {

    }
    public void Skill()
    {
        visible = true;

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        Application.LoadLevel(0);
    }
}
