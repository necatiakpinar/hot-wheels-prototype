using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CControllerPlayer : MonoBehaviour
{
    [Header("Attributes")]
    public float NormalSpeed;
    public float BoostMultiplier;
    public Vector3 LocationOffset;
    public float StartDistance;
    public float EndDistance;

    [SerializeField] private float Speed;

    [Header("Objects")]
    [SerializeField] private PathCreator PathCreator;

    [Header("Watch")]
    [SerializeField] private bool BlockInput;
    [SerializeField] private bool IsBoosted;
    [SerializeField] private bool IsPathEnded;
    [SerializeField] private float TravelledDistance;


    private CAnimator Animator;
    private CControllerMaterial MaterialController;
    
    private void Awake()
    {
        Animator = GetComponentInChildren<CAnimator>();
        MaterialController = GetComponentInChildren<CControllerMaterial>();
    }
    private void Start()
    {
        this.Animator.SetBool("IsBoosted", IsBoosted);
        this.TravelledDistance = StartDistance;
        this.BlockInput = false;
        this.Speed = this.NormalSpeed;
        this.transform.SetPositionAndRotation(this.PathCreator.path.GetPoint(0) + LocationOffset, this.PathCreator.path.GetRotationAtDistance(0));
    }
    private void Update()
    {
        if(this.BlockInput) return; 

        if(Input.GetMouseButtonDown(0))
        {
            this.Speed = this.NormalSpeed * this.BoostMultiplier;
            this.Animator.SetBool("IsBoosted", true);
        } 
        if(Input.GetMouseButtonUp(0)) 
        {
            this.Speed = this.NormalSpeed;
            this.Animator.SetBool("IsBoosted", false);
        }

        this.TravelledDistance += this.Speed * Time.deltaTime;
        this.transform.position = PathCreator.path.GetPointAtDistance(this.TravelledDistance) + LocationOffset;
        this.transform.rotation = this.PathCreator.path.GetRotationAtDistance(this.TravelledDistance);

        IsPathEnded = (this.TravelledDistance >= this.PathCreator.path.length - EndDistance);
        if(IsPathEnded)
        {
            CWorld.Main.LevelWon();
            this.BlockInput = true;
        }
    }
    public void Stop()
    {
        this.BlockInput = true;
    }

}
