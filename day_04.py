import hashlib

i = 0
found = False

while True:
	s = hashlib.md5(("ckczppom" + str(i)).encode('utf-8')).hexdigest()
	if "0" * 5 in s[0:5] and not found:
		print("Part One:", i)
		found = True

	if "0" * 6 in s[0:6]:
		print("Part Two:", i)
		break
	i += 1
