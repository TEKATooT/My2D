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

    private void Start()
    {
    }

    private void Update()
    {
        BarDrawCorrector();
    }

    public void Draw(int startValue, int newValue)
    {
        _slider.maxValue = startValue;
        _slider2.maxValue = startValue;

        _slider.DOValue(newValue, _reactionSlider);
        _slider2.DOValue(newValue, _reactionSlider2);

        _textHelthBar.Draw(startValue, newValue);
    }

    private void BarDrawCorrector()
    {
        if (transform.rotation != Quaternion.Euler(0, 0, 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}