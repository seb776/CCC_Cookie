using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public CharacterController Controller;
    public Animator Animator;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        _isSat = false;
    }
    private bool _isSat;

    // Update is called once per frame
    void Update()
    {
        var moveDir = this.gameObject.transform.forward * Input.GetAxis("Vertical");
        this.gameObject.transform.Rotate(Vector3.up, Input.GetAxis("Horizontal")*Time.deltaTime*100.0f);
        Animator.SetBool("Walking", moveDir.magnitude > 0.1f || Input.GetAxis("Horizontal") > 0.1f);
        Controller.SimpleMove(moveDir*Speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isSat)
            {
                Animator.SetTrigger("Stand");
            }
            else
            {
                Animator.SetTrigger("Sit");
            }
            _isSat = !_isSat;
        }
    }
}
