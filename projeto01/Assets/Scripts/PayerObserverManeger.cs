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
}
