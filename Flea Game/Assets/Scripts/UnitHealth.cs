using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    //Tutorial here: https://www.youtube.com/watch?v=9i0UGVUKiaE

    // Fields
    float _currentHealth;
    float _currentMaxHealth;

    // Properties
    public float Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    public float MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }

    // Constructor
    public UnitHealth(float health, float maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    //Methods
    public void DmgUnit(float dmgAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }

    public void HealUnit(float healAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }

        if(_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }

    }

}
