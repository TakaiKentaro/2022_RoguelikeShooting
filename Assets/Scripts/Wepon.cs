using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Wepon : MonoBehaviour, IPool
{

    [Header("�X�e�[�^�X")]
    [Tooltip("�U����")] public byte _attackDmg = 1;
    [Tooltip("�ړ����x")] public float _weponSpeed = 1;
    [Tooltip("��")] public byte _weponNum = 1;
    [SerializeField, Tooltip("�C���^�[�o��")] float _timer;

    [Tooltip("���˂̈ʒu")] Vector3 _shootVec;
    [Tooltip("TargetEnemy")] Enemy _target;

    [Tooltip("�����锻��")] bool _check;

    public bool Waiting { get; set; }

    /// <summary>
    /// �������̏�����. Start�֐�
    /// </summary>
    /// <param name="parent">�eObject</param>
    public void SetUp(Transform parent)
    { 
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Use�����ۂ̏�����. Start�֐�
    /// </summary>
    public void IsUseSetUp()
    {
        if (_target == null) return;

        _shootVec = _target.transform.position - GameManager.Player.transform.position;
        _shootVec.Normalize();

        _check = true;
        _timer = 0;
        _target = GetComponent<Enemy>();
        gameObject.SetActive(true);
    }

    /// <summary>
    /// �g�p���̏���. Update�֐� true���Ԃ������葱����
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        transform.position += _shootVec * _weponSpeed * Time.deltaTime;

        return true;
    }

    /// <summary>
    /// Execute����������ۂ̏���, Destroy�֐�
    /// </summary>
    public void Delete()
    {

    }

}
