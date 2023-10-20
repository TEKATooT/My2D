using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntryHouse : MonoBehaviour
{
    [SerializeField] private UnityEvent _entry;
    [SerializeField] private UnityEvent _exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player2d>(out Player2d player))
            _entry.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player2d>(out Player2d player))

            _exit.Invoke();
    }
}
