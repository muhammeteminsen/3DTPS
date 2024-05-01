using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Shooting : MonoBehaviour
{
    [Header("HitSettings")]
    [SerializeField] float hitTime;
    float _hitCount;
    float _hitDistance = 50;
    public int _firePower;
    [Header("Objects")]
    public Camera cam;
    [Header("Effects")]
    public ParticleSystem flashEffect;
    public ParticleSystem stoneEffect;
    public ParticleSystem bloodEffect;
    [Header("Sounds")]
    public AudioSource hitSound;
    public AudioSource outofAmmoSound;
    public AudioSource reloadingMagazine;
    [Header("UISettings")]
    int _magazineCapacity = 30;
    int _bulletRemaining;
    int _maxBullet = 350;
    public TextMeshProUGUI bulletRemainingText;
    public TextMeshProUGUI maxBulletText;
    public UIControl uýControl;



    void Start()
    {

        _bulletRemaining = _magazineCapacity;
        bulletRemainingText.text = _bulletRemaining.ToString();
        maxBulletText.text = _maxBullet.ToString();


    }



    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Hitting();
            if (_bulletRemaining == 0 && Time.time > _hitCount)
            {
                hitTime = 1;
                _hitCount = Time.time + hitTime;
                outofAmmoSound.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && _bulletRemaining >= 0 && _maxBullet != 0 && PlayerMovement.mainHealth > 0 && uýControl.Win.activeSelf == false)
        {
            ReloadAnimation();
            ReloadTechnical();

        }
        bulletRemainingText.text = _bulletRemaining.ToString();
        maxBulletText.text = _maxBullet.ToString();
    }
    void Hitting()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, _hitDistance) && Time.time > _hitCount && _bulletRemaining != 0 && PlayerMovement.mainHealth > 0 && uýControl.Win.activeSelf == false)
        {
            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
            NavMeshAgent navMesh = hit.transform.gameObject.GetComponent<NavMeshAgent>();
            hitTime = .13f;
            _hitCount = Time.time + hitTime;
            flashEffect.Play();
            _bulletRemaining--;
            hitSound.Play();
            PlayerMovement.mainAnimation.Play("Fire Rifle");
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                if (enemy!= null)
                {
                    enemy.isRounds = false;
                    enemy.isDedect = true;
                    enemy.health -= _firePower;
                    enemy.enemyAnimator.Play("Hit Reaction");
                    navMesh.SetDestination(enemy.destination.transform.position);
                    enemy.enemyAnimator.SetBool("isWalk", false);
                    enemy.enemyAnimator.SetBool("isRun", true);
                    Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal), enemy.transform);
                }
                
                

            }

            if (!hit.transform.gameObject.CompareTag("Enemy") && !hit.transform.gameObject.CompareTag("Winning"))
            {
                Instantiate(stoneEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }


        }
    }
    void ReloadAnimation()
    {
        if (_bulletRemaining <= _magazineCapacity && _maxBullet != 0 && _bulletRemaining != _magazineCapacity)
        {
            PlayerMovement.mainAnimation.Play("Reloading");
            reloadingMagazine.Play();

        }

    }
    public void ReloadTechnical()
    {


        if (_bulletRemaining == 0)
        {
            _maxBullet -= _magazineCapacity;
            _bulletRemaining = _magazineCapacity;
        }


        int spentBullet = _magazineCapacity - _bulletRemaining;
        if (spentBullet > _maxBullet)
        {

            _bulletRemaining += _maxBullet;
            _maxBullet = 0;
        }
        else
        {

            _maxBullet -= spentBullet;
            _bulletRemaining = _magazineCapacity;

        }


    }
}
