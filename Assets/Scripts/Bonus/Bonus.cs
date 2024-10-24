using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] protected int _score;
    [SerializeField] protected float _time = 4f;
    public bool isInfinite = false;

    private float _currentTime;
    private const float TimeStep = 0.5f;
    public GameDataScript gameData;

    public abstract void Apply();

    protected abstract void Remove();

    public void StopAndRemove()
    {
        Remove();
        Destroy(gameObject);
    }

    protected void StartTimer()
    {
        gameData.points += _score;
        gameData.pointsToBall += _score;
        _currentTime = _time;
        if (!isInfinite) 
        {
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        while (_currentTime > 0)
        {
            _currentTime -= TimeStep;
            yield return new WaitForSeconds(TimeStep);
        }
        Remove();
        Destroy(gameObject);
    }
}
