using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimator : MonoBehaviour
{
    [SerializeField] private CControllerPlayer Controller;
    [SerializeField] private Animator Animator;
    private void Awake()
    {
        Controller = GetComponentInParent<CControllerPlayer>();
        Animator = GetComponent<Animator>();

        transform.rotation = new Quaternion(0.5f,-0.5f,-0.5f,0.5f);
    }
    private void OnTriggerEnter(Collider P_Collider)
    {
        Debug.Log(P_Collider.gameObject.layer);
        if(Controller == null) return;
        
        if(P_Collider.gameObject.layer == CWorld.Main.Layers.Obstacle)
        {
            Controller.Stop();
            CWorld.Main.LevelLost();
        }  
    }
    public void AnimationEvent_Death()
    {
        // CWorld.Main.LevelLost();
    }
    public void SetTrigger(string P_Name) => Animator.SetTrigger(P_Name);
    public void SetBool(string P_Name, bool P_State) => Animator.SetBool(P_Name, P_State);
    public void SetInteger(string P_Name, int P_Value) => Animator.SetInteger(P_Name, P_Value);
}
