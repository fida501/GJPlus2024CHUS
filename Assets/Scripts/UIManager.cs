using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text woodText;
    public TMP_Text rockText;
    private StringBuilder _stringBuilder = new StringBuilder();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetWoodText(int amount)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append("X ");
        _stringBuilder.Append(amount);
        woodText.text = _stringBuilder.ToString();
    }
    
    public void SetRockText(int amount)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append("X ");
        _stringBuilder.Append(amount);
        rockText.text = _stringBuilder.ToString();
    }
}