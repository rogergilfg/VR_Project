using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Transform slider;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;

    private float timePass;
    private VRMagazine magazine;
    private bool sliderCargado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePass += Time.deltaTime;
        if (slider.localPosition.z > 0.03f)
        {
            sliderCargado = true;
        }
    }

    public void AddMagazine(SelectEnterEventArgs eventArgs)
    {
        Debug.Log("Bien metio niño");
        magazine = eventArgs.interactableObject.transform.GetComponent<VRMagazine>();
        sliderCargado = false;
    }

    public void RemoveMagazine(SelectExitEventArgs eventArgs)
    {
        Debug.Log("Eso eso, recarga");
        magazine = null;
        sliderCargado = false;
    }

    public void Shoot()
    {
        if(magazine != null && sliderCargado == true)
        {
            if (fireRate <= timePass && magazine.bullets>0)
            {
                GameObject bulletClone = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bulletClone.GetComponent<Rigidbody>().linearVelocity = bulletClone.transform.forward * bulletSpeed;
                magazine.bullets -= 1;
                timePass = 0;
            }
        }   
    }
}
