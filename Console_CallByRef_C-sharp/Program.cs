﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_CallByRef_C_sharp
{
	class Program
	{
		public static int value = 5;
		public static string refString = "Just another refString!"; 

		static void Main(string[] args)
		{
			Console.WriteLine("// Beispiel: ..\\Kapitel 3\\Wertuebergabe");
			Console.WriteLine("");

			// casual call by value
			DoSomething(value);
			DoSomething(refString);
			Console.WriteLine($"call by value = {value}");
			Console.WriteLine($"call by value = {refString}");

			// call by reference Operation
			DoSomething(ref value);
			DoSomething(ref refString);
			Console.WriteLine($"call by reference = {value}");
			Console.WriteLine($"call by reference = {refString}");

			DoSomethingO(out value);
			DoSomethingO(out refString);
			Console.WriteLine($"called \"out\" = {value}");
			Console.WriteLine($"called \"out\" = {refString}");

			Console.WriteLine("");
			Console.WriteLine("// Beispiel: ..\\Kapitel 3\\UebergabeEinerReferenz");
			Console.WriteLine("");

			Demo1 object1 = new Demo1();
			Demo2 object2 = new Demo2();
			object2.ChangeValue(object1);

			Console.WriteLine("object2.ChangeValue( object1) call:");

			Console.Write(object1.Value);
			Console.WriteLine(" = object1.Value");
			Console.WriteLine(object1);
			
			Console.WriteLine("");
			Console.WriteLine("TEST no .value for object");
			Console.WriteLine("");

			//Console.WriteLine("object2");
			Console.WriteLine(object2);
			Console.WriteLine("");

			Console.WriteLine("object2.ChangeValue(ref object1) call:");
			object2.ChangeValue(ref object1);
			Console.Write(object1.Value);
			Console.WriteLine(" = object1.Value");
			
			Console.WriteLine("");
			Console.WriteLine	("Assigning an object to a parameter means that the " +
								"reference to the object\nis passed as an argument, " +
								"not just any value.");
			Console.WriteLine("");

			Console.WriteLine("TEST no~2a new obj3&4 as above, call of object4.ChangeValue(object3)");
			Demo1 object3 = new Demo1();
			Demo2 object4 = new Demo2();
			object4.ChangeValue(object3);
			Console.WriteLine(object3.Value);
			Console.WriteLine("= object3.Value");
			Console.WriteLine("");

			Console.WriteLine("TEST no~2b same objects agian call of object4.ChangeValue(ref object3) agian!");
			object4.ChangeValue(ref object3);
			Console.WriteLine(object1.Value);

			Console.WriteLine("= object.1.Value");

			// When objects like (object1 & object3) are created from Class Demo1 they "inherit"? the Value = 500.
			// The objects (object2 & object4)are created from Class Demo2 they will get assigned the Value of the Demo2
			// class [by calling the ChangeValue Method with (ref Demo1 @object) they receive the object Value of 4711...]

			Console.ReadLine();
		}
		
		class Demo1
		{
			public int Value = 500;
		}
		class Demo2
		{
			public void ChangeValue(Demo1 @object)
			{
				// (commenting out the following line will result 4711...)
				//@object = new Demo1(); // Output will be 500 todo: understand why..!
				// both together commented or uncommented have the same result (500 & 4711)!
				//@object.Value = 4711; // Q: if uncommented this has no (visible) changes for the Output! Why?
			}

			public void ChangeValue(ref Demo1 @object)
			{
				// (commenting out the following line will result 4711...)
				//@object = new Demo1(); // commented out has no (visible) changes// todo: understand why..! 
				@object.Value = 4711;

			}
		}

		static void DoSomething(int param)
		{
			value = 550;
		}

		static void DoSomething(ref int param)
		{
			param = 555;
		}

		static void DoSomethingO(out int param)
		{
			param = 600;
		}

		static void DoSomethingO(out string refstring)
		{
			refstring = "I´m the \"out\" String!\n" +
						"out definitly changes the value of the output parameter!";
		}

		static void DoSomething(string refstring)
		{
			refString = "I´m the String called by value!";
		}

		static void DoSomething(ref string refstring)
		{
			refString = "I´m the String called by reference!\n" +
						"ref may change the oring-input-parameter value!";
		}
	}
}
