// See https://aka.ms/new-console-template for more information
using Generic;
using GenericDay1;

Console.WriteLine("Start Hello, World!");
People people = new People() {Age=12,Name="张三" };
Constraint.Show<People>(people);

ISports sports= new SportBase();
Constraint.GetNameList(sports);

Console.WriteLine("End Hello, World!");



