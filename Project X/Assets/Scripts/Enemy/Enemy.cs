public class Enemy : Character
{
    private SimpleAIMoving moving;


    protected void Awake()
    {
        Type = ObjectType.Enemy;
        moving = GetComponent<SimpleAIMoving>();
    }

    private void Update()
    {
        moving.Move();
    }
}