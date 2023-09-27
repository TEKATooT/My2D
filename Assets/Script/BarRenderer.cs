using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class BarRenderer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _reactionSlider;

    private float _maxValue = 1;
    private float _minValue = 0;
    private float _nowValue = 1;

    public void UpSlider(float value)
    {
        if (_nowValue < _maxValue)
        {
            _nowValue += value;
            _slider.DOValue(_nowValue, _reactionSlider);
        }
    }

    public void DownSlider(float value)
    {
        if (_nowValue > _minValue)
        {
            _nowValue -= value;
            _slider.DOValue(_nowValue, _reactionSlider);
        }
    }
}