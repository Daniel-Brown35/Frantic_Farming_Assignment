using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject grassProjectile;
    public GameObject grainProjectile;
    public GameObject appleProjectile;

    public float shootForce;

    public float timeBetweenShooting;
    public float reloadTime;
    public float timeBetweenShots;

    public int magazineSize;
    public bool allowHoldFire;
    int grassAmmoLeft;
    int grainAmmoLeft;
    int appleAmmoLeft;
    int ammoType;

    bool shooting;
    bool readyToShoot;
    bool reloading;

    public Camera playerCamera;
    public Transform projectileSpawnPoint;

    public bool playerSucking;

    public Slider grassSlider;
    public Slider grainSlider;
    public Slider appleSlider;
    public TMP_Text grassText;
    public TMP_Text grainText;
    public TMP_Text appleText;

    private BoxCollider suckableArea;

    public AudioSource audioSource;
    public AudioClip gunSound;

    private void Awake()
    {
        grassAmmoLeft = magazineSize;
        grassSlider.maxValue = magazineSize;
        grassSlider.value = grassAmmoLeft;
        grassText.text = grassAmmoLeft.ToString();

        grainAmmoLeft = magazineSize;
        grainSlider.maxValue = magazineSize;
        grainSlider.value = grainAmmoLeft;
        grainText.text = grainAmmoLeft.ToString();

        appleAmmoLeft = magazineSize;
        appleSlider.maxValue = magazineSize;
        appleSlider.value = appleAmmoLeft;
        appleText.text = appleAmmoLeft.ToString();

        ammoType = 1;
        readyToShoot = true;
        playerSucking = false;

        suckableArea = GameObject.Find("SuckableArea").GetComponent<BoxCollider>();
        suckableArea.enabled = false;
    }

    private void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ammoType = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ammoType = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ammoType = 3;
        }

        if (allowHoldFire == true)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            suckableArea.enabled = true;
            playerSucking = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            suckableArea.enabled = false;
            playerSucking = false;
        }


        //if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && reloading == false)
        //{
        //    Reload();
        //}
        //if (readyToShoot == true && shooting == true && reloading == false && bulletsLeft <= 0)
        //{
        //    Reload();
        //}

        switch (ammoType)
        {
            case 1:
                if (readyToShoot && shooting && !reloading && grassAmmoLeft > 0)
                {
                    ShootGrass();
                }
                break;
            case 2:
                if (readyToShoot && shooting && !reloading && grainAmmoLeft > 0)
                {
                    ShootGrain();
                }
                break;
            case 3:
                if (readyToShoot && shooting && !reloading && appleAmmoLeft > 0)
                {
                    ShootApple();
                }
                break;
        }
    }

    private void ShootGrass()
    {
        readyToShoot = false;

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 projectileDirection = targetPoint - projectileSpawnPoint.position;


        GameObject currentProjectile = Instantiate(grassProjectile, projectileSpawnPoint.position, Quaternion.identity);

        currentProjectile.transform.forward = projectileDirection.normalized;

        currentProjectile.GetComponent<Rigidbody>().AddForce(projectileDirection.normalized * shootForce, ForceMode.Impulse);

        grassAmmoLeft--;
        audioSource.PlayOneShot(gunSound);
        grassSlider.value = grassAmmoLeft;
        grassText.text = grassAmmoLeft.ToString();

        Invoke("ResetShot", timeBetweenShooting);
    }
    private void ShootGrain()
    {
        readyToShoot = false;

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 projectileDirection = targetPoint - projectileSpawnPoint.position;


        GameObject currentProjectile = Instantiate(grainProjectile, projectileSpawnPoint.position, Quaternion.identity);

        currentProjectile.transform.forward = projectileDirection.normalized;

        currentProjectile.GetComponent<Rigidbody>().AddForce(projectileDirection.normalized * shootForce, ForceMode.Impulse);

        grainAmmoLeft--;
        audioSource.PlayOneShot(gunSound);
        grainSlider.value = grainAmmoLeft;
        grainText.text = grainAmmoLeft.ToString();

        Invoke("ResetShot", timeBetweenShooting);
    }

    private void ShootApple()
    {  
            readyToShoot = false;

            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(75);
            }

            Vector3 projectileDirection = targetPoint - projectileSpawnPoint.position;


            GameObject currentProjectile = Instantiate(appleProjectile, projectileSpawnPoint.position, Quaternion.identity);

            currentProjectile.transform.forward = projectileDirection.normalized;

            currentProjectile.GetComponent<Rigidbody>().AddForce(projectileDirection.normalized * shootForce, ForceMode.Impulse);

            appleAmmoLeft--;
            audioSource.PlayOneShot(gunSound);
            appleSlider.value = appleAmmoLeft;
            appleText.text = appleAmmoLeft.ToString();

            Invoke("ResetShot", timeBetweenShooting);       
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    public void HarvestedGrass()
    {
        grassAmmoLeft++;
        if (grassAmmoLeft > magazineSize)
        {
            grassAmmoLeft = magazineSize;
        }
        grassSlider.value = grassAmmoLeft;
        grassText.text = grassAmmoLeft.ToString();
    }

    public void HarvestedGrain()
    {
        grainAmmoLeft++;
        if (grainAmmoLeft > magazineSize)
        {
            grainAmmoLeft = magazineSize;
        }
        grainSlider.value = grainAmmoLeft;
        grainText.text = grainAmmoLeft.ToString();
    }

    public void HarvestedApple()
    {
        appleAmmoLeft++;
        if (appleAmmoLeft > magazineSize)
        {
            appleAmmoLeft = magazineSize;
        }
        appleSlider.value = appleAmmoLeft;
        appleText.text = appleAmmoLeft.ToString();
    }

    //private void Reload()
    //{
    //    reloading = true;
    //    Invoke("ReloadFinished", reloadTime);
    //}

    //private void ReloadFinished()
    //{
    //    bulletsLeft = magazineSize;
    //    reloading = false;
    //}
}
