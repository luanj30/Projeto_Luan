using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class CylinderUI : MonoBehaviour

{
    
    [SerializeField] private TMP_Text cylinderText;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        PayerObserverManeger.OnPayercylinderChanged += UpdateCylindertText;

    }

    // Update is called once per frame
    private void OnDisable()
    {
        PayerObserverManeger.OnPayercylinderChanged -= UpdateCylindertText;
    }

    private void UpdateCylindertText(int cylinder)
    {
        cylinderText.text = cylinder.ToString();
    }
}
