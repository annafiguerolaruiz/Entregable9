using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI level;
    public static GameManager sharedInstance;

    public TextMeshProUGUI username;

    public TextMeshProUGUI powerUpText;

    public AudioSource Musica;

    public TextMeshProUGUI ContadorAnterior;

    public TextMeshProUGUI ContadorActual;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        
        ApplyUserOptions();
    }

    public void ApplyUserOptions()
    {

        username.text = PersistenciaDeDatos.sharedInstance.username;
        level.text = PersistenciaDeDatos.sharedInstance.level.ToString();
        powerUpText.text = PersistenciaDeDatos.sharedInstance.powerUp.ToString();
        CheckMusic();
        ContadorActual.text = PersistenciaDeDatos.sharedInstance.ContadorEscenasActual.ToString();
        ContadorAnterior.text = PersistenciaDeDatos.sharedInstance.ContadorAnteriorEscenas.ToString();

    }
    public void CheckMusic()
    {
        if (PersistenciaDeDatos.sharedInstance.CheckVolumen == 0)
        {
            Musica.Pause();
        }
        else
        {
            Musica.Play();
        }
    }
}
