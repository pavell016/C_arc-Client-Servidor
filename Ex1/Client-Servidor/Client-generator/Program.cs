using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Simulador
{
    class Program
    {
        static void Main(string[] args)
        {
            bool program = true;
            while (program) {
                Console.WriteLine("Vols crear un client (S/N)");
                string creation = Console.ReadLine();
                if (creation != "S" || creation != "s" || creation != "Si" || creation != "SI" || creation != "sI" || creation != "si")
                {
                    Process P = new Process();
                    //allow to open shells
                    P.StartInfo.UseShellExecute = true;
                    P.StartInfo.CreateNoWindow = true;
                    //programa que crea la fitxa de notes de l'alumne
                    P.StartInfo.FileName = @"C:\\Users\\programacion\\Documents\GitHub\\C_arc-Client-Servidor\\Ex1\\Client-Servidor\\Client\\bin\\Debug\\net8.0\\Client.exe";
                    
                        P.Start();
                    
                }
                else {
                    Console.WriteLine("Vols sortir del programa? (S/N)?");
                    creation = Console.ReadLine();
                    if (creation != "S" || creation != "s" || creation != "Si" || creation != "SI" || creation != "sI" || creation != "si")
                    { 
                        program = false;
                    }
                 }
                
            }
        }
    }
}
