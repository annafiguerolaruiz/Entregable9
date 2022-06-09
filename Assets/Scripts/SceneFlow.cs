using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour
{
    
    
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        PersistenciaDeDatos.sharedInstance.ContadorEscenasActual++;
  
    }
    public void Exit()
    {

        PersistenciaDeDatos.sharedInstance.ContadorAnteriorEscenas = PersistenciaDeDatos.sharedInstance.ContadorEscenasActual;
        PersistenciaDeDatos.sharedInstance.SaveForFutureGames();
        UnityEditor.EditorApplication.isPlaying = false;

    }
      

}
