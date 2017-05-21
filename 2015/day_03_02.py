santaMap = [[0 for x in range(1000)] for x in range(1000)]

santaX = 500
santaY = 500
robotX = 500
robotY = 500

total = 0

santaMap[500][500] = 1

def walk(direction, x, y):
	if direction == ">":
		x += 1
	elif direction == "<":
		x -= 1
	elif direction == "^":
		y += 1
	elif direction == "v":
		y -= 1

	santaMap[x][y] = 1

	return x, y

with open("input.txt") as f:
	for line in f:
		for i, direction in enumerate(line):
			if i % 2 == 0:
				santaX, santaY = walk(direction, santaX, santaY)
			else:
				robotX, robotY = walk(direction, robotX, robotY)


for a in santaMap:
	for b in a:
		if b > 0:
			total += 1

print(total)
