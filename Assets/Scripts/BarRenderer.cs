using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BarRenderer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _slider2;
    [SerializeField] private float _reactionSlider;
    [SerializeField] private float _reactionSlider2;

    [SerializeField] private TextHelthBar _textHelthBar;
    
    private float _nowValue;
    private float _maxValue = 100;
    private float _minValue = 0;

    private void Start()
    {
        _nowValue = _maxValue;

        _textHelthBar.Draw(_nowValue);
    }

    private void Update()
    {
        BarDrawCorrector();
    }

    public void SliderUp(int value)
    {
        if (_nowValue < _maxValue)
        {
            _nowValue += value;

            _slider.DOValue(_nowValue, _reactionSlider);
            _slider2.DOValue(_nowValue, _reactionSlider2);

            _textHelthBar.Draw(_nowValue);
        }
    }

    public void SliderDown(int value)
    {
        if (_nowValue > _minValue)
        {
            _nowValue -= value;

            _slider.DOValue(_nowValue, _reactionSlider);
            _slider2.DOValue(_nowValue, _reactionSlider2);

            _textHelthBar.Draw(_nowValue);
        }
    }

    private void BarDrawCorrector()
    {
        if (transform.rotation != Quaternion.Euler(0, 0, 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}