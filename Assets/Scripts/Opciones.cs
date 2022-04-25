using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Opciones : MonoBehaviour
{
    public GameObject PanelOpciones;

    private AudioSource Audio;
    private float VolumenMusica = 1f;

    public TextMeshProUGUI Dificultad;

    public string NombreDeUsuario;
    public string SaveName;
    public TextMeshProUGUI ImputText;
    public TextMeshProUGUI LoadedName;


    // Start is called before the first frame update
    void Start()
    {
        PanelOpciones.SetActive(false);

        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Audio.volume = VolumenMusica;
        NombreDeUsuario = PlayerPrefs.GetString("name", "none");
        LoadedName.text = NombreDeUsuario;
    }
    //Botones panel opciones
    public void AbrirOpciones()
    {
        PanelOpciones.SetActive(true);
    }
    public void CerrarOpciones()
    {
        PanelOpciones.SetActive(false);
    }
    //Cambiamos el volumen (medidor)
    public void UpdateVolume(float volume)
    {
        VolumenMusica = volume;
    }
    //Cuando pulsamos las opciones de dificultad, un texto nos indica que dificultad hemos elegido
    public void Alta()
    {
        Dificultad.text = "ALTA";
    }
    public void Media()
    {
        Dificultad.text = "MEDIA";
    }
    public void Baja()
    {
        Dificultad.text = "BAJA";
    }
    //Cambiar nombre de usuario
    public void SetName()
    {
        SaveName = ImputText.text;
        PlayerPrefs.SetString("name", SaveName);

    }

}
