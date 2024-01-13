using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BarRenderer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _reactionSlider;

    private float _nowValue = 1;
    private float _stepValue = .1f;

    public void UpSlider()
    {
            _nowValue += _stepValue;
            _slider.DOValue(_nowValue, _reactionSlider);
    }

    public void DownSlider()
    {
            _nowValue -= _stepValue;
            _slider.DOValue(_nowValue, _reactionSlider);
    }
}