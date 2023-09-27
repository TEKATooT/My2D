using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BarRenderer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _reactionSlider;

    public void UpSlider(float value)
    {
            _slider.DOValue(value, _reactionSlider);
    }

    public void DownSlider(float value)
    {
            _slider.DOValue(value, _reactionSlider);
    }
}
