using System;
using System.Collections.Generic;
using System.Timers;

namespace SeeWar
{
    class Program
    {
        static List<int> placetoshot = new List<int>() { };
        static int ipos = 0, kpos = 0, botscore = 0, plscore = 0;

        //метод створення кораблів
        static void setShip(int xcord, int ycord, char[,] matrix, bool del)
        {
            if (del == true)
            {
                matrix[ycord, xcord] = '□';
            }
            if (del == false)
            {

                matrix[ycord, xcord] = '◙';
            }


        }





        //метод перевірки правильності розташування кораблів
        static void shipCheck(char[,] playspace, ref bool gamestart)
        {
            int sum = 0, bordererror = 0, linkor=0, kreis = 0, esmin = 0 ,boat=0;

            //первинна перевірка
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                 
                    //загальна кількість палуб
                    if (playspace[i, k] == '◙')
                    {
                        sum += 1;
                    }
                    //пошук діагональних помилок 
                    if (i!=0 && i!=9 && k != 0 && k != 9 && playspace[i, k] == '◙'  )
                    {
                        if (playspace[i - 1, k - 1] == '◙' || playspace[i - 1, k + 1] == '◙' || playspace[i + 1, k + 1] == '◙' || playspace[i + 1, k - 1] == '◙')
                        {
                            bordererror += 1;
                        }
                    }    
                }  
            }

            if (sum != 20 || bordererror != 0 )
            {
                Console.Clear();
                Console.WriteLine("Неправильна кількість човнів або човни дотикаються, змініть для продовження");
                gamestart = false;
                return;
            }



