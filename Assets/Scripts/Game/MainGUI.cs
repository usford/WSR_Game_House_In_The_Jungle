using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGUI : MonoBehaviour
{
    public GameObject panelWithTarget; //Панель с текстом в начале игры
    public Text numberOfSpheres; //Количество сфер
    public GameObject panelEsc; //Esc

    private bool pause = false; //Пауза в игре
    private float time; //Перемени для подсчёта времени

    void Awake()
    {
        numberOfSpheres.text = "0";
        panelWithTarget.SetActive(true);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 4.0f)
        {
            panelWithTarget.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            panelEsc.SetActive(pause);           
        }
    }

    /// <summary>
    /// Вернуться в меню
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    /// <summary>
    /// Продолжить игру
    /// </summary>
    public void Continue()
    {
        pause = !pause;
        panelEsc.SetActive(pause);
    }
}
