// задача 1

// using System;

// namespace ConsoleApplication1
// {
//     class Dot
//     {
//         public int x;
//         public int y;
//         static Random rnd = new Random();

//         public Dot(int x, int y)
//         {
//             this.x = x;
//             this.y = y;
//         }

//         public void Move()
//         {
//             x += rnd.Next(-2, 3); // Корректировка: верхняя граница не включается
//             y += rnd.Next(-2, 3); // Корректировка: верхняя граница не включается
//         }
//     }

//     class Event
//     {
//         public event EventHandler SomeEvent;

//         public void OnSomeEvent()
//         {
//             SomeEvent?.Invoke(this, EventArgs.Empty); // Используем условный оператор null
//         }
//     }

//     class Program
//     {
//         static void Handler(object? source, EventArgs arg) // Допускаем null для source
//         {
//             Console.WriteLine("Точка вышла за пределы области");
//         }

//         static void Main(string[] args)
//         {
//             Event evt = new Event();
//             evt.SomeEvent += Handler; // Подписываемся на событие сразу

//             Dot a = new Dot(0, 0);
//             Dot b = new Dot(6, 6);

//             Random rnd = new Random();
//             Dot dot = new Dot(rnd.Next(a.x, b.x + 1), rnd.Next(a.y, b.y + 1)); // Случайные координаты внутри области

//             while (true)
//             {
//                 dot.Move();
//                 Console.WriteLine(dot.x + " " + dot.y);
//                 if (dot.x < a.x || dot.x > b.x || dot.y < a.y || dot.y > b.y)
//                 {
//                     evt.OnSomeEvent(); // Вызываем событие
//                     break;
//                 }
//             }
//         }
//     }
// }

// using System;
// using System.Collections.Generic;
// // задача 2
// namespace RaceSimulation
// {
//     delegate void RaceOverHandler();

//     class Racer
//     {
//         public string Nickname { get; set; }
//         public int Velocity { get; set; }

//         public Racer(string nickname, int velocity)
//         {
//             Nickname = nickname;
//             Velocity = velocity;
//         }

//         public void AnnounceVictory()
//         {
//             Console.WriteLine(Nickname + " становится чемпионом!");
//         }
//     }

//     class Race
//     {
//         public event RaceOverHandler OnRaceOver;

//         public void SignalRaceOver()
//         {
//             OnRaceOver?.Invoke();
//         }
//     }

//     class Arena
//     {
//         public static bool EvaluateResults(Racer[] racers, int[] distances, int targetDistance, out Racer[] winners)
//         {
//             List<Racer> victoriousRacers = new List<Racer>();

//             for (int i = 0; i < racers.Length; i++)
//             {
//                 if (distances[i] >= targetDistance)
//                 {
//                     victoriousRacers.Add(racers[i]);
//                 }
//             }

//             winners = victoriousRacers.ToArray();
//             return winners.Length > 0;
//         }

//         static void HandleMultipleWinners()
//         {
//             Console.WriteLine("Ничья!");
//         }

//         static void Main(string[] args)
//         {
//             Race theRace = new Race();

//             Racer[] participants = new Racer[3] {
//                 new Racer("Алекс", 10),
//                 new Racer("Боб", 5),
//                 new Racer("Чарли", 20)
//             };

//             int participantCount = participants.Length;
//             int tick = 0;
//             int finishLine = 1000;

//             int[] distancesCovered = new int[participantCount];
//             int[] currentSpeeds = new int[participantCount];


//             while (true)
//             {
//                 tick += 5;

//                 for (int i = 0; i < participantCount; i++)
//                 {
//                     currentSpeeds[i] = participants[i].Velocity;
//                     distancesCovered[i] += currentSpeeds[i] * tick;
//                     Console.WriteLine(participants[i].Nickname + ": " + currentSpeeds[i] + " * " + tick + " = " + distancesCovered[i]);
//                 }

//                 Console.WriteLine();

//                 if (EvaluateResults(participants, distancesCovered, finishLine, out Racer[] topRacers))
//                 {
//                     if (topRacers.Length > 1)
//                         theRace.OnRaceOver += HandleMultipleWinners;
//                     else
//                         theRace.OnRaceOver += topRacers[0].AnnounceVictory;

//                     theRace.SignalRaceOver();
//                     break;
//                 }

//                 Random randomizer = new Random();
//                 for (int i = 0; i < participantCount; i++)
//                 {
//                     participants[i].Velocity = currentSpeeds[randomizer.Next(0, participantCount)];
//                 }
//             }
//         }
//     }
// }