            //вторинна перевірка
            else
            {
                //шукаємо та замінюємо чотирипалубні
                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        //кількість чотирипалубних горизонтально
                        if (i<7 && playspace[i, k] == '◙' && playspace[i+1, k] == '◙' && playspace[i+2, k] == '◙' && playspace[i+3, k] == '◙')
                        {
                            playspace[i, k] = '0';
                            playspace[i + 1, k] = '0';
                            playspace[i + 2, k] = '0';
                            playspace[i + 3, k] = '0';
                            linkor += 1;
                            if(1+4 < 10 && playspace[i + 4, k] == '◙')
                            {
                                linkor += 10;
                            }
                        }
                        //кількість чотирипалубних вертикально
                        else if (k<7 && playspace[i, k] == '◙' && playspace[i, k + 1] == '◙' && playspace[i, k + 2] == '◙' && playspace[i, k + 3] == '◙')
                        {
                            playspace[i, k] = '0';
                            playspace[i, k+1] = '0';
                            playspace[i, k+2] = '0';
                            playspace[i, k+3] = '0';
                            linkor += 1;

                            if (k + 4 < 10 && playspace[i, k + 4] == '◙')
                            {
                                linkor += 10;
                            }
                        }
                    }
                }



                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < 10; k++)
                    {

                        //кількість трипалубних
                        if (i<8 && playspace[i, k] == '◙' && playspace[i + 1, k] == '◙' && playspace[i + 2, k] == '◙')
                        {
                            playspace[i, k] = '0';
                            playspace[i + 1, k] = '0';
                            playspace[i + 2, k] = '0';
                            kreis += 1;
                        }
                        else if (k<8 && playspace[i, k] == '◙' && playspace[i, k + 1] == '◙' && playspace[i, k + 2] == '◙')
                        {
                            playspace[i, k] = '0';
                            playspace[i, k + 1] = '0';
                            playspace[i, k + 2] = '0';
                            kreis += 1;
                        }

                    }
                }
               




                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        //кількість двопалубних
                        if (i<9 && playspace[i, k] == '◙' && playspace[i + 1, k] == '◙')
                        {
                            playspace[i, k] = '0';
                            playspace[i + 1, k] = '0';
                            esmin += 1;
                        }
                        else if (k<9 && playspace[i, k] == '◙' && playspace[i, k + 1] == '◙')
                        {
                            playspace[i, k] = '0';
                            playspace[i, k + 1] = '0';
                            esmin += 1;
                        }
                    }
                }




                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        //кількість однопалубних 
                        if (playspace[i, k] == '◙' && linkor == 1 && kreis == 2 && esmin == 3)
                        {
                            playspace[i, k] = '0';
                            boat += 1;
                        }

                    }
                }










               
                


                

                


















                //перевіряємо кулькусть кораблів кожного типу
                if (linkor != 1 || kreis != 2 || esmin != 3 || boat != 4)
                {
                    Console.Clear();
                    Console.WriteLine("Неправильне, неправильна кількість човнів змініть для продовження");
                    gamestart = false;
                }
                else
                {
                    //повернення матриці до початкового вигляду
                    for (int i = 0; i < 10; i++)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                             
                            if (playspace[i, k] == '0')
                            {
                                playspace[i, k] = '◙';
                            }

                        }
                    }
                    //починаємо гру
                    gamestart = true;
                    
                }
            }

            
        }




        //метод відображення ігрового поля
        static void showPlaySpace(char[,] plmatrix, char[,] clear, int cordx, int cordy, bool startgame, int plscore, int btscore)
        {
            if (startgame == false) 
            {
                Console.Clear();
                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        Console.Write(plmatrix[i, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(cordx * 2, cordy);
            }




            else if (startgame == true)
            {
                Console.Clear();
                for (int i = 0; i < 10; i++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        Console.Write(plmatrix[i, k] + " ");
                    }

                    Console.Write("\t||\t");
                    
                    for (int k = 0; k < 10; k++)
                    {
                        Console.Write(clear[i, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"Your score = {plscore} "+"\t||\t"+$"Oppponent score = {btscore} ");
                Console.SetCursorPosition(cordx * 2 + 32, cordy);
            }



        }



        //метод для пострілу
        static void makeShot(int xcord, int ycord, char[,] playerm, char[,] botm, char[,] clear, string user, string level)
        {
            if(user == "user")
            {
                if (botm[ycord, xcord] == '□')
                {
                    clear[ycord, xcord] = '□';
                }
                if (botm[ycord, xcord] == '◙')
                {
                    botm[ycord, xcord] = '□';
                    clear[ycord, xcord] = '*';
                    plscore++;
                }
            }




            //перший рівень складності
            if (user == "bot" && level == "1")
            {
                
                if (playerm[ipos,kpos] == '□')
                {
                    playerm[ipos, kpos] = '.';
                    if (kpos > 8)
                    {
                        kpos = 0;
                        ipos++;
                    }
                    else
                    {
                        kpos++;
                    }
                }
                if (playerm[ipos, kpos] == '◙')
                {

                    playerm[ipos, kpos] = '*';

                    if (kpos > 8)
                    {
                        kpos = 0;
                        ipos++;
                    }
                    else
                    {
                        kpos++;
                    }
                    botscore++;



                    
                }
            }




            // другий рівень складності
            if (user == "bot" && level == "2")
            {
                ipos = placetoshot[0] / 10;
                kpos = placetoshot[0] % 10;

                if (playerm[ipos, kpos] == '□')
                {
                    placetoshot.RemoveAt(0);
                    playerm[ipos, kpos] = '.';

                }
                if (playerm[ipos, kpos] == '◙')
                {
                    playerm[ipos, kpos] = '*';


                    placetoshot.RemoveAt(0);
                    // лівий верхній діагональний
                    if ((ipos - 1) * 10 >= 0 && kpos -1 >=0)
                    {
                        placetoshot.Remove((ipos - 1) * 10 + kpos-1);
                        //playerm[ipos, kpos] = '.';
                    }

                    //лівий нижній
                    if ((ipos +1) * 10 < 100 && kpos - 1 >= 0)
                    {
                        placetoshot.Remove((ipos + 1) * 10 + kpos - 1);
                        //playerm[ipos, kpos] = '.';
                    }

                    //правий нижній
                    if ((ipos + 1) * 10 < 100 && kpos + 1 < 10)
                    {
                        placetoshot.Remove((ipos + 1) * 10 + kpos + 1);
                        //playerm[ipos, kpos] = '0';
                    }

                    //правий верхній
                    if ((ipos - 1) * 10 >= 0 && kpos + 1 < 10)
                    {
                        placetoshot.Remove((ipos - 1) * 10 + kpos + 1);
                        //playerm[ipos + 1, kpos + 1] = '0';

                    }
                    botscore++;
                }
            }




            // третій рівень складності
            if (user == "bot" && level == "3")
            {
                ipos = placetoshot[0] / 10;
                kpos = placetoshot[0] % 10;

                if (playerm[ipos, kpos] == '□')
                {
                    placetoshot.RemoveAt(0);
                    playerm[ipos, kpos] = '.';

                }

                if (playerm[ipos, kpos] == '◙')
                {
                    playerm[ipos, kpos] = '*';


                    placetoshot.RemoveAt(0);
                    // лівий верхній діагональний
                    if ((ipos - 1) * 10 >= 0 && kpos - 1 >= 0)
                    {
                        placetoshot.Remove((ipos - 1) * 10 + kpos - 1);
                        //playerm[ipos, kpos] = '.';
                    }

                    //лівий нижній
                    if ((ipos + 1) * 10 < 100 && kpos - 1 >= 0)
                    {
                        placetoshot.Remove((ipos + 1) * 10 + kpos - 1);
                        //playerm[ipos, kpos] = '.';
                    }

                    //правий нижній
                    if ((ipos + 1) * 10 < 100 && kpos + 1 < 10)
                    {
                        placetoshot.Remove((ipos + 1) * 10 + kpos + 1);
                        //playerm[ipos, kpos] = '0';
                    }

                    //правий верхній
                    if ((ipos - 1) * 10 >= 0 && kpos + 1 < 10)
                    {
                        placetoshot.Remove((ipos - 1) * 10 + kpos + 1);
                        //playerm[ipos + 1, kpos + 1] = '0';

                    }
                    botscore++;

                    if ((ipos +1) < 10)
                    {

                        int index = placetoshot.BinarySearch((ipos+1)*10 + kpos);
                        
                        if(index >= 0)
                        {
                            int elem = placetoshot[index];
                            //placetoshot.Insert(index, placetoshot[1]);
                            placetoshot.RemoveAt(index);
                            placetoshot.Insert(1, elem);
                            
                        }

                    }
                }
            }

            if (botscore == 20|| plscore == 20)
            {
                Final();
            }



        }



        //метод для створення поля бота
        static void createBotSpace(char[,] playermatrix, char[,] botmatrix)
        {

            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    botmatrix[i, k] = playermatrix[i, k];
                }
            }
            
            Random rnd = new Random();
            int amount = rnd.Next(5,20);
            for (int i = 0; i <= amount; i++)
            {
                //відображення
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (i < 5)
                        {
                            botmatrix[j, k] = botmatrix[9 - j, k];
                        }

                        if (i > 5)
                        {
                            char symb = playermatrix[9 - j, k];
                            botmatrix[j, k] = symb;
                        }
                    }
                }

                ////транспонування
                //for (int a = 0; a < 10; ++a)
                //{
                //    for (int b = i; b < 10; ++b)
                //    {
                //        char t = botmatrix[a, b];
                //        botmatrix[a, b] = botmatrix[b, a];
                //        botmatrix[b, a] = t;
                //    }

                //}
            }
        }




        //Кінець гри
        static void Final()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"це кінець, дякую за гру, було приємно\nрахунок компьютера {botscore}, а ваш {plscore}");
                if(botscore > plscore)
                {
                    Console.WriteLine("На жаль ви програли");
                }
                else if(botscore < plscore)
                {
                    Console.WriteLine("Вітаємо з перемогою");
                }
                

                Console.ReadKey();
            }
        }










        //основне тіло гри
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            char hiden = '■';
            char empty = '□';
            char shot = '▣';
            int x, y;
            string level;
            bool gameStarted = false;
             
            ConsoleKeyInfo KeyInfo;

            int redo = 0, leftdist = 0, updist = 0;
            Console.SetCursorPosition(leftdist, updist);
            char[,] botmatrix = new char[10, 10];
            char[,] playspace = new char[10, 10];
            char[,] clear = new char[10, 10];

            for (int i = 0; i < 100; i++)
            {
                placetoshot.Add(i);
                //Console.Write(i + " ");

            }

                           
            //Console.Write("\n**"+placetoshot.BinarySearch(200));

           

            //заповнення поля порожніми символами
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    playspace[i, k] = empty;
                }

            }
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    clear[i, k] = hiden;
                }

            }













            //Початок гри
            //головне меню
            while (true)
            {
                Console.WriteLine("\t\tВітаю в грі морський бій,\n\nознайомлю трохи з керуванням та правилами:\n для початку  необхiдно буде обрати рівень cкладності,\n для цього просто введи відповідну цифру та натисни <enter>\n далі розташуй кораблі, згідно з правилами\n переміщення за допомогою стрілок, розміщення за допомогою\n <enter>, видалення за допомогою <del>, початок гри - <P>)\n\n \tПравила:\n у вас на озброєнні знаходится:\n1 лінкор(4 клітинки),\n2 крейсери(3 клітинки),\n3 есмінці(2 клітинки) та \n4 катери(1 клітинка)\n\n\tРівні складності:\n1. легко\n2. середньо\n3. важко ");
                Console.Write("\n\nрівень складності\n");
                level = Console.ReadLine();
                Console.Clear();
                if (level == "1" || level == "2" || level == "3")
                {
                    break;
                }
            }

            //виводимо поле
            showPlaySpace(playspace,clear, leftdist, updist, gameStarted, plscore, botscore);





            

            //заповнення поля
            do
            {
                //рух по полю
                KeyInfo = Console.ReadKey(true);

                switch (KeyInfo.Key)
                {

                    //рух праворуч
                    case ConsoleKey.RightArrow:
                        if (gameStarted != true && leftdist + 2 <= 18)
                        {
                            leftdist += 2;
                            Console.SetCursorPosition(leftdist, updist);
                            break;
                        }
                        else if(gameStarted == true && leftdist <= 48)
                        {
                            leftdist += 2;
                            Console.SetCursorPosition(leftdist, updist);
                            break;
                        }
                        else
                        {
                            break;
                        }




                    //рух ліворуч
                    case ConsoleKey.LeftArrow:
                        if (gameStarted != true && leftdist >= 2)
                        {
                            leftdist -= 2;
                            Console.SetCursorPosition(leftdist, updist);
                            break;
                        }
                        else if (gameStarted == true && leftdist >= 34 )
                        {
                            leftdist -= 2;
                            Console.SetCursorPosition(leftdist, updist);
                            break;
                        }
                        else
                        {
                            break;
                        }







                    //рух догори
                    case ConsoleKey.UpArrow :
                        if (updist > 0)
                        {
                            updist--;
                            Console.SetCursorPosition(leftdist, updist);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    //рух донизу
                    case ConsoleKey.DownArrow:
                        if (updist + 1 <= 9)
                        {
                            updist++;
                            Console.SetCursorPosition(leftdist, updist);
                            break;
                        }
                        else
                        {
                            break;
                        }






                        //створення корабля або постріл
                    case ConsoleKey.Enter:
                        //створення
                        if (gameStarted != true)
                        {
                            x = leftdist / 2;
                            y = updist;
                            setShip(x, y, playspace, false);

                            showPlaySpace(playspace,clear, leftdist / 2, updist, gameStarted, plscore, botscore);
                            break;
                        }
                        //постріл
                        else
                        {
                            x = (leftdist-32) / 2;
                            y = updist;
                            makeShot(x, y, playspace, botmatrix, clear, "user",level);
                            makeShot(x, y, playspace, botmatrix, clear, "bot", level);
                            showPlaySpace(playspace, clear, x, updist, gameStarted, plscore, botscore);
                            break;
                        }


                        //видалення комірки човна
                    case ConsoleKey.Delete:
                        x = leftdist / 2;
                        y = updist;
                        if (gameStarted != true)
                        {
                            setShip(x, y, playspace, true);

                            showPlaySpace(playspace,clear, leftdist / 2, updist, gameStarted, plscore, botscore);
                            break;
                        }
                        else
                        {
                            break;
                        }
                        


                    case ConsoleKey.P:

                        if (gameStarted != true)
                        {
                            shipCheck(playspace, ref gameStarted);
                            if (gameStarted == true)
                            {
                                createBotSpace(playspace,botmatrix);
                                showPlaySpace(playspace,clear, leftdist / 2, updist, gameStarted, plscore, botscore);
                                leftdist = 32;
                                updist = 0;
                                Console.SetCursorPosition(leftdist, updist);
                                    

                            }
                            
                            break;
                        }
                        else
                        {
                            break;
                        }
                        
                }
            }
            while (redo == 0);





            //char chose = Console.ReadKey(true);
        }

        
    }
}

