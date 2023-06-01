namespace ArionDigital
{
    using UnityEngine;

    public class CrashCrate : MonoBehaviour
    {
        [Header("Whole Create")]
        public MeshRenderer wholeCrate;
        public BoxCollider boxCollider;
        [Header("Fractured Create")]
        public GameObject fracturedCrate;
        [Header("Audio")]
        public AudioSource crashAudioClip;

        private bool isCrashed = false;

        // private void OnTriggerEnter(Collider other)
        // {
        //     wholeCrate.enabled = false;
        //     boxCollider.enabled = false;
        //     fracturedCrate.SetActive(true);
        //     crashAudioClip.Play();
        // }

        private void OnTriggerStay(Collider other) {
            //if sword is colliding with crate and is attacking and crate is not crashed then crash crate
            if (other.gameObject.CompareTag("Sword") && other.GetComponentInParent<JorginhoController>().GetAtacando() && isCrashed == false)
            {
                CrashCrateMethod();
            }
        }

        void CrashCrateMethod()
        {
            isCrashed = true;

            // crash crate
            wholeCrate.enabled = false;
            boxCollider.enabled = false;
            fracturedCrate.SetActive(true);
            crashAudioClip.Play();
        }

        [ContextMenu("Test")]
        public void Test()
        {
            wholeCrate.enabled = false;
            boxCollider.enabled = false;
            fracturedCrate.SetActive(true);
        }
    }
}