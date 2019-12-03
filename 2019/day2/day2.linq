<Query Kind="Program" />

List<int> GetInput() => File.ReadAllText(@"./input.txt").Split(',').Select(x => int.Parse(x)).ToList();

void Main()
{
	Part1().Dump();
	Part2().Dump();
}

int Part1()
{
	var lines = GetInput();
	var i = 0;
	var halt = false;

	while (!halt)
	{
		(halt, lines) = Solve(lines, i, i + 1, i + 2, i + 3);
		i += 4;
	}

	return lines.ElementAt(0);
}

int Part2()
{
	var lines = GetInput();
	for (int noun = 0; noun < 100; noun++)
	{
		for (int verb = 0; verb < 100; verb++)
		{
			lines[1] = noun;
			lines[2] = verb;
			var i = 0;
			var halt = false;

			while (!halt)
			{
				(halt, lines) = Solve(lines, i, i + 1, i + 2, i + 3);
				i += 4;
			}

			if (lines[0] == 19690720)
			{
				return 100*noun+verb;
			}
			else
			{
				lines = GetInput();
			}
		}
	}
	
	return -1;

}

(bool, List<int>) Solve(List<int> input, int p0, int p1, int p2, int p3) {
	
	if(input[p0] == 1) {
		input[input[p3]] = input[input[p1]] + input[input[p2]];
		return (false, input);
	}
	else if (input[p0] == 2)
	{
		input[input[p3]] = input[input[p1]] * input[input[p2]];
		return (false, input);
	}
	else if(input[p0] == 99) {
		return (true, input);
	}
	
	throw new Exception("Something went wrong");
}
