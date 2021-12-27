<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var lines = File.ReadAllLines(@"C:\Sources\adventofcode\2021\fsharp\day-1-input.txt");
	
	lines.Length.Dump();
	
	var increments = 0;
	
	for(int index = 1; index < lines.Length; index++)
	{
		if(int.Parse(lines[index]) > int.Parse(lines[index - 1]))
			increments += 1;
	}
	
	increments.Dump();
}

// You can define other methods, fields, classes and namespaces here