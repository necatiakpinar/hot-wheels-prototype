using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using Cinemachine;


[System.Serializable]
public struct SLayers
{
    public int Player;
    public int Obstacle;
};
public class CWorld : MonoBehaviour
{
    public CControllerPlayer Player;
    public GameObject PF_ExplosionParticle;
    public ParticleSystem InGame_CelebrationParticle;

    [Header("Managers")]
    public CManagerLevel LevelManager;

    public SLayers Layers;

    public static CWorld Main;
    private void Awake()
    {
        Main = this;

        this.Layers.Player = LayerMask.NameToLayer("Player");
        this.Layers.Obstacle = LayerMask.NameToLayer("Obstacle");
    }
    public void DestroyLastLevel()
    {
        this.LevelManager.Restart();
    }
    public void LevelWon()
    {
        if(this.Player == null) return;

        InGame_CelebrationParticle.Play();

        this.LevelManager.LoadNextLevel();
    }
    public void LevelLost()
    {
        if(this.Player == null) return;
        
        ParticleSystem explosionParticle = GameObject.Instantiate(this.PF_ExplosionParticle, this.Player.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        explosionParticle.Play();
        this.Player.gameObject.SetActive(false);
        DestroyLastLevel();
    }
    
}
