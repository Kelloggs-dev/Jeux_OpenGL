using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE_OPEN_GL
{
    public class C_MONDE
    {
        List<C_OBJ_GRAPHIQUE> Les_Obj;

        public C_MONDE()
        {
            Les_Obj = new List<C_OBJ_GRAPHIQUE>();
        }

        public void Ajoute_Objet(C_OBJ_GRAPHIQUE P_Objet)
        {
            Les_Obj.Add(P_Objet);
        }
        public void Affiche_Toi()
        {
            int Taille = Les_Obj.Count;
            for (int Index = 0; Index < Taille; Index++) {
                Les_Obj[Index].Affiche_Toi();
            }
        }

        public void Remouve(C_OBJ_GRAPHIQUE Obj)
        {
            Les_Obj.Remove(Obj);
        }
        
    }
}
