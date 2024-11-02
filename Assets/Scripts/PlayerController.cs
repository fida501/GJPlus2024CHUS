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
    float speed = 200f;

    [SerializeField] private bool canMove;

    [SerializeField] Rigidbody rb;

    [SerializeField] private GameObject treeTarget;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
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

        // rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation.x, MathF.Round(targetRotation.y / 45) * 45, targetRotation.z);
        rb.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(targetRotation.x, Mathf.Round(targetRotation.y / 45) * 45, targetRotation.z),
            Time.deltaTime * rotationSpeed);

        Vector3 vel = input * speed * Time.deltaTime;
        if (!canMove)
        {
            vel = Vector3.zero;
        }

        rb.velocity = vel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pohon"))
        {
            treeTarget = other.gameObject;
            ButtonManager.instance.buttonTreeChop.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pohon"))
        {
            treeTarget = null;
            ButtonManager.instance.buttonTreeChop.SetActive(false);
        }
    }

    public void ChopTree()
    {
        treeTarget.SetActive(false);
        treeTarget = null;
        ButtonManager.instance.buttonTreeChop.SetActive(false);
        GameManager.instance.player.AddWood(1);
        UIManager.instance.SetWoodText(GameManager.instance.player.Wood);
    }
}