using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_ : MonoBehaviour
{
    //������Ʈ �ҷ�����
    Rigidbody2D rb;

    /// <summary>
    /// �÷��̾� ��ġ Ÿ����
    /// </summary>
    Vector2 targetPos;

    /// <summary>
    /// �¿� üũ�� ��Ʈ
    /// </summary>
    public int checkLR = 1;

    /// <summary>
    /// �� ��ü�� �ִ� ü��
    /// </summary>
    public int maxHp = 10;

    /// <summary>
    /// �� ��ü�� ���� ü��
    /// </summary>
    private int hp = 10;

    /// <summary>
    /// �� ��ü�� ������ 
    /// </summary>
    public int mobDamage = 0;

    /// <summary>
    /// �� ��ü�� �̵��ӵ�
    /// </summary>
    public float mobMoveSpeed = 0;

    /// <summary>
    /// Hp ������Ƽ
    /// </summary>
    public int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            hp = Mathf.Max(hp, 0);

            // Hp�� 0 ���ϸ� ���
            if (Hp <= 0)
            {
                Die();
            }

        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = maxHp;
    }

    protected virtual void Start()
    {
        //player = GameManager.Instantiate.Player;
    }

    protected virtual void Update()
    {
        // �÷��̾��� ��ġ�� �޴´�.
        // targetPos = 

        // �÷��̾��� ��ġ�� ���� ��������Ʈ�� �����Ѵ� ( �¿� )
        if (targetPos.x < rb.position.x) checkLR = -1; // ( �����̸� - )
        else checkLR = 1;                              // �����̸� +

    }

    /// <summary>
    /// �浹�� �����ϴ� �޼���
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack")) // �÷��̾��� ���ݿ� �¾Ҵٸ�
        {
            Damaged(1); // ������ �Լ��� �����Ų��.
        }
    }

    /// <summary>
    /// ���ظ� �޾����� ������ �Լ� ����
    /// </summary>
    /// <param name="Damage">�÷��̾�� ���� ����</param>
    /// <exception cref="NotImplementedException"></exception>
    private void Damaged(int Damage)
    {
        Hp -= Damage;
    }


    /// <summary>
    /// �׾����� ���� �� �޼���
    /// </summary>
    protected virtual void Die()
    {

    }
}
