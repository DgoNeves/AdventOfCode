<Query Kind="Program" />

void Main()
{
	var input = File.ReadAllText(@"./input.txt");
	var from = int.Parse(input.Split('-')[0]);
	var to = int.Parse(input.Split('-')[1]);

	$"From: {from}".Dump();
	$"To: {to}".Dump();
	
	Part1(from,to).Dump();
	Part2(from,to).Dump();
	
}

int Part2(int from, int to) =>
	Enumerable.Range(from,to-from).Count(i => DoesItIncreaseOrKeep(i) && AnySinglePairOfDouble(i));

int Part1(int from, int to) =>
	 Enumerable.Range(from,to-from).Count(i => DoesItHaveAdjacentRepeated(i) && DoesItIncreaseOrKeep(i));

bool AnySinglePairOfDouble(int number)
{
	var numbersCharArray = number.ToString().ToCharArray();
	return DoesItHaveAdjacentRepeated(number) &&
			numbersCharArray.GroupBy(x => x)
				.Count(x => x.Count() == 2) > 0;
}

bool DoesItHaveAdjacentRepeated(int number){
	var numbersCharArray = number.ToString().ToCharArray();
	return Enumerable.Range(0, numbersCharArray.Length - 1)
			.Any(i => numbersCharArray[i] == numbersCharArray[i + 1]);
}

bool DoesItIncreaseOrKeep(int number)
{
	var numbersCharArray = number.ToString().ToCharArray();
	return Enumerable.Range(0, numbersCharArray.Length -1 )
			.All(i => numbersCharArray[i] <= numbersCharArray[i+1]);
}