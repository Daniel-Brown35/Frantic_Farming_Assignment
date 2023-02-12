using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

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
    public int grassAmmoLeft;
    public int grainAmmoLeft;
    public int appleAmmoLeft;
    int ammoType;

    bool shooting;
    public bool readyToShoot;
    bool reloading;

    public Camera playerCamera;
    public Transform projectileSpawnPoint;

    public bool playerSucking;

    public Slider grassSlider;
    public Slider grainSlider;
    public Slider appleSlider;
    public Image grassAmmoHolder;
    public Image grainAmmoHolder;
    public Image appleAmmoHolder;
    public Sprite selectedAmmoImage;
    public Sprite notSelectedAmmoImage;
    public TMP_Text grassText;
    public TMP_Text grainText;
    public TMP_Text appleText;

    private BoxCollider suckableArea;

    public AudioSource audioSource;
    public AudioClip gunSound;

    public GameObject gunBarrel001Low;
    public GameObject gunBarrel002Low;
    public GameObject gunPart001Low;
    public GameObject gunPart002Low;
    public GameObject handlePart001Low;
    public GameObject handlePart002Low;
    public GameObject handlePart003Low;
    public GameObject trigger001Low;
    public GameObject triggerGuard001Low;
    public GameObject tube001Low;
    public GameObject tube002Low;
    public GameObject tube003Low;
    public GameObject tube004Low;
    public GameObject tubePart001Low;
    public GameObject tubePart002Low;
    public GameObject tubePart003Low;
    public GameObject tubePart004Low;
    public GameObject tubePart005Low;
    public GameObject tubePart006Low;
    public GameObject tubePart007Low;
    public GameObject tubePart008Low;
    public Material gunGrassMaterial;
    public Material gunGrainMaterial;
    public Material gunAppleMaterial;

    public AudioClip suckedInSound;
    public AudioSource suctionSoundSystem;
    private bool vacuumSoundDoOnce;

    private void Awake()
    {
        grassAmmoLeft = magazineSize;
        grainAmmoLeft = magazineSize;
        appleAmmoLeft = magazineSize;

        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            grassAmmoLeft = 3;
            grainAmmoLeft = 3;
            appleAmmoLeft = 3;
        }

        grassSlider.maxValue = magazineSize;
        grassSlider.value = grassAmmoLeft;
        grassText.text = grassAmmoLeft.ToString();

        grainSlider.maxValue = magazineSize;
        grainSlider.value = grainAmmoLeft;
        grainText.text = grainAmmoLeft.ToString();

        appleSlider.maxValue = magazineSize;
        appleSlider.value = appleAmmoLeft;
        appleText.text = appleAmmoLeft.ToString();

        ammoType = 1;
        grassAmmoHolder.sprite = selectedAmmoImage;
        gunBarrel001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        gunBarrel002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        gunPart001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        gunPart002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        handlePart001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        handlePart002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        handlePart002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        trigger001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tube001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tube002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tube003Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tube004Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tubePart001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tubePart002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tubePart003Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tubePart004Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tubePart005Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tubePart006Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tubePart007Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        tubePart008Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
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
            grassAmmoHolder.sprite = selectedAmmoImage;
            grainAmmoHolder.sprite = notSelectedAmmoImage;
            appleAmmoHolder.sprite = notSelectedAmmoImage;
            gunBarrel001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            gunBarrel002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            gunPart001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            gunPart002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            handlePart001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            handlePart002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            handlePart002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            trigger001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tube001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tube002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tube003Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tube004Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tubePart001Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tubePart002Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tubePart003Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tubePart004Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tubePart005Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tubePart006Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tubePart007Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
            tubePart008Low.GetComponent<MeshRenderer>().material = gunGrassMaterial;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ammoType = 2;
            grassAmmoHolder.sprite = notSelectedAmmoImage;
            grainAmmoHolder.sprite = selectedAmmoImage;
            appleAmmoHolder.sprite = notSelectedAmmoImage;
            gunBarrel001Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            gunBarrel002Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            gunPart001Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            gunPart002Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            handlePart001Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            handlePart002Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            handlePart002Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            trigger001Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tube001Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tube002Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tube003Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tube004Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tubePart001Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tubePart002Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tubePart003Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tubePart004Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tubePart005Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tubePart006Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tubePart007Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
            tubePart008Low.GetComponent<MeshRenderer>().material = gunGrainMaterial;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ammoType = 3;
            grassAmmoHolder.sprite = notSelectedAmmoImage;
            grainAmmoHolder.sprite = notSelectedAmmoImage;
            appleAmmoHolder.sprite = selectedAmmoImage;
            gunBarrel001Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            gunBarrel002Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            gunPart001Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            gunPart002Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            handlePart001Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            handlePart002Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            handlePart002Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            trigger001Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tube001Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tube002Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tube003Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tube004Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tubePart001Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tubePart002Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tubePart003Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tubePart004Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tubePart005Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tubePart006Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tubePart007Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
            tubePart008Low.GetComponent<MeshRenderer>().material = gunAppleMaterial;
        }

        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (vacuumSoundDoOnce == false)
            {
                vacuumSoundDoOnce = true;
            suctionSoundSystem.Play();
            }
            suckableArea.enabled = true;
            playerSucking = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            vacuumSoundDoOnce = false;
            suctionSoundSystem.Stop();
            suckableArea.enabled = false;
            playerSucking = false;
        }

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
        audioSource.PlayOneShot(suckedInSound);
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
        audioSource.PlayOneShot(suckedInSound);
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
        audioSource.PlayOneShot(suckedInSound);
        appleAmmoLeft++;
        if (appleAmmoLeft > magazineSize)
        {
            appleAmmoLeft = magazineSize;
        }
        appleSlider.value = appleAmmoLeft;
        appleText.text = appleAmmoLeft.ToString();
    }
}
