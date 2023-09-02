using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _alarm;
    private Coroutine _volumeChanger;

    private float _alarmVolumeMin = 0f;
    private float _alarmVolumeMax = 1f;
    private float _alarmVolumeUpStep = 0.1f;
    private float _alarmVolumeDownStep = -0.1f;

    private bool _isWork = false;

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

    public void Control()
    {
        if (_isWork == false)
        {
            CoroutinesControler();

            _alarm.Play();
            _alarm.volume = 0.0f;

            _volumeChanger = StartCoroutine(VolumeChange(_alarmVolumeMax, _alarmVolumeUpStep));

            _isWork = true;
        }
        else
        {
            CoroutinesControler();

            _volumeChanger = StartCoroutine(VolumeChange(_alarmVolumeMin, _alarmVolumeDownStep));

            _isWork = false;
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
