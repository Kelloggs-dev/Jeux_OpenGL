using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenGLDotNet;

namespace BASE_OPEN_GL
{
	partial class Program
	{
		 static void Main()
		{

			Initialisation_3D();
			FG.ReshapeFunc(On_Changement_Taille_Fenetre);	
			FG.DisplayFunc(On_Afficher_Scene);
			FG.KeyboardFunc(Gestion_Clavier);
      FG.KeyboardUpFunc(Gestion_Clavier_Relache);
      FG.SpecialFunc(Gestion_Touches_Speciales);
			FG.IdleFunc(Animation_Scene);
			FG.MouseFunc(Gestion_Bouton_Souris);
			FG.MouseWheelFunc(Gestion_Molette);
			FG.PassiveMotionFunc(Gestion_Souris_Libre);
			FG.MotionFunc(Gestion_Souris_Clique);

			Initialisation_Animation();
			FG.MainLoop();
		}
	}
}
 