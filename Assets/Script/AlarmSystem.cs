using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    private AudioSource _alarm;
    private Coroutine _volumeChanger;

    private float _alarmVolumeMin = 0f;
    private float _alarmVolumeMax = 1f;
    private float _alarmVolumeUpStep = 0.1f;
    private float _alarmVolumeDownStep = -0.1f;

    public void On()
    {
        Debug.Log("In");
        _alarm.Play();
        _alarm.volume = 0.0f;

        CoroutinesControler();
        _volumeChanger = StartCoroutine(VolumeChange(_alarmVolumeMax, _alarmVolumeUpStep));
    }

    public void Off() 
    {
        Debug.Log("Off");
        CoroutinesControler();
        _volumeChanger = StartCoroutine(VolumeChange(_alarmVolumeMin, _alarmVolumeDownStep));
    }

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
    }

    private IEnumerator VolumeChange(float needVolume, float volumeStep)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_alarm.volume != needVolume)
        {
            _alarm.volume += volumeStep;

            yield return waitForOneSeconds;
        }
    }

    private void CoroutinesControler()
    {
        if (_volumeChanger != null)
        {
            StopCoroutine(_volumeChanger);
        }
    }
}
