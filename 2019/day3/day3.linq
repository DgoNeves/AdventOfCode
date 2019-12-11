<Query Kind="Program" />

void Main()
{
	var input = File.ReadAllText(@"/input.txt");
	var firstWirePath = input.Split('\n')[0];
	var secondWirePath = input.Split('\n')[1];
	var firstWireName = "Wire_1";
	var secondWireName = "Wire_2";

	var dic = new Dictionary<Point, string>();
	var pointsFirstWireTook = FollowSteps(dic, firstWirePath, firstWireName);
	var pointsSecondWireTook = FollowSteps(dic, secondWirePath, secondWireName);

	// Part 1
	pointsSecondWireTook
		.Where(x => x.Value.Contains(firstWireName) && x.Value.Contains(secondWireName))
		.Select(x => Math.Abs(x.Key.X) + Math.Abs(x.Key.Y))
		.OrderBy(x => x)
		.First()
		.Dump();

	// Part 2
	var result = pointsSecondWireTook
		.Where(x => x.Value.Contains(firstWireName) && x.Value.Contains(secondWireName))
		.Select(x => 
			int.Parse(x.Value.Split(new char[] {':', ','})[1])
			+ int.Parse(x.Value.Split(new char[] {':', ','})[3]))
		.First()
		.Dump();
		
}

Dictionary<Point, string> FollowSteps(Dictionary<Point, string> dic,string stepText, string shipName)
{
	var steps = stepText.Split(',');
	var startingPoint = new Point(0,0);
	var totalStepsTaken = 0;
	
	foreach (var step in steps)
	{
		var direction = step.First();
		var number = int.Parse(step.Substring(1));
		
		
		var nextPoints = Point.GetPoints(startingPoint, direction, number);
		startingPoint =  nextPoints.Last();
		
		foreach (var point in nextPoints)
		{
			totalStepsTaken++;
			if(!dic.ContainsKey(point))
				dic.Add(point,$"{shipName}:{totalStepsTaken}");
			else
			{
				dic[point] += $",{shipName}:{totalStepsTaken}";
			}
		}
	}
	
	return dic;
}

class Point {

	public int X { get; set; }
	public int Y { get; set; }

	public Point(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}
	
	public static List<Point> GetPoints(Point startingPoint, char dir, int steps) 
	{
		if(dir == 'R') {
			return Enumerable.Range(1, steps)
				.Select(i => new Point(startingPoint.X + i ,startingPoint.Y)).ToList();
		}
		if (dir == 'L')
		{
			return Enumerable.Range(1, steps)
				.Select(i => new Point(startingPoint.X -i , startingPoint.Y)).ToList();
		}
		if (dir == 'U')
		{
			return Enumerable.Range(1, steps)
				.Select(i => new Point(startingPoint.X, startingPoint.Y + i)).ToList();
		}
		if (dir == 'D')
		{
			return Enumerable.Range(1, steps)
				.Select(i => new Point(startingPoint.X, startingPoint.Y - i)).ToList();
		}
		
		throw new Exception("Wrong direction!");
	}

	public override int GetHashCode()
	{
		return this.X.GetHashCode() + this.Y.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if(obj is Point p) 
			return p.X == this.X && p.Y == this.Y;
		return base.Equals(obj);
	}
}

// Define other methods and classes here