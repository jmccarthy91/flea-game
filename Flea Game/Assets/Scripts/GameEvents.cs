using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents gameEvents;                       // https://www.youtube.com/watch?v=gx0Lt4tCDE0&t=247s for reference

    void Awake()
    {
        if (gameEvents != null && gameEvents != this)
        {
            Destroy(this);
        }
        else
        {
            gameEvents = this;
        }
    }

    public event Action<float> onEnemyCollision;
    public void EnemyCollision(float damage)
    {
        if(onEnemyCollision != null)
        {
            onEnemyCollision(damage);
        }
    }

}
