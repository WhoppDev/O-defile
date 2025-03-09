using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public float volume;
    public AudioSource audioSource;
    public float velocidadeAumentoVolume;
    public float velocidadeDiminuirVolume;
    public float fimDoDesfile; //variavel que define depois de quantos metros o volume da musica vai diminuir, indicando o fim do desfile

    [SerializeField] GameManager gameManager;
    [SerializeField] MoverCarro moverCarro;

    void Update()
    {
        
        audioSource.volume = volume;

        if(gameManager.gameStart && volume < 1 && moverCarro.distanceTraveled < fimDoDesfile) {

            volume += Time.deltaTime * velocidadeAumentoVolume;

        }

        if(volume > 1) { volume = 1; }

        if(volume > 0 && moverCarro.distanceTraveled >= fimDoDesfile) {

            volume -= Time.deltaTime * velocidadeDiminuirVolume;

        }

        if(volume < 0) { volume = 0; }

        if(volume == 0) {

            gameManager.gameStart = false;
            SceneManager.LoadScene(0);

        }
    }
}
