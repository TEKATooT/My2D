using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AlarmSystem))]

public class EntryHouse : MonoBehaviour
{
    private AlarmSystem _alarmSystem;

    private void Awake()
    {
        _alarmSystem = GetComponent<AlarmSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _alarmSystem.On();
    }

    private void OnTriggerExit2D()
    {
        _alarmSystem.Off();
    }
}
