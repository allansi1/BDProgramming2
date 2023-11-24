using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleProp
{
    class MyClass
    {
        // acesseur et mutateur pareilles à Java
        private int x1;
        public int getX1() { return x1; }
        public void setX1(int x1) { this.x1 = x1; }

        private int x2;
        public int X2 { get { return x2; } set { x2 = value; } }

        private int x3 = 10;
        public int X3 { get { return x3; } private set { x3 = value; } }

        private int x4;
        public int X4 { get => x4; set => x4 = (value >= 0) ? value : 0; }
        // set => if(value >=0){x4=value ;}else { x4=0;}  n'est pas acceptable.
        // mais ce possible d'avoir: 
        // set { if (value >= 0) { x4 = value; } else { x4 = 0; } }
        // public int X4 { get => x4; set { if (value >= 0) { x4 = value; } else { x4 = 0; } } }

        private int x5;
        public int X5 { get => x5; private set => x5 = (value >= 0) ? value : 0; }

        // Nous pouvons avoir deux propriétés sur le même attribut (privé) interne.
        // Les deux propriétés peuvent définir de règles différentes pour leurs accesseurs et leurs mutateurs.
        private int x6;
        public int X6 { get => x6; set => x6 = (value >= 0) ? value : 0; }
        public int X7 { get => x6; set => x6 = Math.Abs(value); } 

        // Propriétés automatiques
        public int X8 { get; set ; }   // C'est presque le même que la variable publique X8 : public int X8; 

        public int X9 { get; private set; } = 100;

    }
}
