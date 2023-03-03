using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;                       // https://www.youtube.com/watch?v=gx0Lt4tCDE0&t=247s for reference

    void Awake()
    {
        current = this;
    }

    public event Action onEnemyCollision;
    public void EnemyCollision()
    {
        if(onEnemyCollision != null)
        {
            onEnemyCollision();
        }
    }

}
