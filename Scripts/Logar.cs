using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Logar : MonoBehaviour {

    private const string Login = "gustavo";
    private const string Password = "guga2002";

    [SerializeField]
    private InputField usuarioField = null;
    [SerializeField]
    private InputField senhaField = null;
    [SerializeField]
    private Text feed = null;
    [SerializeField]
    private Toggle rememberData = null;
    [SerializeField]
    private GameObject load = null;
    
    public string ProximaCena;
    void Start() 
    {
        load.SetActive(false);
        if(PlayerPrefs.HasKey("lembra") && PlayerPrefs.GetInt("lembra") == 1){
            usuarioField.text = PlayerPrefs.GetString("remeberUser");
            senhaField.text = PlayerPrefs.GetString("remeberSenha");
        }
    }
    
    public void FazerOLogin() 
    {
       string usuario = usuarioField.text;
       string senha = senhaField.text;

       if(rememberData.isOn){
           PlayerPrefs.SetInt("lembra", 1);
           PlayerPrefs.SetString("remeberUser", usuario);
           PlayerPrefs.SetString("remeberSenha", senha);
       }

       if(usuario == Login && senha == Password){
           load.SetActive(true);
           feed.CrossFadeAlpha(100f, 0f, false);
           feed.color = Color.green;
           feed.text = "Conectando...";
           StartCoroutine(Carregando());
       }
       else{
           load.SetActive(false);
           feed.CrossFadeAlpha(100f, 0f, false);
           feed.color = Color.red;
           feed.text = "Usuario ou senha incorreto";
           feed.CrossFadeAlpha(0f, 2f, false);
           usuarioField.text = "";
           senhaField.text = "";
           usuarioField.Select();
       }
    }

    public void Sair()
    {
        Application.Quit();
    }
   

   IEnumerator Carregando()
   {
       yield return new WaitForSeconds(5);
       SceneManager.LoadScene(ProximaCena);
   }
}