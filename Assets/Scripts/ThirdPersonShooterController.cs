using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField]
    private float normalSensitivity;
    [SerializeField]
    private float aimSensitivity;
    [SerializeField]
    private float attackSpeed = 1f;
    [SerializeField]
    private float attackCooldown = 0f;
    [SerializeField]
    private LayerMask aimColliderMask = new LayerMask();
    [SerializeField]
    private Transform debugRay;
    [SerializeField]
    private Transform spellObject;
    [SerializeField]
    private Transform spawnPosition;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 centerScreen = new Vector2(Screen.width / 2f, Screen.height / 2f);

        Ray ray = Camera.main.ScreenPointToRay(centerScreen);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            debugRay.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }


        if (starterAssetsInputs.aim)
        {
            starterAssetsInputs.sprint = false;
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            //animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            /*if (!starterAssetsInputs.shoot)
                animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));*/
        }

        if (starterAssetsInputs.shoot)
        {
            if (attackCooldown <= 0f)
            {
                attackCooldown = 1f / attackSpeed;
                animator.SetTrigger("Shoot");
                Vector3 aimDir = (mouseWorldPosition - spawnPosition.position).normalized;
                Instantiate(spellObject, spawnPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                starterAssetsInputs.shoot = false;
            }

        }
    }
}
