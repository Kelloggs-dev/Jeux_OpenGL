using System;

using Microsoft.SqlServer.Server;

using OpenGLDotNet;


/*
 * 
 * 
 * Exemple de base d'une application OPENGL. Cet exemple est destiné au SIO 1B CCI de nimes. 
 * C'est une base pour développer un ensemble de projets - session 2022
 */
namespace BASE_OPEN_GL
{
    partial class Program
    {

        // vous pouvez mettre vos variables globales ici
        // vous pouvez mettre vos fonctions (méthodes statiques) ici


        static C_MONDE Le_Monde;
        static C_PERSONNAGE Personnage;
        static C_PROJECTIL Projectil;
        static C_ESPACE Espace = new C_ESPACE();
        //==========================================================
        // Cette fonction est invoquée qu'une seule fois avant que le moteur OpenGl travaille.
        // elle est utile pour initialiser des éléments globaux à l'application
        static void Initialisation_Animation()
        {
            OPENGL_Active_Reflexion();
            C_PERSONNAGE.Vaisseau_Texture = OPENGL_Charge_Texture("Vaiseau.jpeg.png");
            C_MUR.Border = OPENGL_Charge_Texture("Border_2.jpeg.png");
            C_ENNEMIE.Ennemie = OPENGL_Charge_Texture("Enemie.png");

            Le_Monde = new C_MONDE();
            for (int Index = 0; Index < 20; Index++) {
                C_MUR Mon_Objet;
                Le_Monde.Ajoute_Objet(Mon_Objet = new C_MUR(Index, 0, -0.25f,1));
                C_MUR Mon_Objet2;
                Le_Monde.Ajoute_Objet(Mon_Objet2 = new C_MUR(Index, 19, -0.25f,1));
                C_MUR Mon_Objet3;
                Le_Monde.Ajoute_Objet(Mon_Objet3 = new C_MUR(0, Index, -0.25f,1));
                C_MUR Mon_Objet4;
                Le_Monde.Ajoute_Objet(Mon_Objet4 = new C_MUR(19, Index, -0.25f,1));

            }
            for (int Index = 2; Index < 20; Index += 2) {
                C_ENNEMIE Mon_Object;
                Le_Monde.Ajoute_Objet(Mon_Object = new C_ENNEMIE(Index, 10, 0.5f,0.5f));
                C_ENNEMIE Mon_Object2;
                Le_Monde.Ajoute_Objet(Mon_Object2 = new C_ENNEMIE(Index, 15, 0.5f,0.5f));
            }
            Le_Monde.Ajoute_Objet(Personnage = new C_PERSONNAGE(9, 2, 1,1));

        }


        //==========================================================
        // Cette fonction est invoquée par le Moteur de manière périodique pour Afficher une Frame
        static void Afficher_Ma_Scene()
        {
            // c'est ici que vous pouvez coder l'affichage d'une frame


            GL.Translated(-10, -10, 0);
            Le_Monde.Affiche_Toi();
            if(Projectil != null) {
                Projectil.Deplacement_Projectil(0.03f);
                if(Projectil.Y >= Espace.Haut) {
                    Le_Monde.Remouve(Projectil);
                    Projectil = null;
                }
                
            }
            

        }

        //=========================================================
        // cette fonction est invoquée en boucle par openGl.
        // Peut être utilisée pour modifier des variables globales utilisée dans "Afficher_Ma_Scene"
        static void Animation_Scene()
        {

            //fortement recommandé
            FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
        }

        //======================================================================
        // cette fonction est invoquée par OpenGl lorsqu'on appuie sur une touche spéciale (flèches, Fx, ...)
        // P_Touche contient le code de la touche, P_X et P_Y contiennent les coordonnées de la souris quand on appuie sur une touche
        static void Gestion_Touches_Speciales(int P_Touche, int P_X, int P_Y)
        {
            if (P_Touche == FG.GLUT_KEY_F1) FG.FullScreen();
            if (P_Touche == FG.GLUT_KEY_F2) FG.LeaveFullScreen();



            //fortement recommandé
            FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
        }

        //======================================================================
        // cette fonction est invoquée par OpenGl lorsqu'on appuie sur une touche normale (A,Z,E, ...)
        // P_Touche contient le code de la touche, P_X et P_Y contiennent les coordonnées de la souris quand on appuie sur une touche
        static void Gestion_Clavier(byte P_Touche, int P_X, int P_Y)
        {
            // 27 est le code de la touche "Echap"
            if (P_Touche == 27) FG.LeaveMainLoop();
            switch (P_Touche) {
                case (byte)'a': {
                        Personnage.Deplace_Toi_G();
                    }
                    break;
                case (byte)'z': {
                        Personnage.Deplace_Toi_D();
                    }
                    break;
                case (byte)'e': {
                        if (Projectil == null) {
                            Projectil = new C_PROJECTIL(Personnage.X, Personnage.Y + 2, 0.25f, 0.25f);
                            Le_Monde.Ajoute_Objet(Projectil);
                        }
                    }break;
            }



            //fortement recommandé
            FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
        }

        //======================================================================
        // cette fonction est invoquée par OpenGl lorsqu'on relache une touche normale (A,Z,E, ...)
        // P_Touche contient le code de la touche, P_X et P_Y contiennent les coordonnées de la souris quand on relache sur une touche
        static void Gestion_Clavier_Relache(byte P_Touche, int P_X, int P_Y)
        {


            // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
        }

        //==================================================================================
        // cette fonction est invoquée par OpenGl lorsqu'on appuie sur un bouton de la souris
        // P_Bouton contient le code du bouton (gauche ou droite), P_Etat son etat, les coordonnées de la souris quand on appuie sur un bouton sont dans P_X et P_Y

        static void Gestion_Bouton_Souris(int P_Bouton, int P_Etat, int P_X, int P_Y)
        {

            //fortement recommandé
            FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
        }

        //====================================================================
        // cette fonction est invoquée par OpenGl lorsqu'on tourne la molette de la souris
        // P_Molette contient le code de la molette, P_Sens son sens de rotation, les coordonnées de la souris quand on tourne la molette sont dans P_X et P_Y

        static void Gestion_Molette(int P_Molette, int P_Sens, int P_X, int P_Y)
        {

            //  FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
        }

        //====================================================================
        // cette fonction est invoquée par OpenGl lorsqu'on bouge la souris sans appuyer sur un bouton
        // les coordonnées de la souris ont dans P_X et P_Y
        static void Gestion_Souris_Libre(int P_X, int P_Y)
        {

            // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
        }


        //====================================================================
        // cette fonction est invoquée par OpenGl lorsqu'on bouge la souris tout en appuyant sur un bouton
        // les coordonnées de la souris ont dans P_X et P_Y
        static void Gestion_Souris_Clique(int P_X, int P_Y)
        {

            // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
        }
    }
}
