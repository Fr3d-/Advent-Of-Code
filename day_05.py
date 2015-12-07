vowels = "aeiou"
bad = ["ab", "cd", "pq", "xy"]
nice = 0

def badInString(line):
	for badString in bad:
		if badString in line:
			return True

	return False

with open("input.txt") as f:
	for line in f:
		i = 0
		double = False

		for c in line:
			for v in vowels:
				if v == c:
					i += 1
					continue

		print(i)
		if i < 3:
			continue

		for i, char in enumerate(line):
			if i > 0 and i < len(line) - 1:
				if char == line[i-1] or char == line[i+1]:
					double = True

		if not double:
			continue

		if badInString(line):
			continue

		nice += 1

print(nice)
