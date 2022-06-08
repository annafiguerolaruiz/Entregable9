using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenciaDeDatos : MonoBehaviour
{
    public int level;

    // Instancia compartida
    public static PersistenciaDeDatos sharedInstance;
    public string username;

    public float powerUp;


    private void Awake()
    {
        // Si la instancia no existe
        if (sharedInstance == null)
        {
            sharedInstance = this;
            // No desapareece entre escenas
            DontDestroyOnLoad(sharedInstance);
        }
        else
        {
            // Destruimos copia
            Destroy(this);
        }
    }
    public void SaveForFutureGames()
    {
        // Nivel
        PlayerPrefs.SetInt("LEVEL", level);

        // Nombre de usuario
        PlayerPrefs.SetString("USERNAME", username);

        //Guardamos la variable float
        PlayerPrefs.SetFloat("PowerUp", powerUp);


    }

}
