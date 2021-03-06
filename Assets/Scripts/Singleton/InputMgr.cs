﻿//#define _DEBUG
using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class InputMgr: SingletonMonoBehaviourFast<InputMgr> 
{
	GameObject go;
	FadeMgr fade;

	public void Awake()
	{
		if(this != Instance)

		{
			Destroy(this);
			return;
		}
		// Unityではシーンを切り替えるとGameObject等は全部破棄される
		// 引数に指定したGameObjectは破棄されなくなり
		// Scene切替時にそのまま引き継がれます
		DontDestroyOnLoad(this);

		// Fade 生成or見つける
        GlobalSetting gs = Resources.Load<GlobalSetting>("Setting/GlobalSetting");
        fade = gs.FadeMgr;
	}	

    //-----------XBOXコントローラキーコード--------------S
    //X(□)：KeyCode.JoystickButton2
    //Y(△)：KeyCode.JoystickButton3
    //A(×)：KeyCode.JoystickButton0
    //B(○)：KeyCode.JoystickButton1

    //Ｌ１：KeyCode.JoystickButton4
    //Ｒ１：KeyCode.JoystickButton5
    //Ｌ２：反応なし
    //Ｒ２：反応なし

    //Ｌ３：KeyCode.JoystickButton8
    //Ｒ３：KeyCode.JoystickButton
    //---------------------------------------------------E


    //--------------- Redボタン関係 ---------------------------S         デバッグ用に１キー割り当て

    public bool RedButtonPress{
        get{
            return (Input.GetKey(KeyCode.JoystickButton1) | Input.GetKey(KeyCode.Alpha3) ) & !fade.IsFading();
        }
    }

    public bool RedButtonTrigger{
        get{
            return (Input.GetKeyDown(KeyCode.JoystickButton1) | Input.GetKeyDown(KeyCode.Alpha3)) & !fade.IsFading();
        }
    }

    public bool RedButtonRelease{
        get{
            return (Input.GetKeyUp(KeyCode.JoystickButton1) | Input.GetKeyUp(KeyCode.Alpha3)) & !fade.IsFading();
        }
    }

    //--------------- Redボタン関係 ---------------------------E


    //--------------- Greenボタン関係 -------------------------S         デバッグ用に２キー割り当て

    public bool GreenButtonPress
    {
        get{
            return (Input.GetKey(KeyCode.JoystickButton0) | Input.GetKey(KeyCode.Alpha4)) & !fade.IsFading();
        }
    }

    public bool GreenButtonTrigger
    {
        get{
            return (Input.GetKeyDown(KeyCode.JoystickButton0) | Input.GetKeyDown(KeyCode.Alpha4)) & !fade.IsFading();
        }
    }

    public bool GreenButtonRelease
    {
        get{
           return (Input.GetKeyUp(KeyCode.JoystickButton0) | Input.GetKeyUp(KeyCode.Alpha4)) & !fade.IsFading();
        }
    }

    //--------------- Greenボタン関係 -------------------------E

    //--------------- Blueボタン関係 --------------------------S         デバッグ用に３キー割り当て

    public bool BlueButtonPress
    {
        get{
            return (Input.GetKey(KeyCode.JoystickButton2) | Input.GetKey(KeyCode.Alpha2)) & !fade.IsFading();
        }
    }

    public bool BlueButtonTrigger
    {
        get{
            return (Input.GetKeyDown(KeyCode.JoystickButton2) | Input.GetKeyDown(KeyCode.Alpha2)) & !fade.IsFading();
        }
    }

    public bool BlueButtonRelease
    {
        get{
            return (Input.GetKeyUp(KeyCode.JoystickButton2) | Input.GetKeyUp(KeyCode.Alpha2)) & !fade.IsFading();
        }
    }

    //--------------- Blueボタン関係 --------------------------E

    //--------------- Yellowボタン関係 ------------------------S         デバッグ用に４キー割り当て

    public bool YellowButtonPress
    {
        get{
            return (Input.GetKey(KeyCode.JoystickButton3) | Input.GetKey(KeyCode.Alpha1)) & !fade.IsFading();
        }
    }

    public bool YellowButtonTrigger
    {
        get{
            return (Input.GetKeyDown(KeyCode.JoystickButton3) | Input.GetKeyDown(KeyCode.Alpha1)) & !fade.IsFading();
        }
    }

    public bool YellowButtonRelease
    {
        get{
            return (Input.GetKeyUp(KeyCode.JoystickButton3) | Input.GetKeyUp(KeyCode.Alpha1)) & !fade.IsFading();
        }
    }

    //--------------- Yellowボタン関係 ------------------------E



	// ++++++++++++ 何かのボタン ++++++++++++++++S

	public bool AnyButtonTrigger{
        get
        {
            if (RedButtonTrigger
               || YellowButtonTrigger
               || BlueButtonTrigger
               || GreenButtonTrigger)
            {
                return true;
            }
            return false;
        }
	}

	public bool AnyButtonPress{
        get
        {
            if (RedButtonPress
               || YellowButtonPress
               || BlueButtonPress
               || GreenButtonPress)
            {
                return true;
            }
            return false;
        }
	}

	public bool AnyButtonRelease{
        get
        {
            if (RedButtonRelease
               || YellowButtonRelease
               || BlueButtonRelease
               || GreenButtonRelease)
            {
                return true;
            }
            return false;
        }
	}
}
