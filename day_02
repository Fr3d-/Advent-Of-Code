paper = 0
ribbon = 0

with open("input.txt") as f:
	for line in f:
		dimensions = [int(x) for x in line.split("x")]
		l = dimensions[0]
		w = dimensions[1]
		h = dimensions[2]

		sortedDimensions = sorted(dimensions)

		paper += 2*l*w + 2*w*h + 2*h*l
		paper += sortedDimensions[0] * sortedDimensions[1]

		ribbon += sortedDimensions[0] * 2 + sortedDimensions[1] * 2
		ribbon += l*w*h 

print(paper, ribbon)
