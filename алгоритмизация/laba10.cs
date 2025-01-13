// Дан класс, состоящий из двух полей целого типа. Необходимо реализовать в классе три конструктора:
// Конструктор без параметра (все поля инициализируются нулями)

// Конструктор с одним параметром (в этом случае второй поле инициализируется нулём)

// Конструктор с двумя параметрами (инициализируется заданными значениям) 



// Создать четыре метода, которые реализуют: 
// сложения двух элементов,
//  разность первого со вторым,
//  произведение двух элементов 
// и деление первого на второй. При делении отловить ошибку на ноль. 

// В головной программе создать объекты с помощью трёх разных конструкторов. 

// Для каждого объекта выполнить все четыре метода.

using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;

namespace project{

    public class Numbers{
        public int Number1;
        public int Number2;
        public Numbers(){
            Number1 = 0;
            Number2 = 0;
        }
        public Numbers(int number1){
            Number1 = number1;
            Number2 = 0; 
        }
        public Numbers(int number1, int number2){
            Number1 = number1;
            Number2 = number2; 
        }
        public int Add(){
            int sum = Number1 + Number2;
            return sum;
        }
        public int Subtract(){
            int razn = Number1 - Number2;
            return razn;
        }
        public int Multiply(){
            int proizv = Number1 * Number2;
            return proizv;
        }
       

        public double Divide()
        {
            try
        {
        if (Number2 == 0)
        {
           throw new DivideByZeroException("Деление на ноль недопустимо!");
        }
           return Number1 / Number2; 
        }
        catch (DivideByZeroException ex)
        {
         Console.WriteLine($"Ошибка: {ex.Message}");
          return double.NaN;
        }
        catch(Exception ex)
        {
        Console.WriteLine($"Произошла ошибка: {ex.Message}");
        return double.NaN;
     }
  }
        public void PrintNumberInfo(){
            Console.WriteLine($"Number1: {Number1}, Number2: {Number2}");
        }
    }


    public class Laba10{
        static void Main(string[] args){
            
            Numbers couple1 = new Numbers();
            Console.Write("couple1: ");
            couple1.PrintNumberInfo();

            Numbers couple2 = new Numbers(5);
            Console.Write("couple2: ");
            couple2.PrintNumberInfo();

            Numbers couple3 = new Numbers(10, 2);
            Console.Write("couple3: ");
            couple3.PrintNumberInfo();


            Console.WriteLine("Результаты для couple1:");
            Console.WriteLine($"Сумма: {couple1.Add()}");
            Console.WriteLine($"Разность: {couple1.Subtract()}");
            Console.WriteLine($"Произведение: {couple1.Multiply()}");
            Console.WriteLine($"Деление: {couple1.Divide()}");

            Console.WriteLine("Результаты для couple2:");
            Console.WriteLine($"Сумма: {couple2.Add()}");
            Console.WriteLine($"Разность: {couple2.Subtract()}");
            Console.WriteLine($"Произведение: {couple2.Multiply()}");
            Console.WriteLine($"Деление: {couple2.Divide()}");

            Console.WriteLine("Результаты для couple3:");
            Console.WriteLine($"Сумма: {couple3.Add()}");
            Console.WriteLine($"Разность: {couple3.Subtract()}");
            Console.WriteLine($"Произведение: {couple3.Multiply()}");
            Console.WriteLine($"Деление: {couple3.Divide()}");


        }
    }
}