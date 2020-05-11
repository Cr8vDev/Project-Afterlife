using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Transform projectile;

    [SerializeField]
    private Transform exit;

    [SerializeField]
    private float delay;
    private float setDelay = 0.0f;

    private Equip equip;

    private TextMeshProUGUI ammoCounter;

    private GameManager gameManager;

    private MuzzleAnimation muzzleAnimation;

    private bool playAnimation = false;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float animationDelay;
    private float setAnimationDelay = 0.0f;
    private int muzzleIncrement = 0;



    public void SetEquip(Equip setEquip, TextMeshProUGUI ammoC, GameManager gameM, MuzzleAnimation animation)
    {
        equip = setEquip;
        ammoCounter = ammoC;
        gameManager = gameM;
        muzzleAnimation = animation;
        spriteRenderer = animation.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playAnimation)
        {
            if (Time.time > setAnimationDelay)
            {
                if (muzzleIncrement < muzzleAnimation.shootRight.Count)
                {
                    spriteRenderer.sprite = muzzleAnimation.shootRight[muzzleIncrement];
                    muzzleIncrement++;
                    setAnimationDelay = Time.time + animationDelay;
                }
                else
                {
                    playAnimation = false;
                    muzzleIncrement = 0;
                    spriteRenderer.sprite = null;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (equip.GetWeapon().ammo > 0)
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

                        Instantiate(projectile, exit.position, exit.rotation);

                        setDelay = delay + Time.time;

                        equip.GetWeapon().ammo--;

                        ammoCounter.text = "Ammo: " + equip.GetWeapon().ammo.ToString();
                    }
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
}
