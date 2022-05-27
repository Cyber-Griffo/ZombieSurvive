using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    [Header("Health")]
    public float maxHealthEasy = 50f;
    public float maxHealthMedium = 75f;
    public float maxHealthHard = 100f;

    [Header("Damage")]
    public float damageEasy = 5f;
    public float damageMedium = 8f;
    public float damageHard = 10f;

    [Header("AttackSpeed")]
    public float zombieAttackSpeedEasy = 2f;
    public float zombieAttackSpeedMedium = 3f;
    public float zombieAttackSpeedHard = 4f;

    public float speed = 20f;
    public float distanceFromTargetToStop = 0.1f;
    public float zombieAttackRange = 4f;


    [System.NonSerialized]
    public bool hasTakenDamage = false;
    [System.NonSerialized]
    public bool active = false;
    [System.NonSerialized]
    public float zombieAttackSpeed;
    [System.NonSerialized]
    public float damage;
    [System.NonSerialized]
    public float maxHealth;

    private GameObject groundLevel;
    private Unit zombie;

    private Target target;
    private HealthBar hb;

    private float nextTimeToAttack = 0f;

    void Awake()
    {
        SetDifficultyValues();
    }

    public void SetUpValues()
    {
        GetComponents();
        SetValues();

        hb.SetMaxHealth(Mathf.RoundToInt(target.max));
        hb.SetText(Mathf.RoundToInt(target.health), Mathf.RoundToInt(target.max));

        groundLevel = GameObject.FindGameObjectWithTag("SpawnModule");
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (transform.position.y + transform.localScale.y / 2 - .5f < groundLevel.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, groundLevel.transform.position.y + transform.position.y / 2 + .5f, transform.position.z);
            }

            CheckForPlayer();

            hb.SetHealth(Mathf.RoundToInt(target.health));
            hb.SetText(Mathf.RoundToInt(target.health), Mathf.RoundToInt(target.max));

            SetValues();
        }
    }

    void CheckForPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, zombieAttackRange);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Player" && Time.time >= nextTimeToAttack)
            {
                nextTimeToAttack = Time.time + 1 / zombieAttackSpeed;
                collider.transform.GetComponent<Player>().TakeDamage(damage);
                //Play Sound
                GetComponent<ZombieAudioManager>().Play("Attack01");
            }
        }
    }

    void SetZombieValuesToUnitScript()
    {
        zombie.distanceFromTargetToStop = distanceFromTargetToStop;
        zombie.speed = speed;
    }

    void GetComponents()
    {
        hb = transform.Find("Canvas").Find("Healthbar").GetComponent<HealthBar>();
        target = GetComponent<Target>();
        zombie = GetComponent<Unit>();
    }

    void SetZombieValuesToTargetScript()
    {
        target.maxHealth = maxHealth;
    }

    void SetValues()
    {
        SetZombieValuesToUnitScript();
        SetZombieValuesToTargetScript();
    }

    void SetDifficultyValues()
    {
        switch (SaveSystem.LoadDataDifficultySave().difficultySave)
        {
            case 0:

                zombieAttackSpeed = zombieAttackSpeedEasy;
                damage = damageEasy;
                maxHealth = maxHealthEasy;

                break;
            case 1:

                zombieAttackSpeed = zombieAttackSpeedMedium;
                damage = damageMedium;
                maxHealth = maxHealthMedium;

                break;
            case 2:

                zombieAttackSpeed = zombieAttackSpeedHard;
                damage = damageHard;
                maxHealth = maxHealthHard;

                break;
        }
    }
}
