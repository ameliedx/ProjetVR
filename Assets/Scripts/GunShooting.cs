using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GunShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Pr�fabriqu� de la balle
    public Transform bulletSpawn;     // Position de spawn de la balle
    public float shootingForce = 1000f; // Force de propulsion de la balle
    public float fireRate = 0.2f;     // Temps entre deux tirs (en secondes)
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable; // Le composant XRGrabInteractable attach� au pistolet

    private XRInputActions inputActions; // R�f�rence aux InputActions g�n�r�s
    private bool isShooting = false;    // D�tecter si le joueur tire
    private float nextFireTime = 0f;    // Temps pour le prochain tir
    private bool isGunHeld = false;     // D�tecter si le pistolet est saisi

    void Awake()
    {
        // Initialiser les Input Actions
        inputActions = new XRInputActions();
    }

    void OnEnable()
    {
        // Activer les Input Actions
        inputActions.XRControls.Enable();

        // Lier les �v�nements de tir aux actions de la g�chette
        inputActions.XRControls.Shoot.started += OnShootStart;
        inputActions.XRControls.Shoot.canceled += OnShootStop;

        // Lier les �v�nements de grab et release du pistolet
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        // D�sactiver les Input Actions
        inputActions.XRControls.Disable();

        // D�sabonner les �v�nements de tir
        inputActions.XRControls.Shoot.started -= OnShootStart;
        inputActions.XRControls.Shoot.canceled -= OnShootStop;

        // D�sabonner les �v�nements de grab et release
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    void Update()
    {
        // V�rifier si le pistolet est tenu et si le joueur est en train de tirer
        if (isGunHeld && isShooting && Time.time >= nextFireTime)
        {
            Debug.Log("Tir effectu� !");
            Shoot();
            nextFireTime = Time.time + fireRate; // Calculer le temps pour le prochain tir
        }
    }


    void OnShootStart(InputAction.CallbackContext context)
    {
        // Le joueur commence � tirer
        isShooting = true;
    }

    void OnShootStop(InputAction.CallbackContext context)
    {
        // Le joueur arr�te de tirer
        isShooting = false;
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isGunHeld = true;
        Debug.Log("Pistolet saisi !");
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isGunHeld = false;
        Debug.Log("Pistolet l�ch� !");
    }


    void Shoot()
    {
        // Cr�er la balle � la position de spawn
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Appliquer une force � la balle pour simuler le tir
        rb.AddForce(bulletSpawn.forward * shootingForce);
    }

}