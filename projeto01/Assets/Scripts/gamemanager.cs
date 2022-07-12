using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject playerAndCameraPrefeb;

    [SerializeField] private string locationToLoad;

    [SerializeField] private Scene guiScene;
    
    // Start is called before the first frame update
    
    void Start()
    {
       DontDestroyOnLoad(this.gameObject);
       SceneManager.LoadScene(guiScene);
       //SceneManager.LoadScene(locationToLoad, LoadSceneMode.Additive);
       SceneManager.LoadSceneAsync(locationToLoad, LoadSceneMode.Additive).completed += operation =>
       {
           Vector3 starPosition = gameObject.Find("playerstart").transform.position;

           Instantiate(playerAndCameraPrefeb, starPosition, Quaternion.identity);
       };
    }

   
}
