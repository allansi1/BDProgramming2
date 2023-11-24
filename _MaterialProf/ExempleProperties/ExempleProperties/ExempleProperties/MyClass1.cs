using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplesProperties
{
    class MyClass1
    {
        private int a1;
        private int a2;
        private int a3;
        private int a4 = 100;

        private int r1 = 10;
        private int r2 = 20;
        private int r3 = 30;
        private readonly int r4 =40;

        // les "Properties" peuvent avoir le "get", le "set" ou les deux 
        public int A1   
        {
            get { return a1; }
            set
            {
                if (value < 0) { a1 = -1 * value; }   // value est la valeur attribuée
                else { a1 = value; }
            }
        }

        // le "get" et le "set" peuvent être "expression-bodied members"
        public int A2
        {
            get => a2;
            set => a2 = (value < 0) ? (-1 * value) : value ;
        }

        // Nous pouvons écrire chaque accessor des notations différentes
        public int A3
        {
            get => a3;
            set
            {
                if (value < 0) { a3 = -1 * value; }   // value est la valeur attribuée
                else { a3 = value; }
            }
        }


        // Si la property a les deux "accessor" (get et set), nous pouvons réduire la visibilité d'un d'eux.
        public int A4
        {
            get => a4;
            private set => a4 = (value < 0) ? (-1 * value) : value;
        }

        // La "Property" peut être auto-implemented, mais seulement si le "get" et le "set" sont triviaux 
        // get trivial: get => attribut;
        // set trivial: set => attribut = value;
        public int A5 { get; set; }   // only when the get and set are trivial 

        public int A6 { get; private set; } = 200;


        /* 
         * Read-only properties 
        */
        public int R1
        {
            get { return r1; }
        }   

        public int R2
        {
            get => r2;
        }

        public int R3 => r3;    // only for read-only properties

        public int R4
        {
            get => r4;
            // set => r4 = value;  // set n'est pas possible parce que l'attribut r4 est readonly 
        }

        public int R5 { get; } = 300; // auto-implement readonly property
   
    }
}
