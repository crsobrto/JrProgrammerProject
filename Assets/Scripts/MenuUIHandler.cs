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
        // add code here to handle when a color is selected
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    public void StartNew()
    {
        // SceneManager handles loading and unloading scenes
        // "1" is the main scene's index
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR // If the game is begin run in the Unity Editor
        EditorApplication.ExitPlaymode(); // Exit playmode
#else // If the game is being run outside of the Unity Editor
        Application.Quit(); // Quit the game
#endif
    }
}
