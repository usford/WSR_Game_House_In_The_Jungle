using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGUI : MonoBehaviour
{
    public GameObject panelWithTarget; //Панель с текстом в начале игры
    public Text numberOfSpheres; //Количество сфер

    private float time; //Перемени для подсчёта времени

    void Awake()
    {
        numberOfSpheres.text = "0";
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 4.0f)
        {
            panelWithTarget.SetActive(false);
        }
    }
}
