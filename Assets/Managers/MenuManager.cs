using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
        //Le pasamos el loading porque el loading va a cargar el level
        private const string LEVEL_1_SCENE = "Loading";
        private const string CREDITS_SCENE = "Credits";

        [SerializeField] private Button _actionPlay;
        [SerializeField] private Button _actionCredits;
        [SerializeField] private Button _actionQuit;

        private void Start()
        {
                //Reseteo el timescale por si volvio al menu despues de perder o ganar
                Time.timeScale = 1;
                
                _actionPlay.onClick.AddListener(()=> LoadSceneByName(LEVEL_1_SCENE));
                _actionCredits.onClick.AddListener(()=> LoadSceneByName(CREDITS_SCENE));
                _actionQuit.onClick.AddListener(QuitGame);
        }

        private void LoadSceneByName(string name) => SceneManager.LoadScene(name);

        private void QuitGame() => Application.Quit();
}
