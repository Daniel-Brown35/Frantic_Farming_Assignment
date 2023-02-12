using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SiloGrass : MonoBehaviour
{
    public TMP_Text storageCountText;
    public TMP_Text storageCountText2;
    private int storageCount;
    private bool inSiloRange;
    private Gun gun;
    public int storageCap;
    public AudioSource audioSource;
    public AudioClip siloDropSound;
    public AudioClip suckedInSound;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Gun").GetComponent<Gun>();
        storageCount = 0;
        storageCountText.text = storageCount.ToString();
        storageCountText2.text= storageCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (inSiloRange == true && gun.grassAmmoLeft > 0 && storageCount < storageCap && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.PlayOneShot(siloDropSound);
            storageCount++;
            gun.grassAmmoLeft--;
            storageCountText.text = storageCount.ToString();
            storageCountText2.text = storageCount.ToString();
            gun.grassSlider.value = gun.grassAmmoLeft;
            gun.grassText.text = gun.grassAmmoLeft.ToString();
        }
        if (inSiloRange == true && gun.grassAmmoLeft < gun.magazineSize && storageCount > 0 && Input.GetKeyDown(KeyCode.Q)) 
        {
            audioSource.PlayOneShot(suckedInSound);
            storageCount--;
            gun.grassAmmoLeft++;
            storageCountText.text = storageCount.ToString();
            storageCountText2.text = storageCount.ToString();
            gun.grassSlider.value = gun.grassAmmoLeft;
            gun.grassText.text = gun.grassAmmoLeft.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            inSiloRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            inSiloRange = false;
        }
    }
}
