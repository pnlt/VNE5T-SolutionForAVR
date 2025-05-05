using Oculus.Interaction;
using UnityEngine;

/// <summary>
/// The ISDK Scene Manager handles the enabling and disabling
/// of the ISDK Menu panel and plays audio for each action.
/// </summary>
public class ISDKSceneMenuManager : MonoBehaviour
{
    /// <summary>
    /// The Parent Object of the Menu
    /// </summary>
    [Tooltip("The parent object of the menu")] [Header("Place the grabbable parent object here")] [SerializeField]
    private GameObject _menuParent;

    /// <summary>
    /// The audio to play when showing the menu panel
    /// </summary>
    [Tooltip("The audio to play when showing the menu panel")]
    [Header("Place the menu open audio here")]
    [SerializeField]
    private AudioSource _showMenuAudio;

    /// <summary>
    /// The audio to play when hiding the menu panel
    /// </summary>
    [Tooltip("The audio to play when hiding the menu panel")]
    [Header("Place the menu hide audio here")]
    [SerializeField]
    private AudioSource _hideMenuAudio;

    /// <summary>
    /// The location the menu should be spawning at
    /// </summary>
    //[Tooltip("The location the menu should be spawning at")]
    //[Header("The location the menu should be spawning at")]
    //[SerializeField]
    //private GameObject _spawnPoint;
    protected bool _started = false;

    protected virtual void Start() {
        this.BeginStart(ref _started);
        this.AssertField(_menuParent, nameof(_menuParent));
        this.AssertField(this._showMenuAudio, nameof(_showMenuAudio));
        this.AssertField(this._hideMenuAudio, nameof(_hideMenuAudio));
        //this.AssertField(this._spawnPoint, nameof(_spawnPoint));

        this.EndStart(ref _started);
    }

    /// <summary>
    /// Show/hide the menu.
    /// </summary>
    public void ToggleMenu() {
        if (_menuParent.activeSelf) {
            _hideMenuAudio.Play();
            _menuParent.SetActive(false);
        }
        else {
            _showMenuAudio.Play();
            //  _menuParent.transform.position = _spawnPoint.transform.position;
            // _menuParent.transform.rotation = _spawnPoint.transform.rotation;
            _menuParent.SetActive(true);
        }
    }

    #region Injects

    public void InjectAllMenuItems(
        GameObject parent,
        AudioSource show,
        AudioSource hide,
        GameObject spawnpoint) {
        InjectMenuParent(parent);
        InjectShowAudio(show);
        InjectHideAudio(hide);
        InjectSpawnPoint(spawnpoint);
    }

    public void InjectMenuParent(GameObject parent) {
        _menuParent = parent;
    }

    public void InjectShowAudio(AudioSource show) {
        _showMenuAudio = show;
    }

    public void InjectHideAudio(AudioSource hide) {
        _showMenuAudio = hide;
    }

    public void InjectSpawnPoint(GameObject spawnpoint) {
        _menuParent = spawnpoint;
    }

    #endregion
}