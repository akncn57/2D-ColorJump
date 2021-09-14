using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public GameObject Logo;
    public GameObject PlayBtn;
    public GameObject SettingsBtn;
    public GameObject DesignDevelopeText;

    public GameObject SettingsUI;
    public GameObject SettingsText;
    public GameObject MusicText;
    public GameObject MusicSlider;
    public GameObject EffectText;
    public GameObject EffectSlider;

    private void Start()
    {
        SettingsBtn.transform.localScale = new Vector3(0, 0, 0);
        SettingsBtn.transform.DOScale(1, 1.5f).SetEase(Ease.OutBounce);

        PlayBtn.transform.DOLocalMoveX(-207, 1.5f).SetEase(Ease.OutBounce);
        DesignDevelopeText.transform.DOLocalMoveY(-1849, 1.5f).SetEase(Ease.OutBounce);

        Logo.transform.DOLocalMoveY(1700, 1.5f).SetEase(Ease.OutBounce);
    }

    public void PlayButtonClick()
    {
        StartCoroutine(SwitchSceneUIAnimations());
    }

    public void SettingsButtonClick()
    {
        SettingsUI.SetActive(true);
        SettingsStartAnimations();
    }

    public void SettingsClose()
    {
        StartCoroutine(SettingsCloseAnimations());
    }

    IEnumerator SwitchSceneUIAnimations()
    {
        SettingsBtn.transform.DOScale(0, 1.5f).SetEase(Ease.OutBounce);
        PlayBtn.transform.DOLocalMoveX(-10000, 1.5f).SetEase(Ease.OutBounce);
        DesignDevelopeText.transform.DOLocalMoveX(-10000, 1.5f).SetEase(Ease.OutBounce);
        Logo.transform.DOLocalMoveY(-10000, 1.5f).SetEase(Ease.OutBounce);
        yield return  new WaitForSeconds(1f);
        SceneManager.LoadScene("1");
    }

    public void SettingsStartAnimations()
    {
        SettingsText.transform.DOLocalMoveY(1948, 1.5f).SetEase(Ease.OutBounce);
        MusicText.transform.DOLocalMoveX(346, 1.5f).SetEase(Ease.OutBounce);
        MusicSlider.transform.DOLocalMoveX(346, 1.5f).SetEase(Ease.OutBounce);
        EffectText.transform.DOLocalMoveX(760, 1.5f).SetEase(Ease.OutBounce);
        EffectSlider.transform.DOLocalMoveX(760, 1.5f).SetEase(Ease.OutBounce);
    }

    IEnumerator SettingsCloseAnimations()
    {
        SettingsText.transform.DOLocalMoveY(-1000, 1.5f).SetEase(Ease.OutBounce);
        MusicText.transform.DOLocalMoveX(-1000, 1.5f).SetEase(Ease.OutBounce);
        MusicSlider.transform.DOLocalMoveX(-1000, 1.5f).SetEase(Ease.OutBounce);
        EffectText.transform.DOLocalMoveX(-1000, 1.5f).SetEase(Ease.OutBounce);
        EffectSlider.transform.DOLocalMoveX(-1000, 1.5f).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(0.35f);
        SettingsUI.SetActive(false);
    }
}
