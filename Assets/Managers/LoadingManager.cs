using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingManager : MonoBehaviour
{
    public static string NEXT_LEVEL = "Level 1";

    #region PROPERTIES
    [SerializeField] private Image _progressBar;
    [SerializeField] private TMP_Text _progressText;
    [SerializeField] private Button _actionContinue;
    private bool _continueToLevel;

    #endregion

    private void Start()
    {
        _actionContinue.onClick.AddListener(ContinueToLevel);
        _actionContinue.interactable = false;
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(NEXT_LEVEL);
        operation.allowSceneActivation = false;
        
        float progress;
        
        while (!operation.isDone)
        {
            progress = operation.progress;
            _progressBar.fillAmount = progress;
            _progressText.text = $"{progress * 100} %";

            //Pasar el 90% de carga y habilita tocar SPACE para continuar
            if (progress >= .9f)
            {
                _progressText.text = "Press CONTINUE to continue";
                _actionContinue.interactable = true;

                if (_continueToLevel)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
    
    private void ContinueToLevel()=> _continueToLevel = true;

}
