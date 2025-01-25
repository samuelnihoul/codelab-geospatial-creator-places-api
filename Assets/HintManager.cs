using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HintManager : MonoBehaviour
{
    public string hintString;
    public TextMeshProUGUI hintText;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hintText.text = hintString;
        }
    }
}
