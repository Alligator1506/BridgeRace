using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : Character
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private Animator animator;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float raycastDistance = 1.5f; // Khoảng cách của raycast

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal * _moveSpeed, rb.velocity.y, joystick.Vertical * _moveSpeed);


        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
        // Tạo tia raycast từ vị trí của người chơi theo hướng xem của người chơi
        Ray ray = new Ray(transform.position + Vector3.up * -0.5f, transform.forward);

        // Biến để lưu thông tin về va chạm
        RaycastHit hitInfo;

        // Thực hiện kiểm tra raycast
        if (Physics.Raycast(ray, out hitInfo, raycastDistance))
        {
            // Lấy thông tin về vật thể mà tia raycast chạm vào
            GameObject hitObject = hitInfo.collider.gameObject;
            //Debug.Log($"{hitObject == null} - {GetComponent<CharacterController>() == null} - {hitObject.GetComponent<CharacterController>() == null}");
            if ((hitObject.CompareTag("StairBrick") && GetComponent<Character>().BackBrickCount == 0) && (int)hitObject.GetComponent<StairBrick>().colorType != (int)colorType)
            {
                //Debug.Log("Chan");
                Collider objectCollider = hitObject.GetComponent<Collider>();
                if (objectCollider != null)
                {
                    objectCollider.isTrigger = false;
                }
            }
            if (hitObject.CompareTag("StairBrick") && GetComponent<Character>().BackBrickCount > 0)
            {
                Collider objectCollider = hitObject.GetComponent<Collider>();
                if (objectCollider != null)
                {
                    objectCollider.isTrigger = true;
                }
            }
        }
        //Vẽ đường raycast
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);

    }
}