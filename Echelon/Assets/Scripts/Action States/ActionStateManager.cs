using UnityEngine;

public class ActionStateManager : MonoBehaviour
{
    public ActionBaseState currentState;
    public ReloadState Reload = new ReloadState();
    public DefaultState Default = new DefaultState();
    public GameObject currentWeapon;
    public WeaponAmmo ammo;
    AudioSource audioSource;
    public Animator anim;




    // Start is called before the first frame update
    void Start()
    {

        SwitchState(Default);
        ammo = currentWeapon.GetComponent<WeaponAmmo>();
        audioSource = currentWeapon.GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(ActionBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void WeaponReloaded()
    {
        ammo.Reload();
        SwitchState(Default);
    }

    public void MagOut()
    {
        audioSource.PlayOneShot(ammo.magOutSound);
    }

    public void MagIn()
    {
        audioSource.PlayOneShot(ammo.magInSound);
    }

    public void RelaseSlide()
    {
        audioSource.PlayOneShot(ammo.relaseSlideSound);
    }



}
