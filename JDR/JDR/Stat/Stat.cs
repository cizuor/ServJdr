using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR
{
    abstract class Stat
    {
        public int id;
        public int valeur;
        abstract public int GetValue(Perso perso);
        abstract public int GetValueForTest(Perso perso);

        public enum Typestats
        {
            Base = 0,
            Secondaire = 1,
            Calculé = 2
        }


        public enum stats
        {
            CC = 0,
            CT = 1,
            Ag = 2,
            F = 3,
            E = 4,
            At = 5,
            Int = 6,
            Fm = 7,
            Magie = 8,
            P = 9,
            Soc = 10,
            PV = 11,
            Armure = 12,
            RM = 13,
            DegatCrit = 14,
            ChanceCrit = 15,
            Dos = 16,
            Ps = 17,
            Degats = 18,
            ResistanceEcho = 19,
            ResistanceCaC = 20,
            ResistanceDist = 21,
            Acrobatie = 22,
            Escalade = 23,
            Mensonge = 24,
            Charisme = 25,
            Marchandage = 26,
            DeplacementSilentieux = 27,
            Dissimulation = 28,
            PointAction = 29,
            Mouvement = 30,
            VolALaTir = 31,
            Vol = 32,
            Parade = 33,
            Riposte = 34,
            ResistanceMutation = 35,
            Fuite = 36,
            Initiative = 37,
            CoefExperience = 38,
            VisonNocturne = 39,
            PVisuel = 40,
            PAuditive = 41,
            POlfactive = 42,
            PToucher = 43,
            Apnee = 44,
            Menace = 45,
            Torture = 46,
            Noeud = 47,
            Encaissement = 48,
            Natation = 49,
            Cartographe = 50,
            Herboristerie = 51,
            Alchimie = 52,
            ResistanceAlcool = 53,
            RegenNuit = 54,
            ResistanceMaladie = 55,
            Pistage = 56,
            Equitation = 57,
            Taille = 58,
            Poid = 59,
            Age = 60,
            ResistanceCritique = 61,
            PointDestin = 62,
            PerceptionMagique = 63,
            Navigation = 64,
            ViePet = 65,
            DegatsPet = 66,
            ToucherPet = 67,
            EsquivePet = 68,
            ForcePet = 69,
            EnduPet = 70,
            CritPet = 71,
            PAPet = 72,
            MouvementPet = 73,
            DegatSubit = 74,
            DegatInfliger = 75,
            DegatSubitMagique = 76,
            DegatInfligerMagique = 77,
            DegatSubitPhysique = 78,
            DegatInfligerPhysique = 79,
            NBPetS = 80,
            NBPetM = 81,
            NBPetL = 82,

        }
    }
}
