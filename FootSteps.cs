using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] AudioSource source;
    //YourSound 
    [SerializeField] AudioClip[] DefoultSounds;
    [SerializeField] float pitchMin;
    [SerializeField] float pitchMax;
    [SerializeField] CharacterController characterController;
    [SerializeField] float walkStepInterval;
    [SerializeField] float runStepInterval;
    [SerializeField] PlayerController playerController;
    private float actualInterval;
    //Your SoundMassiveIndex
    private int DefoultMassiveIndex;

    void Update()
    {
        if (characterController.isGrounded == true && characterController.velocity.magnitude > 0)
        {
            actualInterval += Time.deltaTime;
            if (characterController.velocity.magnitude > playerController.walkingSpeed) //create the variable with player walking speed or insert this here
            {
                if (actualInterval > runStepInterval)
                {
                    CheckGround();
                }
            }
            else if (actualInterval >= walkStepInterval)
            {
                CheckGround();

            }
        }
    }

    private void CheckGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo, 1.5f))
        {
            actualInterval = 0;

            if (hitInfo.collider.CompareTag("YourTag"))
            {
                //PlaySound(YourTagSound, ref YourMassiveIndex);
            }
            else if (hitInfo.collider.CompareTag("YourTag2"))
            {
                //PlaySound(YourTagSound, ref YourMassiveIndex);
            }
            else
            {
                PlaySound(DefoultSounds, ref DefoultMassiveIndex);
            }
        }
    }

    private void PlaySound(AudioClip[] clips, ref int index)
    {
        source.PlayOneShot(clips[index]);
        index++;

        if (index >= clips.Length)
        {
            index = 0;
        }
    }
}