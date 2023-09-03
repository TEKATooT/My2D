using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _signal;
    private Coroutine _volumeChanger;

    [SerializeField] private float _waitSeconds;

    private float _volumeMin = 0f;
    private float _volumeMax = 1f;
    private float _volumeUpStep = 0.01f;
    private float _volumeDownStep = -0.01f;

    private bool _isWork = false;

    private void Start()
    {
        _signal = GetComponent<AudioSource>();
    }

    private IEnumerator VolumeChange(float needVolume, float volumeStep)
    {
        var waitForOneSeconds = new WaitForSeconds(_waitSeconds);

        while (_signal.volume != needVolume)
        {
            _signal.volume += volumeStep;

            yield return waitForOneSeconds;
        }
    }

    public void SignalControl()
    {
        if (_isWork == false)
        {
            ControlCoroutines();

            _signal.Play();
            _signal.volume = 0.0f;

            _volumeChanger = StartCoroutine(VolumeChange(_volumeMax, _volumeUpStep));

            _isWork = true;
        }
        else
        {
            ControlCoroutines();

            _volumeChanger = StartCoroutine(VolumeChange(_volumeMin, _volumeDownStep));

            _isWork = false;
        }
    }

    private void ControlCoroutines()
    {
        if (_volumeChanger != null)
        {
            StopCoroutine(_volumeChanger);
        }
    }
}
