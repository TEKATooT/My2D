using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BarRenderer : MonoBehaviour
{
    [SerializeField] private AbstractWarrior _barRenderObject;

    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _slider2;
    [SerializeField] private float _reactionSlider;

    [SerializeField] private TextHelthBar _textHelthBar;

    private void OnEnable()
    {
        _barRenderObject.HealthCheched += Draw;
    }

    private void OnDisable()
    {
        _barRenderObject.HealthCheched -= Draw;
    }

    private void Start()
    {
        _slider.maxValue = _barRenderObject.Health;
        _slider2.maxValue = _barRenderObject.Health;
    }

    public void Draw(float newValue)
    {
        _slider.DOValue(newValue, _reactionSlider);

        _slider2.value = newValue;

        _textHelthBar.Draw(_barRenderObject.Health, newValue);
    }
}