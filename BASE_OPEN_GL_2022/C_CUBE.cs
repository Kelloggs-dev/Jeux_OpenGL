using OpenGLDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BASE_OPEN_GL
{
    abstract public class C_CUBE : C_OBJ_GRAPHIQUE
    {
        public float Taille_X { get; set; }
        public float Taille_Y { get; set; }
        public C_CUBE()
        {
            Taille_X = 0;
            Taille_Y = 0;
        }
        public C_CUBE(float P_X, float P_Y) : base(P_X, P_Y)
        {

        }
        public C_CUBE(float P_X, float P_Y, float P_Taille_X, float P_Taille_Y) : base(P_X, P_Y)
        {
            Taille_X = P_Taille_X;
            Taille_Y = P_Taille_Y;
        }
        public C_CUBE(float P_X, float P_Y, float P_Z, float P_Taille_X, float P_Taille_Y) : base(P_X, P_Y, P_Z)
        {
            Taille_X = P_Taille_X;
            Taille_Y = P_Taille_Y;
        }
        public C_CUBE(float P_X, float P_Y, float P_Z, double P_R, double P_G, double P_B, float P_Taille_X, float P_Taille_Y) : base(P_X, P_Y, P_Z, P_R, P_G, P_B)
        {
            Taille_X = P_Taille_X; 
            Taille_Y = P_Taille_Y;
        }
        protected override void Dessine_toi()
        {
            Texture();
            GL.Begin(GL.GL_QUAD_STRIP);
            GL.TexCoord2d(0, 1); GL.Vertex3d(-Taille_X, -Taille_Y, 0);
            GL.TexCoord2d(1, 1); GL.Vertex3d(Taille_Y, -Taille_Y, 0);
            GL.TexCoord2d(0, 0); GL.Vertex3d(-Taille_X, Taille_Y, 0);
            GL.TexCoord2d(1, 0); GL.Vertex3d(Taille_Y, Taille_Y, 0);
            GL.End();
            GL.Disable(GL.GL_TEXTURE_2D);


        }
        abstract protected void Texture();
    }
}
