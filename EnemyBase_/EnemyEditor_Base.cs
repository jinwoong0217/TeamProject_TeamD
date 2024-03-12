using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Editor�� ��ӹ����� �����Ϳ����� �۵���
[CustomEditor(typeof(EnemyBase_))]
public class EnemyEditor : Editor
{
    // EnemyEditor�� Enemy�� ������ Ŭ�����̹Ƿ� ���� ���õ� Enemy�� ã�ƿü� �־����
    public EnemyBase_ selected;

    // Editor���� OnEnable�� ���� �����Ϳ��� ������Ʈ�� �������� Ȱ��ȭ��
    private void OnEnable()
    {
        // target�� Editor�� �ִ� ������ ������ ������Ʈ�� �޾ƿ�.
        if (AssetDatabase.Contains(target))
        {
            selected = null;
        }
        else
        {
            // target�� Object���̹Ƿ� Enemy�� ����ȯ
            selected = (EnemyBase_)target;
        }
    }

    // ����Ƽ�� �ν����͸� GUI�� �׷��ִ��Լ�
    public override void OnInspectorGUI()
    {
        if (selected == null)
            return;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("���� ���� �Է� ( �ൿ , ���� ) ");
        EditorGUILayout.Space();

        GUI.color = Color.white;
        selected.maxHp = EditorGUILayout.IntField("���� ü��", selected.Hp);
        if (selected.maxHp < 0)
            selected.maxHp = 1;

        selected.mobDamage = EditorGUILayout.IntField("���� ���ݷ�", selected.mobDamage);

        selected.mobMoveSpeed = EditorGUILayout.FloatField("���� �̵��ӵ�", selected.mobMoveSpeed);
        if (selected.mobMoveSpeed < 0)
            selected.mobMoveSpeed = 0;

        // ũ�� �������� ����
        if (GUILayout.Button("Resize"))
        {
            selected.transform.localScale = Vector3.one * Random.Range(0.5f, 1f);
        }
    }
}

