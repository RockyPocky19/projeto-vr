using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class Menuprincipal : MonoBehaviour

{


    [SerializeField] private string nomeDoLevelDejogo;
    [SerializeField] private GameObject painelmenuprincipal;
    [SerializeField] private GameObject painelopcoes;


    public void jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDejogo);

    }


    public void AbrirOpcoes()
    {

        painelmenuprincipal.SetActive(false);
        painelopcoes.SetActive(true);
    }

    public void fecharOpcoes()
    {
        painelopcoes.SetActive(false);
        painelmenuprincipal.SetActive(true);


    }

    public void sairjogo()

    {
        Debug.Log("sairjogo do jogo");
        Application.Quit();
    }
}
