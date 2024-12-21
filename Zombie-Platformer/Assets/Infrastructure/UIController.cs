using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour, IUIController
{
    [SerializeField] private TMP_Text _ammoCountText;
    [SerializeField] private GameObject _endWindow;

    public void ShowAmmoCount(int ammoCount)
    {
        _ammoCountText.text = ammoCount.ToString();
    }

    public void ShowEndWindow()
    {
        _endWindow.SetActive(true);
    }

    public void OnRestartSelected()
    {
        SceneManager.LoadScene(0);
    }

    public void OnExitSelected()
    {
        Application.Quit();
    }
}