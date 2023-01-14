using UnityEngine;
using UnityEngine.SceneManagement;

namespace GunsMerge
{
    public class RestartButton : MonoBehaviour
    {

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
