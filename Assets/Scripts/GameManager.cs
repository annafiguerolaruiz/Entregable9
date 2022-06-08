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
    }
}
