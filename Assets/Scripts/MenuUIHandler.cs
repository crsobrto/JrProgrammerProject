using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required to use the SceneManager
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // Call MainManager for data persistence
        MainManager.Instance.TeamColor = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        ColorPicker.SelectColor(MainManager.Instance.TeamColor); // If there is a saved color in MainManager, preselect it in the menu
    }

    public void StartNew()
    {
        // SceneManager handles loading and unloading scenes
        // "1" is the main scene's index
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MainManager.Instance.SaveColor(); // Saves the player's last selected color when the game is quit
#if UNITY_EDITOR // If the game is begin run in the Unity Editor
        EditorApplication.ExitPlaymode(); // Exit playmode
#else // If the game is being run outside of the Unity Editor
        Application.Quit(); // Quit the game
#endif
    }

    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
}
