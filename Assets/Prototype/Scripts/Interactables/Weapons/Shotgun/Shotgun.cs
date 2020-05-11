using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shotgun : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Transform projectile;

    [SerializeField]
    private List<Transform> exit;

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

        if (Input.GetMouseButtonDown(0))
        {
            if (equip.GetWeapon().ammo > 0)
            {
                if (gameManager.gameState == 0)
                {
                    if (Time.time > setDelay)
                    {
                        playAnimation = true;

                        audioSource.Play();

                        for (int i = 0; i < exit.Count; ++i)
                        {
                            Instantiate(projectile, exit[i].position, exit[i].rotation);

                            if (shootRay)
                            {
                                Debug.DrawLine(exit[i].position, exit[i].forward * maxRayDistance, Color.green);

                                if (Physics.Raycast(exit[i].position, exit[i].forward, out hit, maxRayDistance))
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

                        equip.GetWeapon().ammo--;

                        ammoCounter.text = "Ammo: " + equip.GetWeapon().ammo.ToString();
                    }
                }
            }
        }
    }
}
