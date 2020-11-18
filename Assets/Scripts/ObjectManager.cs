using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public string characterName, jenisAnimal;
    public int numberFoodChain = 0;
    // public Animator animator;
    Animation anim;
    public AnimationClip attack, attacked;
    Vector3 scaleCurent;
    

    private void Awake()
    {
        anim = GetComponent<Animation>();
        scaleCurent = transform.localScale;
    }

    private void Start()
    {
        characterName = gameObject.name;
    }

    public void Attack()
    {
       // animator.SetBool("Attack", true);
    }

    public void Attacked()
    {
       // animator.SetBool("Attacked", true);
    }

    public void BackToIdle()
    {
        // animator.SetBool("Attack", false);
        // animator.SetBool("Attacked", false);
        transform.localScale = scaleCurent;
    }
}
