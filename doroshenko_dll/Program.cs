using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace doroshenko_dll
{

    public class Comp
    {
        private string CPU { get; set; }
        private int RAM { get; set; }
        private double Cost { get; set; }

        public Comp()
        {
            this.CPU = "";
            this.RAM = 0;
            this.Cost = 0;
        }

        public Comp(string CPU, int RAM, double cost)
        {
            this.CPU = CPU;
            this.RAM = RAM;
            this.Cost = cost;
        }

        public Comp(Comp d)
        {
            this.CPU = d.CPU;
            this.RAM = d.RAM;
            this.Cost = d.Cost;
        }

        [DllImport("dllmain.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void PrintString(string str);

        [DllImport("dllmain.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void PrintInt(int num);

        [DllImport("dllmain.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void PrintDouble(double num);

        [DllImport("dllmain.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void ScanString(string str, int size);

        [DllImport("dllmain.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void ScanInt(ref int num);

        [DllImport("dllmain.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern void ScanDouble(ref double num);

        public void Input()
        {
            Console.WriteLine("Enter CPU:");
            string CPU = Console.ReadLine();
            ScanString(CPU, CPU.Length);

            Console.WriteLine("Enter RAM:");
            int RAM = int.Parse(Console.ReadLine());
            ScanInt(ref RAM);

            Console.WriteLine("Enter Cost:");
            double Cost = double.Parse(Console.ReadLine());
            ScanDouble(ref Cost);

            this.CPU = CPU;
            this.RAM = RAM;
            this.Cost = Cost;
        }

        public void Output() => Console.WriteLine($"CPU: {CPU}  RAM: {RAM}  Cost: {Cost}");

    }

    class Program
    {

        [StructLayout(LayoutKind.Sequential,
         Pack = 4,
         CharSet = CharSet.Unicode)]
        public unsafe struct __CompExtended1S
        {
            //public IntPtr* _vtable;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 250)]
            public string CPU;

            public int RAM;
            public double Cost;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 250)]
            public string GPU;
        };

        public unsafe class CompExtended1S : IDisposable
        {
            private __CompExtended1S _cpp;

            [DllImport("dllmain.dll", EntryPoint = "??0CompExtended1S@@QAE@XZ", CallingConvention = CallingConvention.ThisCall)]
            private static extern IntPtr _CompExtended1S_Constructor(ref __CompExtended1S ths);

            [DllImport("dllmain.dll", EntryPoint = "??1CompExtended1S@@QAE@XZ", CallingConvention = CallingConvention.ThisCall)]
            private static extern int _CompExtended1S_Destructor(ref __CompExtended1S ths);

            [DllImport("dllmain.dll", EntryPoint = "?InputCompExtended1@CompExtended1S@@QAEXXZ", CallingConvention = CallingConvention.ThisCall)]
            private static extern void _InputCompExtended1(ref __CompExtended1S ths);

            [DllImport("dllmain.dll", EntryPoint = "?OutputCompExtended1@CompExtended1S@@QAEXXZ", CallingConvention = CallingConvention.ThisCall)]
            private static extern void _OutputCompExtended1(ref __CompExtended1S ths);

            public CompExtended1S()
            {
                _cpp = new __CompExtended1S();
                _CompExtended1S_Constructor(ref _cpp);
            }
            public void Dispose()
            {
                _CompExtended1S_Destructor(ref _cpp);
            }

            public void InputCompExtended1()
            {
                _InputCompExtended1(ref _cpp);
            }

            public void OutputCompExtended1()
            {
                _OutputCompExtended1(ref _cpp);
            }
        };

        [StructLayout(LayoutKind.Sequential,
        //Pack = 4,
        CharSet = CharSet.Unicode)]
        public unsafe struct __CompExtended2S
        {
            public __CompExtended1S Base;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 250)]
            public string Brand;
        };

        public unsafe class CompExtended2S : IDisposable
        {
            private __CompExtended2S _cpp2;

            [DllImport("dllmain.dll", EntryPoint = "??0CompExtended2S@@QAE@XZ", CallingConvention = CallingConvention.ThisCall)]
            private static extern IntPtr _CompExtended2S_Constructor(ref __CompExtended2S ths);

            [DllImport("dllmain.dll", EntryPoint = "??1CompExtended2S@@QAE@XZ", CallingConvention = CallingConvention.ThisCall)]
            private static extern int _CompExtended2S_Destructor(ref __CompExtended2S ths);

            [DllImport("dllmain.dll", EntryPoint = "?InputCompExtended2@CompExtended2S@@QAEXXZ", CallingConvention = CallingConvention.ThisCall)]
            private static extern void _InputCompExtended2(ref __CompExtended2S ths);

            [DllImport("dllmain.dll", EntryPoint = "?OutputCompExtended2@CompExtended2S@@QAEXXZ", CallingConvention = CallingConvention.ThisCall)]
            private static extern void _OutputCompExtended2(ref __CompExtended2S ths);

            public CompExtended2S()
            {
                _cpp2 = new __CompExtended2S();
                _CompExtended2S_Constructor(ref _cpp2);
            }

            public void Dispose()
            {
                _CompExtended2S_Destructor(ref _cpp2);
            }

            public void InputCompExtended2()
            {
                _InputCompExtended2(ref _cpp2);
            }

            public void OutputCompExtended2()
            {
                _OutputCompExtended2(ref _cpp2);
            }
        };


        static void Main(string[] args)
        {

            /*           Comp comp = new Comp();

                        comp.Input();
                        Console.WriteLine();
                        comp.Output();
            */

            CompExtended1S sc1 = new CompExtended1S();
            CompExtended2S sc2 = new CompExtended2S();

            sc1.InputCompExtended1();
            Console.WriteLine();
            sc1.OutputCompExtended1();
            Console.WriteLine();

            sc2.InputCompExtended2();
            Console.WriteLine();
            sc2.OutputCompExtended2();
            Console.WriteLine();


            Console.WriteLine();

            Thread.Sleep(200000);
        }
    }
}
