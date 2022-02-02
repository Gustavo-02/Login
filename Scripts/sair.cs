using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class sair : MonoBehaviour
{
    
    public Button BotaoSair;
    public string VoltarCena;

    void Start()
    {
        BotaoSair.onClick = new Button.ButtonClickedEvent();
      
        BotaoSair.onClick.AddListener(() => Sair());
    }
    
    void Update() 
    {

    }
    
    private void Sair() 
    {
        SceneManager.LoadScene(VoltarCena);
    }
}
