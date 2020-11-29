using System;
using UnityEngine;

public static class DeathCounter
{
    private static int _counter;

    public static event Action<int> OnAddDeath;

    private const string DeathCounterString = "DeathCounter";
    
    public static void AddDeath()
    {
        _counter++;
        OnAddDeath?.Invoke(_counter);
    }

    public static void SaveChanges()
    {
        var bestScore = GetCounter();
        if(bestScore < _counter)
            PlayerPrefs.SetInt(DeathCounterString, _counter);
    }

    public static int GetCounter()
    {
        return PlayerPrefs.GetInt(DeathCounterString);
    }
}