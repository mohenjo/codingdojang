# python 3.6
num = range(1, 101)
sOSq = sum([i**2 for i in num])
sqOS = sum([i for i in num])**2
print(abs(sOSq - sqOS))
# ans: 25164150
