using UnityEngine;

public class Glock : MonoBehaviour {

    public bool showDebug;

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 4f;
    public int maxAmmo = 15;
    public float reloadingTime = 3.5f;
    public int critchance = 0;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject impactEffectGround;
    public GameObject impactEffectTree;
    public GameObject rotationParent;

    [System.NonSerialized]
    public bool canShoot = true;
    [System.NonSerialized]
    public bool isReloading = false;
    [System.NonSerialized]
    public int currentAmmo;
    [System.NonSerialized]
    public Reloading reloading;
    [System.NonSerialized]
    public Ammo ammoScript;
    [System.NonSerialized]
    public bool hasSilencer = false;
    [System.NonSerialized]
    public AudioManager audioManager;

    private float nextTimeToFire = 0f;
    private bool wasCritHit = false;

    void Start()
    {
        reloading = cam.gameObject.GetComponent<Reloading>();
        ammoScript = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Ammo>();
        audioManager = GameObject.Find("GameManager").GetComponent<GameManager>().audioManager;
        currentAmmo = maxAmmo;
        ammoScript.SetAmmoValue(currentAmmo);
    }

    // Update is called once per frame
    void Update ()
    {
        int ammoOld = currentAmmo;
        if (canShoot && !isReloading && currentAmmo != 0)
        {
            if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;

                Shoot();
            }
        }
        if((currentAmmo == 0 || Input.GetKeyDown(KeyCode.R)) && !isReloading && currentAmmo != maxAmmo)
        {
            reloading.SetReloadingTime(ReloadingTimeFromSecondsToFloatValue());
            reloading.PlayAnim("reload", true);
            audioManager.Play("Reloading");
        }

        if(ammoOld != currentAmmo) ammoScript.SetAmmoValue(currentAmmo);

        
	}

    void Shoot()
    {
        muzzleFlash.Play();

        wasCritHit = CheckForCrit(critchance);

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (showDebug) Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (hit.transform.tag == "ZombieCharacter")
            {
                GameObject GO = Instantiate(impactEffect, hit.point, Quaternion.identity);
                Destroy(GO, 2f);
            }
            else if(hit.transform.tag == "Ground")
            {
                GameObject GO = Instantiate(impactEffectGround, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(GO, 2f);
            }
            else if(hit.transform.tag == "Tree")
            {
                GameObject GO = Instantiate(impactEffectTree, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(GO, 2f);
            }
            else if(hit.transform.tag == "Zombie")
            {
                GameObject GO = Instantiate(impactEffect, hit.point, Quaternion.identity);
                Destroy(GO, 2f);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (target != null)
            {
                if(wasCritHit)
                    target.TakeDamage(damage * 2);
                else
                    target.TakeDamage(damage);
            }
        }
        if(currentAmmo <= 0)
        {
            currentAmmo = 0;

        }
        currentAmmo--;

        if (wasCritHit)
            audioManager.Play("Crit");
        else
            audioManager.Play("Shot");

        CheckForZombies();
    }

    void CheckForZombies()
    {
        int noiseFromShooting = Mathf.RoundToInt(transform.root.GetComponent<Player>().gm.transform.GetComponent<ZombieManager>().wakeUpRadius);
        if (!hasSilencer)
        {
            noiseFromShooting *= 2;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, noiseFromShooting);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Zombie")
            {
                collider.transform.GetComponent<Unit>().hasHeardSomething = true;
            }
        }
    }

    bool CheckForCrit (int chance)
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
    
    public void RefillAmmo()
    {
        currentAmmo = maxAmmo;
    }

    float ReloadingTimeFromSecondsToFloatValue()
    {
        float floatValue = 1 / reloadingTime;
        return floatValue;
    }
}
