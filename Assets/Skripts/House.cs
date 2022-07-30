using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]
public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.TryGetComponent<Player>(out Player player))
        {
            _reached?.Invoke();
        }
    }
}
