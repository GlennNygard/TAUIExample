using System;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;


public class HomeScreenController : MonoBehaviour {


    [SerializeField]
    private HomeScreenTopBarView _homeScreenTopBarView;

    [SerializeField]
    private HomeScreenBottomBarView _homeScreenBottomBarView;

    [SerializeField]
    private HomeScreenDebugRowView _homeScreenDebugRowView;


    [SerializeField]
    private Image _backgroundImage01;

    [SerializeField]
    private Image _backgroundImage02;

    [SerializeField]
    private Image _backgroundImage03;


    [SerializeField]
    private SettingsPopupController _settingsPopUpController;

    [SerializeField]
    private  LevelCompleteController _levelCompleteController;


    void Start() {

        if(_homeScreenTopBarView == null) {
            _homeScreenTopBarView = GetComponentInChildren<HomeScreenTopBarView>();
        }

        _settingsPopUpController.Hide(skipAnimations: true);
        _levelCompleteController.Hide();
        _homeScreenTopBarView.OnSettingsSelected += () => {
            _settingsPopUpController.Show();
        };

        _homeScreenDebugRowView.OnLevelCompleteSelected += () => {
            _levelCompleteController.Show();
        };


        float duration = 0f;

        Tween.Alpha(_backgroundImage01, endValue: 0f, duration: duration);
        Tween.Alpha(_backgroundImage02, endValue: 0f, duration: duration);
        Tween.Alpha(_backgroundImage03, endValue: 0f, duration: duration);


        // Runs when a new bottom bar item has been toggled on.
        _homeScreenBottomBarView.OnContentActivated += (HomeScreenBottomBarItem item) => {
            Debug.Log(String.Format("New content clicked: {0}. Index: {1}.", item.ButtonLabel, item.ItemIndex));

            float duration = 0.2f;
            float durationOut = 0.2f;
            if(item.ItemIndex == 1) {
                Tween.Alpha(_backgroundImage01, endValue: 1f, duration: duration);
                Tween.Alpha(_backgroundImage02, endValue: 0f, duration: durationOut);
                Tween.Alpha(_backgroundImage03, endValue: 0f, duration: durationOut);
            }
            if(item.ItemIndex == 2) {
                Tween.Alpha(_backgroundImage01, endValue: 0f, duration: duration);
                Tween.Alpha(_backgroundImage02, endValue: 1f, duration: duration);
                Tween.Alpha(_backgroundImage03, endValue: 0f, duration: durationOut);
            }
            if(item.ItemIndex == 3) {
                Tween.Alpha(_backgroundImage01, endValue: 0f, duration: duration);
                Tween.Alpha(_backgroundImage02, endValue: 0f, duration: duration);
                Tween.Alpha(_backgroundImage03, endValue: 1f, duration: duration);
            }
            else {

            }
        };

        // Runs when all bottom bar items have been deactivated. Provides last clicked item.
        _homeScreenBottomBarView.OnClosed += (HomeScreenBottomBarItem item) => {
            Debug.Log(String.Format("All content closed. Last clicked item: {0}. Index: {1}.", item.ButtonLabel, item.ItemIndex));

            float duration = 0.2f;
            Tween.Alpha(_backgroundImage01, endValue: 0f, duration: duration);
            Tween.Alpha(_backgroundImage02, endValue: 0f, duration: duration);
            Tween.Alpha(_backgroundImage03, endValue: 0f, duration: duration);
        };

        _homeScreenTopBarView.Show();
        _homeScreenBottomBarView.Show();
    }
}
