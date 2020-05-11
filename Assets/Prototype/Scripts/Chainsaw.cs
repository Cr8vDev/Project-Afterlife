using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chainsaw : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Transform exit;

    [SerializeField]
    private float delay;
    private float setDelay = 0.0f;

    private Equip equip;

    private GameManager gameManager;

    private MuzzleAnimation muzzleAnimation;

    private bool playAnimation = false;

    private SpriteRenderer spriteRenderer;

    private RaycastHit hit;

    [SerializeField]
    private int damage;

    [SerializeField]
    private bool shootRay;
    [SerializeField]
    private float maxRayDistance;



    public void SetEquip(Equip setEquip, TextMeshProUGUI ammoC, GameManager gameM, MuzzleAnimation animation)
    {
        equip = setEquip;
        ammoC.text = "Ammo: Unlimited";
        gameManager = gameM;
        muzzleAnimation = animation;
        spriteRenderer = animation.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (gameManager.gameState == 0)
            {
                if (Time.time > setDelay)
                {
                    playAnimation = true;

                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                    }

                    if (shootRay)
                    {
                        if (Physics.Raycast(exit.position, exit.forward, out hit, maxRayDistance))
                        {
                            if (hit.collider.tag[0] == '7')
                            {
                                hit.collider.GetComponentInChildren<ParticleSystem>().Play();

                                hit.collider.GetComponent<Health>().DealDamage(damage);
                            }
                        }
                    }

                    setDelay = delay + Time.time;
                }
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
