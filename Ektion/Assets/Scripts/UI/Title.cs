using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Title : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [Header("Font size settings")]
    [SerializeField] private float _minFontSize;
    [SerializeField] private float _maxFontSize;
    [SerializeField] private float _fontSizeSpeed;
    private float _sizeInterpolator;

    [Header("Font color settings")]
    [SerializeField] private Color _color1;
    [SerializeField] private Color _color2;
    [SerializeField] private float _fontColorSpeed;
    private float _colorInterpolator;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        ChangeSize();
        ChangeColor();
    }

    private void ChangeSize()
    {
        _text.fontSize = Mathf.Lerp(_minFontSize, _maxFontSize, _sizeInterpolator);
        _sizeInterpolator += _fontSizeSpeed * Time.deltaTime;
        if (_sizeInterpolator > 1.0f)
        {
            float temp = _maxFontSize;
            _maxFontSize = _minFontSize;
            _minFontSize = temp;
            _sizeInterpolator = 0.0f;
        }
    }

    private void ChangeColor()
    {
        _text.color = Color.Lerp(_color1, _color2, _colorInterpolator);
        _colorInterpolator += _fontColorSpeed * Time.deltaTime;
        if (_colorInterpolator > 1.0f)
        {
            Color temp = _color2;
            _color2 = _color1;
            _color1 = temp;
            _colorInterpolator = 0.0f;
        }
    }
}
