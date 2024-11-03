using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float vertical;
    float horizontal;

    private float verticalRaw;
    private float horizontalRaw;

    private Vector3 targetRotation;

    float rotationSpeed = 10f;

    [SerializeField] float speed = 200f;

    [SerializeField] private bool canMove;

    [SerializeField] Rigidbody rb;

    [SerializeField] private Animator animator;

    public bool isMoving;

    public bool isGathering;

    private bool isFacingTarget = false;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!canMove)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        horizontalRaw = Input.GetAxisRaw("Horizontal");
        verticalRaw = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(horizontal, 0, vertical);
        Vector3 inputRaw = new Vector3(horizontalRaw, 0, verticalRaw);

        if (input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }

        if (inputRaw.sqrMagnitude > 1f)
        {
            inputRaw.Normalize();
        }

        if (inputRaw != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input).eulerAngles;
        }

        rb.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(targetRotation.x, Mathf.Round(targetRotation.y / 45) * 45, targetRotation.z),
            Time.deltaTime * rotationSpeed);

        Vector3 vel = input * speed * Time.deltaTime;

        rb.velocity = vel;
        animator.SetBool("IsMoving", vel != Vector3.zero);
        isMoving = vel != Vector3.zero;
    }

    // Call this method with the target GameObject you want the object to face
    public void FaceTarget(GameObject target)
    {
        if (!isFacingTarget && target != null) // Ensure coroutine only starts once per call
        {
            StartCoroutine(FaceTargetCoroutine(target));
        }
    }

    private IEnumerator FaceTargetCoroutine(GameObject objectToFace)
    {
        isFacingTarget = true;

        while (true)
        {
            // Calculate the direction and target rotation
            Vector3 direction = objectToFace.transform.position - transform.position;
            direction.y = 0; // Ignore y-axis for horizontal rotation
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Rotate towards the target
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Check if we're close enough to stop rotating
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation; // Snap to target rotation
                break;
            }

            yield return null;
        }

        isFacingTarget = false;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public void BackToIdleFromLoot()
    {
        animator.SetBool("IsLooting", false);
        isGathering = false;
    }

    public void StartLootingAnimation()
    {
        animator.SetBool("IsLooting", true);
        isGathering = true;
    }

    public void CollectResource()
    {
        GameManager.instance.CollectObject();
        // check if list 0
        if (GameManager.instance.playerDetector._gatherableList.Count < 1)
        {
            GameManager.instance.gatherObjectGameObject.SetActive(false);
        }
        GameManager.instance.gatherObjectGameObject = null;
        SetCanMove(true);
        ButtonManager.instance.buttonGatherResource.SetActive(false);
    }
}