using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_1._2
{ 
    class Program
    {
        
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"iris.data");    //verisetindeki dosya işlemleri 
            string[] liste = System.IO.File.ReadAllLines(@"iris.data");          
            ArrayList array = new ArrayList(); //Ekleme ve silme işlemlerinde kullanılan arraylist
            foreach (String item in liste) 
            {
                array.Add(item);
            }
            while (true)
            {
                Console.WriteLine("1-)Tahminleme İşlemi(Bitki Sınıflandırma)" + "\n" + "2-)Ekleme İşlemi" + "\n" + "3-)İndise Bağlı Silme İşlemi" + "\n" + "4-)Tüm Listeyi Silme İşlemi" + "\n" +"5-Listeleme İşlemi"+"\n"+ "0-)Çıkış");
                int menu;
                Console.Write("Hangi işlemi yapacağınızı seçiniz : ");
                menu = Convert.ToInt32(Console.ReadLine());
                if (menu==0)
                {
                    Console.WriteLine("Çıkış yapılıyor.....");
                    break;
                }
                if (menu==1)
                {
                    int k; 
                    Console.Write("k değerini giriniz: ");
                    k = Convert.ToInt32(Console.ReadLine());

                    int giris; //Tahminleme için girilecek özellik sayısı
                    Console.Write("Kaç giriş yapmak istiyorsunuz (2-4)? : ");
                    giris = Convert.ToInt32(Console.ReadLine());


                    if (giris == 2) //2 giriş için başlangıç
                    {

                        String yaprak;
                        Console.Write("Taç Yaprak mı Çanak Yaprak mı ?(Taç ise Taç,Çanak ise Çanak giriniz)  ");
                        yaprak = Console.ReadLine();
                        if (yaprak == "Taç")   //2 giriş için taç yaprak başlangıcı
                        {
                            double[] ozellik = new double[giris]; //2 giriş inputunu tutan array

                            Console.Write("Taç Yaprak Uzunluğunu giriniz(Double bir değer girmek isterseniz virgülle giriniz): ");
                            ozellik[0] = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Taç Yaprak Genişlğini giriniz(Double bir değer girmek isterseniz virgülle giriniz): ");
                            ozellik[1] = Convert.ToDouble(Console.ReadLine());
                            ///////////////
                            double[,] listeCopy = new double[liste.Length,2];//Distance değerlerini ve indexleri tutan 2 boyutlu array
                            for (int i = 0; i < liste.Length; i++)
                            {

                                string[] temp = liste[i].Split(','); //Listede bulunan değerlerin içindeki elemanlara erişip onu tempe attık
                               
                                //Temp'deki değerler 5.2 yerine 52 gibi alındığı için 10'a bölme yapıldı.
                                double a = Math.Sqrt(Math.Pow(ozellik[0] - Convert.ToDouble(temp[2]) / 10, 2) +
                                            Math.Pow(ozellik[1] - Convert.ToDouble(temp[3]) / 10, 2));
                                listeCopy[i, 0] = a;
                                listeCopy[i, 1] = i;

                            }
                            //k değerine bağlı çıkan çiçeklerin hangisinden kaç tane olduğunu belirten değişkenler
                            int Setosa = 0;
                            int Versicolor = 0;
                            int Virginica = 0;
                            ////çıkan eşitlik durumunda ilk gelen çiçeği bulmak için kullanılan bir değişkenler
                            int kucukindex = 0;
                            int flag = 0;

                            for (int i = 0; i < k; i++)
                            {
                                double enkucuk = 9998;

                                double index = 0;
                                for (int j = 0; j < liste.Length; j++)
                                {
                                    if (listeCopy[j, 0] < enkucuk)
                                    {
                                        enkucuk = listeCopy[j, 0];
                                        index = j;
                                    }
                                }
                                if (flag == 0)
                                {
                                    kucukindex = Convert.ToInt32(index);
                                }
                                flag++;
                                Console.WriteLine();
                                Console.WriteLine(liste[Convert.ToInt32(index)] + "  " + listeCopy[Convert.ToInt32(index), 0]);
                                Console.WriteLine();
                                listeCopy[Convert.ToInt32(index), 0] = 9999;

                                if (liste[Convert.ToInt32(index)].Split(',')[4] == "Iris-setosa")
                                {
                                    Setosa++;
                                }
                                else if (liste[Convert.ToInt32(index)].Split(',')[4] == "Iris-versicolor")
                                {
                                    Versicolor++;
                                }
                                else if (liste[Convert.ToInt32(index)].Split(',')[4] == "Iris-virginica")
                                {
                                    Virginica++;
                                }
                            }
                            if (Setosa > Versicolor && Setosa > Virginica)
                            {
                                Console.WriteLine("**Tahminlenen çiçek türü: Iris-setosa**");
                                Console.WriteLine();
                            }
                            else if (Versicolor > Setosa && Versicolor > Virginica)
                            {
                                Console.WriteLine("**Tahminlenen çiçek türü: Iris-versicolor**");
                                Console.WriteLine();
                            }
                            else if (Virginica > Setosa && Virginica > Versicolor)
                            {
                                Console.WriteLine("**Tahminlenen çiçek türü: Iris-virginica**");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine(liste[kucukindex].Split(',')[4]);
                                Console.WriteLine();
                            }

                        }
                        else  //2 giriş için çanak yaprak başlangıcı
                        {
                            double[] ozellik = new double[giris]; //2 giriş inputunu tutan array

                            Console.Write("Çanak Yaprak Uzunluğunu giriniz(Double bir değer girmek isterseniz virgülle giriniz): ");
                            ozellik[0] = Convert.ToDouble(Console.ReadLine());

                            Console.Write("Çanak Yaprak Genişliğini giriniz(Double bir değer girmek isterseniz virgülle giriniz): ");
                            ozellik[1] = Convert.ToDouble(Console.ReadLine());
                            /////////////////////////////////////
                            double[,] listeCopy = new double[liste.Length,2];
                            for (int i = 0; i < liste.Length; i++)
                            {
                                string[] temp = liste[i].Split(',');                               
                                //Temp'deki değerler 5.2 yerine 52 gibi alındığı için 10'a bölme yapıldı.
                                double a = Math.Sqrt(Math.Pow(ozellik[0] - Convert.ToDouble(temp[0]) / 10, 2) +
                                    Math.Pow(ozellik[1] - Convert.ToDouble(temp[1]) / 10, 2));

                                listeCopy[i, 0] = a;
                                listeCopy[i, 1] = i;

                            }

                            int Setosa = 0;
                            int Versicolor = 0;
                            int Virginica = 0;
                            int kucukindex = 0;
                            int flag = 0;

                            for (int i = 0; i < k; i++)
                            {
                                double enkucuk = 9998;
                                double index = 0;
                                for (int j = 0; j < listeCopy.GetLength(0); j++)
                                {
                                    if (listeCopy[j, 0] < enkucuk)
                                    {
                                        enkucuk = listeCopy[j, 0];
                                        index = j;
                                    }                                  
                                }
                                if (flag == 0)
                                {
                                    kucukindex = Convert.ToInt32(index);
                                }
                                flag++;
                                Console.WriteLine();
                                Console.WriteLine(liste[Convert.ToInt32(index)] + "  " + listeCopy[Convert.ToInt32(index), 0]);
                                Console.WriteLine();
                                listeCopy[Convert.ToInt32(index), 0] = 9999;

                                if (liste[Convert.ToInt32(index)].Split(',')[4] == "Iris-setosa")
                                {
                                    Setosa++;
                                }
                                else if (liste[Convert.ToInt32(index)].Split(',')[4] == "Iris-versicolor")
                                {
                                    Versicolor++;
                                }
                                else if (liste[Convert.ToInt32(index)].Split(',')[4] == "Iris-virginica")
                                {
                                    Virginica++;
                                }
                            }
                            if (Setosa > Versicolor && Setosa > Virginica)
                            {
                                Console.WriteLine("**Tahminlenen çiçek türü: Iris-setosa**");
                                Console.WriteLine();
                            }
                            else if (Versicolor > Setosa && Versicolor > Virginica)
                            {
                                Console.WriteLine("**Tahminlenen çiçek türü: Iris-versicolor**");
                                Console.WriteLine();
                            }
                            else if (Virginica > Setosa && Virginica > Versicolor)
                            {
                                Console.WriteLine("**Tahminlenen çiçek türü: Iris-virginica**");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine(liste[kucukindex].Split(',')[4]);
                                Console.WriteLine();
                            }
                        }
                    }
                    else  //4 giriş başlangıcı
                    {
                        double[] ozellik = new double[4]; //4 giriş inputunu tutan array

                        Console.Write("Çanak Yaprak Uzunluğunu giriniz(Double bir değer girmek isterseniz virgülle giriniz): ");
                        ozellik[0] = Convert.ToDouble(Console.ReadLine());


                        Console.Write("Çanak Yaprak Genişliğini giriniz(Double bir değer girmek isterseniz virgülle giriniz): ");
                        ozellik[1] = Convert.ToDouble(Console.ReadLine());


                        Console.Write("Taç Yaprak Uzunluğunu giriniz(Double bir değer girmek isterseniz virgülle giriniz): ");
                        ozellik[2] = Convert.ToDouble(Console.ReadLine());


                        Console.Write("Taç Yaprak Genişlğini giriniz(Double bir değer girmek isterseniz virgülle giriniz): ");
                        ozellik[3] = Convert.ToDouble(Console.ReadLine());

                        double[,] listeCopy = new double[liste.Length, 2];
                        for (int i = 0; i < liste.Length; i++)
                        {

                            string[] temp = liste[i].Split(',');                          
                            //Temp'deki değerler 5.2 yerine 52 gibi alındığı için 10'a bölme yapıldı.
                            double a = Math.Sqrt(Math.Pow(ozellik[0] - Convert.ToDouble(temp[0]) / 10, 2) +
                                Math.Pow(ozellik[1] - Convert.ToDouble(temp[1]) / 10, 2) +
                                Math.Pow(ozellik[2] - Convert.ToDouble(temp[2]) / 10, 2) +
                                Math.Pow(ozellik[3] - Convert.ToDouble(temp[3]) / 10, 2));
                            listeCopy[i, 0] = a;
                            listeCopy[i, 1] = i;

                        }

                        int Setosa = 0;
                        int Versicolor = 0;
                        int Virginica = 0;
                        int kucukindex = 0;
                        int flag = 0;

                        for (int i = 0; i < k; i++)
                        {
                            double enkucuk = 9998;

                            double index = 0;
                            for (int j = 0; j < listeCopy.GetLength(0); j++)
                            {
                                if (listeCopy[j, 0] < enkucuk)
                                {
                                    enkucuk = listeCopy[j, 0];
                                    index = j;

                                }
                                
                            }
                            if (flag == 0)
                            {
                                kucukindex = Convert.ToInt32(index);
                            }
                            flag++;
                            Console.WriteLine();
                            Console.WriteLine(liste[Convert.ToInt32(index)] + "  " + listeCopy[Convert.ToInt32(index), 0]);
                            Console.WriteLine();
                            listeCopy[Convert.ToInt32(index), 0] = 9999;

                            if (liste[Convert.ToInt32(index)].Split(',')[4] == "Iris-setosa")
                            {
                                Setosa++;
                            }
                            else if (liste[Convert.ToInt32(index)].Split(',')[4] == "Iris-versicolor")
                            {
                                Versicolor++;
                            }
                            else if (liste[Convert.ToInt32(index)].Split(',')[4] == "Iris-virginica")
                            {
                                Virginica++;
                            }


                        }
                        if (Setosa > Versicolor && Setosa > Virginica)
                        {
                            Console.WriteLine("Tahminlenen çiçek türü: **Iris-setosa**");
                            Console.WriteLine();
                        }
                        else if (Versicolor > Setosa && Versicolor > Virginica)
                        {
                            Console.WriteLine("**Tahminlenen çiçek türü: Iris-versicolor**");
                            Console.WriteLine();
                        }
                        else if (Virginica > Setosa && Virginica > Versicolor)
                        {
                            Console.WriteLine("Tahminlenen çiçek türü: **Iris-virginica**");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(liste[kucukindex].Split(',')[4]);
                            Console.WriteLine();
                        }
                    }
                }
                if (menu==2)
                {
                    Console.Write("Tür ismini giriniz : "); 
                    
                    string eklenecekTur= Console.ReadLine();
                    Console.WriteLine("Çanak Yaprak uzunluğu (Değerleri (2.0 , 5.5 , 3.9 , 3.6  gibi noktalı bir şekilde giriniz.):");
                    string cu = Console.ReadLine();
                    Console.WriteLine("Çanak Yaprak Genişliği Değerleri (2.0 , 5.5 , 3.9 , 3.6 gibi noktalı bir şekilde giriniz.):");
                    string cg = Console.ReadLine();
                    Console.WriteLine("Taç Yaprak Uzunluğu Değerleri (2.0 , 5.5 , 3.9 , 3.6  gibi noktalı bir şekilde giriniz.):");
                    string tu = Console.ReadLine();
                    Console.WriteLine("Taç Yaprak Genişliği Değerleri (2.0 , 5.5 , 3.9 , 3.6  gibi noktalı bir şekilde giriniz.):");
                    string tg = Console.ReadLine();
                    array.Add(cu+","+cg+","+tu+","+tg+","+eklenecekTur);
                    liste = new string[liste.Length +1];
                    for (int i = 0; i < array.Count; i++)
                    {
                        liste[i] = array[i].ToString();
                    }
                    Console.WriteLine();
                    Console.WriteLine("Ekleme başarıyla yapıldı.");
                    Console.WriteLine();

                }
                if (menu==3)
                {
                    int silinecek;
                    Console.Write("Kaçıncı indisi silmek istiyorsunuz? : ");
                    silinecek = Convert.ToInt32(Console.ReadLine());
                    array.RemoveAt(silinecek);
                    liste = new string[liste.Length - 1];
                    for (int i = 0; i < array.Count; i++)
                    {
                        liste[i] = array[i].ToString();
                    }
                    Console.WriteLine();
                    Console.WriteLine("Silme işlemi başarıyla yapıldı...");
                    Console.WriteLine();
                }
                if (menu==4)
                {
                    liste = new string[0];
                    Console.WriteLine();
                    Console.WriteLine("Silme işlemi başarıyla yapıldı...");
                    Console.WriteLine();
                }
                if (menu==5)
                {
                    foreach (string item in liste)
                    {
                        Console.WriteLine(item);                       
                    }
                    if (liste.Length==0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Liste boş...");
                        Console.WriteLine();
                    }
                    Console.WriteLine("Devam etmek için herhangi bir tuşa basınız..");
                    Console.ReadKey();
                }               
            }
                     
        }

    }

}