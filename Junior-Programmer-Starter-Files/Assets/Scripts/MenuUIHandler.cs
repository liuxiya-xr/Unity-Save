using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR//
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
    public void StartNew()//“开始”按钮——调用场景
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()//“退出按钮”——退出程序界面
    {

#if UNITY_EDITOR//仅在Unity 编辑器中执行（在实际版本中不存在）

        EditorApplication.ExitPlaymode();
#else//在实际构建的游戏版本中执行
                  Application.Quit();
#endif
    }
}
