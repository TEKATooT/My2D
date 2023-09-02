using System.Collections;
using UnityEngine;

public class HouseEnter : MonoBehaviour
{
    private AudioSource _alarm;
    private Coroutine VolumeChanger;

    private float _alarmVolumeMin = 0f;
    private float _alarmVolumeMax = 1f;
    private float _alarmVolumeUpStep = 0.1f;
    private float _alarmVolumeDownStep = -0.1f;

    void Start()
    {
        _alarm = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarm.Play();
            _alarm.volume = 0.0f;

            CoroutinesControler();
            VolumeChanger = StartCoroutine(VolumeChange(_alarmVolumeMax, _alarmVolumeUpStep));
        }
    }

    private void OnTriggerExit2D()
    {
        CoroutinesControler();
        VolumeChanger = StartCoroutine(VolumeChange(_alarmVolumeMin, _alarmVolumeDownStep));
    }

    private void CoroutinesControler()
    {
        if (VolumeChanger != null)
        {
            StopCoroutine(VolumeChanger);
        }
    }

    private IEnumerator VolumeChange(float needVolume, float volumeStep)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_alarm.volume != needVolume)
        {
            _alarm.volume += volumeStep;
            Debug.Log(_alarm.volume);

            yield return waitForOneSeconds;
        }
    }
}
