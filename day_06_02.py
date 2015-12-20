import re

def traverse(o, tree_types=(list, tuple)):
    if isinstance(o, tree_types):
        for value in o:
            for subvalue in traverse(value, tree_types):
                yield subvalue
    else:
        yield o

onemap = [[0 for i in range(1000)] for j in range(1000)]

with open("input.txt") as f:
	for line in f:
		values = [int(x) for x in re.findall('\d+', line)]
		xmin = values[0]
		ymin = values[1]
		xmax = values[2]
		ymax = values[3]

		if "toggle" in line:
			for i in range(xmin, xmax + 1):
				for j in range(ymin, ymax + 1):
					onemap[i][j] += 2
		elif "turn off" in line:
			for i in range(xmin, xmax + 1):
				for j in range(ymin, ymax + 1):
					if onemap[i][j] > 0:
						onemap[i][j] -= 1
		elif "turn on" in line:
			for i in range(xmin, xmax + 1):
				for j in range(ymin, ymax + 1):
					onemap[i][j] += 1
		else:
			print("!!!")

c = 0

for i in traverse(onemap):
	c += i

print(c)