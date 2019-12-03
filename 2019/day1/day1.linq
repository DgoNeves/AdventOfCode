<Query Kind="Program" />

void Main()
{
	var input = File.ReadAllLines(@"./input.txt");
    Part1(input).Dump();
	Part2(input).Dump();
}

int Part1(string[] input) => (int) input.Select(x => int.Parse(x))
									.Sum(x => EquacionPart1(x));

int Part2(string[] input) => input.Select(x => int.Parse(x))
							.Sum(x => EquacionPart2(x));

int EquacionPart1(int number) => (int)Math.Floor(((double)number / 3) - 2);

int EquacionPart2(int number) =>
	number > 0 ? EquactionNotNegative(number)  + EquacionPart2(EquactionNotNegative(number)) : 0;

int EquactionNotNegative(int number)
{
	var eq1 = EquacionPart1(number);
	return eq1 > 0 ? eq1 : 0;
}