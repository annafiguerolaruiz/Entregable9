using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public int level;
    public int minLevel = 1;
    public int maxLevel = 10;
    public TextMeshProUGUI levelText;
    public TMP_InputField username;

    public TextMeshProUGUI powerUpText;
    public float randomNum;

    public Toggle Check;
    public bool ValorCheck;

    public TextMeshProUGUI ContadorAnterior;

    public TextMeshProUGUI ContadorActual;

    // Start is called before the first frame update
    void Start()
    {
        level = int.Parse(levelText.text);
        LoadUserOptions();
    }

    // Update is called once per frame
    void Update()
    {
        SaveCheck();
    }
    public void SaveUserOptions()
    {
        PersistenciaDeDatos.sharedInstance.level = level;
        PersistenciaDeDatos.sharedInstance.username = username.text;
       
        // Persistencia de datos entre partidas
        PersistenciaDeDatos.sharedInstance.powerUp = randomNum;
        PersistenciaDeDatos.sharedInstance.SaveForFutureGames();
  
    }
    public void LoadUserOptions()
    {
        if (PlayerPrefs.HasKey("USERNAME"))
        {
            level = PlayerPrefs.GetInt("LEVEL");
            UpdateLevel();

            username.text = PlayerPrefs.GetString("USERNAME");


            powerUpText.text = PlayerPrefs.GetFloat("PowerUp").ToString();

            Check.GetComponent<Toggle>().isOn = IntToBool(PlayerPrefs.GetInt("CHECK"));

            ContadorAnterior.text = PlayerPrefs.GetInt("Contador").ToString();

            ContadorActual.text = PersistenciaDeDatos.sharedInstance.ContadorEscenasActual.ToString();

            PersistenciaDeDatos.sharedInstance.ContadorAnteriorEscenas = PlayerPrefs.GetInt("Contador");
        }
      
    }
    public bool IntToBool(int Valor)
    {
        if (Valor == 0)
        {
            return false;
            }
        else
        {
            return true;
        }
    }
    #region Level Settings

    public void PlusLevel()
    {
        level++;
        level = Mathf.Clamp(level, minLevel, maxLevel);
        UpdateLevel();
    }

    public void MinusLevel()
    {
        level--;
        level = Mathf.Clamp(level, minLevel, maxLevel);
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        levelText.text = level.ToString();
    }
    #endregion

    public void RandomPowerUp()
    {
        randomNum = Random.Range(1.0f, 10.0f);
        powerUpText.text = randomNum.ToString();

    }

    public void SaveCheck()
    {
        ValorCheck = Check.GetComponent<Toggle>().isOn;
        if (ValorCheck)
        {
            PersistenciaDeDatos.sharedInstance.CheckVolumen = 1;

        }
        else
        {
            PersistenciaDeDatos.sharedInstance.CheckVolumen = 0;
        }
     

    }
}
