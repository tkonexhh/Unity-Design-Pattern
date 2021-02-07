using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Facade
{
    public class FacadePatternExample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Computer computer = new Computer();
            computer.Start();
        }
    }

    class CPU
    {
        public void DoCPU()
        {
            Debug.LogError("CPU");
        }

        //Other Func
    }

    class GPU
    {
        public void DoGPU()
        {
            Debug.LogError("GPU");
        }
        //Other Func
    }

    class Disk
    {
        public void DoDisk()
        {
            Debug.LogError("Disk");
        }
        //Other Func
    }

    class Computer
    {
        private CPU cpu = new CPU();
        private GPU gpu = new GPU();
        private Disk disk = new Disk();

        public void Start()
        {
            cpu.DoCPU();
            gpu.DoGPU();
            disk.DoDisk();
        }
    }
}