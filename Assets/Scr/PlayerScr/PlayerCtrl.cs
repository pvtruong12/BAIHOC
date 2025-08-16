using Assets.Scr;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerCtrl : SingleTon<PlayerCtrl>
{
    [SerializeField] protected CharacterController controller;
    public CharacterController Controller => controller;

    [SerializeField] protected CinemachineFreeLook freeLookCam;
    public CinemachineFreeLook FreeLookCm => freeLookCam;

    [SerializeField] protected Transform mainCame;
    public Transform MainCame => mainCame;


    [SerializeField] protected Transform cameraFreelook;
    public Transform CameraTarget => cameraFreelook;

    [SerializeField] protected ParticleSystem particleSystem;
    public ParticleSystem ParticleSystem => particleSystem;


    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    protected override void loadComponents()
    {
        loadAnimator();
        loadCharactorController();
        loadFreeLockCamera();
        loadCameraTaget();
        loadMainCame();
        loadParticleSystem();
    }
    private void loadAnimator()
    {
        if (animator != null)
            return;
        animator = GetComponentInChildren<Animator>();
    }
    private void loadCameraTaget()
    {
        if (cameraFreelook != null)
            return;
        cameraFreelook = GameObject.Find("FreeLook Camera").transform;
    }
    private void loadParticleSystem()
    {
        if (particleSystem != null)
            return;
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    private void loadFreeLockCamera()
    {
        if (freeLookCam != null)
            return;
        freeLookCam = FindObjectOfType<CinemachineFreeLook>();
    }
    private void loadMainCame()
    {
        if (mainCame != null)
            return;
        mainCame = GameObject.Find("Main Camera").transform;
    }
    private void loadCharactorController()
    {
        if (controller != null)
            return;
        controller = GetComponent<CharacterController>();
    }
   
}
