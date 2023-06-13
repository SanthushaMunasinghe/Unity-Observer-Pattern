using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNarrator : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _playerSubject;

    //Jump Settings
    private int _jumpCount = 0;
    private int _jumpActionThreshold = 3;
    Coroutine _currentJumpResetRoutine = null;

    public void OnNotify(PlayerActions action)
    {
        if (action == PlayerActions.Jump)
        {
            if (_currentJumpResetRoutine != null)
            {
                StopCoroutine(_currentJumpResetRoutine);
            }

            _jumpCount++;

            if (_jumpCount == _jumpActionThreshold)
            {
                Debug.Log("Player Keeps Jumping");
            }

            _currentJumpResetRoutine = StartCoroutine(IJumpResetRoutine());
        }
    }

    IEnumerator IJumpResetRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        _jumpCount = 0;
    }

    private void OnEnable()
    {
        _playerSubject.AttachObserver(this);
    }

    private void OnDisable()
    {
        _playerSubject.DetachObserver(this);
    }
}

public enum PlayerActions
{
    Jump,
    Walk,
    Attack,
}
