using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    PointsManager pointsManager;
 

    void Update()
    {
        if(pointsManager.slider.value == pointsManager.slider.maxValue)
        {
            Time.timeScale = 0f;
        }
    }
}
