using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Skor : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI text;
    private float decreaseInterval = 5f;
    private float timeSinceLastDecrease = 0f;
    void Start()
    {
        GuncelSkor();
        
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Skor", score);
        PlayerPrefs.Save();
        print(score);
    }
    void GuncelSkor()
    {
        if(text != null)
        {
            text.text = "Skor : " + score;

        }
        else
        {
            Debug.LogWarning("Text nesnesi atanmýþ!");
        }
    }
    void Update()
    {
        timeSinceLastDecrease += Time.deltaTime;
        if (timeSinceLastDecrease >= decreaseInterval)
        {
            AzaltSkor(10);
            timeSinceLastDecrease = 0f;
        }
        
    }
    void AzaltSkor(int miktar)
    {
        score -= miktar;
        GuncelSkor();
    }
}
