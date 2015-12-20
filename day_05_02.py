nice = 0

with open("input.txt") as f:
	for line in f:
		firstCheck = False
		secondCheck = False

		for i in range(len(line) - 1):
			if line.count(line[i:(i+2)]) > 1:
				firstCheck = True
				break

		if not firstCheck:
			continue

		for i in range(len(line) - 2):
			if line[i] == line[i+2]:
				secondCheck = True
				break

		if not secondCheck:
			continue

		nice += 1

print(nice)