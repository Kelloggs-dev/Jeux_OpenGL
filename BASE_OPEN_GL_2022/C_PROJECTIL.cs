using OpenGLDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE_OPEN_GL
{
    public class C_PROJECTIL :C_CUBE
    {
        public static uint Projectil;
        public C_PROJECTIL()
        {

        }
        public C_PROJECTIL(float P_X, float P_Y, float P_Taille_X,float P_Taille_Y) : base(P_X, P_Y, P_Taille_X, P_Taille_Y)
        {

        }
        public C_PROJECTIL(float P_X, float P_Y, float P_Z, float P_Taille_X, float P_Taille_Y) : base(P_X, P_Y, P_Z, P_Taille_X, P_Taille_Y)
        {

        }
        public C_PROJECTIL(float P_X, float P_Y, float P_Z, double P_R, double P_G, double P_B, float P_Taille_X, float P_Taille_Y) : base(P_X, P_Y, P_Z, P_R, P_G, P_B, P_Taille_X, P_Taille_Y)
        {

        }
        protected override void Texture()
        {
            GL.BindTexture(GL.GL_TEXTURE_2D, Projectil);
            GL.Enable(GL.GL_TEXTURE_2D);
        }
    }
}
