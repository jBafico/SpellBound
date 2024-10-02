using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
        private const string MENU_SCENE = "Menu";

        [SerializeField] private Button _actionReturn;

        private void Start()
        {
                _actionReturn.onClick.AddListener(()=> LoadSceneByName(MENU_SCENE));
        }

        private void LoadSceneByName(string name) => SceneManager.LoadScene(name);
}
