santaMap = [[0 for x in range(1000)] for x in range(1000)]

x = 0
y = 0

total = 0

santaMap[x][y] = 1

with open("input.txt") as f:
	for line in f:
		for direction in line:
			if direction == ">":
				x += 1
			elif direction == "<":
				x -= 1
			elif direction == "^":
				y += 1
			elif direction == "v":
				y -= 1

			santaMap[x][y] = 1

for a in santaMap:
	for b in a:
		if b == 1:
			total += 1

print(total)
