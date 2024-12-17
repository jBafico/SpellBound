using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    //Le pasamos el loading porque el loading va a cargar el level
    private const string LEVEL_1_SCENE = "Loading";

    [SerializeField] private Button _actionPlay;

    private void Start()
    {
        
        LoadingManager.NEXT_LEVEL = "Tutorial";
                
        _actionPlay.onClick.AddListener(()=> LoadSceneByName(LEVEL_1_SCENE));
    }

    private void LoadSceneByName(string name) => SceneManager.LoadScene(name);
    
}