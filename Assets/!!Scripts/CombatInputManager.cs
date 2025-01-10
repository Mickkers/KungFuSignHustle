using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatInputManager : MonoBehaviour
{
    public static CombatInputManager Instance { get; private set; }

    private CombatInputActions _combatInputAction;
    public CombatInputActions.CombatActions CombatAction { get; private set; }

    [SerializeField] VoidEventChannelSO _gameOverEventChannel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _combatInputAction = new CombatInputActions();
        CombatAction = _combatInputAction.Combat;
    }

    private void OnDestroy()
    {
        _gameOverEventChannel.OnEventRaised -= DisableCombatInput;
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void OnEnable()
    {
        CombatAction.Enable();
    }

    private void OnDisable()
    {
        CombatAction.Disable();
    }

    public void EnableCombatInput()
    {
        this.enabled = true;
    }

    public void DisableCombatInput()
    {
        this.enabled = false;
    }

    private void Start()
    {
        CombatAction.SubmitAnswer.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SubmitAnswer();

        CombatAction.A.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("a");
        CombatAction.B.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("b");
        CombatAction.C.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("c");
        CombatAction.D.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("d");
        CombatAction.E.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("e");
        CombatAction.F.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("f");
        CombatAction.G.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("g");
        CombatAction.H.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("h");
        CombatAction.I.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("i");
        CombatAction.J.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("j");
        CombatAction.K.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("k");
        CombatAction.L.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("l");
        CombatAction.M.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("m");
        CombatAction.N.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("n");
        CombatAction.O.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("o");
        CombatAction.P.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("p");
        CombatAction.Q.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("q");
        CombatAction.R.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("r");
        CombatAction.S.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("s");
        CombatAction.T.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("t");
        CombatAction.U.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("u");
        CombatAction.V.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("v");
        CombatAction.W.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("w");
        CombatAction.X.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("x");
        CombatAction.Y.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("y");
        CombatAction.Z.performed += (InputAction.CallbackContext ctx) => PlayerManager.Instance.PAttack.SetAnswerKey("z");

        _gameOverEventChannel.OnEventRaised += DisableCombatInput;

        DisableCombatInput();
    }

    
}
