using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBomb : MonoBehaviour
{

    [Header("Health")]
    public float maxCapacityEasy = 50f;
    public float maxCapacityMedium = 75f;
    public float maxCapacityHard = 100f;

    [Header("Damage")]
    public float waterDamageEasy = 5f;
    public float waterDamageMedium = 8f;
    public float waterDamageHard = 10f;

    [Header("AttackSpeed")]
    public float waterBombAttackSpeedEasy = 2f;
    public float waterBombAttackSpeedMedium = 3f;
    public float waterBombAttackSpeedHard = 4f;

    public float speed = 20f;
    public float distanceFromTargetToStop = 0.1f;
    public float waterBombAttackRange = 4f;

    [Header("Materials")]
    public Material lowCapa;
    public Material mediumCapa;
    public Material highCapa;

    [System.NonSerialized]
    public bool hasTakenDamage = false;
    [System.NonSerialized]
    public bool active = false;
    [System.NonSerialized]
    public float waterBombAttackSpeed;
    [System.NonSerialized]
    public float waterDamage;
    [System.NonSerialized]
    public float maxCapacity;
    [System.NonSerialized]
    public bool spawnComplete = false;

    private GameObject groundLevel;
    private Unit waterBomb;

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

        hb.SetText(0, Mathf.RoundToInt(target.maxCapa));
        hb.SetMaxCapacity(Mathf.RoundToInt(target.maxCapa));

        groundLevel = GameObject.FindGameObjectWithTag("SpawnModule");
    }

    // Update is called once per frame
    void Update()
    {

        if (active)
        {
            if (transform.position.y + transform.localScale.y / 2  - .5f < groundLevel.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, groundLevel.transform.position.y + transform.position.y / 2 + .5f, transform.position.z);
            }

            CheckForPlayer();

            ColourChange();

            hb.SetCapacity(Mathf.RoundToInt(target.capa));
            hb.SetText(Mathf.RoundToInt(target.capa), Mathf.RoundToInt(target.maxCapa));

            SetValues();
        }
    }

    void ColourChange()
    {
        float percent = target.capa / target.maxCapa;

        if(percent >= 0.66f)
        {
            gameObject.transform.Find("Character").GetComponent<MeshRenderer>().material = highCapa;
        }
        else if(percent < 0.66f && percent >= 0.33f)
        {
            gameObject.transform.Find("Character").GetComponent<MeshRenderer>().material = mediumCapa;
        }
        else
        {
            gameObject.transform.Find("Character").GetComponent<MeshRenderer>().material = lowCapa;
        }
    }

    void CheckForPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, waterBombAttackRange);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Player" && Time.time >= nextTimeToAttack)
            {
                nextTimeToAttack = Time.time + 1 / waterBombAttackSpeed;
                collider.transform.GetComponent<Player>().FillWater(waterDamage);
                //Play Sound
                GetComponent<WaterBombAudioManager>().Play("Attack01");
            }
        }
    }

    void SetWaterBombValuesToUnitScript()
    {
        waterBomb.distanceFromTargetToStop = distanceFromTargetToStop;
        waterBomb.speed = speed;
    }

    void GetComponents()
    {
        hb = transform.Find("Canvas").Find("Healthbar").GetComponent<HealthBar>();
        target = GetComponent<Target>();
        waterBomb = GetComponent<Unit>();
    }

    void SetWaterBombValuesToTargetScript()
    {
        target.maxCapacity = maxCapacity;
    }

    void SetValues()
    {
        SetWaterBombValuesToUnitScript();
        SetWaterBombValuesToTargetScript();
    }

    void SetDifficultyValues()
    {
        switch (SaveSystem.LoadDataDifficultySave().difficultySave)
        {
            case 0:

                waterBombAttackSpeed = waterBombAttackSpeedEasy;
                waterDamage = waterDamageEasy;
                maxCapacity = maxCapacityEasy;

                break;
            case 1:

                waterBombAttackSpeed = waterBombAttackSpeedMedium;
                waterDamage = waterDamageMedium;
                maxCapacity = maxCapacityMedium;

                break;
            case 2:

                waterBombAttackSpeed = waterBombAttackSpeedHard;
                waterDamage = waterDamageHard;
                maxCapacity = maxCapacityHard;

                break;
        }
    }
}
