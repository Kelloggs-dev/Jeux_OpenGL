using OpenGLDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE_OPEN_GL
{
    abstract public class C_OBJ_GRAPHIQUE
    {
        static C_ESPACE Espace = new C_ESPACE();

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public float DX { get; set; }
        public float DY { get; set; }


        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }

        public double Taille { get; set; }

        public C_OBJ_GRAPHIQUE()
        {
            X = 0;
            Y = 0;
            Z = 0;

            R = 1;
            G = 1;
            B = 1;

            Taille = 1;
        }
        public C_OBJ_GRAPHIQUE(float P_X,float P_Y)
        {
            X = P_X;
            Y = P_Y;
            Z = 0;

            R = 1;
            G = 1;
            B = 1;

            DX = 1f;

            Taille = 1;
        }
        public C_OBJ_GRAPHIQUE(float P_X,float P_Y,float P_Z)
        {
            X = P_X;
            Y = P_Y;
            Z = P_Z;

            R = 1;
            G = 1;
            B = 1;

            Taille = 1;
        }
        public C_OBJ_GRAPHIQUE(float P_X,float P_Y,float P_Z,double P_R,double P_G,double P_B)
        {
            X = P_X;
            Y = P_Y;
            Z = P_Z;

            R = P_R;
            G = P_G;
            B = P_B;

            Taille = 1;
        }
        public C_OBJ_GRAPHIQUE(float P_X, float P_Y, float P_Z, double P_R, double P_G, double P_B,double P_Taille)
        {
            X = P_X;
            Y = P_Y;
            Z = P_Z;

            R = P_R;
            G = P_G;
            B = P_B;

            Taille = P_Taille;
        }
        public void Affiche_Toi()
        {
            GL.PushMatrix();
            GL.Translated(X, Y, Z);
            GL.Color3d(R, G, B);
            Dessine_toi();
            GL.PopMatrix();
        }
        abstract protected void Dessine_toi();
        

        public void Deplace_Toi_D()
        {
            
            if (X < Espace.Droite) X += DX;
            
        } 
        public void Deplace_Toi_G()
        {
            
            if ( X > Espace.Gauche) X -= DX;
            
        }
        public void Deplacement_Projectil(float P_DY)
        {
            DY = P_DY;

            if (Y < Espace.Haut) Y += DY;

        }
    }
}
