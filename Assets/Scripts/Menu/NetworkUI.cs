using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkUI : NetworkBehaviour
{
   

    public static NetworkUI instance;

    private void Awake()
    {
        if (NetworkUI.instance == null)
        {
            NetworkUI.instance = this;
            DontDestroyOnLoad(NetworkUI.instance);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void selectionScene(int selectionOrden)
    {
        switch (selectionOrden)
        {
            case 1: 
                
                ChangeScene("GameSinglePlayer", 1); 
         
            break;

            case 2: 
                
               ChangeScene("Game", 2);

            
            break;

            case 3: 
                
                ChangeScene("Game", 3);


            
            break;

            case 4:

                ExitGame();

            break;

        }
    }

    public void ChangeScene(string sceneName, int selection)
    {
        StartCoroutine(LoadSceneAsync(sceneName, selection));
    }

    private IEnumerator LoadSceneAsync(string sceneName, int selection)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // No permitir el cambio de escena hasta que se haya cargado por completo
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // Verificar si se ha cargado el 90% de la escena
            if (operation.progress >= 0.9f)
            {
                // Permitir el cambio de escena
                operation.allowSceneActivation = true;
            }
            //DOTween.KillAll();
            yield return null;
           
        }

        switch (selection)
        {
            case 2:
                NetworkManager.Singleton.StartClient();
                break;

            case 3:
                NetworkManager.Singleton.StartHost();
                break;
        }

       



    }

   

    public void ExitGame()
    {
        Application.Quit();
    }
}
