using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class EntryText : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _fadeSpeed;

    [Header("Colors")]
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _fadeColor;

    private float _fadeInterpolator;
    private int _randomNumber;

    private void Awake()
    {
        _randomNumber = Random.Range(0, int.MaxValue);
        _text.text = "Generation\n" + _randomNumber;
    }
    private void Update()
    {
        _text.color = Color.Lerp(_startColor, _fadeColor, _fadeInterpolator);
        _fadeInterpolator += Time.deltaTime * _fadeSpeed;
        if (_text.color == _fadeColor)
        {
            Destroy(gameObject);
        }
    }
}
