using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cointUI : MonoBehaviour

{
    
    [SerializeField]
    private TMP_Text coinText;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        PayerObserverManeger.OnPlayerCoinsChanged += UpdatecointText;

    }

    // Update is called once per frame
   private void OnDisable()
    {
        PayerObserverManeger.OnPlayerCoinsChanged -= UpdatecointText;
    }

   private void UpdatecointText(int coins)
   {
       coinText.text = coins.ToString();
   }
}
