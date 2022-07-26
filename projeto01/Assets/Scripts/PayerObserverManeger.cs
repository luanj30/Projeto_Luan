using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PayerObserverManeger 
{
    public static Action<int> OnPlayerCoinsChanged;

    public static void PlayerCoinsChanged(int value)
    {
        OnPlayerCoinsChanged?.Invoke(value);
    }
    
    public static Action<int> OnPayercylinderChanged;

    public static void PlayercylinderChanged(int value)
    {
        OnPayercylinderChanged?.Invoke(value);
    }
    
    
}


