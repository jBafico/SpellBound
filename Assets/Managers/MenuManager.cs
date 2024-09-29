﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
        //Le pasamos el loading porque el loading va a cargar el level
        private const string LEVEL_1_SCENE = "Loading";

        [SerializeField] private Button _actionPlay;
        [SerializeField] private Button _actionQuit;

        private void Start()
        {
                _actionPlay.onClick.AddListener(()=> LoadSceneByName(LEVEL_1_SCENE));
                _actionQuit.onClick.AddListener(QuitGame);
        }

        private void LoadSceneByName(string name) => SceneManager.LoadScene(name);

        private void QuitGame() => Application.Quit();
}
