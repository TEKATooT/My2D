using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BarRenderer : MonoBehaviour
{
    [SerializeField] private AbstractWarrior _barRenderObject;

    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _healthSlider2;
    [SerializeField] private float _reactionSlider;

    [SerializeField] private TextHelthBar _textHelthBar;

    private void OnEnable()
    {
        _healthSlider.maxValue = _barRenderObject.Health;
        _healthSlider2.maxValue = _barRenderObject.Health;

        _barRenderObject.HealthCheched += Draw;
    }

    private void OnDisable()
    {
        _barRenderObject.HealthCheched -= Draw;
    }

    private void Update()
    {
        transform.position = _barRenderObject.transform.position;
    }

    public void Draw(float newValue)
    {
        _healthSlider.DOValue(newValue, _reactionSlider);

        _healthSlider2.value = newValue;

        _textHelthBar.Draw(_barRenderObject.Health, newValue);
    }
}