# python 3.6
sum = 0
for i in range(10, 1001):
    mul = 1
    for c in str(i):
        mul *= int(c)
    sum += mul
print(sum)
# ans: 93150
