# python 3.6
cnt = int(input("The number of int inputs: "))
tot = 0
for i in range(cnt):
    tot += int(input("Input %dth int: " % (i + 1)))
print("sum: %d, avg: %f" % (tot, tot / cnt))
del(cnt, tot, i)