using System;
using TMPro;
using UnityEngine;

public class CurrDate : MonoBehaviour
{
    string[] months = new[]
    {
        "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
    };

    private void Start()
    {
        var dt = DateTime.Now;
        GetComponent<TMP_Text>().text = $"{months[dt.Month - 1]} {dt.Day}, {dt.Year}";
    }
}
