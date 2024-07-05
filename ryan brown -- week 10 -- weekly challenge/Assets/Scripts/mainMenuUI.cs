using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class mainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject HTP_panel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartButton(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void HTP_Button()
    {
        HTP_panel.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void HTP_Back_Button()
    {
        HTP_panel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
