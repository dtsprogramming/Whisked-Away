using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject[] setInactive;
    [SerializeField] private PlayerMovement pm;

    public void WhiskedAway()
    {
        pm = GetComponent<PlayerMovement>();
        pm.enabled = false;
        foreach (GameObject obj in setInactive)
        {
            obj.SetActive(false);
        }

        anim.SetTrigger("Death");

        Invoke(nameof(Restart), 3);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
