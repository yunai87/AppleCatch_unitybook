using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
public class GameDirector : MonoBehaviour
{
    GameObject _timerText;
    GameObject _pointText;
    float _time = 30.0f;
    int point = 0;
    GameObject generator;
    
    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

    void Start()
    {
        this._timerText = GameObject.Find("Time");
        this._pointText = GameObject.Find("Point");
        this.generator = GameObject.Find("ItemGenerator");
    }
    
    void Update()
    {
        this._time -= Time.deltaTime;
        if (this._time < 0)
        {
            this._time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0,0);
        }
        else if (0 <= this._time && this._time < 4)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.3f, 0,-0.06f);
        }
        else if (4 <= this._time && this._time < 12)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, 6,-0.05f);
        }
        else if (12 <= this._time && this._time < 23)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.8f, 4,-0.04f);
        }
        else if (23 <= this._time && this._time < 30)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, 2,-0.03f);
        }

        this._timerText.GetComponent<TextMeshProUGUI>().text = this._time.ToString("F1");
        this._pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString()+"point";
    }
}
