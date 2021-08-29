using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winContainer;
    public static GameManager Instance;
    
    public DynamicJoystick joystick;
    private float moveX;
    private float moveZ;
    private Vector3 direction;

    public float playerSpeed;
    public float rotationSpeed;

    public CharacterController char1;
    
    
    

    private void Awake()
    {
        SingletonPattern();
        Debug.Log("awake çalıştı");
    }


    void FixedUpdate()
    {
        moveX = joystick.Horizontal;
        moveZ = joystick.Vertical;
        direction = new Vector3(moveX,0,moveZ).normalized;
        
        char1.gameObject.transform.localRotation = 
            Quaternion.Slerp(char1.gameObject.transform.localRotation,
            Quaternion.LookRotation(direction),rotationSpeed*Time.fixedDeltaTime);
        
        direction *= playerSpeed;
        
        
        char1.Move(direction);
        
    }


    #region Singleton
    
        private void SingletonPattern()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        
    
        #endregion
        
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameCompleted()
    {
        winContainer.SetActive(true);
    }
}
