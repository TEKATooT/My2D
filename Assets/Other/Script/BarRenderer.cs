using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BarRenderer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _reactionSlider;

    private float _nowValue = 1;
    private float _stepValue = .1f;

    private float _maxValue = 1;
    private float _minValue = 0;

    public void UpSlider()
    {
        if (_nowValue < _maxValue)
        {
            _nowValue += _stepValue;
            _slider.DOValue(_nowValue, _reactionSlider);
        }
    }

    public void DownSlider()
    {
        if (_nowValue > _minValue)
        {
            _nowValue -= _stepValue;
            _slider.DOValue(_nowValue, _reactionSlider);
        }
    }
}