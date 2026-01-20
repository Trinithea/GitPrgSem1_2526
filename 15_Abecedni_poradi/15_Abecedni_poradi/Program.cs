namespace _15_Abecedni_poradi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // První vstup: c<b a<c
            string[] vztahy = Console.ReadLine().Split();
            // ["c<b","a<c"]
            List<char> znakyAbecedy = new List<char>();
            for (int i = 0; i < vztahy.Length; i++) 
            {
                string vztah = vztahy[i];
                if (!znakyAbecedy.Contains(vztah[0]))
                    znakyAbecedy.Add(vztah[0]);
                if (!znakyAbecedy.Contains(vztah[2]))
                    znakyAbecedy.Add(vztah[2]);
            }
            // znakyAbecedy = {'c','b','a'}
            // vztahy = ["c<b","a<c"]
            int pocetVrcholu = znakyAbecedy.Count;
            int[,] graf = new int[pocetVrcholu,pocetVrcholu];
            foreach(string vztah in vztahy)
            {
                int indexZ = znakyAbecedy.IndexOf(vztah[0]);
                int indexDo = znakyAbecedy.IndexOf(vztah[2]);

                graf[indexZ,indexDo] = 1;
            }
            VypisGraf(graf, pocetVrcholu);

            /*
             * Spočítej vstupní stupně (in-degree) všech vrcholů (kolik hran do nich vede).
                Najdi vrcholy, do kterých nevede žádná hrana (vstupní stupeň = 0). To jsou zdroje.
                Vlož zdroje do fronty.
                Dokud fronta není prázdná:
                Vyber vrchol u, vypiš ho (přidej do seřazení).
                "Odstraň" ho z grafu -> projdi všechny jeho sousedy a sniž jim vstupní stupeň o 1.
                Pokud nějakému sousedovi klesne stupeň na 0, přidej ho do fronty.
            */
            // vstupní stupně vrcholů -> suma v sloupci
            int[] stupneVrcholu = new int[pocetVrcholu];
            for (int i = 0; i < pocetVrcholu; i++) // sloupce
            {
                int suma = 0;
                for (int j = 0; j < pocetVrcholu; j++) //buňky v řádcích sloupce
                {
                    suma += graf[j, i];
                }
                stupneVrcholu[i] = suma;    
            }

            // výpis 
            //for (int i = 0; i < stupneVrcholu.Length; i++)
              //  Console.WriteLine(stupneVrcholu[i]);

            // přidání zdrojů do fronty
            Queue<int> fronta = new Queue<int>();
            for (int i = 0; i < stupneVrcholu.Length; i++)
            {
                if (stupneVrcholu[i]==0)
                    fronta.Enqueue(i);
            }
            

         }
        static void VypisGraf(int[,] graf, int pocetVrcholu)
        {
            for (int i = 0; i < pocetVrcholu; i++)
            {
                for (int j = 0; j < pocetVrcholu; j++)
                {
                    Console.Write(graf[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
