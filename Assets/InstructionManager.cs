using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TinyGiantStudio.Text;
using TMPro;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    public static InstructionManager Instance;

    public TMP_Text instructionFront;
   // public TMP_Text instructionBack;
    public TMP_Text instructionBackGlass;

    public AudioSource instructionAudioSource;

    public List<Instruction> instructions = new();

    public int currentInstruction;

    public InstructionHighlight currentBlinker;

    private void Start()
    {
        Instance = this;
        instructionBackGlass.text = "";
        PlayInstruction(instructions[currentInstruction]);
       
    }

    public void PlayInstruction(Instruction instruction)
    {
        if (instruction.instructionHighlight != null)
        {
            currentBlinker = instruction.instructionHighlight;
            currentBlinker.StartBlinking();
        }

        switch (instruction.instructionSide)
        {
            case InstructionSide.Back:
                instructionBackGlass.text = instruction.instructionText;
                break;
            case InstructionSide.Front:
                instructionFront.text = instruction.instructionText;
                break;
            case InstructionSide.Both:
                instructionBackGlass.text = instruction.instructionText;
                instructionFront.text = instruction.instructionText;
                break;
            default:
                Debug.Log("ERROR");
                throw new ArgumentOutOfRangeException();
        }

        instructionAudioSource.PlayOneShot(instruction.instructionAudio);

        switch (instruction.type)
        {
            case InstructionType.AutoSwitch:
                Invoke(nameof(NextInstruction), instruction.instructionLength);
                break;
            case InstructionType.Normal:
                if (instruction.instructionLength == 0) return;
                Invoke(nameof(ClearInstruction), instruction.instructionLength);
                break;
        }
    }

    public void ClearInstruction()
    {

        instructionBackGlass.text = "";
        instructionFront.text = "";
       
        if (currentBlinker != null)
        {
            currentBlinker.StopBlinking();
            currentBlinker = null;
        }
    }

    public void NextInstruction()
    {
        CancelInvoke(nameof(ClearInstruction));
        ClearInstruction();
            if (currentBlinker != null)
            {
                currentBlinker.StopBlinking();
                currentBlinker = null;
            }

            currentInstruction++;
            Debug.Log("Going to Next Instruction "+currentInstruction);
            PlayInstruction(instructions[currentInstruction]);
        }
    
}

[System.Serializable]
public class Instruction
{
    [TextArea(5,10)]
    public string instructionText;
    public AudioClip instructionAudio;
    public float instructionLength;
    [EnumToggleButtons]
    public InstructionType type;
    [EnumToggleButtons]
    public InstructionSide instructionSide;
    public  InstructionHighlight instructionHighlight;
}

public enum InstructionSide
{
    Front,
    Back,
    Both
}

public enum InstructionType
{
    Normal,
    AutoSwitch
}