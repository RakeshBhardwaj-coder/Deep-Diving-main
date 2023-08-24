using UnityEngine;

public class PlayerDestruction : MonoBehaviour
{
    public GameObject destructionVFX;
    private bool isPlayerDestoryed = false;

    private void DestroyPlayer()
    {
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SoundManager.Instance.PlayExplosionAudio();
        isPlayerDestoryed = true;
       
    }
    void Update()
    {
        if(HealthManager.Instance.currentHearts == 0f && !isPlayerDestoryed)
        {

            DestroyPlayer();
           
        }
    }


}
