using UnityEngine;
using UnityEngine.UI;
using System;
using PrimeTween;


public class HomeScreenTopBarView : MonoBehaviour {

    [SerializeField]
    private Button _settingsButton;

    public event Action OnSettingsSelected;


    private RectTransform _rectTransform;
    private Vector2 _initialBarLocation;
    private float _startOffset = 260;


    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        _initialBarLocation = _rectTransform.anchoredPosition;

        PrimeTween.Tween.UIAnchoredPosition(_rectTransform, _initialBarLocation + new Vector2(0,1)*_startOffset, duration:0);
    
    } 


    void Start() {

        if(_settingsButton != null) {
            _settingsButton.onClick.AddListener(() => OnSettingsSelected?.Invoke());
        }
    }

    public void Show() {
        PrimeTween.Tween.UIAnchoredPosition(
            _rectTransform, new TweenSettings<Vector2>(
                _initialBarLocation + new Vector2(0,1)*_startOffset, _initialBarLocation, 0.65f, Ease.OutCubic));
    }
}
