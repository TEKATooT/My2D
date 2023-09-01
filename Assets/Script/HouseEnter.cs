using System.Collections;
using UnityEngine;

public class HouseEnter : MonoBehaviour
{
    private AudioSource _alarm;
    private SpriteRenderer _home;
    private Color _defaultColor;

    private float _alarmVolumeMin = 0f;
    private float _alarmVolumeMax = 1f;
    private float _alarmVolumeUpStep = 0.1f;
    private float _alarmVolumeDownStep = -0.1f;

    void Start()
    {
        _alarm = GetComponent<AudioSource>();
        _home = GetComponent<SpriteRenderer>();

        _defaultColor = _home.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopAllCoroutines();

        if (collision.TryGetComponent<Player>(out Player player))
        {
            _alarm.Play();
            _alarm.volume = 0.0f;
            _home.color = Color.red;

            StartCoroutine(VolumeChange(_alarmVolumeMax, _alarmVolumeUpStep));
        }
    }

    private void OnTriggerExit2D()
    {
        StopAllCoroutines();
        _home.color = _defaultColor;

        StartCoroutine(VolumeChange(_alarmVolumeMin, _alarmVolumeDownStep));
    }

    private IEnumerator VolumeChange(float needVolume, float VolumeStep)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_alarm.volume != needVolume)
        {
            _alarm.volume += VolumeStep;
            Debug.Log(_alarm.volume);

            yield return waitForOneSeconds;
        }
    }
}
