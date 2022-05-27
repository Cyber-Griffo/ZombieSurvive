using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

    const float minPathUpdateTime = .2f;
    const float pathUpdateMoveThreshold = .5f;

    public float speed = 20;
    public float turnSpeed = 3;
    public float turnDst = 5;
    public float stoppingDst = 10;

    [System.NonSerialized]
    public bool isFollowingPlayer = false;
    [System.NonSerialized]
    public ZombieManager zombieManager;
    [System.NonSerialized]
    public WaterBombManager waterBombManager;
    [System.NonSerialized]
    public bool goFollowPlayer = false;

    public float distanceFromTargetToStop = 0.1f;

    public bool followingPath;
    public bool hasFollowedPlayer = false;
    public bool zombieIsReady = false;
    public bool waterBombIsReady = false;

    Path path;

    Transform target;
    Zombie zombie;
    WaterBomb waterBomb;
    GameManager gameManager;

    int gameMode;

    void Start()
    {
        gameMode = SaveSystem.LoadDataGameMode().gameModeSave;

        switch (gameMode)
        {
            case 0:

                waterBombManager = GameObject.Find("GameManager").GetComponent<WaterBombManager>();
                gameManager = waterBombManager.gameObject.GetComponent<GameManager>();
                waterBomb = GetComponent<WaterBomb>();
                waterBomb.active = true;
                waterBombIsReady = true;

                break;
            case 1:

                zombieManager = GameObject.Find("GameManager").GetComponent<ZombieManager>();
                gameManager = zombieManager.gameObject.GetComponent<GameManager>();
                zombie = GetComponent<Zombie>();
                StartCoroutine(moveZombieToGroundLevel());
                StopCoroutine(moveZombieToGroundLevel());
                zombie.active = true;
                zombieIsReady = true;

                break;
        }

        target = GameObject.Find("Player").transform;
        StartCoroutine(UpdatePath());
    }

    public void OnPathFound(Vector3[] waypoints, bool pathSuccessful)
    {
        if (this != null)
        {
            if (pathSuccessful)
            {
                if (this != null)
                {
                    path = new Path(waypoints, transform.position, turnDst, stoppingDst);
                }
                StopCoroutine("FollowPath");
                StartCoroutine("FollowPath");
            }
        }
    }

    IEnumerator UpdatePath()
    {
        while (zombieIsReady || waterBombIsReady)
        {
            if (Time.timeSinceLevelLoad < .3f)
            {
                yield return new WaitForSeconds(1f);
            }
            if (CanStartFollowing() && this != null)
                PathRequestManager.RequestPath(new PathRequest(transform.position, target.position, OnPathFound));

            float sqrMoveThreshold = pathUpdateMoveThreshold * pathUpdateMoveThreshold;
            Vector3 targetPosOld = target.position;

            while (true)
            {
                yield return new WaitForSeconds(minPathUpdateTime);
                if (((((target.position - targetPosOld).sqrMagnitude > sqrMoveThreshold) && CanStartFollowing()) || CanStartFollowing()) && this != null)
                {
                    PathRequestManager.RequestPath(new PathRequest(transform.position, target.position, OnPathFound));
                    targetPosOld = target.position;
                }
            }
        }
    }

    IEnumerator FollowPath()
    {
        hasFollowedPlayer = true;
        followingPath = true;
        int pathIndex = 0;
        transform.LookAt(path.lookPoints[0]);

        float speedPercent = 1;

        while (followingPath)
        {
            Vector2 pos2D = new Vector2(transform.position.x, transform.position.z);
            while (path.turnBoundaries[pathIndex].HasCrossedLine(pos2D))
            {
                if (pathIndex == path.finishLineIndex)
                {
                    followingPath = false;
                    break;
                }
                else
                {
                    pathIndex++;
                }
            }

            if (followingPath)
            {

                if (pathIndex >= path.slowDownIndex && stoppingDst > 0)
                {
                    speedPercent = Mathf.Clamp01(path.turnBoundaries[path.finishLineIndex].DistanceFromPoint(pos2D) / stoppingDst);
                    if (speedPercent < distanceFromTargetToStop)
                    {
                        followingPath = false;
                    }
                }

                Quaternion targetRotation = Quaternion.LookRotation(path.lookPoints[pathIndex] - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
                transform.Translate(Vector3.forward * Time.deltaTime * speed * speedPercent, Space.Self);
            }

            yield return null;

        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            path.DrawWithGizmos();
        }
    }

    public bool isPlayerInActivationRadius(GameObject player)
    {
        bool foundPlayer = false;

        Collider[] colliders;

        switch (gameMode)
        {
            case 0:

                colliders = Physics.OverlapSphere(transform.position, waterBombManager.startFollowingRadius);

                foreach (Collider collider in colliders)
                {
                    if (collider.tag == "Player")
                    {
                        foundPlayer = true;
                        return true;
                    }
                    if (foundPlayer)
                    {
                        break;
                    }
                }

                break;
            case 1:

                colliders = Physics.OverlapSphere(transform.position, zombieManager.wakeUpRadius);

                foreach (Collider collider in colliders)
                {
                    if (collider.tag == "Player")
                    {
                        foundPlayer = true;
                        return true;
                    }
                    if (foundPlayer)
                    {
                        break;
                    }
                }

                break;
        }

        return false;
    }

    bool CanStartFollowing()
    {
        switch (gameMode)
        {
            case 0:

                if (!isFollowingPlayer && isPlayerInActivationRadius(target.gameObject) || (gameManager.sceneHasInitialized && waterBombIsReady && (waterBomb.hasTakenDamage ||
                hasHeardSomething || !waterBombManager.IsAnyOneFollowingPlayer())))
                {
                    if (!hasFollowedPlayer)
                    {
                        hasFollowedPlayer = true;
                        GetComponent<WaterBombAudioManager>().Play("Awake");
                    }
                    isFollowingPlayer = true;
                    return true;
                }
                else
                {
                    isFollowingPlayer = false;
                    return false;
                }

            case 1:

                if (!isFollowingPlayer && isPlayerInActivationRadius(target.gameObject) || (gameManager.sceneHasInitialized && zombieIsReady && (zombie.hasTakenDamage ||
                hasHeardSomething || !zombieManager.IsAnyOneFollowingPlayer())))
                {
                    if (!hasFollowedPlayer)
                    {
                        hasFollowedPlayer = true;
                        GetComponent<ZombieAudioManager>().Play("Awake");
                    }
                    isFollowingPlayer = true;
                    return true;
                }
                else
                {
                    isFollowingPlayer = false;
                    return false;
                }

        }
        return false;
    }

    public bool hasHeardSomething
    {
        get
        {
            return goFollowPlayer;
        }
        set
        {
            goFollowPlayer = value;
        }
    }

    private IEnumerator moveZombieToGroundLevel()
    {
        bool isAboveGround = false;
        RaycastHit hit;
        Rigidbody rb = GetComponent<Rigidbody>();
        while (!isAboveGround)
        {
            if (!Physics.Raycast(this.gameObject.transform.position, Vector3.down, out hit, Mathf.Infinity, gameManager.groundMask))
            {
                rb.AddForce(Vector3.up, ForceMode.Impulse);
                yield return null;
            }
            else
            {
                isAboveGround = true;
            }
        }
        yield return null;
    }
}
