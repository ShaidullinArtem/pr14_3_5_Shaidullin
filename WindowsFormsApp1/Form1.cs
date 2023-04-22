using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		// задание 3
		private void Task3_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			int n = (int)numericUpDown1.Value;
			Queue queue = new Queue();

			for (int i = 1; i <= n; i++) { queue.Enqueue(i); }

			while (queue.Count > 0)
			{
				int number = (int)queue.Dequeue();
				listBox1.Items.Add(number);
			}
		}

		// задание 4
		private void task4_Click(object sender, EventArgs e)
		{
			int n = (int)numericUpDown2.Value;
			Queue youngPeople = new Queue();
			Queue oldPeople = new Queue();
			listBox2.Items.Clear();
			listBox3.Items.Clear();

			FileInfo fileInfo = new FileInfo("task_four.txt");
			if (!fileInfo.Exists || fileInfo.Length == 0) { MessageBox.Show("Ошибка!", "Файл пустой или не найден."); return; }

			using (StreamReader sr = new StreamReader("task_four.txt"))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					string[] parts = line.Split(' ');
					string lastName = parts[0];
					string firstName = parts[1];
					string middleName = parts[2];
					int age = int.Parse(parts[3]);
					int weight = int.Parse(parts[4]);

					if (age < n) { youngPeople.Enqueue($"{lastName} {firstName} {middleName}, возраст: {age}, вес: {weight}"); }
					else { oldPeople.Enqueue($"{lastName} {firstName} {middleName}, возраст: {age}, вес: {weight}"); }
				}
			}
			foreach (string person in youngPeople) { listBox2.Items.Add(person); }
			foreach (string person in oldPeople) { listBox3.Items.Add(person); }
		}

		// задание 5
		private void task5_Click(object sender, EventArgs e)
		{
			Queue<string> people = new Queue<string>();
			listBox4.Items.Clear();

			FileInfo fileInfo = new FileInfo("task_five.txt");
			if (!fileInfo.Exists || fileInfo.Length == 0) { MessageBox.Show("Ошибка!", "Файл пустой или не найден."); return; }

			using (StreamReader sr = new StreamReader("task_five.txt"))
			{
				string line;
				while ((line = sr.ReadLine()) != null) { people.Enqueue(line); }
			}

			people = new Queue<string>(people.OrderBy(p => int.Parse(p.Split()[3])));
			Queue sortedPeople = new Queue();

			foreach (string person in people) 
			{
				string[] parts = person.Split();
				sortedPeople.Enqueue($"{parts[0]} {parts[1]} {parts[2]}, возраст: {parts[3]}, вес: {parts[4]}");
			}
			foreach (string person in sortedPeople) { listBox4.Items.Add(person); }

		}
	}
}
