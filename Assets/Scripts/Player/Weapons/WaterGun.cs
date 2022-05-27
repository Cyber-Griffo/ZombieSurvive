using UnityEngine;

public class WaterGun : MonoBehaviour
{

    public bool showDebug;

    public float waterFill = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 4f;
    public int maxTank = 15;
    public float refillingTime = 3.5f;
    public int doubleFillChance = 0;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffectWaterBomb;
    public GameObject impactEffectGround;
    public GameObject impactEffectPalmTree;
    public GameObject impactEffectSonnenSchirm;
    public GameObject rotationParent;

    [System.NonSerialized]
    public bool canShoot = true;
    [System.NonSerialized]
    public bool isRefilling = false;
    [System.NonSerialized]
    public int currentTank;
    [System.NonSerialized]
    public Refilling refilling;
    [System.NonSerialized]
    public Tank tankScript;
    [System.NonSerialized]
    public AudioManager audioManager;

    private float nextTimeToFire = 0f;
    private bool wasDoubleFill = false;

    void Start()
    {
        refilling = cam.gameObject.GetComponent<Refilling>();
        tankScript = GameObject.FindGameObjectWithTag("Tank").GetComponent<Tank>();
        audioManager = GameObject.Find("GameManager").GetComponent<GameManager>().audioManager;
        currentTank = maxTank;
        tankScript.SetTankValue(currentTank);
    }

    // Update is called once per frame
    void Update()
    {
        int tankOld = currentTank;
        if (canShoot && !isRefilling && currentTank != 0)
        {
            if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;

                Shoot();
            }
        }
        if ((currentTank == 0 || Input.GetKeyDown(KeyCode.R)) && !isRefilling && currentTank != maxTank)
        {
            print(refillingTime);
            refilling.SetRefillingTime(ReloadingTimeFromSecondsToFloatValue());
            refilling.PlayAnim("refill", true);
            audioManager.Play("Refilling");
            refilling.UpdateUI_WaterGun();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        wasDoubleFill = CheckForDoubleFill(doubleFillChance);

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (showDebug) Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (hit.transform.tag == "WaterBombCharacter" || hit.transform.tag == "WaterBomb")
            {
                GameObject GO = Instantiate(impactEffectWaterBomb, hit.transform.position, Quaternion.identity);
                Destroy(GO, 2f);
            }
            else if (hit.transform.tag == "WaterBomb" || hit.transform.tag == "WaterBomb")
            {
                GameObject GO = Instantiate(impactEffectWaterBomb, hit.transform.position, Quaternion.identity);
                Destroy(GO, 2f);
            }
            else if(hit.transform.tag == "Ground")
            {
                GameObject GO = Instantiate(impactEffectGround, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(GO, 2f);
            }
            else if(hit.transform.tag == "PalmTree")
            {
                GameObject GO = Instantiate(impactEffectPalmTree, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(GO, 2f);
            }
            else if(hit.transform.tag == "SonnenSchirm")
            {
                GameObject GO = Instantiate(impactEffectSonnenSchirm, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(GO, 2f);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (target != null)
            {
                if (wasDoubleFill)
                    target.FillWater(waterFill * 2);
                else
                    target.FillWater(waterFill);
            }
        }

        if (currentTank <= 0)
        {
            currentTank = 0;

        }
        currentTank--;

        tankScript.SetTankValue(currentTank);

        if (wasDoubleFill)
            audioManager.Play("DoubleFill");
        else
            audioManager.Play("Shot_WaterGun");

        CheckForWaterBombs();
    }

    void CheckForWaterBombs()
    {
        int noiseFromShooting = Mathf.RoundToInt(transform.root.GetComponent<Player>().gm.transform.GetComponent<WaterBombManager>().startFollowingRadius);

        Collider[] colliders = Physics.OverlapSphere(transform.position, noiseFromShooting);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "WaterBomb")
            {
                collider.transform.GetComponent<Unit>().hasHeardSomething = true;
            }
        }
    }

    bool CheckForDoubleFill(int chance)
    {
        int random = Random.Range(0, 100);
        if (chance != 0 && (random >= 0 && random <= chance))
            return true;
        else
            return false;
    }

    public void ToggleCanShoot()
    {
        canShoot = !canShoot;
    }

    public void RefillTank()
    {
        currentTank = maxTank;
    }

    float ReloadingTimeFromSecondsToFloatValue()
    {
        float floatValue = 1 / refillingTime;
        return floatValue;
    }
}
