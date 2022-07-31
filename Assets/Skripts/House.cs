using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _movementStarted;
    [SerializeField] private UnityEvent _movementLeft;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.TryGetComponent<Player>(out Player player))
        {
            _movementStarted?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _movementLeft?.Invoke();
        }
    }
}
