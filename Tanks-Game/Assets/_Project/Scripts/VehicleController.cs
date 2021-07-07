using UnityEngine;

namespace Gisha.TanksGame.Core
{
    public class VehicleController : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform shootPos;


        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        float _hInput;
        float _vInput;
        Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _vInput = Input.GetAxisRaw("Vertical");
            _hInput = Input.GetAxisRaw("Horizontal");

            transform.Rotate(-Vector3.forward * _hInput * rotationSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
                Shoot();
        }

        private void FixedUpdate()
        {
            _rb.velocity = transform.up * _vInput * moveSpeed * Time.deltaTime;
        }

        private void Shoot()
        {
            Instantiate(projectilePrefab, shootPos.position, shootPos.rotation);
        }
    }
}
