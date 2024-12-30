
// using System;

// // ЗЕЛЬЕВАРЕНЬЕ

// public class PotionMaking
// {
//     public static void Main(string[] args)
//     {
//         string[] actions = new string[100];
//         string[] results = new string[100];
//         string line;
//         int actionCount = 0;

//         while (true)
//         {
//             line = Console.ReadLine();
//             if (string.IsNullOrEmpty(line))
//                 break;
//              actions[actionCount++] = line;

//         }

//          string finalSpell = "";

//         for (int i = 0; i < actionCount; i++)
//         {
//             string action = actions[i];
//             string[] parts = action.Split(' ');
//             string command = parts[0];
//             string ingredients = "";
//             for (int j = 1; j < parts.Length; j++)
//             {
//                 if (int.TryParse(parts[j], out int index))
//                 {
//                     ingredients += results[index - 1];
//                 }
//                 else
//                 {
//                     ingredients += parts[j];
//                 }
//             }

//              string spellWord = "";
//             switch (command)
//             {
//                 case "MIX":
//                     spellWord = "MX" + ingredients + "XM";
//                     break;
//                 case "WATER":
//                     spellWord = "WT" + ingredients + "TW";
//                     break;
//                 case "DUST":
//                     spellWord = "DT" + ingredients + "TD";
//                     break;
//                 case "FIRE":
//                     spellWord = "FR" + ingredients + "RF";
//                     break;
//             }
//             results[i] = spellWord;
//              finalSpell = spellWord;
//         }

//         Console.WriteLine(finalSpell);
//     }
// }