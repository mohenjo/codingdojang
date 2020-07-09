# python 3.6
n = nmax = 20
while True:
    chk = any([n % i for i in range(1, nmax + 1)])
    if chk is False:
        print(n)
        break
    n += nmax
# ans: 232792560
